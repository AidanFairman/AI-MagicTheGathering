using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI
{
    public abstract class Creature : Card
    {
        public enum CreatureAbilities
        {
            Trample = 0,
            Flying,
            Changeling,
            Flash,
            Defender,
            FirstStrike,
            LifeLink,
            Flanking,
            Vigilance,
            LevelUp,
            Reach,
            DoubleStrike,
            ProtectionFromX,
            Indestructable,
            None
        }

        public long abilityMask = 0;
        public CreatureAbilities[] abilities;
        public TargetEffects.BuffTarget buff;
        string ability;
        private int power;
        private int toughness;
        private int health;
        public int Health { get; set; }
        public bool SummonSick { get; set; }
        manaColor color;
        public int powerCounters;
        public int toughnessCounters;
        private ArtifactEnchant enchantment = null;
        public bool[] protection = { false, false, false, false, false, false };

        public int Power
        {
            get
            {
                return (int)((int)power + (int)powerCounters);
            }

            set
            {
                power = value;
            }
        }

        public int Toughness
        {
            get
            {
                return (int)((int)toughness + (int)toughnessCounters);
            }

            set
            {
                toughness = value;
            }
        }

        public override void deepCopy(Card c)
        {
            if (c.GetType() == this.GetType()) {
                Creature inC = (Creature)c;
                this.abilityMask = inC.abilityMask;
                this.health = inC.Health;
                this.SummonSick = inC.SummonSick;
                this.abilities = inC.abilities;
                this.powerCounters = inC.powerCounters;
                this.toughnessCounters = inC.toughnessCounters;
                this.buff = inC.buff;
                this.Tapped = inC.Tapped;
            }
        }

        public Creature(string cardName, string mana, int convMana, int cpower, int ctoughness, manaColor ccolor, CreatureAbilities[] abilityArr, string abilityText) : base(cardName, mana, convMana)
        {
            abilities = abilityArr;
            createAbilityMask(abilityArr);
            Power = cpower;
            color = ccolor;
            Toughness = ctoughness;
            ability = abilityText;
            Health = Toughness;
        }

        public void EnchantCreature(ArtifactEnchant enchant)
        {
            enchantment = enchant;
        }

        public void DisenchantCreature()
        {
            enchantment = null;
        }

        void createAbilityMask(CreatureAbilities[] abilities)
        {
            foreach(CreatureAbilities a in abilities)
            {
                addAbility(a);
            }
        }

        public void addAbility(CreatureAbilities add)
        {
            LinkedList<CreatureAbilities> tempAbilityList = new LinkedList<CreatureAbilities>();
            
            foreach (CreatureAbilities c in abilities)
            {
                tempAbilityList.AddLast(c);
            }
            abilityMask = abilityMask | (long)(Math.Pow(2, (int)add));
            if (!tempAbilityList.Contains<CreatureAbilities>(add))
            {
                tempAbilityList.AddLast(add);
            }
            abilities = tempAbilityList.ToArray<CreatureAbilities>();
        }

        public void removeAbility(CreatureAbilities remove)
        {
            LinkedList<CreatureAbilities> tempAbilityList = new LinkedList<CreatureAbilities>();

            foreach (CreatureAbilities c in abilities)
            {
                tempAbilityList.AddLast(c);
            }
            if ((abilityMask & (long)Math.Pow(2, (int)remove)) == 0 && tempAbilityList.Contains(remove))
            {
                tempAbilityList.Remove(remove);
            }
            abilities = tempAbilityList.ToArray<CreatureAbilities>();
        }

        protected void resetAbilities()
        {
            LinkedList<CreatureAbilities> ability = new LinkedList<CreatureAbilities>();
            for ( int i = 0; i < (int)CreatureAbilities.None; ++i)
            {
                if ((abilityMask & (long)Math.Pow(2, i)) > 0)
                {
                    ability.AddLast((CreatureAbilities)i);
                }
            }
            abilities = ability.ToArray<CreatureAbilities>();
            powerCounters = 0;
            toughnessCounters = 0;
        }

        public abstract void Cast();
        public abstract void EnterBattlefield();
        public abstract void OtherEnterBattlefield(Creature c);
        public abstract void Attacking();
        public abstract void Defending();
        public abstract void Dead();
        public abstract void Tap();
        public abstract void Untap();
        public abstract void Ability();
        public abstract void EndOfTurn();
    }
}
