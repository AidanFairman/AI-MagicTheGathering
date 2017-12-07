using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Oblivian_Ring : ArtifactEnchant
    {
        public Oblivian_Ring () : base ("Oblivion Ring", "2W", 3, "W", SpellType.Enchantment, "When Oblivion Ring enters the battlefield, exile another target nonland permanent. When Oblivion Ring leaves the battlefield, return the exiled card to the battlefield under its owner's control.")
        {

        }
        public override void Cast()
        {
            
        }

        public override void Tap()
        {
           
        }

        public override void Untap()
        {
            
        }

        public override void Ability()
        {
           
        }

        public override void EndOfTurn()
        {
           
        }

        public override void EnterBattlefield()
        {
            Card target = AI.Target(new TargetEffects.Exile(), AI.getCurrentGameState());
            if (target != null)
            {
                AI.sendDirections(String.Format("Exile {0}", target.CName));
            }
            else
            {
                AI.sendDirections("Oblivion ring casts with no targets");
            }
        }
    }
}
