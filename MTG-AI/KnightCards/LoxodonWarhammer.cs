using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.KnightCards
{
    class LoxodonWarhammer : ArtifactEnchant
    {
        public LoxodonWarhammer() : base("Loxodon Warhammer", "3", 3, "N", SpellType.Artifact, "Equipped creature gets +3/+0 and has trample and lifelink")
        {

        }

        public override void Ability()
        {
           /* Card target = AI.Target(new TargetEffects.BuffTarget(3, 0, new Creature.CreatureAbilities[] { Creature.CreatureAbilities.LifeLink, Creature.CreatureAbilities.Trample }), AI.getCurrentGameState());
            AI.sendDirections(String.Format("{0} gets +3/+0 and has trample and lifelink.", target.CName));*/
        }

        public override void Cast()
        {
            
        }

        public override void EndOfTurn()
        {
            
        }

        public override void EnterBattlefield()
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
