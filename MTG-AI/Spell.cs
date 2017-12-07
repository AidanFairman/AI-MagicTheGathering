using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI
{
   
    abstract class Spell : Card
    {
        public enum spellSpeed
        {
            instant,
            sorcery
        }

        string ruleText { get; }
        string color { get; }
        spellSpeed speed { get; }
        protected LinkedList<Card> targets = new LinkedList<Card>();
        protected bool hasEndOfTurnTrigger = false;

        public Spell(string cardName, string mana, int convMana, string rules, string cardColor, spellSpeed spSpeed) : base(cardName, mana, convMana)
        {
            ruleText = rules;
            speed = spSpeed;
            color = cardColor;
        }

        public override void deepCopy(Card c)
        {
            if (c.GetType() == this.GetType())
            {
                //good job
            }
        }

        public void addTarget(Card c)
        {
            targets.AddLast(c);
        }

        public abstract void Cast();
        public abstract void EndOfTurn();
    }
}
