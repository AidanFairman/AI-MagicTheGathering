using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class ConeOfFlame : Spell
    {
        Card c1;
        Card c2;
            Card c3;



        public ConeOfFlame()
            : base("Cone of Flame", "3RR", 5, "Cone of Flame deals 1 damage to target creature or player, 2 damage to another target creature or player,and 3 damage to a third target creature or player.", "R", Spell.spellSpeed.sorcery)
        {

        }

        public override void Cast()
        {



            Card c1 = AI.Target(new TargetEffects.Damage(1, TargetEffects.Damage.dmgTarget.Creature), AI.getCurrentGameState());
            if (c1 != null)
            {
                AI.sendDirections(String.Format("Deal {0} damage to {1}", 1, c1.CName));
                ((Creature)c1).Health -= 1;
                if (((Creature)c1).Health <= 0)
                {
                    c1.Field.Remove(c1);
                    c1.Graveyard.Add(c1);
                    
                    AI.sendDirections(String.Format("{0} has died", c1.CName));
                }
            }
            Card c2 = AI.Target(new TargetEffects.Damage(2, TargetEffects.Damage.dmgTarget.Creature), AI.getCurrentGameState());
            if (c2 != null)
            {
                AI.sendDirections(String.Format("Deal {0} damage to {1}", 2, c2.CName));
                ((Creature)c2).Health -= 2;
                if (((Creature)c2).Health <= 0)
                {
                    c1.Field.Remove(c1);
                    c1.Graveyard.Add(c1);
                    AI.sendDirections(String.Format("{0} has died", c2.CName));
                }
            }
            Card c3 = AI.Target(new TargetEffects.Damage(3, TargetEffects.Damage.dmgTarget.Player), AI.getCurrentGameState());
            AI.getCurrentGameState().enemyHealth -= 3;
            AI.sendDirections("Deal 3 damage to Enemy Player");

        }

        public override void EndOfTurn()
        {
            
        }
    }
}
