using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Pyramid2000.Engine.Interfaces;
using Windows.UI.Xaml.Documents;
using Pyramid2000.Engine;
using Windows.UI.Xaml.Input;
using Windows.UI.ViewManagement;
using Pyramid2000.UWP.Services.GameSettingsServices;
using Pyramid2000.Controls;
using Windows.UI.Xaml.Navigation;

namespace Pyramid2000.UWP.Views
{
    public sealed partial class MainPage : Page, IPrinter
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;

            // Add handlers for showing/hiding the input pane (on screen keyboard)
            _inputPane.Showing += InputPaneShowing;
            _inputPane.Hiding += InputPaneHiding;

            // Setup the game engine
            var printer = new Printer(this, GameSettingsService.Instance);
            ViewModel.GamePartViewModel.SetupGame(printer);

            // Setup the initial room description as the dialogue header
            pageHeader.Text = ViewModel.GamePartViewModel.CurrentRoom.ShortDescription;

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
            if (FocusManager.GetFocusedElement() != Command)
            {
                Command.Focus(FocusState.Programmatic);
                //Command.Select(0, Command.Text.Length);
            }
        }

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
            if (GameSettingsService.Instance.ClearDialogueOnRoomChange && _currentRoom != ViewModel.GamePartViewModel.CurrentRoomName)
            {
                if (!ViewModel.GamePartViewModel.IsReincarnating)
                {
                    BodyParagraph.Inlines.Clear();
                }
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
                Compass.IsEnabled = false;
            }

            // Set the dialogue header to match the room description which may have changed
            if (ViewModel.GamePartViewModel.IsRoomLit)
            {
                pageHeader.Text = ViewModel.GamePartViewModel.CurrentRoom.ShortDescription;
            }
            else
            {
                // TODO: Need to localise this text
                pageHeader.Text = "In the dark";
            }

            // Clear the command text box
            Command.Text = "";
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Show the compass if configured to be visible
            Compass.Visibility = ViewModel.ShowCompass ? Visibility.Visible : Visibility.Collapsed;

            base.OnNavigatedTo(e);
        }

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

            Compass.IsEnabled = true;

            // Clear the dialogue
            Body.Text = "";

            Command.Focus(FocusState.Programmatic);

            // Re-setup the game engine
            IPrinter printer = new Printer(this, GameSettingsService.Instance);
            ViewModel.GamePartViewModel.SetupGame(printer);

            // Setup the header text as the initial room decription
            pageHeader.Text = ViewModel.GamePartViewModel.CurrentRoom.ShortDescription;
        }
        #endregion

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
        InputPane _inputPane = InputPane.GetForCurrentView();

        /// <summary>
        /// Handler for the input pane being shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputPaneShowing(InputPane sender, InputPaneVisibilityEventArgs e)
        {
            Compass.Visibility = Visibility.Collapsed;
            e.EnsuredFocusedElementInView = true;

            // Show the footer to force the dialogue to not appear beneath the input pane
            FooterPlaceHolder.Height = e.OccludedRect.Height;
            FooterPlaceHolder.Visibility = Visibility.Visible;

            BodyScroller.UpdateLayout();
            BodyScroller.ChangeView(null, BodyScroller.ExtentHeight, null);
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

            BodyScroller.UpdateLayout();
            BodyScroller.ChangeView(null, BodyScroller.ExtentHeight, null);

            if (ViewModel.ShowCompass)
            {
                Compass.Visibility = Visibility.Visible;
            }
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