using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp2.Models;
using WinFormsApp2;

namespace WinFormsApp2.AdminPage
{
    public partial class AdminHomePage : Form
    {
        private string Email, eName, Phone;
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        public AdminHomePage(Employee emp)
        {
            Email = emp.Email;
            eName = emp.Name;
            Phone = emp.Phone;
            InitializeComponent();
            SetupForm();
            this.Load += AdminHomePage_Load;
        }

        private void SetupForm()
        {
            // Make form fullscreen
            this.WindowState = FormWindowState.Maximized;

            // Drag functionality for header
            this.panelHeader.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    startPoint = new Point(e.X, e.Y);
                }
            };

            this.panelHeader.MouseMove += (s, e) =>
            {
                if (isDragging)
                {
                    Point p = PointToScreen(e.Location);
                    this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
                }
            };

            this.panelHeader.MouseUp += (s, e) => isDragging = false;

            // Window controls
            this.btnClose.Click += (s, e) => Application.Exit();
            this.btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            this.btnLogout.Click += BtnLogout_Click;

            // Button events
            this.btnAddEmployee.Click += BtnAddEmployee_Click;
            this.btnShowReservation.Click += BtnShowReservation_Click;
            this.btnEditData.Click += BtnEditData_Click;

            // Hover effects for buttons
            SetupHoverEffects();
        }

        private void SetupHoverEffects()
        {
            // Add Employee button
            this.btnAddEmployee.MouseEnter += (s, e) => btnAddEmployee.BackColor = Color.FromArgb(41, 128, 185);
            this.btnAddEmployee.MouseLeave += (s, e) => btnAddEmployee.BackColor = Color.FromArgb(52, 152, 219);

            // Show Reservation button
            this.btnShowReservation.MouseEnter += (s, e) => btnShowReservation.BackColor = Color.FromArgb(39, 174, 96);
            this.btnShowReservation.MouseLeave += (s, e) => btnShowReservation.BackColor = Color.FromArgb(46, 204, 113);

            // Edit Data button
            this.btnEditData.MouseEnter += (s, e) => btnEditData.BackColor = Color.FromArgb(243, 156, 18);
            this.btnEditData.MouseLeave += (s, e) => btnEditData.BackColor = Color.FromArgb(241, 196, 15);

            // Logout button
            this.btnLogout.MouseEnter += (s, e) => btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            this.btnLogout.MouseLeave += (s, e) => btnLogout.BackColor = Color.FromArgb(231, 76, 60);
        }

        private void AdminHomePage_Load(object sender, EventArgs e)
        {
            // Set user information
            lblNameValue.Text = eName;
            lblEmailValue.Text = Email;
            lblPhoneValue.Text = Phone;

            // Set welcome message
            labelWelcomeTitle.Text = $"Welcome {eName}";

            // Try to load logo image
            try
            {
                // pictureBoxLogo.Image = Properties.Resources.admin_logo;
            }
            catch { /* Image not available */ }
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog();
        }

        private void BtnShowReservation_Click(object sender, EventArgs e)
        {
            ShowReservation showReservation = new ShowReservation();
            showReservation.ShowDialog();
        }

        private void BtnEditData_Click(object sender, EventArgs e)
        {
            EditData editData = new EditData();
            editData.ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}