using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace MTG_AI
{
    public abstract class Card
    {
        public enum manaColor
        {
            Colorless = 0,
            Green,
            White,
            Blue,
            Black,
            Red
        }

        public string CName { get; }
        //public string ManaCost { get; }
        public int ConvManaCost { get; }
        public bool Tapped { get; set; }
        public ListBox.ObjectCollection Hand { get; set; }
        public ListBox.ObjectCollection Library { get; set; }
        public ListBox.ObjectCollection Field { get; set; }
        public ListBox.ObjectCollection Graveyard { get; set; }
        public ListBox.ObjectCollection Exile { get; set; }
        public ListBox.ObjectCollection e_Field { get; set; }
        public int[] ManaByColor = new int[6]; //[N, G, W, U, B, R]

        public abstract void deepCopy(Card c);

        public Card(string cardName, string mana, int convMana)
        {
            Tapped = false;
            CName = cardName;
            ConvManaCost = convMana;
            //ManaCost = mana;
            foreach(char c in mana)
            {
                switch (c)
                {
                    case 'G':
                        ManaByColor[(int)manaColor.Green]++;
                        break;
                    case 'W':
                        ManaByColor[(int)manaColor.White]++;
                        break;
                    case 'U':
                        ManaByColor[(int)manaColor.Blue]++;
                        break;
                    case 'B':
                        ManaByColor[(int)manaColor.Black]++;
                        break;
                    case 'R':
                        ManaByColor[(int)manaColor.Red]++;
                        break;
                    default:
                        int.TryParse(c.ToString(), out ManaByColor[(int)manaColor.Colorless]);
                        break;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(CName);
            if (Tapped)
            {
                sb.Append(" (T)");
            }
            return sb.ToString();
        }

    }
}
