using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000_StraightPort
{
    public interface IGame
    {
        void ProcessPlayerInput(string input);
        void Init();
    }
}
