using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class DragonsClaw : ArtifactEnchant
    {
        public DragonsClaw()
            : base("Dragon's Claw", "2", 2, "N", SpellType.Enchantment, "whenever a player casts a red spell, you may gain 1 life.")
        {
            // "whenever a player casts a red spell, you may gain 1 life."

            
        }
        
        public override void EnterBattlefield()
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
            foreach (Card c1 in Field)
            {

                // if (Card.ccoler = red )

                {
                    //players face gains 1 life here

                }
            }
        }

        public override void EndOfTurn()
        {
            
        }
    }
}
