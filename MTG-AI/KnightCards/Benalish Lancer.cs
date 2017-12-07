using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class Benalish_Lancer : Creature
    {
        public Benalish_Lancer() : base("Benalish Lancer", "2W", 3, 2, 2, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.None }, "Kicker 2W (You may pay an additional 2W as you cast this spell.) If Benalish Lancer was kicked, it enters the battlefield with two +1/+1 counters on it and with first strike.")
        {

        }

        public override void Ability()
        {
            
        }

        public override void Attacking()
        {
            
        }

        public override void Cast()
        {
            
        }

        public override void Dead()
        {
            resetAbilities();
        }

        public override void Defending()
        {
            
        }

        public override void EndOfTurn()
        {
            
        }

        public override void EnterBattlefield()
        {
            SummonSick = true;
            /*//if mana is paid
            Card target = AI.Target(new TargetEffects.BuffTarget(2, 2, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.FirstStrike }), AI.getCurrentGameState());
            AI.sendDirections(String.Format("{0} enters the battlefield with two +1/+1 counters on it and with first strike.", target.CName));*/
        }

        public override void OtherEnterBattlefield(Creature C)
        {
           
        }

        public override void Tap()
        {
            
        }

        public override void Untap()
        {
            
        }
    }
}
