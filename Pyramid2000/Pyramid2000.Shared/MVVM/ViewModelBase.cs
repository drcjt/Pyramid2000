using Pyramid2000.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyramid2000.MVVM
{
    public class ViewModelBase
    {
        public INavigationService NavigationService { get; set; }

        public ViewModelBase()
        {
            NavigationService = new NavigationService();
        }
    }
}
