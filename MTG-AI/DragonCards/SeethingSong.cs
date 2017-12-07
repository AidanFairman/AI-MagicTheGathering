using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class SeethingSong : Spell
    {
        public SeethingSong()
            : base("Seething Song", "2R", 3, "add 'RRRRR' to your mana pool", "R", Spell.spellSpeed.instant)
        {

        }

        public override void Cast()
        {
            AI.getCurrentGameState().mana[(int)manaColor.Red] += 5;
            //insert text command and others
            string command = ("Add 5 mana to mana pool");
            // string command = String.Format("Return {0} to your hand", c.CName);

            AI.sendDirections(command);
        }

        public override void EndOfTurn()
        {
           
        }
    }
}
