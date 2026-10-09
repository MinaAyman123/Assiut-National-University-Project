using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            buttonShowPassword = new Button();
            linkForgotPassword = new LinkLabel();
            panelHeader = new Panel();
            btnClose = new Button();
            btnMinimize = new Button();
            labelWelcome = new Label();
            labelTitle = new Label();
            panelLeft = new Panel();
            pictureBoxLogo = new PictureBox();
            panelRight = new Panel();
            labelLoginTitle = new Label();
            panelEmail = new Panel();
            pictureBoxEmail = new PictureBox();
            panelPassword = new Panel();
            pictureBoxPassword = new PictureBox();
            panelHeader.SuspendLayout();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelRight.SuspendLayout();
            panelEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmail).BeginInit();
            panelPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPassword).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(245, 247, 250);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.ForeColor = Color.FromArgb(44, 62, 80);
            textBox1.Location = new Point(51, 13);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Email";
            textBox1.Size = new Size(337, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(245, 247, 250);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.ForeColor = Color.FromArgb(44, 62, 80);
            textBox2.Location = new Point(51, 13);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.PlaceholderText = "Password";
            textBox2.Size = new Size(291, 27);
            textBox2.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(52, 152, 219);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(217, 461);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(400, 67);
            button1.TabIndex = 2;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            // 
            // buttonShowPassword
            // 
            buttonShowPassword.BackColor = Color.Transparent;
            buttonShowPassword.Cursor = Cursors.Hand;
            buttonShowPassword.FlatAppearance.BorderSize = 0;
            buttonShowPassword.FlatStyle = FlatStyle.Flat;
            buttonShowPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonShowPassword.ForeColor = Color.FromArgb(52, 152, 219);
            buttonShowPassword.Location = new Point(331, 13);
            buttonShowPassword.Margin = new Padding(3, 4, 3, 4);
            buttonShowPassword.Name = "buttonShowPassword";
            buttonShowPassword.Size = new Size(57, 40);
            buttonShowPassword.TabIndex = 3;
            buttonShowPassword.Text = "Show";
            buttonShowPassword.UseVisualStyleBackColor = false;
            // 
            // linkForgotPassword
            // 
            linkForgotPassword.ActiveLinkColor = Color.FromArgb(46, 204, 113);
            linkForgotPassword.AutoSize = true;
            linkForgotPassword.BackColor = Color.Transparent;
            linkForgotPassword.Font = new Font("Segoe UI", 10F);
            linkForgotPassword.ForeColor = Color.FromArgb(52, 152, 219);
            linkForgotPassword.LinkColor = Color.FromArgb(52, 152, 219);
            linkForgotPassword.Location = new Point(354, 400);
            linkForgotPassword.Name = "linkForgotPassword";
            linkForgotPassword.Size = new Size(143, 23);
            linkForgotPassword.TabIndex = 4;
            linkForgotPassword.TabStop = true;
            linkForgotPassword.Text = "Forgot Password?";
            linkForgotPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(44, 62, 80);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Controls.Add(btnMinimize);
            panelHeader.Controls.Add(labelWelcome);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Cursor = Cursors.SizeAll;
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1371, 93);
            panelHeader.TabIndex = 5;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(192, 57, 43);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1320, 24);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 47);
            btnClose.TabIndex = 6;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.BackColor = Color.FromArgb(52, 73, 94);
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(1274, 24);
            btnMinimize.Margin = new Padding(3, 4, 3, 4);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(40, 47);
            btnMinimize.TabIndex = 5;
            btnMinimize.Text = "_";
            btnMinimize.UseVisualStyleBackColor = false;
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.BackColor = Color.Transparent;
            labelWelcome.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            labelWelcome.ForeColor = Color.White;
            labelWelcome.Location = new Point(271, 13);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(210, 54);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Welcome!";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(23, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(242, 37);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Employee System";
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(44, 62, 80);
            panelLeft.Controls.Add(pictureBoxLogo);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 93);
            panelLeft.Margin = new Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(909, 907);
            panelLeft.TabIndex = 6;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = Properties.Resources.swimming_pool_beach_luxury_hotel_type_entertainment_complex_amara_dolce_vita_luxury_hotel_resort_tekirova_kemer_turkey;
            pictureBoxLogo.Location = new Point(3, -22);
            pictureBoxLogo.Margin = new Padding(3, 4, 3, 4);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(909, 1005);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 2;
            pictureBoxLogo.TabStop = false;
            pictureBoxLogo.Click += pictureBoxLogo_Click;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.White;
            panelRight.Controls.Add(labelLoginTitle);
            panelRight.Controls.Add(panelEmail);
            panelRight.Controls.Add(panelPassword);
            panelRight.Controls.Add(linkForgotPassword);
            panelRight.Controls.Add(button1);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(909, 93);
            panelRight.Margin = new Padding(3, 4, 3, 4);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(462, 907);
            panelRight.TabIndex = 7;
            panelRight.Paint += panelRight_Paint;
            // 
            // labelLoginTitle
            // 
            labelLoginTitle.AutoSize = true;
            labelLoginTitle.BackColor = Color.Transparent;
            labelLoginTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            labelLoginTitle.ForeColor = Color.FromArgb(44, 62, 80);
            labelLoginTitle.Location = new Point(286, 107);
            labelLoginTitle.Name = "labelLoginTitle";
            labelLoginTitle.Size = new Size(150, 62);
            labelLoginTitle.TabIndex = 7;
            labelLoginTitle.Text = "Login";
            // 
            // panelEmail
            // 
            panelEmail.BackColor = Color.FromArgb(245, 247, 250);
            panelEmail.Controls.Add(pictureBoxEmail);
            panelEmail.Controls.Add(textBox1);
            panelEmail.Location = new Point(229, 227);
            panelEmail.Margin = new Padding(3, 4, 3, 4);
            panelEmail.Name = "panelEmail";
            panelEmail.Size = new Size(400, 67);
            panelEmail.TabIndex = 5;
            // 
            // pictureBoxEmail
            // 
            pictureBoxEmail.BackColor = Color.Transparent;
            pictureBoxEmail.Location = new Point(11, 16);
            pictureBoxEmail.Margin = new Padding(3, 4, 3, 4);
            pictureBoxEmail.Name = "pictureBoxEmail";
            pictureBoxEmail.Size = new Size(29, 33);
            pictureBoxEmail.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxEmail.TabIndex = 0;
            pictureBoxEmail.TabStop = false;
            // 
            // panelPassword
            // 
            panelPassword.BackColor = Color.FromArgb(245, 247, 250);
            panelPassword.Controls.Add(pictureBoxPassword);
            panelPassword.Controls.Add(textBox2);
            panelPassword.Controls.Add(buttonShowPassword);
            panelPassword.Location = new Point(229, 320);
            panelPassword.Margin = new Padding(3, 4, 3, 4);
            panelPassword.Name = "panelPassword";
            panelPassword.Size = new Size(400, 67);
            panelPassword.TabIndex = 6;
            // 
            // pictureBoxPassword
            // 
            pictureBoxPassword.BackColor = Color.Transparent;
            pictureBoxPassword.Location = new Point(11, 16);
            pictureBoxPassword.Margin = new Padding(3, 4, 3, 4);
            pictureBoxPassword.Name = "pictureBoxPassword";
            pictureBoxPassword.Size = new Size(29, 33);
            pictureBoxPassword.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPassword.TabIndex = 1;
            pictureBoxPassword.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1000);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            panelEmail.ResumeLayout(false);
            panelEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmail).EndInit();
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPassword).EndInit();
            ResumeLayout(false);
        }

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button buttonShowPassword;
        private LinkLabel linkForgotPassword;
        private Panel panelHeader;
        private Button btnClose;
        private Button btnMinimize;
        private Label labelTitle;
        private Panel panelLeft;
        private PictureBox pictureBoxLogo;
        private Label labelWelcome;
        private Panel panelRight;
        private Panel panelEmail;
        private PictureBox pictureBoxEmail;
        private Panel panelPassword;
        private PictureBox pictureBoxPassword;
        private Label labelLoginTitle;
    }
}