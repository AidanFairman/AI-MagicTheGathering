using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.TargetEffects
{
    public class Protection
    {
        public bool[] colors = { false, false, false, false, false, false }; //[N, G, W, U, B, R]
        public Protection(Card.manaColor color)
        {
            colors[(int)color] = true;
        }
    }
}
