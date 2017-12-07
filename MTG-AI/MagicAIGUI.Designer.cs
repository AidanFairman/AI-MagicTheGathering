namespace MTG_AI
{
    partial class MagicAIGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnAdvPhase = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.lbxEnemyLibrary = new System.Windows.Forms.ListBox();
            this.lbxEnemyField = new System.Windows.Forms.ListBox();
            this.lbxUsLibrary = new System.Windows.Forms.ListBox();
            this.lbxUsHand = new System.Windows.Forms.ListBox();
            this.lbxUsField = new System.Windows.Forms.ListBox();
            this.lbxUsGraveyard = new System.Windows.Forms.ListBox();
            this.lbxUsExile = new System.Windows.Forms.ListBox();
            this.lbxEnemyGraveyard = new System.Windows.Forms.ListBox();
            this.lbxEnemyExile = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxAction = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxPhase = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbxAttacking = new System.Windows.Forms.ListBox();
            this.lbxDefending = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pbxUs = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pbxThem = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.rbtUs = new System.Windows.Forms.RadioButton();
            this.rbtThem = new System.Windows.Forms.RadioButton();
            this.bgxStartPlayer = new System.Windows.Forms.GroupBox();
            this.bgxDeck = new System.Windows.Forms.GroupBox();
            this.rbtKnights = new System.Windows.Forms.RadioButton();
            this.rbtDragons = new System.Windows.Forms.RadioButton();
            this.tbxEnemyHealth = new System.Windows.Forms.TextBox();
            this.tbxUsHealth = new System.Windows.Forms.TextBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnUsToHand = new System.Windows.Forms.Button();
            this.btnUsCast = new System.Windows.Forms.Button();
            this.btnUsAttackDefend = new System.Windows.Forms.Button();
            this.btnUsKill = new System.Windows.Forms.Button();
            this.btnUsExileToField = new System.Windows.Forms.Button();
            this.btnEnemyExileToField = new System.Windows.Forms.Button();
            this.btnEnemyKill = new System.Windows.Forms.Button();
            this.btnEnemyAttackDefend = new System.Windows.Forms.Button();
            this.btnEnemyCast = new System.Windows.Forms.Button();
            this.btnUsFieldToExile = new System.Windows.Forms.Button();
            this.btnEnemyFieldToExile = new System.Windows.Forms.Button();
            this.btnRemoveDefender = new System.Windows.Forms.Button();
            this.btnRemoveAttacker = new System.Windows.Forms.Button();
            this.lbxTokens = new System.Windows.Forms.ListBox();
            this.btnGobToUs = new System.Windows.Forms.Button();
            this.btnGobToEnemy = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUsTapCard = new System.Windows.Forms.Button();
            this.btnEnemyTapCard = new System.Windows.Forms.Button();
            this.btnEnemyGraveToField = new System.Windows.Forms.Button();
            this.btnUsGraveToField = new System.Windows.Forms.Button();
            this.btnUsUndraw = new System.Windows.Forms.Button();
            this.btnEnemyUncast = new System.Windows.Forms.Button();
            this.btnFieldToHand = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxThem)).BeginInit();
            this.bgxStartPlayer.SuspendLayout();
            this.bgxDeck.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(1177, 646);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnAdvPhase
            // 
            this.btnAdvPhase.Location = new System.Drawing.Point(411, 49);
            this.btnAdvPhase.Name = "btnAdvPhase";
            this.btnAdvPhase.Size = new System.Drawing.Size(185, 23);
            this.btnAdvPhase.TabIndex = 1;
            this.btnAdvPhase.Text = "Advance Phase";
            this.btnAdvPhase.UseVisualStyleBackColor = true;
            this.btnAdvPhase.Click += new System.EventHandler(this.btnAdvPhase_Click);
            // 
            // btnMore
            // 
            this.btnMore.Location = new System.Drawing.Point(602, 49);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(166, 23);
            this.btnMore.TabIndex = 2;
            this.btnMore.Text = "More?";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // lbxEnemyLibrary
            // 
            this.lbxEnemyLibrary.FormattingEnabled = true;
            this.lbxEnemyLibrary.Location = new System.Drawing.Point(12, 108);
            this.lbxEnemyLibrary.Name = "lbxEnemyLibrary";
            this.lbxEnemyLibrary.Size = new System.Drawing.Size(120, 225);
            this.lbxEnemyLibrary.Sorted = true;
            this.lbxEnemyLibrary.TabIndex = 7;
            // 
            // lbxEnemyField
            // 
            this.lbxEnemyField.FormattingEnabled = true;
            this.lbxEnemyField.Location = new System.Drawing.Point(138, 108);
            this.lbxEnemyField.Name = "lbxEnemyField";
            this.lbxEnemyField.Size = new System.Drawing.Size(120, 225);
            this.lbxEnemyField.Sorted = true;
            this.lbxEnemyField.TabIndex = 8;
            this.lbxEnemyField.SelectedIndexChanged += new System.EventHandler(this.lbxEnemyField_SelectedIndexChanged);
            // 
            // lbxUsLibrary
            // 
            this.lbxUsLibrary.FormattingEnabled = true;
            this.lbxUsLibrary.Location = new System.Drawing.Point(1132, 108);
            this.lbxUsLibrary.Name = "lbxUsLibrary";
            this.lbxUsLibrary.Size = new System.Drawing.Size(120, 225);
            this.lbxUsLibrary.Sorted = true;
            this.lbxUsLibrary.TabIndex = 9;
            // 
            // lbxUsHand
            // 
            this.lbxUsHand.FormattingEnabled = true;
            this.lbxUsHand.Location = new System.Drawing.Point(1006, 108);
            this.lbxUsHand.Name = "lbxUsHand";
            this.lbxUsHand.Size = new System.Drawing.Size(120, 225);
            this.lbxUsHand.Sorted = true;
            this.lbxUsHand.TabIndex = 10;
            // 
            // lbxUsField
            // 
            this.lbxUsField.FormattingEnabled = true;
            this.lbxUsField.Location = new System.Drawing.Point(880, 108);
            this.lbxUsField.Name = "lbxUsField";
            this.lbxUsField.Size = new System.Drawing.Size(120, 225);
            this.lbxUsField.Sorted = true;
            this.lbxUsField.TabIndex = 11;
            // 
            // lbxUsGraveyard
            // 
            this.lbxUsGraveyard.FormattingEnabled = true;
            this.lbxUsGraveyard.Location = new System.Drawing.Point(754, 108);
            this.lbxUsGraveyard.Name = "lbxUsGraveyard";
            this.lbxUsGraveyard.Size = new System.Drawing.Size(120, 121);
            this.lbxUsGraveyard.Sorted = true;
            this.lbxUsGraveyard.TabIndex = 12;
            this.lbxUsGraveyard.SelectedIndexChanged += new System.EventHandler(this.lbxUsGraveyard_SelectedIndexChanged);
            // 
            // lbxUsExile
            // 
            this.lbxUsExile.FormattingEnabled = true;
            this.lbxUsExile.Location = new System.Drawing.Point(754, 251);
            this.lbxUsExile.Name = "lbxUsExile";
            this.lbxUsExile.Size = new System.Drawing.Size(120, 82);
            this.lbxUsExile.Sorted = true;
            this.lbxUsExile.TabIndex = 13;
            // 
            // lbxEnemyGraveyard
            // 
            this.lbxEnemyGraveyard.FormattingEnabled = true;
            this.lbxEnemyGraveyard.Location = new System.Drawing.Point(265, 108);
            this.lbxEnemyGraveyard.Name = "lbxEnemyGraveyard";
            this.lbxEnemyGraveyard.Size = new System.Drawing.Size(120, 134);
            this.lbxEnemyGraveyard.Sorted = true;
            this.lbxEnemyGraveyard.TabIndex = 14;
            this.lbxEnemyGraveyard.SelectedIndexChanged += new System.EventHandler(this.lbxEnemyGraveyard_SelectedIndexChanged);
            // 
            // lbxEnemyExile
            // 
            this.lbxEnemyExile.FormattingEnabled = true;
            this.lbxEnemyExile.Location = new System.Drawing.Point(265, 264);
            this.lbxEnemyExile.Name = "lbxEnemyExile";
            this.lbxEnemyExile.Size = new System.Drawing.Size(120, 69);
            this.lbxEnemyExile.Sorted = true;
            this.lbxEnemyExile.TabIndex = 15;
            this.lbxEnemyExile.SelectedIndexChanged += new System.EventHandler(this.lbxEnemyExile_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Enemy Library";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Enemy Field";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Enemy Graveyard";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Enemy Exile";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(754, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Our Exile";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(754, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Our Graveyard";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(880, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Our Field";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1006, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Our Hand";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1132, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Our Library";
            // 
            // tbxAction
            // 
            this.tbxAction.Location = new System.Drawing.Point(446, 108);
            this.tbxAction.Multiline = true;
            this.tbxAction.Name = "tbxAction";
            this.tbxAction.Size = new System.Drawing.Size(302, 225);
            this.tbxAction.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(446, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Actions";
            // 
            // tbxPhase
            // 
            this.tbxPhase.Location = new System.Drawing.Point(411, 23);
            this.tbxPhase.Name = "tbxPhase";
            this.tbxPhase.Size = new System.Drawing.Size(357, 20);
            this.tbxPhase.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(411, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Phase";
            // 
            // lbxAttacking
            // 
            this.lbxAttacking.FormattingEnabled = true;
            this.lbxAttacking.Location = new System.Drawing.Point(414, 380);
            this.lbxAttacking.Name = "lbxAttacking";
            this.lbxAttacking.Size = new System.Drawing.Size(302, 95);
            this.lbxAttacking.TabIndex = 29;
            // 
            // lbxDefending
            // 
            this.lbxDefending.FormattingEnabled = true;
            this.lbxDefending.Location = new System.Drawing.Point(414, 498);
            this.lbxDefending.Name = "lbxDefending";
            this.lbxDefending.Size = new System.Drawing.Size(302, 95);
            this.lbxDefending.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(414, 364);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Attackers";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(414, 482);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Defenders";
            // 
            // pbxUs
            // 
            this.pbxUs.Location = new System.Drawing.Point(880, 24);
            this.pbxUs.Name = "pbxUs";
            this.pbxUs.Size = new System.Drawing.Size(246, 49);
            this.pbxUs.TabIndex = 33;
            this.pbxUs.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(880, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "US";
            // 
            // pbxThem
            // 
            this.pbxThem.Location = new System.Drawing.Point(54, 24);
            this.pbxThem.Name = "pbxThem";
            this.pbxThem.Size = new System.Drawing.Size(246, 49);
            this.pbxThem.TabIndex = 35;
            this.pbxThem.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(54, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "THEM";
            // 
            // rbtUs
            // 
            this.rbtUs.AutoSize = true;
            this.rbtUs.Location = new System.Drawing.Point(28, 24);
            this.rbtUs.Name = "rbtUs";
            this.rbtUs.Size = new System.Drawing.Size(76, 17);
            this.rbtUs.TabIndex = 38;
            this.rbtUs.TabStop = true;
            this.rbtUs.Text = "We go first";
            this.rbtUs.UseVisualStyleBackColor = true;
            // 
            // rbtThem
            // 
            this.rbtThem.AutoSize = true;
            this.rbtThem.Location = new System.Drawing.Point(28, 48);
            this.rbtThem.Name = "rbtThem";
            this.rbtThem.Size = new System.Drawing.Size(83, 17);
            this.rbtThem.TabIndex = 39;
            this.rbtThem.TabStop = true;
            this.rbtThem.Text = "They go first";
            this.rbtThem.UseVisualStyleBackColor = true;
            // 
            // bgxStartPlayer
            // 
            this.bgxStartPlayer.Controls.Add(this.rbtThem);
            this.bgxStartPlayer.Controls.Add(this.rbtUs);
            this.bgxStartPlayer.Location = new System.Drawing.Point(987, 496);
            this.bgxStartPlayer.Name = "bgxStartPlayer";
            this.bgxStartPlayer.Size = new System.Drawing.Size(130, 85);
            this.bgxStartPlayer.TabIndex = 40;
            this.bgxStartPlayer.TabStop = false;
            this.bgxStartPlayer.Text = "Starting Player";
            // 
            // bgxDeck
            // 
            this.bgxDeck.Controls.Add(this.rbtKnights);
            this.bgxDeck.Controls.Add(this.rbtDragons);
            this.bgxDeck.Location = new System.Drawing.Point(1123, 496);
            this.bgxDeck.Name = "bgxDeck";
            this.bgxDeck.Size = new System.Drawing.Size(130, 85);
            this.bgxDeck.TabIndex = 42;
            this.bgxDeck.TabStop = false;
            this.bgxDeck.Text = "Our Deck";
            // 
            // rbtKnights
            // 
            this.rbtKnights.AutoSize = true;
            this.rbtKnights.Location = new System.Drawing.Point(28, 44);
            this.rbtKnights.Name = "rbtKnights";
            this.rbtKnights.Size = new System.Drawing.Size(60, 17);
            this.rbtKnights.TabIndex = 1;
            this.rbtKnights.TabStop = true;
            this.rbtKnights.Text = "Knights";
            this.rbtKnights.UseVisualStyleBackColor = true;
            // 
            // rbtDragons
            // 
            this.rbtDragons.AutoSize = true;
            this.rbtDragons.Location = new System.Drawing.Point(28, 20);
            this.rbtDragons.Name = "rbtDragons";
            this.rbtDragons.Size = new System.Drawing.Size(65, 17);
            this.rbtDragons.TabIndex = 0;
            this.rbtDragons.TabStop = true;
            this.rbtDragons.Text = "Dragons";
            this.rbtDragons.UseVisualStyleBackColor = true;
            // 
            // tbxEnemyHealth
            // 
            this.tbxEnemyHealth.Location = new System.Drawing.Point(98, 2);
            this.tbxEnemyHealth.Name = "tbxEnemyHealth";
            this.tbxEnemyHealth.Size = new System.Drawing.Size(78, 20);
            this.tbxEnemyHealth.TabIndex = 43;
            this.tbxEnemyHealth.TextChanged += new System.EventHandler(this.tbxEnemyHealth_TextChanged);
            // 
            // tbxUsHealth
            // 
            this.tbxUsHealth.Location = new System.Drawing.Point(908, 2);
            this.tbxUsHealth.Name = "tbxUsHealth";
            this.tbxUsHealth.Size = new System.Drawing.Size(100, 20);
            this.tbxUsHealth.TabIndex = 44;
            this.tbxUsHealth.TextChanged += new System.EventHandler(this.tbxUsHealth_TextChanged);
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(1096, 587);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(75, 23);
            this.btnStartGame.TabIndex = 45;
            this.btnStartGame.Text = "Setup Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnUsToHand
            // 
            this.btnUsToHand.Location = new System.Drawing.Point(1132, 340);
            this.btnUsToHand.Name = "btnUsToHand";
            this.btnUsToHand.Size = new System.Drawing.Size(120, 23);
            this.btnUsToHand.TabIndex = 46;
            this.btnUsToHand.Text = "To Hand";
            this.btnUsToHand.UseVisualStyleBackColor = true;
            this.btnUsToHand.Click += new System.EventHandler(this.btnUsToHand_Click);
            // 
            // btnUsCast
            // 
            this.btnUsCast.Location = new System.Drawing.Point(1006, 340);
            this.btnUsCast.Name = "btnUsCast";
            this.btnUsCast.Size = new System.Drawing.Size(120, 23);
            this.btnUsCast.TabIndex = 47;
            this.btnUsCast.Text = "Cast";
            this.btnUsCast.UseVisualStyleBackColor = true;
            this.btnUsCast.Click += new System.EventHandler(this.btnUsCast_Click);
            // 
            // btnUsAttackDefend
            // 
            this.btnUsAttackDefend.Location = new System.Drawing.Point(880, 340);
            this.btnUsAttackDefend.Name = "btnUsAttackDefend";
            this.btnUsAttackDefend.Size = new System.Drawing.Size(120, 23);
            this.btnUsAttackDefend.TabIndex = 48;
            this.btnUsAttackDefend.Text = "Attack/Defend";
            this.btnUsAttackDefend.UseVisualStyleBackColor = true;
            this.btnUsAttackDefend.Click += new System.EventHandler(this.btnUsAttackDefend_Click);
            // 
            // btnUsKill
            // 
            this.btnUsKill.Location = new System.Drawing.Point(880, 370);
            this.btnUsKill.Name = "btnUsKill";
            this.btnUsKill.Size = new System.Drawing.Size(120, 23);
            this.btnUsKill.TabIndex = 49;
            this.btnUsKill.Text = "Kill";
            this.btnUsKill.UseVisualStyleBackColor = true;
            this.btnUsKill.Click += new System.EventHandler(this.btnUsKill_Click);
            // 
            // btnUsExileToField
            // 
            this.btnUsExileToField.Location = new System.Drawing.Point(754, 369);
            this.btnUsExileToField.Name = "btnUsExileToField";
            this.btnUsExileToField.Size = new System.Drawing.Size(120, 23);
            this.btnUsExileToField.TabIndex = 50;
            this.btnUsExileToField.Text = "Exile to Field";
            this.btnUsExileToField.UseVisualStyleBackColor = true;
            this.btnUsExileToField.Click += new System.EventHandler(this.btnUsExileToField_Click);
            // 
            // btnEnemyExileToField
            // 
            this.btnEnemyExileToField.Location = new System.Drawing.Point(265, 368);
            this.btnEnemyExileToField.Name = "btnEnemyExileToField";
            this.btnEnemyExileToField.Size = new System.Drawing.Size(120, 23);
            this.btnEnemyExileToField.TabIndex = 54;
            this.btnEnemyExileToField.Text = "Exile to Field";
            this.btnEnemyExileToField.UseVisualStyleBackColor = true;
            this.btnEnemyExileToField.Click += new System.EventHandler(this.btnEnemyExileToField_Click);
            // 
            // btnEnemyKill
            // 
            this.btnEnemyKill.Location = new System.Drawing.Point(138, 368);
            this.btnEnemyKill.Name = "btnEnemyKill";
            this.btnEnemyKill.Size = new System.Drawing.Size(120, 23);
            this.btnEnemyKill.TabIndex = 53;
            this.btnEnemyKill.Text = "Kill";
            this.btnEnemyKill.UseVisualStyleBackColor = true;
            this.btnEnemyKill.Click += new System.EventHandler(this.btnEnemyKill_Click);
            // 
            // btnEnemyAttackDefend
            // 
            this.btnEnemyAttackDefend.Location = new System.Drawing.Point(138, 339);
            this.btnEnemyAttackDefend.Name = "btnEnemyAttackDefend";
            this.btnEnemyAttackDefend.Size = new System.Drawing.Size(120, 23);
            this.btnEnemyAttackDefend.TabIndex = 52;
            this.btnEnemyAttackDefend.Text = "Attack/Defend";
            this.btnEnemyAttackDefend.UseVisualStyleBackColor = true;
            this.btnEnemyAttackDefend.Click += new System.EventHandler(this.btnEnemyAttackDefend_Click);
            // 
            // btnEnemyCast
            // 
            this.btnEnemyCast.Location = new System.Drawing.Point(12, 339);
            this.btnEnemyCast.Name = "btnEnemyCast";
            this.btnEnemyCast.Size = new System.Drawing.Size(120, 23);
            this.btnEnemyCast.TabIndex = 51;
            this.btnEnemyCast.Text = "Cast";
            this.btnEnemyCast.UseVisualStyleBackColor = true;
            this.btnEnemyCast.Click += new System.EventHandler(this.btnEnemyCast_Click);
            // 
            // btnUsFieldToExile
            // 
            this.btnUsFieldToExile.Location = new System.Drawing.Point(880, 400);
            this.btnUsFieldToExile.Name = "btnUsFieldToExile";
            this.btnUsFieldToExile.Size = new System.Drawing.Size(120, 23);
            this.btnUsFieldToExile.TabIndex = 55;
            this.btnUsFieldToExile.Text = "Field to Exile";
            this.btnUsFieldToExile.UseVisualStyleBackColor = true;
            this.btnUsFieldToExile.Click += new System.EventHandler(this.btnUsFieldToExile_Click);
            // 
            // btnEnemyFieldToExile
            // 
            this.btnEnemyFieldToExile.Location = new System.Drawing.Point(138, 397);
            this.btnEnemyFieldToExile.Name = "btnEnemyFieldToExile";
            this.btnEnemyFieldToExile.Size = new System.Drawing.Size(120, 23);
            this.btnEnemyFieldToExile.TabIndex = 56;
            this.btnEnemyFieldToExile.Text = "Field to Exile";
            this.btnEnemyFieldToExile.UseVisualStyleBackColor = true;
            this.btnEnemyFieldToExile.Click += new System.EventHandler(this.btnEnemyFieldToExile_Click);
            // 
            // btnRemoveDefender
            // 
            this.btnRemoveDefender.Location = new System.Drawing.Point(414, 600);
            this.btnRemoveDefender.Name = "btnRemoveDefender";
            this.btnRemoveDefender.Size = new System.Drawing.Size(151, 23);
            this.btnRemoveDefender.TabIndex = 57;
            this.btnRemoveDefender.Text = "Remove Defender";
            this.btnRemoveDefender.UseVisualStyleBackColor = true;
            this.btnRemoveDefender.Click += new System.EventHandler(this.btnRemoveDefender_Click);
            // 
            // btnRemoveAttacker
            // 
            this.btnRemoveAttacker.Location = new System.Drawing.Point(571, 600);
            this.btnRemoveAttacker.Name = "btnRemoveAttacker";
            this.btnRemoveAttacker.Size = new System.Drawing.Size(144, 23);
            this.btnRemoveAttacker.TabIndex = 58;
            this.btnRemoveAttacker.Text = "Remove Attacker";
            this.btnRemoveAttacker.UseVisualStyleBackColor = true;
            this.btnRemoveAttacker.Click += new System.EventHandler(this.btnRemoveAttacker_Click);
            // 
            // lbxTokens
            // 
            this.lbxTokens.FormattingEnabled = true;
            this.lbxTokens.Location = new System.Drawing.Point(776, 512);
            this.lbxTokens.Name = "lbxTokens";
            this.lbxTokens.Size = new System.Drawing.Size(166, 43);
            this.lbxTokens.TabIndex = 59;
            // 
            // btnGobToUs
            // 
            this.btnGobToUs.Location = new System.Drawing.Point(776, 561);
            this.btnGobToUs.Name = "btnGobToUs";
            this.btnGobToUs.Size = new System.Drawing.Size(84, 23);
            this.btnGobToUs.TabIndex = 60;
            this.btnGobToUs.Text = "To Our Field";
            this.btnGobToUs.UseVisualStyleBackColor = true;
            this.btnGobToUs.Click += new System.EventHandler(this.btnGobToUs_Click);
            // 
            // btnGobToEnemy
            // 
            this.btnGobToEnemy.Location = new System.Drawing.Point(866, 561);
            this.btnGobToEnemy.Name = "btnGobToEnemy";
            this.btnGobToEnemy.Size = new System.Drawing.Size(76, 23);
            this.btnGobToEnemy.TabIndex = 61;
            this.btnGobToEnemy.Text = "To Enemy";
            this.btnGobToEnemy.UseVisualStyleBackColor = true;
            this.btnGobToEnemy.Click += new System.EventHandler(this.btnGobToEnemy_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(773, 496);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 13);
            this.label16.TabIndex = 62;
            this.label16.Text = "Token Holding Station";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1078, 646);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(93, 23);
            this.btnReset.TabIndex = 63;
            this.btnReset.Text = "Reset Game";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUsTapCard
            // 
            this.btnUsTapCard.Location = new System.Drawing.Point(880, 430);
            this.btnUsTapCard.Name = "btnUsTapCard";
            this.btnUsTapCard.Size = new System.Drawing.Size(120, 23);
            this.btnUsTapCard.TabIndex = 64;
            this.btnUsTapCard.Text = "Tap";
            this.btnUsTapCard.UseVisualStyleBackColor = true;
            this.btnUsTapCard.Click += new System.EventHandler(this.btnUsTapCard_Click);
            // 
            // btnEnemyTapCard
            // 
            this.btnEnemyTapCard.Location = new System.Drawing.Point(138, 427);
            this.btnEnemyTapCard.Name = "btnEnemyTapCard";
            this.btnEnemyTapCard.Size = new System.Drawing.Size(120, 23);
            this.btnEnemyTapCard.TabIndex = 65;
            this.btnEnemyTapCard.Text = "Tap";
            this.btnEnemyTapCard.UseVisualStyleBackColor = true;
            this.btnEnemyTapCard.Click += new System.EventHandler(this.btnEnemyTapCard_Click);
            // 
            // btnEnemyGraveToField
            // 
            this.btnEnemyGraveToField.Location = new System.Drawing.Point(264, 339);
            this.btnEnemyGraveToField.Name = "btnEnemyGraveToField";
            this.btnEnemyGraveToField.Size = new System.Drawing.Size(120, 23);
            this.btnEnemyGraveToField.TabIndex = 66;
            this.btnEnemyGraveToField.Text = "Grave To Field";
            this.btnEnemyGraveToField.UseVisualStyleBackColor = true;
            this.btnEnemyGraveToField.Click += new System.EventHandler(this.btnEnemyGraveToField_Click);
            // 
            // btnUsGraveToField
            // 
            this.btnUsGraveToField.Location = new System.Drawing.Point(754, 340);
            this.btnUsGraveToField.Name = "btnUsGraveToField";
            this.btnUsGraveToField.Size = new System.Drawing.Size(120, 23);
            this.btnUsGraveToField.TabIndex = 67;
            this.btnUsGraveToField.Text = "Grave To Field";
            this.btnUsGraveToField.UseVisualStyleBackColor = true;
            this.btnUsGraveToField.Click += new System.EventHandler(this.btnUsGraveToField_Click);
            // 
            // btnUsUndraw
            // 
            this.btnUsUndraw.Location = new System.Drawing.Point(1006, 369);
            this.btnUsUndraw.Name = "btnUsUndraw";
            this.btnUsUndraw.Size = new System.Drawing.Size(120, 23);
            this.btnUsUndraw.TabIndex = 68;
            this.btnUsUndraw.Text = "Oops. To Library";
            this.btnUsUndraw.UseVisualStyleBackColor = true;
            this.btnUsUndraw.Click += new System.EventHandler(this.btnUsUndraw_Click);
            // 
            // btnEnemyUncast
            // 
            this.btnEnemyUncast.Location = new System.Drawing.Point(12, 368);
            this.btnEnemyUncast.Name = "btnEnemyUncast";
            this.btnEnemyUncast.Size = new System.Drawing.Size(120, 23);
            this.btnEnemyUncast.TabIndex = 69;
            this.btnEnemyUncast.Text = "Uncast";
            this.btnEnemyUncast.UseVisualStyleBackColor = true;
            // 
            // btnFieldToHand
            // 
            this.btnFieldToHand.Location = new System.Drawing.Point(1006, 400);
            this.btnFieldToHand.Name = "btnFieldToHand";
            this.btnFieldToHand.Size = new System.Drawing.Size(120, 23);
            this.btnFieldToHand.TabIndex = 70;
            this.btnFieldToHand.Text = "Field to Hand";
            this.btnFieldToHand.UseVisualStyleBackColor = true;
            this.btnFieldToHand.Click += new System.EventHandler(this.btnFieldToHand_Click);
            // 
            // MagicAIGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnFieldToHand);
            this.Controls.Add(this.btnEnemyUncast);
            this.Controls.Add(this.btnUsUndraw);
            this.Controls.Add(this.btnUsGraveToField);
            this.Controls.Add(this.btnEnemyGraveToField);
            this.Controls.Add(this.btnEnemyTapCard);
            this.Controls.Add(this.btnUsTapCard);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnGobToEnemy);
            this.Controls.Add(this.btnGobToUs);
            this.Controls.Add(this.lbxTokens);
            this.Controls.Add(this.btnRemoveAttacker);
            this.Controls.Add(this.btnRemoveDefender);
            this.Controls.Add(this.btnEnemyFieldToExile);
            this.Controls.Add(this.btnUsFieldToExile);
            this.Controls.Add(this.btnEnemyExileToField);
            this.Controls.Add(this.btnEnemyKill);
            this.Controls.Add(this.btnEnemyAttackDefend);
            this.Controls.Add(this.btnEnemyCast);
            this.Controls.Add(this.btnUsExileToField);
            this.Controls.Add(this.btnUsKill);
            this.Controls.Add(this.btnUsAttackDefend);
            this.Controls.Add(this.btnUsCast);
            this.Controls.Add(this.btnUsToHand);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.tbxUsHealth);
            this.Controls.Add(this.tbxEnemyHealth);
            this.Controls.Add(this.bgxDeck);
            this.Controls.Add(this.bgxStartPlayer);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pbxThem);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pbxUs);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbxDefending);
            this.Controls.Add(this.lbxAttacking);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbxPhase);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbxAction);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxEnemyExile);
            this.Controls.Add(this.lbxEnemyGraveyard);
            this.Controls.Add(this.lbxUsExile);
            this.Controls.Add(this.lbxUsGraveyard);
            this.Controls.Add(this.lbxUsField);
            this.Controls.Add(this.lbxUsHand);
            this.Controls.Add(this.lbxUsLibrary);
            this.Controls.Add(this.lbxEnemyField);
            this.Controls.Add(this.lbxEnemyLibrary);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.btnAdvPhase);
            this.Controls.Add(this.btnQuit);
            this.Name = "MagicAIGUI";
            this.Text = "Magic the Gathering AI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxUs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxThem)).EndInit();
            this.bgxStartPlayer.ResumeLayout(false);
            this.bgxStartPlayer.PerformLayout();
            this.bgxDeck.ResumeLayout(false);
            this.bgxDeck.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnAdvPhase;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.ListBox lbxEnemyLibrary;
        private System.Windows.Forms.ListBox lbxEnemyField;
        private System.Windows.Forms.ListBox lbxUsLibrary;
        private System.Windows.Forms.ListBox lbxUsHand;
        private System.Windows.Forms.ListBox lbxUsField;
        private System.Windows.Forms.ListBox lbxUsGraveyard;
        private System.Windows.Forms.ListBox lbxUsExile;
        private System.Windows.Forms.ListBox lbxEnemyGraveyard;
        private System.Windows.Forms.ListBox lbxEnemyExile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxAction;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxPhase;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lbxAttacking;
        private System.Windows.Forms.ListBox lbxDefending;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pbxUs;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pbxThem;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton rbtUs;
        private System.Windows.Forms.RadioButton rbtThem;
        private System.Windows.Forms.GroupBox bgxStartPlayer;
        private System.Windows.Forms.GroupBox bgxDeck;
        private System.Windows.Forms.RadioButton rbtKnights;
        private System.Windows.Forms.RadioButton rbtDragons;
        private System.Windows.Forms.TextBox tbxEnemyHealth;
        private System.Windows.Forms.TextBox tbxUsHealth;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnUsToHand;
        private System.Windows.Forms.Button btnUsCast;
        private System.Windows.Forms.Button btnUsAttackDefend;
        private System.Windows.Forms.Button btnUsKill;
        private System.Windows.Forms.Button btnUsExileToField;
        private System.Windows.Forms.Button btnEnemyExileToField;
        private System.Windows.Forms.Button btnEnemyKill;
        private System.Windows.Forms.Button btnEnemyAttackDefend;
        private System.Windows.Forms.Button btnEnemyCast;
        private System.Windows.Forms.Button btnUsFieldToExile;
        private System.Windows.Forms.Button btnEnemyFieldToExile;
        private System.Windows.Forms.Button btnRemoveDefender;
        private System.Windows.Forms.Button btnRemoveAttacker;
        private System.Windows.Forms.ListBox lbxTokens;
        private System.Windows.Forms.Button btnGobToUs;
        private System.Windows.Forms.Button btnGobToEnemy;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUsTapCard;
        private System.Windows.Forms.Button btnEnemyTapCard;
        private System.Windows.Forms.Button btnEnemyGraveToField;
        private System.Windows.Forms.Button btnUsGraveToField;
        private System.Windows.Forms.Button btnUsUndraw;
        private System.Windows.Forms.Button btnEnemyUncast;
        private System.Windows.Forms.Button btnFieldToHand;
    }
}

