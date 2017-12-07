using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Spidersilk_Armor : ArtifactEnchant
    {
        public Spidersilk_Armor () : base ("Spidersilk Armor", "2G", 3, "G", SpellType.Aura, "Creatures you control get +0/+1 and have reach. (They can block creatures with flying.)")
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
            foreach (Card card in Field)
            {
                if (card is Creature)
                {
                    Creature c = card as Creature;
                    c.toughnessCounters++;
                    c.addAbility(Creature.CreatureAbilities.Reach);
                }
                
            }
            
        }
    }
}
