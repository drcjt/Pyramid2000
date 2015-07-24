using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Documents;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.Storage;

using System.Text.RegularExpressions;


using Pyramid2000.Engine;
using Pyramid2000.Engine.Interfaces;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pyramid2000
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, IPrinter
    {
        private IPrinter _printer;
        private IGameState _gameState;
        private IGame _game;
        private IPlayer _player;
        private IRooms _rooms;

        private Regex _nounsRegex;

        // Based on Chris Cantrell's Javascript implementation:
        // See http://www.computerarcheology.com/wiki/wiki/CoCo/Pyramid

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            SetupGame();

            _inputPane.Showing += InputPaneShowing;
            _inputPane.Hiding += InputPaneHiding;
        }

        private void SetupGame()
        {
            _printer = new Printer(this, App.Settings);
            IItems items = new Items();
            _player = new Player();
            _player.CurrentRoom = "room_1";
            IParser parser = new Parser(_player, _printer, items, App.Settings);
            _rooms = new Rooms(items);
            _gameState = new GameState();
            IScripter scripter = new Scripter(_printer, items, _rooms, _player, _gameState, App.Settings);
            IDefaultScripter defaultScripter = new DefaultScripter();

            _game = new Game(_player, _printer, parser, scripter, _rooms, defaultScripter, items, _gameState, App.Settings);

            IList<string> nouns = parser.GetNouns();
            _nounsRegex = new Regex(string.Join("|", nouns), RegexOptions.IgnoreCase);

            _game.Init();

            UpdateHeader();
        }

        private void UpdateHeader()
        {
            var roomDetail = _rooms.GetRoom(_player.CurrentRoom);

            Header.Text = roomDetail.ShortDescription;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            this.DataContext = null;
            this.DataContext = App.Settings;

            Compass.Visibility = App.Settings.ShowCompass ? Visibility.Visible : Visibility.Collapsed;
            AppBar_NorthButton.Visibility = App.Settings.ShowCompass ? Visibility.Collapsed : Visibility.Visible;
            AppBar_SouthButton.Visibility = App.Settings.ShowCompass ? Visibility.Collapsed : Visibility.Visible;
            AppBar_EastButton.Visibility = App.Settings.ShowCompass ? Visibility.Collapsed : Visibility.Visible;
            AppBar_WestButton.Visibility = App.Settings.ShowCompass ? Visibility.Collapsed : Visibility.Visible;

#if WINDOWS_PHONE_APP
            CommandBar cmdBar = CommandBar as CommandBar;
            cmdBar.ClosedDisplayMode = App.Settings.ShowCompass ? AppBarClosedDisplayMode.Minimal : AppBarClosedDisplayMode.Compact;
#else
            Command.Focus(FocusState.Keyboard);
#endif
        }

        // Experimental setting to show nouns as hyperlinks
        private bool _makeNounsClickable = true;

        public void PrintLn(string text)
        {
            Print(text);
            Print("\n");
        }

        public void Print(string text)
        {
            // If player changed room then clear previous dialogue
            if (App.Settings.ClearDialogueOnRoomChange && _currentRoom != _player.CurrentRoom)
            {
                BodyParagraph.Inlines.Clear();
                _currentRoom = _player.CurrentRoom;
            }

            Run run;
            int index = 0;

            // Experimental setting to show nouns as hyperlinks
            if (_makeNounsClickable)
            {
                /*
                var matches = _nounsRegex.Matches(text);
                foreach (Match match in matches)
                {
                    int matchIndex = match.Index;
                    run = new Run();
                    run.Text = text.Substring(index, matchIndex - index);
                    BodyParagraph.Inlines.Add(run);

                    string hyper = match.Value;
                    var link = new Hyperlink();                                                            
                    link.Click += Link_Click;
                    run = new Run();
                    run.Text = hyper;
                    
                    
                    link.Inlines.Add(run);
                    BodyParagraph.Inlines.Add(link);

                    index = matchIndex + match.Length;
                }
                */
            }

            run = new Run();
            run.Text = text.Substring(index, text.Length - index);
            BodyParagraph.Inlines.Add(run);

            BodyScroller.Measure(BodyScroller.RenderSize);
            BodyScroller.ChangeView(0, BodyScroller.ScrollableHeight, 1);
        }

        public void Clear()
        {
            BodyParagraph.Inlines.Clear();
        }

        private void Link_Click(Hyperlink sender, HyperlinkClickEventArgs args)
        {
            
            MenuFlyout menuflyout = new MenuFlyout();
            MenuFlyoutItem item1 = new MenuFlyoutItem();
            item1.Text = "Item1";
            MenuFlyoutItem item2 = new MenuFlyoutItem();
            item2.Text = "Item2";
            menuflyout.Items.Add(item1);
            menuflyout.Items.Add(item2);
            menuflyout.ShowAt(sender.ContentStart.VisualParent);
            
            
            Run run = sender.Inlines[0] as Run;
            //Command.Focus(FocusState.Programmatic);
            Command.SelectedText = run.Text;            
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            ProcessCommand();
        }

        private string _currentRoom;

        private void ProcessCommand(string command = null)
        {
            if (command != null)
            {
                Command.Text = command;
            }

            _makeNounsClickable = false;
            _printer.PrintLn(Command.Text);
            _makeNounsClickable = true;

            _game.ProcessPlayerInput(Command.Text);

            if (_gameState.GameOver)
            {
                Command.Visibility = Visibility.Collapsed;
                Restart.Visibility = Visibility.Visible;
                Command.IsEnabled = false;
            }

            Command.Text = "";
            UpdateHeader();

#if !WINDOWS_PHONE_APP
            Command.Focus(FocusState.Keyboard);
#endif
        }

        Windows.UI.ViewManagement.InputPane _inputPane = Windows.UI.ViewManagement.InputPane.GetForCurrentView();

        private void InputPaneShowing(InputPane sender, InputPaneVisibilityEventArgs e)
        {
            e.EnsuredFocusedElementInView = true;

            FooterPlaceHolder.Height = e.OccludedRect.Height;
            FooterPlaceHolder.Visibility = Visibility.Visible;

            Compass.Visibility = Visibility.Collapsed;

            BodyScroller.UpdateLayout();
            BodyScroller.ChangeView(null, BodyScroller.ExtentHeight, null);

            CommandBar.Visibility = Visibility.Collapsed;
        }

        private void InputPaneHiding(InputPane sender, InputPaneVisibilityEventArgs e)
        {
            FooterPlaceHolder.Height = 0;
            FooterPlaceHolder.Visibility = Visibility.Collapsed;

            Compass.Visibility = Visibility.Visible;

            BodyScroller.UpdateLayout();
            BodyScroller.ChangeView(null, BodyScroller.ExtentHeight, null);

            CommandBar.Visibility = Visibility.Visible;
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            Command.Visibility = Visibility.Visible;
            Restart.Visibility = Visibility.Collapsed;
            Command.IsEnabled = true;
            Body.Text = "";

#if !WINDOWS_PHONE_APP
            Command.Focus(FocusState.Keyboard);
#endif

            SetupGame();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingsPage));
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }

        private void Command_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                ProcessCommand();
            }
        }

        private void InstructionsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Instructions));
        }

        private void NorthButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessCommand("N");
        }

        private void SouthButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessCommand("S");
        }

        private void EastButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessCommand("E");
        }

        private void WestButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessCommand("W");
        }

        private static string SAVE_STATE_FILE = "SAVEDSTATE";

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string state = _game.Save();

            SaveState(state);            
        }

        private async void SaveState(string state)
        {
            try
            {
                var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(SAVE_STATE_FILE, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(file, state);

                MessageDialog md = new MessageDialog("Game Saved");
                await md.ShowAsync();
            }
            catch (Exception)
            {
                //MessageDialog md = new MessageDialog("Unable to save game");
                //await md.ShowAsync();
            }
        }

        private async Task<string> LoadState()
        {
            var file = await ApplicationData.Current.LocalFolder.GetFileAsync(SAVE_STATE_FILE);
            return await FileIO.ReadTextAsync(file);
        }

        private async void Load()
        {
            try
            {
                var state = await LoadState();
                _game.Load(state);
                MessageDialog md = new MessageDialog("Game loaded");
                await md.ShowAsync();
            }
            catch (Exception)
            {
                //MessageDialog md = new MessageDialog("Unable to load game");
                //await md.ShowAsync();
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void CompassControl_ClickNorth(object sender, EventArgs e)
        {
            ProcessCommand("N");
        }

        private void CompassControl_ClickSouth(object sender, EventArgs e)
        {
            ProcessCommand("S");
        }

        private void CompassControl_ClickEast(object sender, EventArgs e)
        {
            ProcessCommand("E");
        }

        private void CompassControl_ClickWest(object sender, EventArgs e)
        {
            ProcessCommand("W");
        }

        private void CompassControl_ClickUp(object sender, EventArgs e)
        {
            ProcessCommand("Up");
        }

        private void CompassControl_ClickDown(object sender, EventArgs e)
        {
            ProcessCommand("Down");
        }

        private void BodyScroller_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            Command.Focus(FocusState.Keyboard);
        }

        private void Compass_ClickNorthEast(object sender, EventArgs e)
        {
            ProcessCommand("NE");
        }

        private void Compass_ClickNorthWest(object sender, EventArgs e)
        {
            ProcessCommand("NW");
        }

        private void Compass_ClickSouthEast(object sender, EventArgs e)
        {
            ProcessCommand("SE");
        }

        private void Compass_ClickSouthWest(object sender, EventArgs e)
        {
            ProcessCommand("SW");
        }
    }
}
