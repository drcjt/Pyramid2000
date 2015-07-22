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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pyramid2000.Controls
{
    public sealed partial class CompassControl : UserControl
    {
        public event EventHandler ClickNorth;
        public event EventHandler ClickSouth;
        public event EventHandler ClickEast;
        public event EventHandler ClickWest;
        public event EventHandler ClickNorthEast;
        public event EventHandler ClickNorthWest;
        public event EventHandler ClickSouthEast;
        public event EventHandler ClickSouthWest;
        public event EventHandler ClickUp;
        public event EventHandler ClickDown;

        public CompassControl()
        {
            this.InitializeComponent();

            NorthButton.Click += NorthButton_Click;
            SouthButton.Click += SouthButton_Click;
            EastButton.Click += EastButton_Click;
            WestButton.Click += WestButton_Click;

            NorthEastButton.Click += NorthEastButton_Click;
            NorthWestButton.Click += NorthWestButton_Click;
            SouthEastButton.Click += SouthEastButton_Click;
            SouthWestButton.Click += SouthWestButton_Click;

            Up.Click += Up_Click;
            Down.Click += Down_Click;
        }

        private void ProcessClick(EventHandler eventHandler)
        {
            if (eventHandler != null)
            {
                eventHandler(this, new EventArgs());
            }
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            ProcessClick(this.ClickDown);
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            ProcessClick(this.ClickUp);
        }

        private void WestButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessClick(this.ClickWest);
        }

        private void EastButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessClick(this.ClickEast);
        }

        private void SouthButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessClick(this.ClickSouth);
        }

        private void NorthButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessClick(this.ClickNorth);
        }

        private void NorthEastButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessClick(this.ClickNorthEast);
        }

        private void NorthWestButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessClick(this.ClickNorthWest);
        }

        private void SouthEastButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessClick(this.ClickSouthEast);
        }

        private void SouthWestButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessClick(this.ClickSouthWest);
        }
    }
}
