using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp2.Models;

namespace WinFormsApp2.ManagerPage
{
    public partial class ManagerHomePage : Form
    {
        private MyDbContext db = new MyDbContext();
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        private int empid;
        private int? depid;
        private string Email, eName, Phone;
        private decimal? salary;

        public ManagerHomePage(Employee emp)
        {
            empid = emp.EmployeeId;
            Email = emp.Email;
            salary = emp.Salary;
            eName = emp.Name;
            Phone = emp.Phone;
            depid = emp.DepartmentId;

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
            this.btnEditData.Click += BtnEditData_Click;
            this.btnShowEmployee.Click += BtnShowEmployee_Click;

            // Hover effects
            this.btnEditData.MouseEnter += (s, e) => btnEditData.BackColor = Color.FromArgb(243, 156, 18);
            this.btnEditData.MouseLeave += (s, e) => btnEditData.BackColor = Color.FromArgb(241, 196, 15);

            this.btnShowEmployee.MouseEnter += (s, e) => btnShowEmployee.BackColor = Color.FromArgb(41, 128, 185);
            this.btnShowEmployee.MouseLeave += (s, e) => btnShowEmployee.BackColor = Color.FromArgb(52, 152, 219);

            this.btnLogout.MouseEnter += (s, e) => btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            this.btnLogout.MouseLeave += (s, e) => btnLogout.BackColor = Color.FromArgb(231, 76, 60);

            this.Load += ManagerHomePage_Load;
        }

        private void ManagerHomePage_Load(object sender, EventArgs e)
        {
            // Set user information
            lblNameValue.Text = eName;
            lblEmailValue.Text = Email;
            lblPhoneValue.Text = Phone;
            lblSalaryValue.Text = salary?.ToString("C") ?? "N/A";
            lblIDValue.Text = empid.ToString();

            // Get department name
            var dep = db.Departments.FirstOrDefault(x => x.DepartmentId == depid);
            lblDepartmentValue.Text = dep?.Name ?? "Not Assigned";

            // Set welcome message
            labelWelcome.Text = $"Welcome, {eName}";
        }

        private void BtnEditData_Click(object sender, EventArgs e)
        {
            EditEmployee edit = new EditEmployee(depid);
            edit.ShowDialog();
        }

        private void BtnShowEmployee_Click(object sender, EventArgs e)
        {
            ShowEmployee se = new ShowEmployee(depid);
            se.ShowDialog();
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