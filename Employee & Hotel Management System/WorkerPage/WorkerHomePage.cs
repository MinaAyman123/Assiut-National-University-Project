using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp2.Models;

namespace WinFormsApp2.WorkerPage
{
    public partial class WorkerHomePage : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);
        private string name, phone, email, role;

        public WorkerHomePage(Employee emp)
        {
            name = emp.Name;
            phone = emp.Phone;
            email = emp.Email;
            role = emp.Role;
            InitializeComponent();
            SetupForm();
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
            this.btnAddBooking.Click += BtnAddBooking_Click;
            this.btnDeleteBooking.Click += BtnDeleteBooking_Click;
            this.btnShowRoom.Click += BtnShowRoom_Click;

            // Hover effects for buttons
            this.btnAddBooking.MouseEnter += (s, e) => btnAddBooking.BackColor = Color.FromArgb(41, 128, 185);
            this.btnAddBooking.MouseLeave += (s, e) => btnAddBooking.BackColor = Color.FromArgb(52, 152, 219);

            this.btnDeleteBooking.MouseEnter += (s, e) => btnDeleteBooking.BackColor = Color.FromArgb(192, 57, 43);
            this.btnDeleteBooking.MouseLeave += (s, e) => btnDeleteBooking.BackColor = Color.FromArgb(231, 76, 60);

            this.btnShowRoom.MouseEnter += (s, e) => btnShowRoom.BackColor = Color.FromArgb(39, 174, 96);
            this.btnShowRoom.MouseLeave += (s, e) => btnShowRoom.BackColor = Color.FromArgb(46, 204, 113);

            this.btnLogout.MouseEnter += (s, e) => btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            this.btnLogout.MouseLeave += (s, e) => btnLogout.BackColor = Color.FromArgb(231, 76, 60);

            this.Load += WorkerHomePage_Load;
        }

        private void WorkerHomePage_Load(object sender, EventArgs e)
        {
            // Set user information
            lblNameValue.Text = name;
            lblPhoneValue.Text = phone;
            lblEmailValue.Text = email;
            lblRoleValue.Text = role;

            // Set welcome message
            labelWelcome.Text = $"Welcome, {name}";
        }

        private void BtnAddBooking_Click(object sender, EventArgs e)
        {
            Booking book = new Booking();
            book.ShowDialog();
        }

        private void BtnDeleteBooking_Click(object sender, EventArgs e)
        {
            DeleteBook d = new DeleteBook();
            d.ShowDialog();
        }

        private void BtnShowRoom_Click(object sender, EventArgs e)
        {
            ShowRoom sh = new ShowRoom();
            sh.ShowDialog();
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
    }
}