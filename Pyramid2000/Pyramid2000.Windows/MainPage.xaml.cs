using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.System;
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

            game = new Game(this);

            game.StartGame();
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
            ProcessCommand();
        }

        private void Command_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                ProcessCommand();
            }
        }

        private void ProcessCommand()
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
