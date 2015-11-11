using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class Player : IPlayer
    {
        public string CurrentRoom { get; set; }

        private ObservableCollection<IItem> _Items = new ObservableCollection<IItem>();

        public ObservableCollection<IItem> Items { get { return _Items; } }
    }
}
