using Pyramid2000.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine
{
    public class Item : IItem
    {
        private IPlayer _player;
        public Item(IPlayer player)
        {
            _player = player;
        }

        public string Name { get; set; }

        private string _location;
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                if (_location == "pack")
                {
                    _player.Items.Add(this);
                }
                else
                {
                    _player.Items.Remove(this);
                }
            }
        }
        public bool Packable { get; set; }
        public bool Treasure { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public int Time { get; set; }
    }
}
