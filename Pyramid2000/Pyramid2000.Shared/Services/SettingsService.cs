using System;
using System.Collections.Generic;
using System.Text;

namespace Pyramid2000.Services
{
    public class SettingsService : ISettingsService
    {
        public static SettingsService Instance { get; }
        static SettingsService()
        {
            Instance = Instance ?? new SettingsService();
        }

        public bool ShowCompass { get; set; }
        public int TextSize { get; set; }
    }
}
