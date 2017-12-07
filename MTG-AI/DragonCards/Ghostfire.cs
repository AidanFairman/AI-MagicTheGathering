using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class Ghostfire : Spell
    {
        public Ghostfire()
            : base("Ghostfire", "2R", 3, "Ghostfire is colorless.  Ghostfire deals 3 damage to target creature or player.", "N", Spell.spellSpeed.instant)
        {

        }

        public override void Cast()
        {

            Card c = AI.Target(new TargetEffects.Damage(3, TargetEffects.Damage.dmgTarget.Both), AI.getCurrentGameState());
            if (c == null || c == this)
            {
                AI.getCurrentGameState().enemyHealth -= 3;
                AI.sendDirections("Enemy takes 3 damage");
            }
            else {
                AI.sendDirections(String.Format("{0} takes 3 damage", c.CName));
                ((Creature)c).Health -= 3;
                if (((Creature)c).Health <= 0)
                {
                    c.Field.Remove(c);
                    c.Graveyard.Add(c);
                    AI.sendDirections(String.Format("{0} died", c.CName));
                }
            }
            // string command = String.Format("Return {0} to your hand", c.CName);

            //AI.sendDirections(command);

        }

        public override void EndOfTurn()
        {
            
        }
    }
}
