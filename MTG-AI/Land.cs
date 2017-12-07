using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI
{
    abstract class Land : Card
    {
        string color { get; }
        manaColor[] provides { get; }

        public Land(string cardName, string landColor, manaColor[] createColor) : base(cardName, "", 0)
        {
            color = landColor;
            provides = createColor;
        }

        public override void deepCopy(Card c)
        {
            if (c.GetType() == this.GetType())
            {
                if (c.Tapped)
                {
                    this.Tapped = true;
                }
            }
        }

        public abstract void Tap();
        public abstract void Untap();
        public abstract void Cast();
    }
}
