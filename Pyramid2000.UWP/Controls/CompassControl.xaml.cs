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
    public class CompassClickEventArgs : EventArgs
    {
        public string Direction { get; internal set; }
        public CompassClickEventArgs(string direction)
        {
            Direction = direction;
        }
    }

    public delegate void CompassClickHandler(object sender, CompassClickEventArgs e);

    public sealed partial class CompassControl : UserControl
    {
        public event CompassClickHandler ClickHandler;

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
            ClickHandler?.Invoke(this, new CompassClickEventArgs("Down"));
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler?.Invoke(this, new CompassClickEventArgs("Up"));
        }

        private void WestButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler?.Invoke(this, new CompassClickEventArgs("W"));
        }

        private void EastButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler?.Invoke(this, new CompassClickEventArgs("E"));
        }

        private void SouthButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler?.Invoke(this, new CompassClickEventArgs("S"));
        }

        private void NorthButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler?.Invoke(this, new CompassClickEventArgs("N"));
        }

        private void NorthEastButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler?.Invoke(this, new CompassClickEventArgs("NE"));
        }

        private void NorthWestButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler?.Invoke(this, new CompassClickEventArgs("NW"));
        }

        private void SouthEastButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler?.Invoke(this, new CompassClickEventArgs("SE"));
        }

        private void SouthWestButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler?.Invoke(this, new CompassClickEventArgs("SW"));
        }
    }
}