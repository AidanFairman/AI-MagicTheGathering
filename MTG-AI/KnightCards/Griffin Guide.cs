using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Griffin_Guide : ArtifactEnchant
    {
        public Griffin_Guide() : base ("Griffin Guide", "2W", 3, "W", SpellType.Aura, "Enchanted creature gets +2/+2 and has flying. When enchanted creature is put into a graveyard, put a 2/2 white Griffin creature token with flying onto the battlefield.")
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
        //when it's put into a graveyard, put a 2/2 white Griffin creature token with flying onto the battlefield. 

        public override void EnterBattlefield()
        {
            /*Card target = AI.Target(new TargetEffects.BuffTarget(2, 2, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.Flying }), AI.getCurrentGameState());
            AI.sendDirections(String.Format("{0} gets +2/+2 and flying until end of turn.", target.CName));*/
        }
    }
}
