using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Sejiri_Steppe : Land
    {
        public Sejiri_Steppe() : base("Sejiri Steppe", "W", new manaColor[] {manaColor.White })
        {

        }

        public override void Cast()
        {
            this.Tapped = true;
            Card target = AI.Target(new TargetEffects.Protection(manaColor.Red), AI.getCurrentGameState());
        }

        public override void Tap()
        {
            
        }

        public override void Untap()
        {
            
        }
    }
}
