using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTG_AI
{
    public partial class MagicAIGUI : Form
    {


        //private AI AIRef;
        private GameState.phase currentPhase;
        private int playerHealth, enemyHealth;
        private GameState.activePlayer activePlayer;
        public int[] manaAvailable = { 0, 0, 0, 0, 0, 0 };
        private bool manaForTurn;
        private bool firstTurn;

        public GameState getState()
        {
            return new GameState(lbxUsLibrary.Items ,lbxUsHand.Items, lbxUsField.Items, lbxUsGraveyard.Items, lbxUsExile.Items,
                lbxEnemyField.Items, lbxEnemyGraveyard.Items, lbxEnemyExile.Items, lbxAttacking.Items,
                lbxDefending.Items, playerHealth, enemyHealth, currentPhase, activePlayer, manaAvailable, manaForTurn);
        }

        private void advancePhase()
        {
            switch (currentPhase)
            {
                case GameState.phase.SetupGame:
                    currentPhase = GameState.phase.StartGame;
                    firstTurn = true;
                    StartGame();
                    break;
                case GameState.phase.StartGame:

                    if (rbtThem.Checked)
                    {
                        activePlayer = GameState.activePlayer.Enemy;
                        currentPhase = GameState.phase.EnemyUntap;
                        tbxPhase.Text = "Enemy Untap";
                        EnemyUntap();

                    }
                    else
                    {
                        activePlayer = GameState.activePlayer.Us;
                        currentPhase = GameState.phase.UsUntap;
                        tbxPhase.Text = "Our Untap";
                        UsUntap();
                    }
                    break;
                case GameState.phase.UsUntap:
                    currentPhase = GameState.phase.UsUpkeep;
                    tbxPhase.Text = "Our Upkeep";
                    UsUpkeep();
                    break;
                case GameState.phase.UsUpkeep:
                    currentPhase = GameState.phase.UsDraw;
                    tbxPhase.Text = "Our Draw";
                    UsDraw();
                    break;
                case GameState.phase.UsDraw:
                    currentPhase = GameState.phase.UsFirstMain;
                    tbxPhase.Text = "Our First Main";
                    UsFirstMain();
                    break;
                case GameState.phase.UsFirstMain:
                    currentPhase = GameState.phase.UsDeclareAttackers;
                    tbxPhase.Text = "Our Declare Attackers";
                    UsDeclareAttackers();
                    break;
                case GameState.phase.UsDeclareAttackers:
                    currentPhase = GameState.phase.UsDeclareDefenders;
                    tbxPhase.Text = "Our Enemy Declares Defenders";
                    UsDeclareDefenders();
                    break;
                case GameState.phase.UsDeclareDefenders: //enemy declares defenders while we're main player
                    currentPhase = GameState.phase.UsDamage;
                    tbxPhase.Text = "Damage Calculation";
                    UsDamage();
                    break;
                case GameState.phase.UsDamage:
                    currentPhase = GameState.phase.UsSecondMain;
                    tbxPhase.Text = "Our Second Main";
                    UsSecondMain();
                    break;
                case GameState.phase.UsSecondMain:
                    currentPhase = GameState.phase.UsEndCleanup;
                    tbxPhase.Text = "Our End/Cleanup";
                    UsEndCleanup();
                    break;
                case GameState.phase.UsEndCleanup:
                    activePlayer = GameState.activePlayer.Enemy;
                    currentPhase = GameState.phase.EnemyUntap;
                    tbxPhase.Text = "Enemy Untap";
                    EnemyUntap();
                    break;
                case GameState.phase.EnemyUntap:
                    currentPhase = GameState.phase.EnemyUpkeep;
                    tbxPhase.Text = "Enemy Upkeep";
                    EnemyUpkeep();
                    break;
                case GameState.phase.EnemyUpkeep:
                    currentPhase = GameState.phase.EnemyDraw;
                    tbxPhase.Text = "Enemy Draw";
                    EnemyDraw();
                    break;
                case GameState.phase.EnemyDraw:
                    currentPhase = GameState.phase.EnemyFirstMain;
                    tbxPhase.Text = "Enemy First Main";
                    EnemyFirstMain();
                    break;
                case GameState.phase.EnemyFirstMain:
                    currentPhase = GameState.phase.EnemyDeclareAttackers;
                    tbxPhase.Text = "Enemy Declares Attackers";
                    EnemyDeclareAttackers();
                    break;
                case GameState.phase.EnemyDeclareAttackers:
                    currentPhase = GameState.phase.EnemyDeclareDefenders;
                    tbxPhase.Text = "Our Declare Defenders";
                    EnemyDeclareDefenders();
                    break;
                case GameState.phase.EnemyDeclareDefenders: //we declare defenders while enemy is main player
                    currentPhase = GameState.phase.EnemyDamage;
                    tbxPhase.Text = "Damage Calculations";
                    EnemyDamage();
                    break;
                case GameState.phase.EnemyDamage:
                    currentPhase = GameState.phase.EnemySecondMain;
                    tbxPhase.Text = "Enemy Second Main";
                    EnemySecondMain();
                    break;
                case GameState.phase.EnemySecondMain:
                    currentPhase = GameState.phase.EnemyEndCleanup;
                    tbxPhase.Text = "Enemy End/Cleanup";
                    EnemyEndCleanup();
                    break;
                case GameState.phase.EnemyEndCleanup:
                    activePlayer = GameState.activePlayer.Us;
                    currentPhase = GameState.phase.UsUntap;
                    tbxPhase.Text = "Our Untap";
                    UsUntap();
                    break;
                case GameState.phase.EndGame:
                    currentPhase = GameState.phase.SetupGame;
                    tbxPhase.Text = "Game Start. Please select starting player";
                    EndGame();
                    break;
                default:
                    break;
            }
        }

        private void setupGame()
        {
            if (rbtThem.Checked || rbtUs.Checked)
            {
                lbxUsLibrary.Items.Clear();
                AI.setTextBox(tbxAction);
                lbxEnemyLibrary.Items.Clear();
                lbxTokens.Items.Clear();
                //currentPhase = GameState.phase.StartGame;
                btnStartGame.Enabled = false;
                playerHealth = 20;
                enemyHealth = 20;
                tbxUsHealth.Text = playerHealth.ToString();
                tbxEnemyHealth.Text = enemyHealth.ToString();
               
                

                if (rbtKnights.Checked)
                {
                    foreach (Card c in Cardmaker.Knights)
                    {
                        c.Library = lbxUsLibrary.Items;
                        c.Hand = lbxUsHand.Items;
                        c.Field = lbxUsField.Items;
                        c.Graveyard = lbxUsGraveyard.Items;
                        c.Exile = lbxUsExile.Items;
                        c.e_Field = lbxEnemyField.Items;
                        //c.MyLocation = c.Library;
                        lbxUsLibrary.Items.Add(c);
                    }
                    KnightCards.GriffinToken GT = new KnightCards.GriffinToken();
                    GT.Library = lbxUsLibrary.Items;
                    GT.Hand = lbxUsHand.Items;
                    GT.Field = lbxUsField.Items;
                    GT.Graveyard = lbxUsGraveyard.Items;
                    GT.Exile = lbxUsExile.Items;
                    GT.e_Field = lbxEnemyField.Items;
                    lbxTokens.Items.Add(GT);

                    foreach (Card c in Cardmaker.Dragons)
                    {
                        c.Library = lbxEnemyLibrary.Items;
                        c.Hand = null;
                        c.Field = lbxEnemyField.Items;
                        c.Graveyard = lbxEnemyGraveyard.Items;
                        c.Exile = lbxEnemyExile.Items;
                        c.e_Field = lbxUsField.Items;
                        //c.MyLocation = c.Library;
                        lbxEnemyLibrary.Items.Add(c);
                    }
                    Card gob = new DragonCards.Goblin();
                    gob.Library = lbxEnemyLibrary.Items;
                    gob.Hand = null;
                    gob.Field = lbxEnemyField.Items;
                    gob.Graveyard = lbxEnemyGraveyard.Items;
                    gob.Exile = lbxEnemyExile.Items;
                    gob.e_Field = lbxUsField.Items;
                    lbxTokens.Items.Add(gob);
                }
                else
                {
                    foreach (Card c in Cardmaker.Dragons)
                    {
                        c.Library = lbxUsLibrary.Items;
                        c.Hand = lbxUsHand.Items;
                        c.Field = lbxUsField.Items;
                        c.Graveyard = lbxUsGraveyard.Items;
                        c.Exile = lbxUsExile.Items;
                        c.e_Field = lbxEnemyField.Items;
                        //c.MyLocation = c.Library;
                        lbxUsLibrary.Items.Add(c);
                    }
                    Card GT = new DragonCards.Goblin();
                    GT.Library = lbxUsLibrary.Items;
                    GT.Hand = lbxUsHand.Items;
                    GT.Field = lbxUsField.Items;
                    GT.Graveyard = lbxUsGraveyard.Items;
                    GT.Exile = lbxUsExile.Items;
                    GT.e_Field = lbxEnemyField.Items;
                    lbxTokens.Items.Add(GT);
                    foreach (Card c in Cardmaker.Knights)
                    {
                        c.Library = lbxEnemyLibrary.Items;
                        c.Hand = null;
                        c.Field = lbxEnemyField.Items;
                        c.Graveyard = lbxEnemyGraveyard.Items;
                        c.Exile = lbxEnemyExile.Items;
                        c.e_Field = lbxUsField.Items;
                        //c.MyLocation = c.Library;
                        lbxEnemyLibrary.Items.Add(c);
                    }
                    Card gob = new KnightCards.GriffinToken();
                    gob.Library = lbxEnemyLibrary.Items;
                    gob.Hand = null;
                    gob.Field = lbxEnemyField.Items;
                    gob.Graveyard = lbxEnemyGraveyard.Items;
                    gob.Exile = lbxEnemyExile.Items;
                    gob.e_Field = lbxUsField.Items;
                    lbxTokens.Items.Add(gob);
                }
                LinkedList<Card> untap = new LinkedList<Card>();
                foreach(Card c in lbxUsLibrary.Items)
                {
                    if (c.Tapped)
                    {
                        untap.AddLast(c);
                    }
                }
                foreach (Card c in lbxEnemyLibrary.Items)
                {
                    if (c.Tapped)
                    {
                        untap.AddLast(c);
                    }
                }
                foreach(Card c in untap)
                {
                    c.Tapped = false;
                    c.Library.Remove(c);
                    c.Library.Add(c);
                }
            }
        }

        private void StartGame()
        {
            tbxPhase.Text = "Start of Game";
            tbxAction.Text = "";
            tbxAction.AppendText("START OF GAME");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");
            tbxAction.AppendText("Draw starting 7 cards\n");

        }

        private void UsUntap()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("OUR UNTAP STEP");
            tbxAction.AppendText("\n");
            LinkedList<Card> update = new LinkedList<Card>();

            foreach (Card c in lbxUsField.Items)
            {
                

                if (c.Tapped)
                {
                    c.Tapped = false;
                    update.AddLast(c);
                    tbxAction.AppendText(String.Format("Untap {0}\n", c.CName));
                    if (c is Creature)
                    {
                        ((Creature)c).Untap();
                    } else if (c is ArtifactEnchant)
                    {
                        ((ArtifactEnchant)c).Untap();
                    } else if (c is Land)
                    {
                        ((Land)c).Untap();
                    }
                }
            }

            foreach(Card c in update)
            {
                
                c.Field.Remove(c);
                c.Field.Add(c);
            }

            pbxUs.BackColor = Color.Green;
            pbxThem.BackColor = Color.Red;
        }

        private void UsUpkeep()
        {
            manaForTurn = false;
            foreach (Card c in lbxUsField.Items)
            {
                if (c is Creature)
                {
                    ((Creature)c).SummonSick = false;
                }
            }
            tbxAction.Text = "";
            tbxAction.AppendText("OUR UPKEEP STEP");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("Move to Draw Step.\n");
        }

        private void UsDraw()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("OUR DRAW STEP");
            tbxAction.AppendText("\n");
            if (!firstTurn)
            {
                firstTurn = false;
                tbxAction.AppendText("Draw a card.\n");
            }
        }

        private void UsFirstMain()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("OUR FIRST MAIN PHASE");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");
        }

        private void UsDeclareAttackers()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("WE DECLARE ATTACKERS");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");
        }

        private void UsDeclareDefenders()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("ENEMY DECLARES DEFENDERS");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");
        }//enemy declares defenders while we're main player

        private void UsDamage()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("CALCULATE COMBAT DAMAGE");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");

            //TODO: Add other damage stuff here

            //return creatures to where they need to go
            CleanupBattlefield();

        }

        private void UsSecondMain()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("OUR SECOND MAIN PHASE");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");
        }

        private void UsEndCleanup()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("OUR END STEP");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");
            foreach (Card c in lbxUsField.Items)
            {
                if (c is Creature)
                {
                    ((Creature)c).EndOfTurn();
                } else if (c is ArtifactEnchant)
                {
                    ((ArtifactEnchant)c).EndOfTurn();
                }
            }
            while (lbxUsHand.Items.Count > 7)
            {
                Card Targ = AI.Target(new TargetEffects.Discard(), AI.getCurrentGameState());
                if (Targ != null)
                {
                    Card c = null;
                    foreach (Card ca in lbxUsHand.Items)
                    {
                        if (ca.GetType() == Targ.GetType())
                        {
                            c = ca;
                        }
                    } 
                    lbxUsHand.Items.Remove(c);
                    lbxUsGraveyard.Items.Add(c);
                    AI.sendDirections(String.Format("Discard {0}", Targ.CName));
                    AI.getNewState();
                    AI.ActiveState = getState();

                }
            }
        }

        private void EnemyUntap()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("ENEMY UNTAP STEP");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");
            LinkedList<Card> update = new LinkedList<Card>();
            foreach (Card c in lbxEnemyField.Items)
            {
                if (c.Tapped)
                {
                    
                    c.Tapped = false;
                    update.AddLast(c);
                    tbxAction.AppendText(String.Format("Enemy untaps {0}\n", c.CName));
                    if (c is Creature)
                    {
                        ((Creature)c).Untap();
                    }
                    else if (c is ArtifactEnchant)
                    {
                        ((ArtifactEnchant)c).Untap();
                    }
                    else if (c is Land)
                    {
                        ((Land)c).Untap();
                    }
                }
            }

            foreach (Card c in update)
            {
                c.Field.Remove(c);
                c.Field.Add(c);
            }
            pbxUs.BackColor = Color.Red;
            pbxThem.BackColor = Color.Green;
        }

        private void EnemyUpkeep()
        {
            foreach (Card c in lbxEnemyField.Items)
            {
                c.Tapped = false;
                if (c is Creature)
                {
                    ((Creature)c).SummonSick = false;
                }
            }
            tbxAction.Text = "";
            tbxAction.AppendText("ENEMY UPKEEP STEP");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");
        }

        private void EnemyDraw()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("ENEMY DRAW STEP");
            tbxAction.AppendText("\n");
            firstTurn = false;
        }

        private void EnemyFirstMain()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("ENEMY FIRST MAIN PHASE");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");
        }

        private void EnemyDeclareAttackers()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("ENEMY DECLARE ATTACKERS");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");
        }

        private void EnemyDeclareDefenders()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("WE DECLARE DEFENDERS");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");
        }//we declare defenders while enemy is main player

        private void EnemyDamage()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("CALCULATE COMBAT");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");
            //TODO: Add logic before returning creatures

            //return creatures where they go
            CleanupBattlefield();
        }

        private void EnemySecondMain()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("ENEMY SECOND MAIN PHASE");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");
        }

        private void EnemyEndCleanup()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("ENEMY END STEP");
            tbxAction.AppendText("\n");
            tbxAction.AppendText("**************\n");

        }

        private void EndGame()
        {
            tbxAction.Text = "";
            tbxAction.AppendText("END OF GAME");
            tbxAction.AppendText("\n");

        }

        private void btnAdvPhase_Click(object sender, EventArgs e)
        {
            advancePhase();
        }

        public MagicAIGUI()
        {
            InitializeComponent();
            Cardmaker.MakeDecks();
            AI.setTextBox(tbxAction);
            AI.setGUI(this);
        }

        private void CleanupBattlefield()
        {
            LinkedList<Creature> buffer = new LinkedList<Creature>();
            foreach (Creature c in lbxAttacking.Items)
            {
                if (!c.abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.Vigilance))
                {
                    c.Tapped = true;
                }
                buffer.AddLast(c);
            }
            foreach (Creature c in lbxDefending.Items)
            {
                buffer.AddLast(c);
            }
            lbxAttacking.Items.Clear();
            lbxDefending.Items.Clear();
            while (buffer.Count > 0)
            {
                Creature c = buffer.First.Value;
                declareDamage(c);
                buffer.RemoveFirst();
                if (c.Health <= 0)
                {
                    tbxAction.AppendText(String.Format("{0} goes to the graveyard.\n", c.ToString()));
                    c.Graveyard.Add(c);
                }
                else
                {

                    tbxAction.AppendText(String.Format("{0} needs attention\n", c.ToString()));
                    c.Field.Add(c);
                }

            }
        }

        private void declareDamage(Creature c)
        {
            if (c.abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.DoubleStrike) || c.abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.FirstStrike))
            {
                tbxAction.AppendText(String.Format("{0} deals {1} damage for first strike damage", c.CName, c.Power));
            }
            if (!c.abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.FirstStrike))
            {
                tbxAction.AppendText(String.Format("{0} deals {1} damage for normal damage", c.CName, c.Power));
            }
        }

        private void lbxUsGraveyard_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbxEnemyGraveyard_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            setupGame();

            currentPhase = GameState.phase.SetupGame;
        }

        private void lbxEnemyExile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbxEnemyField_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*E CreateType<E>() where E : new()
        {
            return new E();
        }*/

        private void btnUsToHand_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxUsLibrary.SelectedItem;
            if (temp != null)
            {
                
                lbxUsLibrary.Items.Remove(temp);
                lbxUsHand.Items.Add(temp);
            }
        }

        private void btnUsCast_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxUsHand.SelectedItem;
            if (temp != null)
            {
                lbxUsHand.Items.Remove(temp);
                if (temp is Land)
                {
                    Land l = temp as Land;
                    l.Cast();
                    manaForTurn = true;
                    lbxUsField.Items.Add(temp);
                }
                else if (temp is Creature)
                {
                    Creature c = temp as Creature;
                    c.Cast();
                    lbxUsField.Items.Add(temp);
                    c.EnterBattlefield();
                    foreach(Card ca in lbxUsField.Items)
                    {
                        if (ca is Creature)
                        {
                            Creature cr = ca as Creature;
                            cr.OtherEnterBattlefield(c);
                        }
                    }
                }
                else if ( temp is ArtifactEnchant)
                {
                    ArtifactEnchant ae = temp as ArtifactEnchant;
                    ae.Cast();
                    lbxUsField.Items.Add(temp);
                }
                else
                {
                    Spell sp = temp as Spell;
                    sp.Cast();
                    lbxUsGraveyard.Items.Add(temp);
                }
            }
        }

        private void btnUsAttackDefend_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxUsField.SelectedItem;
            if (temp != null && temp is Creature)
            {
                lbxUsField.Items.Remove(temp);
                if (currentPhase == GameState.phase.UsDeclareAttackers)
                {
                    Creature c = temp as Creature;
                    c.Attacking();
                    lbxAttacking.Items.Add(temp);
                }
                else if(currentPhase == GameState.phase.EnemyDeclareDefenders)
                {
                    Creature c = temp as Creature;
                    c.Defending();
                    lbxDefending.Items.Add(temp);
                }
                else
                {
                    lbxUsField.Items.Add(temp);
                }
            }
        }

        private void btnUsKill_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxUsField.SelectedItem;
            if (temp != null)
            {
                lbxUsField.Items.Remove(temp);
                lbxUsGraveyard.Items.Add(temp);
                if(temp is Creature)
                {
                    ((Creature)temp).Dead();
                }
            }
        }

        private void btnUsFieldToExile_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxUsField.SelectedItem;
            if (temp != null)
            {
                lbxUsField.Items.Remove(temp);
                lbxUsExile.Items.Add(temp);
            }
        }

        private void btnUsExileToField_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxUsExile.SelectedItem;
            if (temp != null)
            {
                lbxUsExile.Items.Remove(temp);
                if (temp is Creature)
                {
                    Creature c = temp as Creature;
                    c.EnterBattlefield();
                }
                if (temp is ArtifactEnchant)
                {
                    ArtifactEnchant ae = temp as ArtifactEnchant;
                    ae.EnterBattlefield();
                }
                lbxUsField.Items.Add(temp);
            }
        }

        private void btnEnemyCast_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxEnemyLibrary.SelectedItem;
            if (temp != null)
            {
                lbxEnemyLibrary.Items.Remove(temp);
                if (temp is Land || temp is Creature || temp is ArtifactEnchant)
                {
                    lbxEnemyField.Items.Add(temp);
                }
                else
                {
                    lbxEnemyGraveyard.Items.Add(temp);
                }
            }
        }

        private void btnEnemyAttackDefend_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxEnemyField.SelectedItem;
            if (temp != null && temp is Creature)
            {
                lbxEnemyField.Items.Remove(temp);
                if (currentPhase == GameState.phase.EnemyDeclareAttackers)
                {
                    lbxAttacking.Items.Add(temp);
                }
                else if (currentPhase == GameState.phase.UsDeclareDefenders)
                {
                    lbxDefending.Items.Add(temp);
                }
                else
                {
                    lbxEnemyField.Items.Add(temp);
                }
            }
        }

        private void btnEnemyKill_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxEnemyField.SelectedItem;
            if (temp != null)
            {
                lbxEnemyField.Items.Remove(temp);
                lbxEnemyGraveyard.Items.Add(temp);
            }
        }

        private void btnEnemyFieldToExile_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxEnemyField.SelectedItem;
            if (temp != null)
            {
                lbxEnemyField.Items.Remove(temp);
                lbxEnemyExile.Items.Add(temp);
            }
        }

        private void btnEnemyExileToField_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxEnemyExile.SelectedItem;
            if (temp != null)
            {
                lbxEnemyExile.Items.Remove(temp);
                lbxEnemyField.Items.Add(temp);
            }
        }

        private void btnRemoveDefender_Click(object sender, EventArgs e)
        {
            Card temp = (Card) lbxDefending.SelectedItem;
            if (temp != null)
            {
                lbxDefending.Items.Remove(temp);
                temp.Field.Add(temp);
            }
        }

        private void btnRemoveAttacker_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxAttacking.SelectedItem;
            if (temp != null)
            {
                lbxAttacking.Items.Remove(temp);
                temp.Field.Add(temp);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lbxAttacking.Items.Clear();
            lbxDefending.Items.Clear();
            lbxUsLibrary.Items.Clear();
            lbxUsHand.Items.Clear();
            lbxUsField.Items.Clear();
            lbxUsGraveyard.Items.Clear();
            lbxUsExile.Items.Clear();
            lbxEnemyLibrary.Items.Clear();
            lbxEnemyField.Items.Clear();
            lbxEnemyGraveyard.Items.Clear();
            lbxEnemyExile.Items.Clear();
            btnStartGame.Enabled = true;
            tbxAction.Text = "";
            tbxPhase.Text = "";
            currentPhase = GameState.phase.SetupGame;

        }

        private void btnUsTapCard_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxUsField.SelectedItem;
            if (temp != null)
            {
                temp.Field.Remove(temp);
                
                if (temp is Land)
                {
                    Land l = temp as Land;
                    l.Tap();
                }
                else if (temp is Creature)
                {
                    Creature c = temp as Creature;
                    c.Tap();
                }
                else if (temp is ArtifactEnchant)
                {
                    ArtifactEnchant ae = temp as ArtifactEnchant;
                    ae.Tap();
                }
                temp.Tapped = true;
                temp.Field.Add(temp);
            }
        }

        private void btnEnemyTapCard_Click(object sender, EventArgs e)
        {
            Card C = (Card)lbxEnemyField.SelectedItem;
            if (C != null)
            {
                C.Field.Remove(C);
                C.Tapped = true;
                C.Field.Add(C);
            }
        }

        private void btnUsGraveToField_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxUsGraveyard.SelectedItem;
            if (temp != null && !(temp is Spell))
            {
                temp.Graveyard.Remove(temp);
                temp.Field.Add(temp);
            }
        }

        private void btnEnemyGraveToField_Click(object sender, EventArgs e)
        {
            Card c = (Card)lbxEnemyGraveyard.SelectedItem;
            if (c != null && !(c is Spell))
            {
                c.Graveyard.Remove(c);
                c.Field.Add(c);
            }
        }

        private void btnUsUndraw_Click(object sender, EventArgs e)
        {
            Card c = (Card)lbxUsHand.SelectedItem;
            if(c != null)
            {
                c.Hand.Remove(c);
                c.Library.Add(c);
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            switch (currentPhase)
            {
                case GameState.phase.StartGame:
                    AI.Mulligan(this.getState());
                    break;
                case GameState.phase.UsFirstMain:
                    AI.MainPhase1(this.getState());
                    break;
                case GameState.phase.UsSecondMain:
                    AI.MainPhase2(this.getState());
                    break;
                /*case GameState.phase.EnemySecondMain:
                    AI.EnemyMain2(this.getState());
                    break;*/
                case GameState.phase.UsDeclareAttackers:
                    AI.Attack(this.getState());
                    break;
                case GameState.phase.EnemyDeclareDefenders:
                    AI.Defend(this.getState());
                    break;
                default:
                    AI.sendDirections("Move to next phase");
                    break;
            }
        }

        private void btnGobToUs_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxTokens.SelectedItem;
            if (temp != null)
            {
                lbxUsField.Items.Add(Activator.CreateInstance(temp.GetType()));
            }
        }

        private void btnGobToEnemy_Click(object sender, EventArgs e)
        {
            Card temp = (Card)lbxTokens.SelectedItem;
            if (temp != null)
            {
                lbxEnemyField.Items.Add(Activator.CreateInstance(temp.GetType()));
            }
        }

        private void tbxEnemyHealth_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(tbxEnemyHealth.Text, out enemyHealth);
        }

        private void tbxUsHealth_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(tbxUsHealth.Text, out playerHealth);
        }

        private void btnFieldToHand_Click(object sender, EventArgs e)
        {
            Card c = (Card)lbxUsField.SelectedItem;
            c.Field.Remove(c);
            c.Hand.Add(c);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
