using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class Mountain : Land
    {

        public Mountain() : base("Mountain", "R", new manaColor[] { manaColor.Red })
        {

        }

        public override void Cast()
        {
            
        }

        public override void Tap()
        {
            ++AI.currentGui.manaAvailable[(int)manaColor.Red];
        }

        public override void Untap()
        {
            
        }
    }
}
