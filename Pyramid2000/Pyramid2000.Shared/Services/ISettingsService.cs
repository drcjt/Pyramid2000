using System;
using System.Collections.Generic;
using System.Text;

namespace Pyramid2000.Services
{
    public interface ISettingsService
    {
        bool ShowCompass { get; set; }
        int TextSize { get; set; }
    }
}
