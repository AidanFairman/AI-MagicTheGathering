using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Selesnya_Sanctuary : Land
    {
        public Selesnya_Sanctuary() : base("Selesnya Sanctuary", "WG", new manaColor[] { manaColor.Green, manaColor.White })
        {
            
        }
 

        public override void Cast()
        {
            this.Tapped = true;
            Card c = AI.Target(new TargetEffects.ReturnToHand(), AI.getCurrentGameState());
            string command = String.Format("Return {0} to your hand", c.CName);
            AI.sendDirections(command);
        }

        public override void Tap()
        {
            ++AI.currentGui.manaAvailable[(int)manaColor.Green];
            ++AI.currentGui.manaAvailable[(int)manaColor.White];
        }

        public override void Untap()
        {
            
        }
    }
}
