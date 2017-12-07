using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI
{
    public abstract class ArtifactEnchant : Card
    {
        public enum SpellType
        {
            Enchantment,
            Aura,
            Artifact
        }

        string ability;
        string color;
        public SpellType type;
        Creature enchantedCreature = null;

        public ArtifactEnchant(string cardName, string mana, int convMana, string ccolor, SpellType ctype, string abilityText) : base(cardName, mana, convMana)
        {
            ability = abilityText;
            color = ccolor;
            type = ctype;
        }

        public void enchantCreature(Creature creature)
        {
            enchantedCreature = creature;
        }

        public void disenchantCreature()
        {
            enchantedCreature = null;
        }

        public override void deepCopy(Card c)
        {
            if (c.GetType() == this.GetType())
            {

            }
        }

        public abstract void Cast();
        public abstract void EnterBattlefield();
        public abstract void Tap();
        public abstract void Untap();
        public abstract void Ability();
        public abstract void EndOfTurn();
    }
}
