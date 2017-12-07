﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class White_Knight : Creature

    {
        public White_Knight() : base("White Knight", "WW", 2, 2, 2, manaColor.White, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.FirstStrike}, "First strike, protection from black.")
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
