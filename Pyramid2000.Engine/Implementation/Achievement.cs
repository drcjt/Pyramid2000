using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine.Implementation
{
    class Achievement : IAchievement
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Achievement(string title, string description = "")
        {
            Title = title;
            Description = description;
        }
    }
}
