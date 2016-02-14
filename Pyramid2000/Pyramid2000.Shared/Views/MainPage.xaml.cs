using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Documents;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.Storage;
using Pyramid2000.Engine.Interfaces;
using System.Threading.Tasks;
using Pyramid2000.ViewModels;
using Windows.UI;
using Pyramid2000.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pyramid2000
{
    /// <summary>
    /// The main page in Pyramid 2000
    /// </summary>
    public sealed partial class MainPage : Page, IPrinter
    {
        // Based on Chris Cantrell's Javascript implementation:
        // See http://www.computerarcheology.com/wiki/wiki/CoCo/Pyramid

        public MainPageViewModel ViewModel => this.DataContext as MainPageViewModel;

        #region Initialisation
        public MainPage()
        {
            this.InitializeComponent();
//#if WINDOWS_PHONE_APP
            // Hide achievements panel - when fully working need to only do this for phone
            RightPanelWidth.Width = new GridLength(0);
//#endif
            this.NavigationCacheMode = NavigationCacheMode.Required;

            // Setup the game engine
            ViewModel.GamePartViewModel.SetupGame(this);

            // Setup the initial room description as the dialogue header
            Header.Text = ViewModel.GamePartViewModel.CurrentRoom.ShortDescription;

            // Add handlers for showing/hiding the input pane (on screen keyboard)
            _inputPane.Showing += InputPaneShowing;
            _inputPane.Hiding += InputPaneHiding;

            /* Setup words for touch selection.*/
            /*
            var verbs = ViewModel.GamePartViewModel.GetWords(false);
            SetButtonList(verbs, VerbWords, VerbButton_Click);
            VerbWords.Visibility = Visibility.Visible;

            var nouns = ViewModel.GamePartViewModel.GetWords(true);
            SetButtonList(nouns, NounWords, NounButton_Click);     
            */

            // Ensure all input goes to the textbox
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
        }

        /// <summary>
        /// Handles all key presses whilst on this page and ensures focus is set on the textbox
        /// </summary>
        /// <param name="sender">sender of event</param>
        /// <param name="args">event arguments</param>
        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (FocusManager.GetFocusedElement()!= Command)
            {
                Command.Focus(FocusState.Programmatic);
                Command.Select(0, Command.Text.Length);
            }
        }

        /// <summary>
        /// Logic for when the page is loaded
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event arguments</param>
        public void Loaded(object sender, RoutedEventArgs e)
        {
            // Setup the navigation service frame
            ViewModel.GamePartViewModel.NavigationService.Frame = Frame;

#if !WINDOWS_PHONE_APP
            // If not running on windows phone then set text in the text box to indicate to user
            // that this is where they need to type commands
            Command.Text = "Enter Command Here";
#endif
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Show the compass if configured to be visible
            Compass.Visibility = ViewModel.SettingsPartViewModel.ShowCompass ? Visibility.Visible : Visibility.Collapsed;

            // Hide the appbar compass buttons if the compass is visible            
            var appBarCompasssButtonVisibility = Compass.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            AppBar_NorthButton.Visibility = appBarCompasssButtonVisibility;
            AppBar_SouthButton.Visibility = appBarCompasssButtonVisibility;
            AppBar_EastButton.Visibility = appBarCompasssButtonVisibility;
            AppBar_WestButton.Visibility = appBarCompasssButtonVisibility;

#if WINDOWS_PHONE_APP
            // For phone if the compass is visible then make the app bar minimal otherwise compact
            CommandBar cmdBar = CommandBar as CommandBar;
            cmdBar.ClosedDisplayMode = ViewModel.SettingsPartViewModel.ShowCompass ? AppBarClosedDisplayMode.Minimal : AppBarClosedDisplayMode.Compact;
#endif
        }
        #endregion

        #region Verb and Noun Selection
        /// <summary>
        /// Create buttons in the specified stack panel from the supplied list
        /// </summary>
        /// <param name="words">words to create buttons for</param>
        /// <param name="p">stackpanel to put buttons into</param>
        /// <param name="eh">handler to fire when buttons pressed</param>
        private void SetButtonList(IList<string> words, StackPanel p, RoutedEventHandler eh)
        {
            foreach (var word in words)
            {
                var button = new Button();
                button.Content = word;
                button.MinWidth = 0;
                button.BorderBrush = new SolidColorBrush(Colors.Transparent);
                button.Click += eh;
                var fontSizeBinding = new Binding();
                fontSizeBinding.Path = new PropertyPath("SettingsPartViewModel.TextSize");
                button.SetBinding(Button.FontSizeProperty, fontSizeBinding);
                p.Children.Add(button);
            }
        }

        /// <summary>
        /// When a verb button is pressed set the text in the command and change
        /// to noun entry mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerbButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Command.Text = b.Content.ToString() + " ";

            VerbWords.Visibility = Visibility.Collapsed;
            NounWords.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// When a noun is pressed add the noun to the verb already entered in the
        /// command text box and process the command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NounButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Command.Text += b.Content.ToString();

            ProcessCommand();
        }
        #endregion

        #region IPrinter implementation
        /// <summary>
        /// Print the specified text followed by a new line in the main dialogue
        /// </summary>
        /// <param name="text"></param>
        public void PrintLn(string text)
        {
            Print(text);
            Print("\n");
        }

        /// <summary>
        /// The current room the player is in - used to decide if the dialogue needs clearing if the player changes room
        /// </summary>
        private string _currentRoom;

        /// <summary>
        /// Print the specified text in the main dialogue
        /// </summary>
        /// <param name="text"></param>
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

        /// <summary>
        /// Clear the dialogue
        /// </summary>
        public void Clear()
        {
            BodyParagraph.Inlines.Clear();
        }
        #endregion

        #region Command Handling
        /// <summary>
        /// Process the specified command
        /// </summary>
        /// <param name="command"></param>
        private void ProcessCommand(string command = null)
        {
            // Make sure the command is shown in the textbox
            if (command != null)
            {
                Command.Text = command;
            }

            // Add the command to the dialogue
            ViewModel.GamePartViewModel.PrintLn(Command.Text);

            // Process the command using the game engine
            ViewModel.GamePartViewModel.ProcessPlayerInputCommand.Execute(Command.Text);

            // If the game is over then show the restart button in place of the command text box
            if (ViewModel.GamePartViewModel.GameOver)
            {
                Command.Visibility = Visibility.Collapsed;
                Restart.Visibility = Visibility.Visible;
                Command.IsEnabled = false;
            }

            // Set the dialogue header to match the room description which may have changed
            Header.Text = ViewModel.GamePartViewModel.CurrentRoom.ShortDescription;

            // Experimental feature for touch selection of verbs/nouns
            /*
            VerbWords.Visibility = Visibility.Visible;
            NounWords.Visibility = Visibility.Collapsed;
            */

            // Clear the command text box
            Command.Text = "";

#if !WINDOWS_PHONE_APP
            // For non phone set the command text box to have the focus
            Command.Focus(FocusState.Programmatic);
#endif
        }

        /// <summary>
        /// Hook enter being pressed in the command text box and use this as
        /// a trigger to process the command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Command_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                ProcessCommand();
            }
        }
        #endregion

        #region Input Pane Handling
        // Input pane for touch enabled devices capable of showing on screen keyboards
        Windows.UI.ViewManagement.InputPane _inputPane = Windows.UI.ViewManagement.InputPane.GetForCurrentView();

        /// <summary>
        /// Handler for the input pane being shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputPaneShowing(InputPane sender, InputPaneVisibilityEventArgs e)
        {
            e.EnsuredFocusedElementInView = true;

            // Show the footer to force the dialogue to not appear beneath the input pane
            FooterPlaceHolder.Height = e.OccludedRect.Height;
            FooterPlaceHolder.Visibility = Visibility.Visible;

            // Hide the compass
            Compass.Visibility = Visibility.Collapsed;

            BodyScroller.UpdateLayout();
            BodyScroller.ChangeView(null, BodyScroller.ExtentHeight, null);

            // Hide the command bar
            CommandBar.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Handler for the input pane being hidden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputPaneHiding(InputPane sender, InputPaneVisibilityEventArgs e)
        {
            // Hide the footer to make the dialogue flow to the bottom of the window
            FooterPlaceHolder.Height = 0;
            FooterPlaceHolder.Visibility = Visibility.Collapsed;

            // Show the compass if required
            Compass.Visibility = ViewModel.SettingsPartViewModel.ShowCompass? Visibility.Visible: Visibility.Collapsed;
            
            BodyScroller.UpdateLayout();
            BodyScroller.ChangeView(null, BodyScroller.ExtentHeight, null);

            // Show the command bar
            CommandBar.Visibility = Visibility.Visible;
        }
        #endregion

        #region Restart the game
        /// <summary>
        /// Handler for restarting the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            // Make the command text box visible
            Command.Visibility = Visibility.Visible;

            // Hide the restart button
            Restart.Visibility = Visibility.Collapsed;

            // Enable the command text box
            Command.IsEnabled = true;

            // Clear the dialogue
            Body.Text = "";

#if !WINDOWS_PHONE_APP
            Command.Focus(FocusState.Programmatic);
            Command.Text = "Enter Command Here";
#endif

            // Re-setup the game engine
            ViewModel.GamePartViewModel.SetupGame(this);

            // Setup the header text as the initial room decription
            Header.Text = ViewModel.GamePartViewModel.CurrentRoom.ShortDescription;
        }
        #endregion

        #region Compass Buttons
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
        #endregion

        #region Load and Save
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
        #endregion

        #region Compass Control Handlers
        private void CompassControl_ClickHandler(object sender, CompassClickEventArgs e)
        {
            ProcessCommand(e.Direction);
        }
        #endregion
    }
}
