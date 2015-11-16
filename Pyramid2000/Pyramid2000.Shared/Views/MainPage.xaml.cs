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
using System.Collections.ObjectModel;
using Pyramid2000.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pyramid2000
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, IPrinter
    {
        // Based on Chris Cantrell's Javascript implementation:
        // See http://www.computerarcheology.com/wiki/wiki/CoCo/Pyramid

        public MainPageViewModel ViewModel => this.DataContext as MainPageViewModel;

        public MainPage()
        {
            this.InitializeComponent();
#if WINDOWS_PHONE_APP
            RightPanelWidth.Width = new GridLength(0);
#endif
            this.NavigationCacheMode = NavigationCacheMode.Required;

            ViewModel.GamePartViewModel.SetupGame(this);

            Header.Text = ViewModel.GamePartViewModel.CurrentRoom.ShortDescription;

            _inputPane.Showing += InputPaneShowing;
            _inputPane.Hiding += InputPaneHiding;
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

            Compass.Visibility = ViewModel.SettingsPartViewModel.ShowCompass ? Visibility.Visible : Visibility.Collapsed;
            AppBar_NorthButton.Visibility = Compass.Visibility;
            AppBar_SouthButton.Visibility = Compass.Visibility;
            AppBar_EastButton.Visibility = Compass.Visibility;
            AppBar_WestButton.Visibility = Compass.Visibility;

#if WINDOWS_PHONE_APP
            CommandBar cmdBar = CommandBar as CommandBar;
            cmdBar.ClosedDisplayMode = ViewModel.SettingsPartViewModel.ShowCompass ? AppBarClosedDisplayMode.Minimal : AppBarClosedDisplayMode.Compact;
#else
            Command.Focus(FocusState.Keyboard);
#endif
        }

        public void PrintLn(string text)
        {
            Print(text);
            Print("\n");
        }

        public void Print(string text)
        {
            // If player changed room then clear previous dialogue
            if (App.GameSettings.ClearDialogueOnRoomChange && _currentRoom != ViewModel.GamePartViewModel.CurrentRoomName)
            {
                BodyParagraph.Inlines.Clear();
                _currentRoom = ViewModel.GamePartViewModel.CurrentRoomName;
            }

            var run = new Run();
            run.Text = text.Substring(0, text.Length);
            BodyParagraph.Inlines.Add(run);

            BodyScroller.Measure(BodyScroller.RenderSize);
            BodyScroller.ChangeView(0, BodyScroller.ScrollableHeight, 1);
        }

        public void Clear()
        {
            BodyParagraph.Inlines.Clear();
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

            ViewModel.GamePartViewModel.PrintLn(Command.Text);

            ViewModel.GamePartViewModel.ProcessPlayerInputCommand.Execute(Command.Text);

            if (ViewModel.GamePartViewModel.GameOver)
            {
                Command.Visibility = Visibility.Collapsed;
                Restart.Visibility = Visibility.Visible;
                Command.IsEnabled = false;
            }

            Command.Text = "";

            Header.Text = ViewModel.GamePartViewModel.CurrentRoom.ShortDescription;

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
            ViewModel.GamePartViewModel.SetupGame(this);

            Header.Text = ViewModel.GamePartViewModel.CurrentRoom.ShortDescription;
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
            SaveState(ViewModel.GamePartViewModel.State);            
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
                ViewModel.GamePartViewModel.State = state;
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

        private async void RateAndReviewButton_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=33ddb4b9-5fc5-4a4d-bec3-5adc282c6b3a"));
        }

        private void BodyTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            Command.Focus(FocusState.Keyboard);
        }
    }
}
