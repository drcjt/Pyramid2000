using Pyramid2000.MVVM;
using System;
using Windows.UI.Xaml.Controls;

namespace Pyramid2000.Services
{
    public class NavigationService : INavigationService
    {
        public Frame Frame { get; set; }

        public void Navigate(Type page)
        {
            Frame.Navigate(page);
        }
    }

    public class NavigationCommand : DelegateCommand
    {
        public NavigationCommand(INavigationService navigationServce, Type page) : base(() => { navigationServce.Navigate(page); })
        {
        }
    }
}
