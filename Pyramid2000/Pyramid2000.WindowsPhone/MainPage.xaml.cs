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

using Pyramid2000Engine;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pyramid2000
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, IPrinter
    {
        private Game game;

        // Based on Chris Cantrell's Javascript implementation:
        // See http://www.computerarcheology.com/wiki/wiki/CoCo/Pyramid

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            game = new Game(this);

            game.StartGame();
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
        }

        public void PrintLn(string text)
        {
            Print(text);
            Print("\n");
        }

        public void Print(string text)
        {
            Body.Text += text;
            BodyScroller.Measure(BodyScroller.RenderSize);
            BodyScroller.ChangeView(0, BodyScroller.ScrollableHeight, 1);
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            PrintLn(Command.Text);

            game.ProcessPlayerInput(Command.Text);

            if (game.GameOver)
            {
                Application.Current.Exit();
            }

            Command.Text = "";
        }
    }
}
