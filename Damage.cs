using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI
{
    public class Damage
    {
        public enum dmgTarget
        {
            Creature,
            Player
        }
        public byte DamageAmount { get; set; }
        public dmgTarget[] targets;

        public Damage(byte dmgAmt, dmgTarget[] targetArr)
        {
            DamageAmount = dmgAmt;
            targets = targetArr;
        }
    }
}
