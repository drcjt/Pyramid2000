using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace Pyramid2000.Services
{
    public interface INavigationService
    {
        Frame Frame { get; set; }
        void Navigate(Type page);
    }
}
