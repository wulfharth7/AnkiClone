
namespace clone
{
    partial class study_flashcards
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
            this.card_box = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCards = new System.Windows.Forms.LinkLabel();
            this.lblBack = new System.Windows.Forms.LinkLabel();
            this.lblDeckname = new System.Windows.Forms.Label();
            this.btnShuffle = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblCardProgress = new System.Windows.Forms.Label();
            this.lblCardCorrect = new System.Windows.Forms.Label();
            this.lblCardOutOf = new System.Windows.Forms.Label();
            this.lblCardRepeat = new System.Windows.Forms.Label();
            this.btnAgain = new System.Windows.Forms.Button();
            this.btnGreat = new System.Windows.Forms.Button();
            this.btnStudyAgain = new System.Windows.Forms.Button();
            this.card_box.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // card_box
            // 
            this.card_box.Controls.Add(this.panel1);
            this.card_box.Location = new System.Drawing.Point(181, 67);
            this.card_box.Name = "card_box";
            this.card_box.Size = new System.Drawing.Size(516, 311);
            this.card_box.TabIndex = 2;
            this.card_box.TabStop = false;
            this.card_box.Text = "Cards";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblCards);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 290);
            this.panel1.TabIndex = 10;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // lblCards
            // 
            this.lblCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCards.LinkArea = new System.Windows.Forms.LinkArea(0, 50);
            this.lblCards.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblCards.LinkColor = System.Drawing.Color.Black;
            this.lblCards.Location = new System.Drawing.Point(56, 78);
            this.lblCards.Name = "lblCards";
            this.lblCards.Size = new System.Drawing.Size(406, 130);
            this.lblCards.TabIndex = 0;
            this.lblCards.TabStop = true;
            this.lblCards.Text = "You haven\'t added cards...yet!";
            this.lblCards.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCards.UseCompatibleTextRendering = true;
            this.lblCards.VisitedLinkColor = System.Drawing.Color.Black;
            this.lblCards.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCards_LinkClicked);
            // 
            // lblBack
            // 
            this.lblBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBack.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblBack.LinkColor = System.Drawing.Color.Black;
            this.lblBack.Location = new System.Drawing.Point(13, 16);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(100, 23);
            this.lblBack.TabIndex = 5;
            this.lblBack.TabStop = true;
            this.lblBack.Text = "< Back";
            this.lblBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBack_LinkClicked);
            // 
            // lblDeckname
            // 
            this.lblDeckname.AutoSize = true;
            this.lblDeckname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDeckname.Location = new System.Drawing.Point(3, 44);
            this.lblDeckname.Name = "lblDeckname";
            this.lblDeckname.Size = new System.Drawing.Size(141, 29);
            this.lblDeckname.TabIndex = 6;
            this.lblDeckname.Text = "Flashcards";
            this.lblDeckname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnShuffle
            // 
            this.btnShuffle.Location = new System.Drawing.Point(8, 384);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(146, 35);
            this.btnShuffle.TabIndex = 7;
            this.btnShuffle.Text = "Shuffle";
            this.btnShuffle.UseVisualStyleBackColor = true;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(8, 91);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(154, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Progress";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(8, 345);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(146, 35);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblCardProgress
            // 
            this.lblCardProgress.Location = new System.Drawing.Point(81, 117);
            this.lblCardProgress.Name = "lblCardProgress";
            this.lblCardProgress.Size = new System.Drawing.Size(81, 24);
            this.lblCardProgress.TabIndex = 11;
            this.lblCardProgress.Text = "0/0";
            this.lblCardProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardCorrect
            // 
            this.lblCardCorrect.AutoSize = true;
            this.lblCardCorrect.Location = new System.Drawing.Point(6, 301);
            this.lblCardCorrect.Name = "lblCardCorrect";
            this.lblCardCorrect.Size = new System.Drawing.Size(70, 17);
            this.lblCardCorrect.TabIndex = 12;
            this.lblCardCorrect.Text = "Correct: 0";
            // 
            // lblCardOutOf
            // 
            this.lblCardOutOf.AutoSize = true;
            this.lblCardOutOf.Location = new System.Drawing.Point(5, 283);
            this.lblCardOutOf.Name = "lblCardOutOf";
            this.lblCardOutOf.Size = new System.Drawing.Size(106, 17);
            this.lblCardOutOf.TabIndex = 13;
            this.lblCardOutOf.Text = "Card: 0 out of 0";
            // 
            // lblCardRepeat
            // 
            this.lblCardRepeat.AutoSize = true;
            this.lblCardRepeat.Location = new System.Drawing.Point(6, 318);
            this.lblCardRepeat.Name = "lblCardRepeat";
            this.lblCardRepeat.Size = new System.Drawing.Size(70, 17);
            this.lblCardRepeat.TabIndex = 14;
            this.lblCardRepeat.Text = "Repeat: 0";
            // 
            // btnAgain
            // 
            this.btnAgain.Location = new System.Drawing.Point(269, 385);
            this.btnAgain.Name = "btnAgain";
            this.btnAgain.Size = new System.Drawing.Size(103, 34);
            this.btnAgain.TabIndex = 15;
            this.btnAgain.Text = "Again";
            this.btnAgain.UseVisualStyleBackColor = true;
            this.btnAgain.Click += new System.EventHandler(this.btnAgain_Click);
            // 
            // btnGreat
            // 
            this.btnGreat.Location = new System.Drawing.Point(506, 385);
            this.btnGreat.Name = "btnGreat";
            this.btnGreat.Size = new System.Drawing.Size(103, 34);
            this.btnGreat.TabIndex = 16;
            this.btnGreat.Text = "Great";
            this.btnGreat.UseVisualStyleBackColor = true;
            this.btnGreat.Click += new System.EventHandler(this.btnGreat_Click);
            // 
            // btnStudyAgain
            // 
            this.btnStudyAgain.Location = new System.Drawing.Point(387, 385);
            this.btnStudyAgain.Name = "btnStudyAgain";
            this.btnStudyAgain.Size = new System.Drawing.Size(103, 34);
            this.btnStudyAgain.TabIndex = 17;
            this.btnStudyAgain.Text = "Study Again";
            this.btnStudyAgain.UseVisualStyleBackColor = true;
            this.btnStudyAgain.Click += new System.EventHandler(this.btnStudyAgain_Click);
            // 
            // study_flashcards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStudyAgain);
            this.Controls.Add(this.btnGreat);
            this.Controls.Add(this.btnAgain);
            this.Controls.Add(this.lblCardRepeat);
            this.Controls.Add(this.lblCardOutOf);
            this.Controls.Add(this.lblCardCorrect);
            this.Controls.Add(this.lblCardProgress);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnShuffle);
            this.Controls.Add(this.lblDeckname);
            this.Controls.Add(this.lblBack);
            this.Controls.Add(this.card_box);
            this.Name = "study_flashcards";
            this.Size = new System.Drawing.Size(713, 427);
            this.card_box.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox card_box;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lblCards;
        private System.Windows.Forms.LinkLabel lblBack;
        private System.Windows.Forms.Label lblDeckname;
        private System.Windows.Forms.Button btnShuffle;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblCardProgress;
        private System.Windows.Forms.Label lblCardCorrect;
        private System.Windows.Forms.Label lblCardOutOf;
        private System.Windows.Forms.Label lblCardRepeat;
        private System.Windows.Forms.Button btnAgain;
        private System.Windows.Forms.Button btnGreat;
        private System.Windows.Forms.Button btnStudyAgain;
    }
}
