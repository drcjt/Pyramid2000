using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Pyramid2000.Services
{
    public interface ISettingsService : INotifyPropertyChanged
    {
        bool ShowCompass { get; set; }
        int TextSize { get; set; }
    }
}
