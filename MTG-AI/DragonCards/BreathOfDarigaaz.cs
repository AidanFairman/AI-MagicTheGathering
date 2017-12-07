using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI.DragonCards
{
    class BreathOfDarigaaz : Spell
    {
        public BreathOfDarigaaz()
            : base("Breathof Draigaaz", "3R", 4, " kicker 2: you may pay an additional 'NN' as you cast this spell.  Breath of darigaaz deals 1 damage to each creature without flying and each player.  If Breath of Darigaaz was kicked, it deals 4 damage to each creature without flying and each player instead.", "R", Spell.spellSpeed.sorcery)
        {

        }

        public override void Cast()
        {
            AI.sendDirections(String.Format("Cast {0} Kicked", this.CName));
            LinkedList<Card> killed = new LinkedList<Card>();
            foreach (Card c1 in Field)
            {

                if (c1 is Creature)
                {

                    Creature c = c1 as Creature;
                    if (!c.abilities.Contains(Creature.CreatureAbilities.Flying))
                    {
                        c.Health -= 4;
                        AI.sendDirections(String.Format("{0} Took 4 damage", c.CName));
                        if (c.Health <= 0)
                        {
                            killed.AddLast(c);
                            AI.sendDirections(String.Format("{0} died", c.CName));
                        }
                    }
                }
            }

            foreach (Card c1 in e_Field)
            {

                if (c1 is Creature)
                {

                    Creature c = c1 as Creature;
                    if (!c.abilities.Contains(Creature.CreatureAbilities.Flying))
                    {
                        c.Health -= 4;
                        AI.sendDirections(String.Format("{0} Took 4 damage", c.CName));
                        if (c.Health <= 0)
                        {
                            killed.AddLast(c);
                            AI.sendDirections(String.Format("{0} died", c.CName));
                        }
                    }
                }
            }

            foreach (Card c in killed)
            {
                c.Field.Remove(c);
                c.Graveyard.Add(c);
            }
            
        }

        public override void EndOfTurn()
        {
           
        }
    }
}
