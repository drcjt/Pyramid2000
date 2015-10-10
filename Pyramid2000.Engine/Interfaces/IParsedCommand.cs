using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine.Interfaces
{
    public enum Function
    {
        North,
        East,
        South,
        West,
        NorthEast,
        SouthEast,
        SouthWest,
        NorthWest,
        Up,
        Down,
        In,
        Out,
        Cross,
        Left,
        Right,
        Jump,
        Climb,
        Panel,
        Back,
        Swim,
        On,
        Off,
        Quit,
        Stop,
        Score,
        Inventory,
        Look,
        Drop,
        Wave,
        Pour,
        Rub,
        Throw,
        Fill,
        Get,
        Open,
        Attack,
        Feed,
        Eat,
        Drink,
        Break,
        Load,
        Save,
        Plugh,
        Help
    }

    public interface IParsedCommand
    {
        Function Function { get; set; }
        IItem Item { get; set; }
    }
}
