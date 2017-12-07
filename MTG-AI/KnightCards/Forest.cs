using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Forest : Land
    {
        public Forest():base("Forest", "G", new manaColor[] {manaColor.Green})
        {

        }

        public override void Cast()
        {
            
        }

        public override void Tap()
        {
            ++AI.currentGui.manaAvailable[(int)manaColor.Green];
        }

        public override void Untap()
        {
            
        }
    }
}
