using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.TargetEffects
{
    public class Damage
    {
        public enum dmgTarget
        {
            Creature,
            Player,
            Both
        }
        public int DamageAmount { get; set; }
        public dmgTarget target;

        public Damage(int dmgAmt, dmgTarget dmgTarget)
        {
            DamageAmount = dmgAmt;
            target = dmgTarget;
        }
    }
}
