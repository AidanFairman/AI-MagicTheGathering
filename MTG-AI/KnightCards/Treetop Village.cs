using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Treetop_Village : Land
    {
        public Treetop_Village() : base("Treetop Village", "G", new manaColor[] { manaColor.Green })
        {

        }

        public override void Cast()
        {
            this.Tapped = true;
        }

        public override void Tap()
        {
            
        }

        public override void Untap()
        {
            
        }
    }
}
