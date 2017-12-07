using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI
{
    public class GameState
    {
        public enum phase
        {
            UsUntap,
            UsUpkeep,
            UsDraw,
            UsFirstMain,
            UsDeclareAttackers,
            UsDeclareDefenders, //enemy declares defenders while we're main player
            UsDamage,
            UsSecondMain,
            UsEndCleanup,
            EnemyUntap,
            EnemyUpkeep,
            EnemyDraw,
            EnemyFirstMain,
            EnemyDeclareAttackers,
            EnemyDeclareDefenders, //we declare defenders while enemy is main player
            EnemyDamage,
            EnemySecondMain,
            EnemyEndCleanup,
            StartGame,
            SetupGame,
            EndGame
        }

        /*public struct stateMeta
        {
            public int playerLife;
            public int enemyLife;
            public int totalPow;
            public int totalTough;
            public int totalMana;
            public int creatureCount;
        }*/

        public enum activePlayer
        {
            Us,
            Enemy
        }

        public static ListBox fauxBox = new ListBox();
        public ListBox.ObjectCollection PlayerLibrary = new ListBox.ObjectCollection(fauxBox);
        public ListBox.ObjectCollection PlayerHand = new ListBox.ObjectCollection(fauxBox);
        public ListBox.ObjectCollection PlayerField = new ListBox.ObjectCollection(fauxBox);
        public ListBox.ObjectCollection PlayerGraveyard = new ListBox.ObjectCollection(fauxBox);
        public ListBox.ObjectCollection PlayerExile = new ListBox.ObjectCollection(fauxBox);
        public ListBox.ObjectCollection EnemyField = new ListBox.ObjectCollection(fauxBox);
        public ListBox.ObjectCollection EnemyGraveyard = new ListBox.ObjectCollection(fauxBox);
        public ListBox.ObjectCollection EnemyExile = new ListBox.ObjectCollection(fauxBox);
        public ListBox.ObjectCollection Attacking = new ListBox.ObjectCollection(fauxBox);
        public ListBox.ObjectCollection Defending = new ListBox.ObjectCollection(fauxBox);
        public LinkedList<GameState> StateBranches = new LinkedList<GameState>();
        public int playerHealth, enemyHealth;
        public phase currentPhase;
        public activePlayer active;
        public Card target;
        public float score;
        public stateMeta meta = new stateMeta();
        public int[] mana;
        public bool manaForTurn;

        public GameState(ListBox.ObjectCollection pLib,
            ListBox.ObjectCollection pHand,
            ListBox.ObjectCollection pField,
            ListBox.ObjectCollection pGrave,
            ListBox.ObjectCollection pExile,
            ListBox.ObjectCollection EField,
            ListBox.ObjectCollection EGrave,
            ListBox.ObjectCollection EExile,
            ListBox.ObjectCollection Atk,
            ListBox.ObjectCollection Def,
            int pHealth, int eHealth, phase curPhase, activePlayer player, int[] manaAvail, bool PlayedMana)
        {
            playerHealth = pHealth;
            enemyHealth = eHealth;
            currentPhase = curPhase;
            active = player;
            target = null;
            score = 0;
            manaForTurn = PlayedMana;
            mana = manaAvail;

            foreach (Card c in pHand)
            {
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                addUsList(newC);
                newC.deepCopy(c);
                PlayerHand.Add(newC);
            }

            foreach (Card c in pField)
            {
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                addUsList(newC);
                newC.deepCopy(c);
                PlayerField.Add(newC);
            }

            foreach (Card c in pGrave)
            {
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                addUsList(newC);
                newC.deepCopy(c);
                PlayerGraveyard.Add(newC);
            }

            foreach (Card c in pExile)
            {
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                addUsList(newC);
                newC.deepCopy(c);
                PlayerExile.Add(newC);
            }

            foreach (Card c in EField)
            {
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                addEnemyList(newC);
                newC.deepCopy(c);
                EnemyField.Add(newC);
            }

            foreach (Card c in EGrave)
            {
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                addEnemyList(newC);
                newC.deepCopy(c);
                EnemyGraveyard.Add(newC);
            }

            foreach (Card c in EExile)
            {
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                addEnemyList(newC);
                newC.deepCopy(c);
                EnemyExile.Add(newC);
            }
            if (active == activePlayer.Us)
            {
                foreach (Card c in Atk)
                {
                    Card newC = (Card)Activator.CreateInstance(c.GetType());
                    addUsList(newC);
                    newC.deepCopy(c);
                    Attacking.Add(newC);
                }

                foreach (Card c in Def)
                {
                    Card newC = (Card)Activator.CreateInstance(c.GetType());
                    addEnemyList(newC);
                    newC.deepCopy(c);
                    Defending.Add(newC);
                }
            }
            else
            {
                foreach (Card c in Atk)
                {
                    Card newC = (Card)Activator.CreateInstance(c.GetType());
                    addEnemyList(newC);
                    newC.deepCopy(c);
                    Attacking.Add(newC);
                }

                foreach (Card c in Def)
                {
                    Card newC = (Card)Activator.CreateInstance(c.GetType());
                    addUsList(newC);
                    newC.deepCopy(c);
                    Defending.Add(newC);
                }
            }
        
            
        }

        public GameState(GameState gs, Card effTarget)
        {
            this.playerHealth = gs.playerHealth;
            this.enemyHealth = gs.enemyHealth;
            this.currentPhase = gs.currentPhase;
            this.target = effTarget;
            this.active = gs.active;
            this.mana = gs.mana;
            this.manaForTurn = gs.manaForTurn;

            foreach (Card c in gs.PlayerHand)
            {
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                addUsList(newC);
                newC.deepCopy(c);
                this.PlayerHand.Add(newC);
            }

            foreach (Card c in gs.PlayerField)
            {
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                addUsList(newC);
                newC.deepCopy(c);
                this.PlayerField.Add(newC);
            }

            foreach (Card c in gs.PlayerGraveyard)
            {
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                addUsList(newC);
                newC.deepCopy(c);
                this.PlayerGraveyard.Add(newC);
            }

            foreach (Card c in gs.PlayerExile)
            {
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                addUsList(newC);
                newC.deepCopy(c);
                this.PlayerExile.Add(newC);
            }

            foreach (Card c in gs.EnemyField)
            {
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                addEnemyList(newC);
                newC.deepCopy(c);
                this.EnemyField.Add(newC);
            }

            foreach (Card c in gs.EnemyGraveyard)
            {
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                addEnemyList(newC);
                newC.deepCopy(c);
                this.EnemyGraveyard.Add(newC);
            }

            foreach (Card c in gs.EnemyExile)
            {
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                addEnemyList(newC);
                newC.deepCopy(c);
                this.EnemyExile.Add(newC);
            }

            foreach (Card c in gs.Attacking)
            {//add check for phase so we know who is attacking
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                newC.deepCopy(c);
                this.Attacking.Add(newC);
            }

            foreach (Card c in gs.Defending)
            {//add check for phase so we know who is defending
                Card newC = (Card)Activator.CreateInstance(c.GetType());
                newC.deepCopy(c);
                this.Defending.Add(newC);
            }
        }

        private void addUsList(Card c)
        {
            c.Library = this.PlayerLibrary;
            c.Hand = this.PlayerHand;
            c.Field = this.PlayerField;
            c.Graveyard = this.PlayerGraveyard;
            c.Exile = this.PlayerExile;
            c.e_Field = this.EnemyField;
        }

        private void addEnemyList(Card c)
        {
            c.Library = null;
            c.Hand = null;
            c.Field = this.EnemyField;
            c.Graveyard = this.EnemyGraveyard;
            c.Exile = this.EnemyExile;
            c.e_Field = this.PlayerField;
        }

        public void addState(GameState state)
        {
            StateBranches.AddLast(state);
        }

        public void generateMeta()
        {
            meta = new stateMeta();
            meta.playerLife = this.playerHealth;
            meta.enemyLife = this.enemyHealth;
            foreach(Card temp in this.PlayerField)
            {
                if (temp is Creature)
                {
                    Creature c = temp as Creature;
                    meta.totalPow += (c.Power);
                    meta.totalTough += (c.Toughness);
                    ++meta.usCreatureCount;
                }
            }
            foreach(Card temp in this.EnemyField)
            {
                if (temp is Creature)
                {
                    Creature c = temp as Creature;
                    meta.enemyTotalPow += c.Power;
                    meta.enemyTotalTough += c.Toughness;
                    ++meta.enemyCreatureCount;
                }
            }
            if (this.active == activePlayer.Us)
            {
                foreach(Card temp in this.Attacking)
                {
                    if (temp is Creature)
                    {
                        Creature c = temp as Creature;
                        meta.totalPow += (c.Power);
                        meta.totalTough += (c.Toughness);
                        ++meta.usCreatureCount;
                    }
                }
                foreach(Card temp in this.Defending)
                {
                    if (temp is Creature)
                    {
                        Creature c = temp as Creature;
                        meta.enemyTotalPow += c.Power;
                        meta.enemyTotalTough += c.Toughness;
                        ++meta.enemyCreatureCount;
                    }
                }
            }
            else
            {
                foreach (Card temp in this.Defending)
                {
                    if (temp is Creature)
                    {
                        Creature c = temp as Creature;
                        meta.totalPow += (c.Power);
                        meta.totalTough += (c.Toughness);
                        ++meta.usCreatureCount;
                    }
                }
                foreach(Card temp in this.Attacking)
                {
                    if (temp is Creature)
                    {
                        Creature c = temp as Creature;
                        meta.enemyTotalPow += c.Power;
                        meta.enemyTotalTough += c.Toughness;
                        ++meta.enemyCreatureCount;
                    }
                }
            }
            
            foreach(Card temp in this.PlayerField)
            {
                if (temp is Land)
                {
                    Land l = temp as Land;
                    if (!l.Tapped)
                    {
                        ++meta.totalMana;
                    }
                }
            }
            
        }
    }
}
