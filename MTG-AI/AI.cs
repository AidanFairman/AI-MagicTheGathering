using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTG_AI
{
    public static class AI
    {
        static TextBox tbxDirections;
        static TextBox tbxReal;
        static TextBox tbxFake = new TextBox();
        //static GameState state;
        static GameState MasterState = null;
        public static GameState ActiveState = null;
        
        public static MagicAIGUI currentGui;

        public static void setTextBox(TextBox tbx)
        {
            tbxDirections = tbx;
            tbxReal = tbx;
        }

        public static void setGUI(MagicAIGUI gui)
        {
            currentGui = gui;
        }

        public static void getNewState()
        {
            MasterState = currentGui.getState();
            
        }

        public static GameState getCurrentGameState()
        {
            return ActiveState;
        }

        public static void sendDirections(string direction)
        {
            tbxDirections.AppendText(direction);
            tbxDirections.AppendText("\n");
        }

        public static void GainLife(int lifeAmount, GameState state)
        {
            state.playerHealth += lifeAmount;
        }

        public static void Mulligan(GameState state)
        {
            int handSize = state.PlayerHand.Count;
            int landCount = 0;
            int creatureCount = 0;
            int spellCount = 0;
            foreach(Card c in state.PlayerHand)
            {
                if (c is Land)
                {
                    ++landCount;
                }
            }
            foreach(Card c in state.PlayerHand)
            {
                if (!(c is Land))
                {
                    if (c.ConvManaCost <= landCount)
                    {
                        ++spellCount;
                        if (c is Creature)
                        {
                            ++creatureCount;
                        }
                    }
                }
            }
            if (handSize > 5)
            {
                if (spellCount >= 2 && landCount >= 2 & creatureCount > 0)
                {
                    AI.sendDirections("Keep Hand");
                }
                else
                {
                    AI.sendDirections(string.Format("Mulligan to {0}", handSize - 1));
                }
            }else if (handSize > 3)
            {
                if (creatureCount > 0)
                {
                    AI.sendDirections("Keep Hand");
                }else
                {
                    if (handSize > 4)
                    {
                        AI.sendDirections(string.Format("Mulligan to {0}", handSize - 1));
                    }
                    else
                    {
                        AI.sendDirections("Concede Game. Bad hands");
                    }
                }
            }
        }

        public static Card Target(TargetEffects.Damage damage, GameState state)
        {
            
            GameState bestState = null;
            LinkedList<Creature> potTargs = new LinkedList<Creature>();
            LinkedList<Creature> potTargsAtk = new LinkedList<Creature>();
            LinkedList<Creature> potTargsDef = new LinkedList<Creature>();
            if (damage.target == TargetEffects.Damage.dmgTarget.Player || damage.target == TargetEffects.Damage.dmgTarget.Both)
            {
                GameState newState = new GameState(state, null);
                newState.enemyHealth -= damage.DamageAmount;
                state.StateBranches.AddLast(newState);
                newState.enemyHealth += damage.DamageAmount;
            }

            if(damage.target == TargetEffects.Damage.dmgTarget.Creature || damage.target == TargetEffects.Damage.dmgTarget.Both)
            {
                
                foreach(Card c in state.EnemyField)
                {
                    if (c is Creature)
                    {
                        Creature creat = c as Creature;
                        potTargs.AddLast(creat);
                        
                        
                    }
                }

                if (state.active == GameState.activePlayer.Us)
                {
                    foreach (Card c in state.Defending)
                    {
                        if (c is Creature)
                        {
                            Creature creat = (Creature)c;
                            potTargsDef.AddLast(creat);
                        }
                    }
                }
                else
                {
                    foreach (Card c in state.Attacking)
                    {
                        if (c is Creature)
                        {
                            Creature creat = (Creature)c;
                            potTargsAtk.AddLast(creat);
                        }
                    }
                }
            }
            foreach (Creature creat in potTargs)
            {
                creat.Health -= damage.DamageAmount;//decrease target health
                if (creat.Health <= 0)
                {
                    creat.Graveyard.Add(creat);
                    creat.Field.Remove(creat);
                }
                GameState newState = new GameState(state, creat);//copy the state with the decreased health
                if (creat.Health <= 0)
                {
                    creat.Graveyard.Remove(creat);
                    creat.Field.Add(creat);
                }
                creat.Health += damage.DamageAmount;//return the target's health... we don't wanna mess the original
                state.StateBranches.AddLast(newState);
            }
            foreach(Creature creat in potTargsDef)
            {
                creat.Health -= damage.DamageAmount;//decrease target health
                if (creat.Health <= 0)
                {
                    creat.Graveyard.Add(creat);
                    state.Defending.Remove(creat);
                }
                GameState newState = new GameState(state, creat);//copy the state with the decreased health
                if (creat.Health <= 0)
                {
                    creat.Graveyard.Remove(creat);
                    state.Defending.Add(creat);
                }
                creat.Health += damage.DamageAmount;//return the target's health... we don't wanna mess the original
                state.StateBranches.AddLast(newState);
            }
            foreach(Creature creat in potTargsAtk)
            {
                creat.Health -= damage.DamageAmount;//decrease target health
                if (creat.Health <= 0)
                {
                    creat.Graveyard.Add(creat);
                    state.Attacking.Remove(creat);
                }
                GameState newState = new GameState(state, creat);//copy the state with the decreased health
                if (creat.Health <= 0)
                {
                    creat.Graveyard.Remove(creat);
                    state.Attacking.Add(creat);
                }
                creat.Health += damage.DamageAmount;//return the target's health... we don't wanna mess the original
                state.StateBranches.AddLast(newState);
            }
            bestState = bestStateFinder(state);
            return bestState.target;
        }

        public static Card Target(TargetEffects.Exile exile, GameState state)
        {
            GameState bestState = null;
            LinkedList<Card> makeNewStates = new LinkedList<Card>();
            foreach(Card c in state.EnemyField)
            {
                if (!(c is Land))
                {
                    makeNewStates.AddLast(c);
                }
            }
            foreach(Card c in makeNewStates)
            {
                c.Field.Remove(c);
                c.Exile.Add(c);
                GameState newState = new GameState(state, c);
                c.Exile.Remove(c);
                c.Field.Add(c);
                state.StateBranches.AddLast(newState);
            }
            bestState = bestStateFinder(state);

            return bestState.target;
        }

        public static Card Target(TargetEffects.Tap tap, GameState state)
        {
            GameState bestState = null;
            LinkedList<Card> makeNewStates = new LinkedList<Card>();
            foreach (Card c in state.EnemyField)
            {
                if (c is Creature && !c.Tapped)
                {
                    makeNewStates.AddLast(c);
                }
            }
            foreach (Card c in makeNewStates)
            {
                c.Tapped = true;
                GameState newState = new GameState(state, c);
                c.Tapped = false;
                state.StateBranches.AddLast(newState);
            }
            bestState = bestStateFinder(state);

            return bestState.target;
        }
        
        public static Card Target(TargetEffects.Protection protect, GameState state)
        {
            int hPower = 0;
            Card hC = null;
            foreach(Card c in state.PlayerField)
            {
                if (c is Creature)
                { 
                    Creature crc = c as Creature;
                
                    if (crc.Power > hPower)
                    {
                        hC = crc;
                        hPower = crc.Power;
                    }
                }
            }

            return hC;
        }

       /* public static Card Target(ArtifactEnchant card, GameState state)
        {
            return null;
        }*/

        public static Card Target(TargetEffects.ReturnToHand RtoH, GameState state)
        {
            LinkedList<Land> landList = new LinkedList<Land>();
            int plainsCount = 0;
            int forestCount = 0;
            Land target = null;
            foreach(Card c in state.PlayerField)
            {
                if (c is Land)
                {
                    landList.AddLast((Land)c);
                }
            }

            foreach (Land L in landList)
            {
                if (L is KnightCards.Plains)
                {
                    ++plainsCount;
                }
                else
                {
                    ++forestCount;
                }
            }

            if (plainsCount >= forestCount * 2)
            {
                foreach (Land l in landList)
                {
                    if (l is KnightCards.Plains && l.Tapped)
                    {
                        target = l;
                    }

                }
                LinkedListNode<Land> node = landList.First;
                target = node.Value;
                while (!(target is KnightCards.Plains))
                {
                    node = node.Next;
                    target = node.Value;
                }

            }
            else
            {
                foreach (Land l in landList)
                {
                    if (l is KnightCards.Forest && l.Tapped)
                    {
                        target = l;
                    }

                }
                LinkedListNode<Land> node = landList.First;
                target = node.Value;
                while (!(target is KnightCards.Forest))
                {
                    node = node.Next;
                    target = node.Value;
                }
            }

            
            return target;
        }

        public static Card Target(TargetEffects.GainControl GControl, GameState state)
        {
            LinkedList<Creature> control = new LinkedList<Creature>();
            foreach(Card c in state.EnemyField)
            {
                if (c is Creature)
                {
                    Creature creat = (Creature)c;
                    if (creat.Power <= state.PlayerGraveyard.Count) {
                        control.AddLast(creat);
                    }
                }
            }
            foreach(Creature c in control)
            {
                state.EnemyField.Remove(c);
                state.PlayerField.Add(c);
                GameState newState = new GameState(state, c);
                state.PlayerField.Remove(c);
                state.EnemyField.Add(c);
                state.StateBranches.AddLast(newState);
            }
            GameState bestState = bestStateFinder(state);
            
            return bestState.target;
        }

        public static Card[] Target(TargetEffects.Devour dev, GameState state)
        {
            LinkedList<Card> devourList = new LinkedList<Card>();
            foreach(Card c in state.PlayerField)
            {
                if (c is DragonCards.Goblin || c is DragonCards.SkirkProspector || c is DragonCards.BloodmarkMentor || c is DragonCards.MudbuttonTorchrunner || c is DragonCards.FireBellyChangeling)
                {
                    devourList.AddLast(c);
                }
            }

            return devourList.ToArray<Card>();
        }

        public static Card Target(TargetEffects.BuffTarget buff, GameState state) //Didn't work for some reason
        {
            foreach(Card c in state.PlayerField)
            {
                if (c is Creature)
                {
                    Creature crc = c as Creature;
                    doBuffs(buff, crc);
                    GameState newState = new GameState(state, c);
                    unDoBuffs(buff, crc);
                    state.addState(newState);
                }
            }
            
            GameState bestState = bestStateFinder(state);
            if(bestState == state)
            {
                return null;
            }
            else
            {
                return bestState.target;
            }
            
        }

        private static Creature doBuffs(TargetEffects.BuffTarget buff, Creature c)
        {
            c.abilities = buff.getBuffedAbilities(c.abilities);
            c.buff = buff;

            return c;
        }

        private static Creature unDoBuffs(TargetEffects.BuffTarget buff, Creature c)
        {
            c.abilities = c.buff.getOriginalAbilities();
            c.buff = null;
            return c;
        }

        public static Card Target(TargetEffects.Discard disc, GameState state)
        {
            
            Card ret = null;
            foreach(Card c in state.PlayerHand)
            {
                if (c is ArtifactEnchant)
                {
                    if (ret == null)
                    {
                        ret = c;
                    }
                    else
                    {
                        if (c.ConvManaCost > ret.ConvManaCost)
                        {
                            ret = c;
                        }
                    }
                }
            }
            if (ret == null)
            {
                int cmc = 0;
                foreach(Card c in state.PlayerHand)
                {
                    if (c.ConvManaCost > cmc && !(c is Land))
                    {
                        ret = c;
                        cmc = c.ConvManaCost;
                    }
                }
            }
            return ret;
        }
        
        public static void MainPhase1(GameState state)
        {
            getNewState();

            string toDo = null;
            tbxDirections = tbxFake;
            if (!MasterState.manaForTurn)
            {
                toDo = playLand(MasterState, false);
                ActiveState = MasterState;
            }
            if (toDo == null)
            {
                toDo = checkCastables(MasterState, false);
                ActiveState = MasterState;
            }
            getNewState();
            ActiveState = MasterState;
            tbxDirections = tbxReal;
            sendDirections(toDo);
            
        }

        public static void Attack(GameState state)
        {
            getNewState();
            state = MasterState;
            ActiveState = MasterState;
            int usCreatureCount = 0;
            int enemyCreatureCount = 0;
            int enemyTotalPower = 0;
            int totalTough = 0;

            foreach(Card c in state.EnemyField)
            {
                if (c is Creature && !c.Tapped)
                {
                    enemyCreatureCount++;
                    if ((c as Creature).abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.DoubleStrike))
                    {
                        enemyTotalPower += (c as Creature).Power;
                    }
                    enemyTotalPower += (c as Creature).Power;
                }
            }

            foreach(Card c in state.PlayerField)
            {
                if (c is Creature && !c.Tapped && !(c as Creature).SummonSick)
                {
                    usCreatureCount++;

                    if ((c as Creature).abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.DoubleStrike))
                    {
                        totalTough -= (c as Creature).Toughness;
                    }
                    totalTough += (c as Creature).Toughness;
                }
            }

            if ((usCreatureCount) == 0)
            {
                AI.sendDirections("Nothing to attack with");
            }
            else if (enemyCreatureCount == 0)
            {
                int atk = 0;
                foreach(Card c in state.PlayerField)
                {
                    if (c is Creature && !c.Tapped)
                    {
                        Creature cr = c as Creature;
                        if (!cr.abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.Defender) && !cr.Tapped && !cr.SummonSick)
                        {
                            atk++;
                            AI.sendDirections(String.Format("Attack with {0}", cr.CName));
                        }
                    }
                }
                if (atk == 0)
                {
                    AI.sendDirections("No legal attackers");
                }
                
            }
            else if ((enemyTotalPower / enemyCreatureCount) > (totalTough / usCreatureCount))
            {
                AI.sendDirections("Don't Attack");
            }
            else
            {
                Creature eBiggest = null;
                foreach(Card c in state.EnemyField)
                {
                    if (c is Creature)
                    {
                        Creature cr = c as Creature;
                        if (eBiggest == null)
                        {
                            eBiggest = cr;
                        }else
                        {
                            if (cr.Power > eBiggest.Power)
                            {
                                eBiggest = cr;
                            }
                        }
                    }
                }
                Creature blocker = findBlockerDuringAttack(eBiggest, state);
                int atk = 0;
                foreach(Card c in state.PlayerField)
                {
                    if (c is Creature && c != blocker && !(c.Tapped) && !(c as Creature).abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.Defender))
                    {
                        if (!(c as Creature).SummonSick)
                        {
                            atk++;
                            AI.sendDirections(String.Format("Attack with {0}", c));
                        }
                    }
                }
                if(atk == 0)
                {
                    AI.sendDirections("Don't attack, stay on defense");
                }
            }
        }

        public static void Defend(GameState state)
        {
            getNewState();
            ActiveState = MasterState;
            state = MasterState;
            LinkedList<Creature> e_blocked = new LinkedList<Creature>();
            LinkedList<Creature> usblocking = new LinkedList<Creature>();
            state.generateMeta();

            foreach(Creature c in state.Attacking)
            {
               if (c.abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.Flying))
                {
                    e_blocked.AddLast(c);
                    usblocking.AddLast(blockDefendFlying(c, usblocking, state));
                }
                
            }
            foreach (Creature c in state.Attacking)
            {
                if (!c.abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.Flying) && !e_blocked.Contains(c))
                {
                    e_blocked.AddLast(c);
                    usblocking.AddLast(blockDefendNonFly(c, usblocking, state));
                }

            }
            LinkedListNode<Creature> enemy = e_blocked.First;
            LinkedListNode<Creature> Us = usblocking.First;
            for (int i = 0; i < e_blocked.Count; ++i)
            {
                if (Us.Value == null)
                {
                    AI.sendDirections(String.Format("{0} goes unblocked", enemy.Value.CName));
                }
                else
                {
                    AI.sendDirections(String.Format("{0} blocks {1}", Us.Value.CName, enemy.Value.CName));
                    
                }
                enemy = enemy.Next;
                Us = Us.Next;
            }

        }

        public static void MainPhase2(GameState state)
        {
            getNewState();
            string toDo = null;
            tbxDirections = tbxFake;
            if (!MasterState.manaForTurn)
            {
                toDo = playLand(MasterState, true);
                ActiveState = MasterState;
            }
            if (toDo == null)
            {
                toDo = checkCastables(MasterState, true);
                ActiveState = MasterState;
            }
            getNewState();
            ActiveState = MasterState;
            tbxDirections = tbxReal;
            sendDirections(toDo);
        }

        public static void EnemyMain2(GameState state)
        {

        }

        private static Creature findBlockerDuringAttack(Creature c, GameState state)
        {
            bool flying = c.abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.Flying);
            Creature ret = null;
            if (flying)
            {
                foreach (Card ca in state.PlayerField)
                {
                    if (ca is Creature && !ca.Tapped)
                    {
                        Creature cr = ca as Creature;
                        if ((cr.abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.Flying) || cr.abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.Reach) )&& ret == null)
                        {
                            ret = cr;
                        }else if((cr.abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.Flying) || cr.abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.Reach)) && cr.Power < ret.Power)
                        {
                            ret = cr;
                        }
                    } 
                }
            }
            else
            {
                foreach(Card ca in state.PlayerField)
                {
                    if (ca is Creature)
                    {
                        Creature cr = ca as Creature;
                        if (cr.abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.Defender))
                        {
                            ret = cr;
                        }
                    }
                }
                if (ret == null)
                {
                    foreach (Card ca in state.PlayerField)
                    {
                        if (ca is Creature && !ca.Tapped)
                        {
                            Creature cr = ca as Creature;
                            if (ret == null)
                            {
                                ret = cr;
                            }
                            else if (cr.Power < ret.Power)
                            {
                                ret = cr;
                            }
                        }
                    }
                }
            }
            return ret;
        }

        private static Creature blockDefendFlying(Creature c, LinkedList<Creature> blocking, GameState state)
        {
            Creature ret = null;
            foreach (Card ca in state.PlayerField)
            {
                if (ca is Creature && !ca.Tapped && !blocking.Contains(ca as Creature))
                {
                    if ((ca as Creature).abilities.Contains<Creature.CreatureAbilities>(Creature.CreatureAbilities.Flying))
                    {
                        if (ret == null)
                        {
                            ret = ca as Creature;
                        }
                        else
                        {
                            if ((ca as Creature).Power > ret.Power)
                            {
                                ret = ca as Creature;
                            }
                        }
                    }
                }
            }
            return ret;
        }

        private static Creature blockDefendNonFly(Creature c, LinkedList<Creature> blocking, GameState state)
        {
            Creature ret = null;
            foreach (Card ca in state.PlayerField)
            {
                if (ca is Creature && !ca.Tapped && !blocking.Contains(ca as Creature))
                {
                    if (ret == null)
                    {
                        ret = ca as Creature;
                    }
                    else
                    {
                        if ((ca as Creature).Power > ret.Power)
                        {
                            ret = ca as Creature;
                        }
                    }
                }
            }
            return ret;
        }

        private static string checkCastables(GameState state, bool secMain)
        {
            GameState m_state = state;
            ActiveState = m_state;



            string toDo = null;
            LinkedList<Card> castables = new LinkedList<Card>();
            foreach (Card c in m_state.PlayerHand)
            {
                if (!(c is Land) && !(c is ArtifactEnchant))
                {
                    if (castable(c, m_state))
                    {
                        castables.AddLast(c);
                    }
                }
                if (c is ArtifactEnchant)
                {
                    ArtifactEnchant ae = c as ArtifactEnchant;
                    if (ae.type == ArtifactEnchant.SpellType.Enchantment)
                    {
                        if (castable(c, m_state))
                        {
                            castables.AddLast(c);
                        }
                    }
                }
            }
            foreach (Card c in castables)
            {
                if (!secMain)
                {
                    if (!(c is Spell))
                    {
                        m_state.StateBranches.AddLast(Cast(c, m_state));
                    }
                }
                else
                {
                    m_state.StateBranches.AddLast(Cast(c, m_state));
                }
                
            }
            if (m_state.StateBranches.Count > 0)
            {
                GameState best = bestStateFinder(m_state);
                if (best == m_state)
                {
                    toDo = "Advance Phase";
                }
                else
                {
                    
                    ManaPayment(best.target, m_state);
                    toDo = String.Format("Play {0}", best.target.CName);
                }
            }
            else
            {
                toDo = "Advance Phase";
            }

            return toDo;
        }

        public static bool castable(Card c, GameState state)
        { 
            int[] manaPool = manaAvailable(state);
            int totalMana = 0;
            bool EnoughMana = true;
            foreach (int i in manaPool)
            {
                totalMana += i;
            }
            if (c.ConvManaCost <= totalMana)
            {
                    
                    if(c is DragonCards.DragonWhelp || c is DragonCards.MordantDragon || c is DragonCards.BogardanHellkite || c is DragonCards.ThunderDragon || c is DragonCards.ShivanHellkite || c is DragonCards.FireBellyChangeling || c is DragonCards.KilnmouthDragon || c is DragonCards.VoraciousDragon)
                    {
                        Card DS = null;
                        foreach(Card ca in state.PlayerField){
                            if (ca is DragonCards.DragonspeakerShaman)
                            {
                                DS = ca;
                            }
                        }
                        if (DS != null)
                        {
                            c.ManaByColor[(int)Creature.manaColor.Colorless] -= 2;
                            if (c.ManaByColor[(int)Creature.manaColor.Colorless] < 0)
                            {
                                c.ManaByColor[(int)Creature.manaColor.Colorless] = 0;
                            }
                        }
                    }
                    for (int i = 1; i < (int)Card.manaColor.Red; ++i)
                    {
                        
                        if (manaPool[i] < c.ManaByColor[i])
                        {
                            EnoughMana = false;
                        }
                    }
                return EnoughMana;
            }
            else
            {
                return false;
            }
           
        }

        private static int[] manaAvailable(GameState state)
        {
            int[] manaPool = { 0, 0, 0, 0, 0, 0 };
            foreach(Card c in state.PlayerField)
            {
                if (!c.Tapped)
                {
                    if (c is KnightCards.Forest || c is KnightCards.Treetop_Village)
                    {
                        manaPool[(int)Creature.manaColor.Green]++;
                    }
                    else if (c is KnightCards.Plains || c is KnightCards.Sejiri_Steppe)
                    {
                        manaPool[(int)Creature.manaColor.White]++;
                    }
                    else if (c is DragonCards.Mountain)
                    {
                        manaPool[(int)Creature.manaColor.Red]++;
                    }
                    else if (c is KnightCards.Selesnya_Sanctuary)
                    {
                        manaPool[(int)Creature.manaColor.Green]++;
                        manaPool[(int)Creature.manaColor.White]++;
                    }
                }
            }
            return manaPool;
        }

        private static void ManaPayment(Card c, GameState state)
        {
            tbxDirections = tbxReal;
            int[] manaPool = manaAvailable(state);
            int forests = 0;
            int plains = 0;
            int mountains = 0;
            int Selesnya = 0;
            int Treetop = 0;
            int sejiri = 0;

            foreach(Card ca in state.PlayerField)
            {
                if (!ca.Tapped)
                {
                    if (ca is KnightCards.Forest)
                    {
                        forests++;
                    }
                    else if (ca is KnightCards.Plains)
                    {
                        plains++;
                    }
                    else if (ca is DragonCards.Mountain)
                    {
                        mountains++;
                    }
                    else if (ca is KnightCards.Selesnya_Sanctuary)
                    {
                        Selesnya++;
                    }
                    else if (ca is KnightCards.Treetop_Village)
                    {
                        Treetop++;
                    }
                    else if (ca is KnightCards.Sejiri_Steppe)
                    {
                        sejiri++;
                    }
                }
            }
            if ((c.ManaByColor[(int)Card.manaColor.White] > 0 || c.ManaByColor[(int)Card.manaColor.Green] > 0) && Selesnya > 0 && c.ConvManaCost > 1)
            {
                AI.sendDirections("Tap Selesnya Sanctuary for W and G");
                int provide = 2;
                if (c.ManaByColor[(int)Card.manaColor.Green] > 0 && provide > 0)
                {
                    --provide;
                    --c.ManaByColor[(int)Card.manaColor.Green];
                }
                if (c.ManaByColor[(int)Card.manaColor.White] > 0 && provide > 0)
                {
                    --provide;
                    --c.ManaByColor[(int)Card.manaColor.White];
                }
                if (provide > 0)
                {
                    --provide;
                    --c.ManaByColor[(int)Card.manaColor.Colorless];
                }
            }
            while(c.ManaByColor[(int)Card.manaColor.Green] > 0)
            {
                if (Treetop > 0)
                {
                    AI.sendDirections("Tap treetop village for G");
                    Treetop--;
                    c.ManaByColor[(int)Card.manaColor.Green]--;
                }else if (forests > 0)
                {
                    AI.sendDirections("Tap Forest for F");
                    forests--;
                    c.ManaByColor[(int)Card.manaColor.Green]--;
                }
            }
            while(c.ManaByColor[(int)Card.manaColor.White] > 0)
            {
                if (sejiri > 0)
                {
                    AI.sendDirections("Tap Sejiri Steppe for W");
                    sejiri--;
                    c.ManaByColor[(int)Card.manaColor.White]--;
                }else if(plains > 0)
                {
                    AI.sendDirections("Tap Plains for W");
                    plains--;
                    c.ManaByColor[(int)Card.manaColor.White]--;
                }
            }
            while(c.ManaByColor[(int)Card.manaColor.Red] > 0)
            {
                AI.sendDirections("Tap Mountain for Red");
                mountains--;
                c.ManaByColor[(int)Card.manaColor.Red]--;
            }
            while (c.ManaByColor[(int)Card.manaColor.Colorless] > 0)
            {
                if (c.GetType().FullName.Contains("Knight"))
                {
                    if ((plains + sejiri) > ((forests + Treetop) * 2))
                    {
                        if (sejiri > 0)
                        {
                            AI.sendDirections("Tap Sejiri Steppe for W");
                            sejiri--;
                            c.ManaByColor[(int)Card.manaColor.Colorless]--;
                        }
                        else
                        {
                            AI.sendDirections("Tap Plains for W");
                            plains--;
                            c.ManaByColor[(int)Card.manaColor.Colorless]--;
                        }
                    }
                    else
                    {
                        if (Treetop > 0)
                        {
                            AI.sendDirections("Tap Treetop Village for G");
                            Treetop--;
                            c.ManaByColor[(int)Card.manaColor.Colorless]--;
                        }
                        else
                        {
                            AI.sendDirections("Tap Forest for G");
                            forests--;
                            c.ManaByColor[(int)Card.manaColor.Colorless]--;
                        }
                    }
                }
                else if (c.GetType().FullName.Contains("Dragon"))
                {
                    AI.sendDirections("Tap Mountain for Red");
                    mountains--;
                    c.ManaByColor[(int)Card.manaColor.Colorless]--;
                }
            }
            tbxDirections = tbxFake;
        }

        private static GameState Cast(Card C, GameState state)
        {
            GameState newState = new GameState(state, C);
            ActiveState = newState;
            Card targ = null;
            Creature cr = null;
            Spell sp = null;
            ArtifactEnchant ae = null;
            foreach (Card ca in newState.PlayerHand)
            {
                if (ca.GetType() == C.GetType())
                {
                    targ = ca;
                }
            }
            if (targ != null)
            {
                targ.Hand.Remove(targ);
                targ.Field.Add(targ);
                if (targ is Creature)
                {
                    cr = targ as Creature;
                    cr.Cast();
                    
                    cr.EnterBattlefield();
                    foreach (Card ca in ActiveState.PlayerField)
                    {
                        if (ca is Creature)
                        {
                            Creature cre = ca as Creature;
                            cre.OtherEnterBattlefield(cr);
                        }
                    }

                }
                else if (targ is Spell)
                {
                    sp = targ as Spell;
                    sp.Field.Remove(sp);
                    sp.Graveyard.Add(sp);
                    sp.Cast();
                    
                }
                else if (targ is ArtifactEnchant)
                {
                    ae = targ as ArtifactEnchant;
                    ae.Cast();
                    ae.EnterBattlefield();
                }

            }
            
            return newState;
            
        }

        private static GameState Kill(Card C, GameState state)
        {
            return null;
        }

        private static float GetScore(GameState newState, GameState state)
        {
            float score = 0;
            score += (float)(newState.meta.playerLife - state.meta.playerLife) * stateMeta.pLifeScore;
            score += (float)(newState.meta.enemyLife - state.meta.enemyLife) * stateMeta.eLifeScore;
            score += (float)(newState.meta.totalPow - state.meta.totalPow) * stateMeta.powerScore;
            score += (float)(newState.meta.totalTough - state.meta.totalTough) * stateMeta.toughScore;
            score += (float)(newState.meta.totalMana - state.meta.totalMana) * stateMeta.manaScore;
            score += (float)(newState.meta.usCreatureCount - state.meta.usCreatureCount) * stateMeta.uCreatScore;
            score += (float)(newState.meta.enemyCreatureCount - state.meta.enemyCreatureCount) * stateMeta.eCreatScore;
            score += (float)(newState.meta.enemyTotalPow - state.meta.enemyTotalPow) * stateMeta.ePowerScore;
            score += (float)(newState.meta.enemyTotalTough - state.meta.enemyTotalTough) * stateMeta.eToughScore;
            return score;
        }

        private static GameState bestStateFinder(GameState state)
        {
            GameState bestState = state;
            state.generateMeta();
            foreach (GameState s in state.StateBranches)
            {
                s.generateMeta();
                s.score = GetScore(s, state);
                if (s.score > bestState.score)
                {
                    bestState = s;
                }
            }

            return bestState;
        }

        private static string playLand(GameState state, bool secondMain)
        {
            int plains = 0;
            int forests = 0;
            bool forestPriority = false;
            bool grasslandsInPlay = false;
            if (secondMain)
            {
                foreach (Card c in state.PlayerHand)
                {
                    if (c is KnightCards.Selesnya_Sanctuary)
                    {
                        return String.Format("Play {0}", c.CName);
                    }
                    if (c is KnightCards.Grasslands)
                    {
                        return String.Format("Play {0}", c.CName);
                    }
                }
            }

            foreach (Card c in state.PlayerField)
            {
                if (c is KnightCards.Forest || c is KnightCards.Treetop_Village)
                {
                    forests++;
                }
                else if (c is KnightCards.Plains || c is KnightCards.Sejiri_Steppe)
                {
                    plains++;
                }
                else if (c is KnightCards.Grasslands)
                {
                    grasslandsInPlay = true;
                }
            }
            forestPriority = (plains > (forests * 2));

            if (grasslandsInPlay)
            {
                if (forestPriority)
                {
                    foreach (Card c in state.PlayerLibrary)
                    {
                        if (c is KnightCards.Forest || c is KnightCards.Treetop_Village)
                        {
                            return String.Format("Sacrifice Grasslands and Play {0} (use Tap button)", c.CName);
                        }
                    }
                    foreach (Card c in state.PlayerLibrary)
                    {
                        if (c is KnightCards.Plains || c is KnightCards.Sejiri_Steppe)
                        {
                            return string.Format("Sacrifice Grasslands and Play {0} (use Tap button)", c.CName);
                        }
                    }
                }
                if (!forestPriority)
                {
                    foreach (Card c in state.PlayerLibrary)
                    {
                        if (c is KnightCards.Plains || c is KnightCards.Sejiri_Steppe)
                        {
                            return string.Format("Sacrifice Grasslands and Play {0} (use Tap button)", c.CName);
                        }
                    }
                    foreach (Card c in state.PlayerLibrary)
                    {
                        if (c is KnightCards.Forest || c is KnightCards.Treetop_Village)
                        {
                            return String.Format("Sacrifice Grasslands and Play {0} (use Tap button)", c.CName);
                        }
                    }
                }
            }

            if (forestPriority)
            {
                foreach(Card c in state.PlayerHand)
                {
                    if (c is KnightCards.Forest || c is KnightCards.Treetop_Village)
                    {
                        return String.Format("Play {0}", c.CName);
                    }
                }
                foreach(Card c in state.PlayerHand)
                {
                    if (c is KnightCards.Plains || c is KnightCards.Sejiri_Steppe)
                    {
                        return string.Format("Play {0}", c.CName);
                    }
                }
            }
            if (!forestPriority)
            {
                foreach (Card c in state.PlayerHand)
                {
                    if (c is KnightCards.Plains || c is KnightCards.Sejiri_Steppe)
                    {
                        return string.Format("Play {0}", c.CName);
                    }
                }
                foreach (Card c in state.PlayerHand)
                {
                    if (c is KnightCards.Forest || c is KnightCards.Treetop_Village)
                    {
                        return String.Format("Play {0}", c.CName);
                    }
                }
            }
            foreach (Card c in state.PlayerHand)
            {
                if (c is DragonCards.Mountain)
                {
                    return string.Format("Play {0}", c.CName);
                }
            }



            return null;
        }
        

        /*private static GameState getNextGameState(GameState state)
        {
            return new GameState(state);
        }*/

    }
}