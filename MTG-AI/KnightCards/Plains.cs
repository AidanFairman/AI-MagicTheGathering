using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Plains : Land
    {
        public Plains() : base("Plains", "W", new manaColor[] { manaColor.White })
        {

        }

public override void Cast()
        {
            
        }

        public override void Tap()
        {
            ++AI.currentGui.manaAvailable[(int)manaColor.White];
        }

        public override void Untap()
        {
            
        }
    }
}
