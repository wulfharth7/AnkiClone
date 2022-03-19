
namespace clone
{
    partial class LoginPage
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
            this.show_pass_panel = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.box_username = new System.Windows.Forms.TextBox();
            this.pass_box = new System.Windows.Forms.TextBox();
            this.error_message_username = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // show_pass_panel
            // 
            this.show_pass_panel.AutoSize = true;
            this.show_pass_panel.Location = new System.Drawing.Point(421, 138);
            this.show_pass_panel.Name = "show_pass_panel";
            this.show_pass_panel.Size = new System.Drawing.Size(128, 21);
            this.show_pass_panel.TabIndex = 15;
            this.show_pass_panel.Text = "Show password";
            this.show_pass_panel.UseVisualStyleBackColor = true;
            this.show_pass_panel.CheckedChanged += new System.EventHandler(this.show_pass_panel_CheckedChanged);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(311, 310);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(90, 30);
            this.btnRegister.TabIndex = 14;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(311, 274);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(90, 30);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Username";
            // 
            // box_username
            // 
            this.box_username.Location = new System.Drawing.Point(311, 97);
            this.box_username.Name = "box_username";
            this.box_username.Size = new System.Drawing.Size(100, 22);
            this.box_username.TabIndex = 11;
            // 
            // pass_box
            // 
            this.pass_box.Location = new System.Drawing.Point(311, 136);
            this.pass_box.Name = "pass_box";
            this.pass_box.Size = new System.Drawing.Size(100, 22);
            this.pass_box.TabIndex = 12;
            // 
            // error_message_username
            // 
            this.error_message_username.AutoSize = true;
            this.error_message_username.Location = new System.Drawing.Point(287, 71);
            this.error_message_username.Name = "error_message_username";
            this.error_message_username.Size = new System.Drawing.Size(0, 17);
            this.error_message_username.TabIndex = 16;
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.error_message_username);
            this.Controls.Add(this.show_pass_panel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.box_username);
            this.Controls.Add(this.pass_box);
            this.Name = "LoginPage";
            this.Size = new System.Drawing.Size(713, 427);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox show_pass_panel;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox box_username;
        private System.Windows.Forms.TextBox pass_box;
        private System.Windows.Forms.Label error_message_username;
    }
}
