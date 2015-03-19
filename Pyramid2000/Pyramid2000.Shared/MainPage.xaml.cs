﻿using System;
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
using Windows.UI.ViewManagement;

using Pyramid2000.Engine;
using Pyramid2000.Engine.Interfaces;

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
            IPlayer player = new Player();
            player.CurrentRoom = "room_1";
            IParser parser = new Parser(player, _printer, items, App.Settings);
            IRooms rooms = new Rooms(items);
            _gameState = new GameState();
            IScripter scripter = new Scripter(_printer, items, rooms, player, _gameState, App.Settings);
            IDefaultScripter defaultScripter = new DefaultScripter();

            _game = new Game(player, _printer, parser, scripter, rooms, defaultScripter, items, _gameState, App.Settings);

            _game.Init();
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
            ProcessCommand();
        }

        private void ProcessCommand(string command = null)
        {
            if (command != null)
            {
                Command.Text = command;
            }

            _printer.PrintLn(Command.Text);

            _game.ProcessPlayerInput(Command.Text);

            if (_gameState.GameOver)
            {
                Command.Visibility = Visibility.Collapsed;
                Restart.Visibility = Visibility.Visible;
                Command.IsEnabled = false;
            }

            Command.Text = "";
        }

        Windows.UI.ViewManagement.InputPane _inputPane = Windows.UI.ViewManagement.InputPane.GetForCurrentView();

        private void InputPaneShowing(InputPane sender, InputPaneVisibilityEventArgs e)
        {
            e.EnsuredFocusedElementInView = true;

            FooterPlaceHolder.Height = e.OccludedRect.Height;
            FooterPlaceHolder.Visibility = Visibility.Visible;

            BodyScroller.UpdateLayout();
            BodyScroller.ChangeView(null, BodyScroller.ExtentHeight, null);

            CommandBar.Visibility = Visibility.Collapsed;
        }

        private void InputPaneHiding(InputPane sender, InputPaneVisibilityEventArgs e)
        {
            FooterPlaceHolder.Height = 0;
            FooterPlaceHolder.Visibility = Visibility.Collapsed;

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
    }
}
