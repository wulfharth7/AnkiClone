
namespace clone
{
    partial class flashcards
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
            this.lblDeckname = new System.Windows.Forms.Label();
            this.card_box = new System.Windows.Forms.GroupBox();
            this.myPanel = new System.Windows.Forms.Panel();
            this.lblCards = new System.Windows.Forms.LinkLabel();
            this.lblCardCount = new System.Windows.Forms.Label();
            this.show_next_card = new System.Windows.Forms.LinkLabel();
            this.show_previous_card = new System.Windows.Forms.LinkLabel();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnStudy = new System.Windows.Forms.Button();
            this.lblBack = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnExprtFile = new System.Windows.Forms.Button();
            this.group_box_card_controls = new System.Windows.Forms.GroupBox();
            this.btn_add_cards = new System.Windows.Forms.Button();
            this.card_box.SuspendLayout();
            this.myPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.group_box_card_controls.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDeckname
            // 
            this.lblDeckname.AutoSize = true;
            this.lblDeckname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDeckname.Location = new System.Drawing.Point(14, 39);
            this.lblDeckname.Name = "lblDeckname";
            this.lblDeckname.Size = new System.Drawing.Size(164, 29);
            this.lblDeckname.TabIndex = 0;
            this.lblDeckname.Text = "Lorem Ipsum";
            // 
            // card_box
            // 
            this.card_box.Controls.Add(this.myPanel);
            this.card_box.Controls.Add(this.lblCardCount);
            this.card_box.Controls.Add(this.show_next_card);
            this.card_box.Controls.Add(this.show_previous_card);
            this.card_box.Location = new System.Drawing.Point(197, 75);
            this.card_box.Name = "card_box";
            this.card_box.Size = new System.Drawing.Size(470, 326);
            this.card_box.TabIndex = 1;
            this.card_box.TabStop = false;
            this.card_box.Text = "Cards";
            // 
            // myPanel
            // 
            this.myPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myPanel.Controls.Add(this.lblCards);
            this.myPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myPanel.Location = new System.Drawing.Point(13, 21);
            this.myPanel.Name = "myPanel";
            this.myPanel.Size = new System.Drawing.Size(441, 225);
            this.myPanel.TabIndex = 10;
            this.myPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
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
            this.lblCards.Size = new System.Drawing.Size(337, 65);
            this.lblCards.TabIndex = 0;
            this.lblCards.TabStop = true;
            this.lblCards.Text = "You haven\'t added cards...yet!";
            this.lblCards.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCards.UseCompatibleTextRendering = true;
            this.lblCards.VisitedLinkColor = System.Drawing.Color.Black;
            this.lblCards.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCards_LinkClicked);
            // 
            // lblCardCount
            // 
            this.lblCardCount.AutoSize = true;
            this.lblCardCount.Location = new System.Drawing.Point(225, 277);
            this.lblCardCount.Name = "lblCardCount";
            this.lblCardCount.Size = new System.Drawing.Size(28, 17);
            this.lblCardCount.TabIndex = 9;
            this.lblCardCount.Text = "0/0";
            // 
            // show_next_card
            // 
            this.show_next_card.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.show_next_card.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.show_next_card.LinkColor = System.Drawing.Color.Black;
            this.show_next_card.Location = new System.Drawing.Point(332, 274);
            this.show_next_card.Name = "show_next_card";
            this.show_next_card.Size = new System.Drawing.Size(100, 23);
            this.show_next_card.TabIndex = 8;
            this.show_next_card.TabStop = true;
            this.show_next_card.Text = ">>>";
            this.show_next_card.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.show_next_card.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.show_next_card_LinkClicked);
            // 
            // show_previous_card
            // 
            this.show_previous_card.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.show_previous_card.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.show_previous_card.LinkColor = System.Drawing.Color.Black;
            this.show_previous_card.Location = new System.Drawing.Point(113, 274);
            this.show_previous_card.Name = "show_previous_card";
            this.show_previous_card.Size = new System.Drawing.Size(100, 23);
            this.show_previous_card.TabIndex = 7;
            this.show_previous_card.TabStop = true;
            this.show_previous_card.Text = "<<<";
            this.show_previous_card.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.show_previous_card.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.show_previous_card_LinkClicked);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(22, 21);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(114, 34);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btn_study_Click);
            // 
            // btnStudy
            // 
            this.btnStudy.Location = new System.Drawing.Point(22, 61);
            this.btnStudy.Name = "btnStudy";
            this.btnStudy.Size = new System.Drawing.Size(114, 34);
            this.btnStudy.TabIndex = 3;
            this.btnStudy.Text = "Flashcards";
            this.btnStudy.UseVisualStyleBackColor = true;
            this.btnStudy.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblBack
            // 
            this.lblBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBack.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblBack.LinkColor = System.Drawing.Color.Black;
            this.lblBack.Location = new System.Drawing.Point(16, 13);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(100, 23);
            this.lblBack.TabIndex = 4;
            this.lblBack.TabStop = true;
            this.lblBack.Text = "< Back";
            this.lblBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBack_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Controls.Add(this.btnStudy);
            this.groupBox1.Location = new System.Drawing.Point(19, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 153);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Study";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Write";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.btnExprtFile);
            this.groupBox2.Location = new System.Drawing.Point(19, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 158);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(22, 105);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 31);
            this.button4.TabIndex = 9;
            this.button4.Text = "smth to do later";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 31);
            this.button3.TabIndex = 8;
            this.button3.Text = "Import Cards";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnExprtFile
            // 
            this.btnExprtFile.Location = new System.Drawing.Point(22, 31);
            this.btnExprtFile.Name = "btnExprtFile";
            this.btnExprtFile.Size = new System.Drawing.Size(114, 31);
            this.btnExprtFile.TabIndex = 7;
            this.btnExprtFile.Text = "Export Cards";
            this.btnExprtFile.UseVisualStyleBackColor = true;
            this.btnExprtFile.Click += new System.EventHandler(this.btnExprtFile_Click);
            // 
            // group_box_card_controls
            // 
            this.group_box_card_controls.Controls.Add(this.btn_add_cards);
            this.group_box_card_controls.Location = new System.Drawing.Point(19, 433);
            this.group_box_card_controls.Name = "group_box_card_controls";
            this.group_box_card_controls.Size = new System.Drawing.Size(648, 80);
            this.group_box_card_controls.TabIndex = 8;
            this.group_box_card_controls.TabStop = false;
            this.group_box_card_controls.Text = "Card Controls";
            // 
            // btn_add_cards
            // 
            this.btn_add_cards.Location = new System.Drawing.Point(243, 25);
            this.btn_add_cards.Name = "btn_add_cards";
            this.btn_add_cards.Size = new System.Drawing.Size(171, 45);
            this.btn_add_cards.TabIndex = 0;
            this.btn_add_cards.Text = "Add Cards";
            this.btn_add_cards.UseVisualStyleBackColor = true;
            this.btn_add_cards.Click += new System.EventHandler(this.btn_add_cards_Click);
            // 
            // flashcards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.group_box_card_controls);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblBack);
            this.Controls.Add(this.lblDeckname);
            this.Controls.Add(this.card_box);
            this.Name = "flashcards";
            this.Size = new System.Drawing.Size(713, 427);
            this.Load += new System.EventHandler(this.flashcards_Load);
            this.card_box.ResumeLayout(false);
            this.card_box.PerformLayout();
            this.myPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.group_box_card_controls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDeckname;
        private System.Windows.Forms.GroupBox card_box;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnStudy;
        private System.Windows.Forms.LinkLabel lblBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnExprtFile;
        private System.Windows.Forms.Label lblCardCount;
        private System.Windows.Forms.LinkLabel show_next_card;
        private System.Windows.Forms.LinkLabel show_previous_card;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel myPanel;
        private System.Windows.Forms.LinkLabel lblCards;
        private System.Windows.Forms.GroupBox group_box_card_controls;
        private System.Windows.Forms.Button btn_add_cards;
    }
}
