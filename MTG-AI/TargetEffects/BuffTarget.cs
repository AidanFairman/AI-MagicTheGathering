using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.TargetEffects
{
    public class BuffTarget
    {
        int powerCounters, toughCounters;
        Creature.CreatureAbilities[] abilityList;
        Creature.CreatureAbilities[] preBuffList = null;

        public BuffTarget(int power, int toughness, Creature.CreatureAbilities[] abilityBuff)
        {
            abilityList = abilityBuff;
            powerCounters = power;
            toughCounters = toughness;
        }

        public BuffTarget(BuffTarget buff)
        {
            this.powerCounters = buff.powerCounters;
            this.toughCounters = buff.toughCounters;
            this.abilityList = buff.abilityList;
        }

        public Creature.CreatureAbilities[] getBuffedAbilities(Creature.CreatureAbilities[] pbl)
        {
            LinkedList<Creature.CreatureAbilities> abilityHolder = new LinkedList<Creature.CreatureAbilities>();
            foreach (Creature.CreatureAbilities a in pbl)
            {
                abilityHolder.AddLast(a);
            }

            foreach(Creature.CreatureAbilities a in abilityList)
            {
                if (!abilityHolder.Contains(a))
                {
                    abilityHolder.AddLast(a);
                }
            }
            preBuffList = pbl;
            return abilityHolder.ToArray<Creature.CreatureAbilities>();
        }

        public Creature.CreatureAbilities[] getOriginalAbilities()
        {
            return preBuffList;
        }


    }
}
