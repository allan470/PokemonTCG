namespace PokemonTCG.WinForms
{
    partial class FrmPartie
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpJoueur = new GroupBox();
            btnPiocher = new Button();
            btnJouerCarte = new Button();
            btnPasserTour = new Button();
            btnAttaquer = new Button();
            cmbAttaques = new ComboBox();
            lblEnergies = new Label();
            lblActif = new Label();
            lstBanc = new ListBox();
            lstMain = new ListBox();
            lblDeck = new Label();
            grpAdversaire = new GroupBox();
            lblActifAdversaire = new Label();
            lblMessage = new Label();
            grpJoueur.SuspendLayout();
            grpAdversaire.SuspendLayout();
            SuspendLayout();
            // 
            // grpJoueur
            // 
            grpJoueur.Controls.Add(btnPiocher);
            grpJoueur.Controls.Add(btnJouerCarte);
            grpJoueur.Controls.Add(btnPasserTour);
            grpJoueur.Controls.Add(btnAttaquer);
            grpJoueur.Controls.Add(cmbAttaques);
            grpJoueur.Controls.Add(lblEnergies);
            grpJoueur.Controls.Add(lblActif);
            grpJoueur.Controls.Add(lstBanc);
            grpJoueur.Controls.Add(lstMain);
            grpJoueur.Controls.Add(lblDeck);
            grpJoueur.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpJoueur.ForeColor = Color.CornflowerBlue;
            grpJoueur.Location = new Point(57, 47);
            grpJoueur.Margin = new Padding(4, 5, 4, 5);
            grpJoueur.Name = "grpJoueur";
            grpJoueur.Padding = new Padding(4, 5, 4, 5);
            grpJoueur.Size = new Size(671, 573);
            grpJoueur.TabIndex = 0;
            grpJoueur.TabStop = false;
            grpJoueur.Text = "nom du joueur";
            // 
            // btnPiocher
            // 
            btnPiocher.Font = new Font("Segoe UI", 9F);
            btnPiocher.ForeColor = SystemColors.WindowText;
            btnPiocher.Location = new Point(40, 493);
            btnPiocher.Margin = new Padding(4, 5, 4, 5);
            btnPiocher.Name = "btnPiocher";
            btnPiocher.Size = new Size(169, 52);
            btnPiocher.TabIndex = 9;
            btnPiocher.Text = "Piocher";
            btnPiocher.UseVisualStyleBackColor = true;
            btnPiocher.Click += btnPiocher_Click;
            // 
            // btnJouerCarte
            // 
            btnJouerCarte.Font = new Font("Segoe UI", 9F);
            btnJouerCarte.ForeColor = SystemColors.WindowText;
            btnJouerCarte.Location = new Point(236, 493);
            btnJouerCarte.Margin = new Padding(4, 5, 4, 5);
            btnJouerCarte.Name = "btnJouerCarte";
            btnJouerCarte.Size = new Size(169, 52);
            btnJouerCarte.TabIndex = 8;
            btnJouerCarte.Text = "Jouer la carte";
            btnJouerCarte.UseVisualStyleBackColor = true;
            btnJouerCarte.Click += btnJouerCarte_Click;
            // 
            // btnPasserTour
            // 
            btnPasserTour.Font = new Font("Segoe UI", 9F);
            btnPasserTour.ForeColor = SystemColors.WindowText;
            btnPasserTour.Location = new Point(457, 493);
            btnPasserTour.Margin = new Padding(4, 5, 4, 5);
            btnPasserTour.Name = "btnPasserTour";
            btnPasserTour.Size = new Size(169, 52);
            btnPasserTour.TabIndex = 7;
            btnPasserTour.Text = "Passer son tour";
            btnPasserTour.UseVisualStyleBackColor = true;
            btnPasserTour.Click += btnPasserTour_Click;
            // 
            // btnAttaquer
            // 
            btnAttaquer.Font = new Font("Segoe UI", 9F);
            btnAttaquer.ForeColor = SystemColors.WindowText;
            btnAttaquer.Location = new Point(361, 408);
            btnAttaquer.Margin = new Padding(4, 5, 4, 5);
            btnAttaquer.Name = "btnAttaquer";
            btnAttaquer.Size = new Size(257, 60);
            btnAttaquer.TabIndex = 6;
            btnAttaquer.Text = "Attaquer";
            btnAttaquer.UseVisualStyleBackColor = true;
            btnAttaquer.Click += btnAttaquer_Click;
            // 
            // cmbAttaques
            // 
            cmbAttaques.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAttaques.Font = new Font("Segoe UI", 9F);
            cmbAttaques.FormattingEnabled = true;
            cmbAttaques.Location = new Point(40, 408);
            cmbAttaques.Margin = new Padding(4, 5, 4, 5);
            cmbAttaques.Name = "cmbAttaques";
            cmbAttaques.Size = new Size(273, 33);
            cmbAttaques.TabIndex = 5;
            // 
            // lblEnergies
            // 
            lblEnergies.AutoSize = true;
            lblEnergies.BackColor = Color.BlanchedAlmond;
            lblEnergies.BorderStyle = BorderStyle.FixedSingle;
            lblEnergies.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEnergies.ForeColor = SystemColors.WindowText;
            lblEnergies.Location = new Point(524, 343);
            lblEnergies.Margin = new Padding(4, 0, 4, 0);
            lblEnergies.Name = "lblEnergies";
            lblEnergies.Size = new Size(99, 27);
            lblEnergies.TabIndex = 4;
            lblEnergies.Text = "lblEnergies";
            // 
            // lblActif
            // 
            lblActif.AutoSize = true;
            lblActif.BackColor = Color.PapayaWhip;
            lblActif.BorderStyle = BorderStyle.FixedSingle;
            lblActif.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblActif.ForeColor = SystemColors.WindowText;
            lblActif.Location = new Point(40, 326);
            lblActif.Margin = new Padding(4, 0, 4, 0);
            lblActif.Name = "lblActif";
            lblActif.Size = new Size(69, 27);
            lblActif.TabIndex = 3;
            lblActif.Text = "lblActif";
            // 
            // lstBanc
            // 
            lstBanc.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstBanc.FormattingEnabled = true;
            lstBanc.Location = new Point(361, 117);
            lstBanc.Margin = new Padding(4, 5, 4, 5);
            lstBanc.Name = "lstBanc";
            lstBanc.Size = new Size(255, 204);
            lstBanc.TabIndex = 2;
            // 
            // lstMain
            // 
            lstMain.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstMain.FormattingEnabled = true;
            lstMain.Location = new Point(40, 117);
            lstMain.Margin = new Padding(4, 5, 4, 5);
            lstMain.Name = "lstMain";
            lstMain.Size = new Size(273, 204);
            lstMain.TabIndex = 1;
            // 
            // lblDeck
            // 
            lblDeck.AutoSize = true;
            lblDeck.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDeck.ForeColor = SystemColors.WindowText;
            lblDeck.Location = new Point(40, 63);
            lblDeck.Margin = new Padding(4, 0, 4, 0);
            lblDeck.Name = "lblDeck";
            lblDeck.Size = new Size(65, 25);
            lblDeck.TabIndex = 0;
            lblDeck.Text = "Deck : ";
            // 
            // grpAdversaire
            // 
            grpAdversaire.Controls.Add(lblActifAdversaire);
            grpAdversaire.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpAdversaire.ForeColor = Color.DarkOrange;
            grpAdversaire.Location = new Point(790, 62);
            grpAdversaire.Margin = new Padding(4, 5, 4, 5);
            grpAdversaire.Name = "grpAdversaire";
            grpAdversaire.Padding = new Padding(4, 5, 4, 5);
            grpAdversaire.Size = new Size(351, 545);
            grpAdversaire.TabIndex = 1;
            grpAdversaire.TabStop = false;
            grpAdversaire.Text = "Adversaire";
            // 
            // lblActifAdversaire
            // 
            lblActifAdversaire.AutoSize = true;
            lblActifAdversaire.BackColor = Color.BlanchedAlmond;
            lblActifAdversaire.Font = new Font("Segoe UI", 9F);
            lblActifAdversaire.ForeColor = SystemColors.WindowText;
            lblActifAdversaire.Location = new Point(2, 48);
            lblActifAdversaire.Margin = new Padding(4, 0, 4, 0);
            lblActifAdversaire.Name = "lblActifAdversaire";
            lblActifAdversaire.Size = new Size(150, 25);
            lblActifAdversaire.TabIndex = 0;
            lblActifAdversaire.Text = "lblActifAdversaire";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(236, 678);
            lblMessage.Margin = new Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 25);
            lblMessage.TabIndex = 2;
            // 
            // FrmPartie
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(lblMessage);
            Controls.Add(grpAdversaire);
            Controls.Add(grpJoueur);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmPartie";
            Text = "FrmPartie";
            grpJoueur.ResumeLayout(false);
            grpJoueur.PerformLayout();
            grpAdversaire.ResumeLayout(false);
            grpAdversaire.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpJoueur;
        private GroupBox grpAdversaire;
        private ListBox lstMain;
        private Label lblDeck;
        private ListBox lstBanc;
        private Label lblActif;
        private Label lblEnergies;
        private ComboBox cmbAttaques;
        private Button btnPiocher;
        private Button btnJouerCarte;
        private Button btnPasserTour;
        private Button btnAttaquer;
        private Label lblActifAdversaire;
        private Label lblMessage;
    }
}
