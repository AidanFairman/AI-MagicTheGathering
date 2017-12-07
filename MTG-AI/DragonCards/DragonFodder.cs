using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class DragonFodder : Spell
    {
        public DragonFodder()
            : base("Dragon Fodder", "1R", 2, "put two 1/1 red goblin creature tokens onto the battlefield.", "R", Spell.spellSpeed.sorcery)
        {

        }

        public override void Cast()
        {
            
            string command = String.Format("Put two 1/1 Goblin tokens onto the battlefield");
            
            AI.sendDirections(command);
            for (int i = 0; i < 2; ++i)
            {
                Goblin gob = new Goblin();
                gob.Library = this.Library;
                gob.Hand = this.Hand;
                gob.Field = this.Field;
                gob.e_Field = this.e_Field;
                gob.Graveyard = this.Graveyard;
                gob.Exile = this.Exile;
                Field.Add(gob);
            }

            
        }

        public override void EndOfTurn()
        {
           
        }
    }
}
