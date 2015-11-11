﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine.Interfaces
{
    public interface IPlayer
    {
        string CurrentRoom { get; set; }

        ObservableCollection<IItem> Items { get; } 
    }
}
