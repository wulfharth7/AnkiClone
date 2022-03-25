
namespace clone
{
    partial class deckControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateDeck = new System.Windows.Forms.Button();
            this.btnExprtFile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnRefreshDecks = new System.Windows.Forms.Button();
            this.lblNoDeck = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Deck";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(482, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cards";
            // 
            // btnCreateDeck
            // 
            this.btnCreateDeck.Location = new System.Drawing.Point(165, 381);
            this.btnCreateDeck.Name = "btnCreateDeck";
            this.btnCreateDeck.Size = new System.Drawing.Size(120, 31);
            this.btnCreateDeck.TabIndex = 2;
            this.btnCreateDeck.Text = "Create Deck";
            this.btnCreateDeck.UseVisualStyleBackColor = true;
            this.btnCreateDeck.Click += new System.EventHandler(this.btnCreateDeck_Click);
            // 
            // btnExprtFile
            // 
            this.btnExprtFile.Location = new System.Drawing.Point(291, 381);
            this.btnExprtFile.Name = "btnExprtFile";
            this.btnExprtFile.Size = new System.Drawing.Size(120, 31);
            this.btnExprtFile.TabIndex = 3;
            this.btnExprtFile.Text = "Export Files";
            this.btnExprtFile.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(417, 381);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 31);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnRefreshDecks
            // 
            this.btnRefreshDecks.Location = new System.Drawing.Point(291, 344);
            this.btnRefreshDecks.Name = "btnRefreshDecks";
            this.btnRefreshDecks.Size = new System.Drawing.Size(120, 31);
            this.btnRefreshDecks.TabIndex = 5;
            this.btnRefreshDecks.Text = "Refresh decks";
            this.btnRefreshDecks.UseVisualStyleBackColor = true;
            this.btnRefreshDecks.Click += new System.EventHandler(this.btnRefreshDecks_Click);
            // 
            // lblNoDeck
            // 
            this.lblNoDeck.Location = new System.Drawing.Point(185, 57);
            this.lblNoDeck.Name = "lblNoDeck";
            this.lblNoDeck.Size = new System.Drawing.Size(352, 23);
            this.lblNoDeck.TabIndex = 6;
            // 
            // deckControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNoDeck);
            this.Controls.Add(this.btnRefreshDecks);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnExprtFile);
            this.Controls.Add(this.btnCreateDeck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "deckControl";
            this.Size = new System.Drawing.Size(713, 427);
            this.Load += new System.EventHandler(this.deckControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateDeck;
        private System.Windows.Forms.Button btnExprtFile;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRefreshDecks;
        private System.Windows.Forms.Label lblNoDeck;
    }
}
