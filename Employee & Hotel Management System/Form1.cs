using Microsoft.IdentityModel.Tokens;
using WinFormsApp2.AdminPage;
using WinFormsApp2.ManagerPage;
using WinFormsApp2.Models;
using WinFormsApp2.WorkerPage;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        MyDbContext my = new MyDbContext();
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Make form fullscreen
            this.WindowState = FormWindowState.Maximized;

            // ÑÈØ ÇáÃÍÏÇË
            this.Load += Form1_Load;
            button1.Click += button1_Click;
            buttonShowPassword.Click += ButtonShowPassword_Click;
            linkForgotPassword.LinkClicked += LinkForgotPassword_Click;

            // ÃÍÏÇË ÊÍÑíß ÇáäÇÝÐÉ
            panelHeader.MouseDown += PanelHeader_MouseDown;
            panelHeader.MouseMove += PanelHeader_MouseMove;
            panelHeader.MouseUp += PanelHeader_MouseUp;

            // ÃÒÑÇÑ ÇáÊÍßã
            btnClose.Click += (s, e) => Application.Exit();
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            // ÊÃËíÑ Hover áÒÑ ÊÓÌíá ÇáÏÎæá
            button1.MouseEnter += (s, e) => button1.BackColor = Color.FromArgb(41, 128, 185);
            button1.MouseLeave += (s, e) => button1.BackColor = Color.FromArgb(52, 152, 219);

            // ÊÚííä ÇáÕæÑ
            try
            {
                // pictureBoxLogo.Image = Properties.Resources.login_image;
                // pictureBoxEmail.Image = Properties.Resources.email_icon;
                // pictureBoxPassword.Image = Properties.Resources.password_icon;
            }
            catch { }
        }

        private void PanelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void PanelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void PanelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                string email = textBox1.Text.Trim();
                string passwordText = textBox2.Text;

                var emp = my.Employees.FirstOrDefault(x => x.Email == email && x.Password == passwordText);

                if (emp != null)
                {
                    this.Hide();

                    if (emp.Role.ToLower() == "admin")
                    {
                        AdminHomePage Admin = new AdminHomePage(emp);
                        Admin.ShowDialog();
                    }
                    else if (emp.Role.ToLower() == "manager")
                    {
                        ManagerHomePage manager = new ManagerHomePage(emp);
                        manager.ShowDialog();
                    }
                    else
                    {
                        WorkerHomePage Worker = new WorkerHomePage(emp);
                        Worker.ShowDialog();
                    }

                    this.Show();
                    textBox2.Clear();
                }
                else
                {
                    MessageBox.Show("Invalid email or password", "Login Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter email and password", "Required Fields",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonShowPassword_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
                buttonShowPassword.Text = "Hide";
            }
            else
            {
                textBox2.PasswordChar = '*';
                buttonShowPassword.Text = "Show";
            }
        }

        private void LinkForgotPassword_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact system administrator to reset your password", "Forgot Password",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void labelWelcomeMessage_Click(object sender, EventArgs e)
        {

        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }
    }
}