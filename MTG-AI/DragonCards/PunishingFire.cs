using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class PunishingFire : Spell
    {
        public PunishingFire()
            : base("Punishing Fire", "1R", 2, "Punishing Fire deals 2 damage to target creature or player. ANND Whenever an opponent gains life, you may pay 'R'. If you do, return Punishing Fire from your graveyard to your hand.", "R", Spell.spellSpeed.instant)
        {

        }

        public override void Cast()
        {
            
            //insert card TargetEffects
            Card c = AI.Target(new TargetEffects.Damage(2, TargetEffects.Damage.dmgTarget.Both), AI.getCurrentGameState());
            // Card c = AI.Target(new TargetEffects.ReturnToHand(), AI.getCurrentGameState());
            if (c == null)
            {
                AI.getCurrentGameState().enemyHealth -= 2;
                AI.sendDirections("Deal 2 damage to enemy");
            }
            else {
                //insert text command and others
                AI.sendDirections(String.Format("Do two damamge to {0}", c.CName));
                
                if (c is Creature)
                {
                    (c as Creature).Health -= 2;
                    if ((c as Creature).Health <= 0)
                    {
                        c.Field.Remove(c);
                        c.Graveyard.Add(c);
                        AI.sendDirections(String.Format("{0} dies", c.CName));
                    }
                }

                
            }

        }

        public override void EndOfTurn()
        {
           
        }
    }
}
