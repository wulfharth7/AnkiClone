
namespace clone
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Decks_Button = new System.Windows.Forms.LinkLabel();
            this.Brows_Button = new System.Windows.Forms.LinkLabel();
            this.Stats_Button = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.Location = new System.Drawing.Point(0, 32);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(741, 39);
            this.progressBar1.TabIndex = 0;
            // 
            // Decks_Button
            // 
            this.Decks_Button.ActiveLinkColor = System.Drawing.Color.Transparent;
            this.Decks_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Decks_Button.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.Decks_Button.LinkColor = System.Drawing.Color.Black;
            this.Decks_Button.Location = new System.Drawing.Point(205, 42);
            this.Decks_Button.Name = "Decks_Button";
            this.Decks_Button.Size = new System.Drawing.Size(65, 17);
            this.Decks_Button.TabIndex = 1;
            this.Decks_Button.TabStop = true;
            this.Decks_Button.Text = "Decks";
            this.Decks_Button.UseCompatibleTextRendering = true;
            this.Decks_Button.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Decks_Button_LinkClicked);
            // 
            // Brows_Button
            // 
            this.Brows_Button.ActiveLinkColor = System.Drawing.Color.Transparent;
            this.Brows_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Brows_Button.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.Brows_Button.LinkColor = System.Drawing.Color.Black;
            this.Brows_Button.Location = new System.Drawing.Point(333, 42);
            this.Brows_Button.Name = "Brows_Button";
            this.Brows_Button.Size = new System.Drawing.Size(73, 17);
            this.Brows_Button.TabIndex = 3;
            this.Brows_Button.TabStop = true;
            this.Brows_Button.Text = "Browse";
            this.Brows_Button.UseCompatibleTextRendering = true;
            this.Brows_Button.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Brows_Button_LinkClicked);
            // 
            // Stats_Button
            // 
            this.Stats_Button.ActiveLinkColor = System.Drawing.Color.Transparent;
            this.Stats_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Stats_Button.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.Stats_Button.LinkColor = System.Drawing.Color.Black;
            this.Stats_Button.Location = new System.Drawing.Point(473, 42);
            this.Stats_Button.Name = "Stats_Button";
            this.Stats_Button.Size = new System.Drawing.Size(58, 17);
            this.Stats_Button.TabIndex = 4;
            this.Stats_Button.TabStop = true;
            this.Stats_Button.Text = "Stats";
            this.Stats_Button.UseCompatibleTextRendering = true;
            this.Stats_Button.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Stats_Button_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 427);
            this.panel1.TabIndex = 6;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(-3, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(109, 17);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "  Logged user: -";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(555, 9);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(86, 17);
            this.dateLabel.TabIndex = 8;
            this.dateLabel.Text = "Username: -";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 508);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.Stats_Button);
            this.Controls.Add(this.Brows_Button);
            this.Controls.Add(this.Decks_Button);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(755, 555);
            this.MinimumSize = new System.Drawing.Size(755, 555);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "text_755_555";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.LinkLabel Decks_Button;
        private System.Windows.Forms.LinkLabel Brows_Button;
        private System.Windows.Forms.LinkLabel Stats_Button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Timer timer1;
    }
}

