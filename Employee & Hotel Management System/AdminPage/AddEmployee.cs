using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp2.Models;

namespace WinFormsApp2.AdminPage
{
    public partial class AddEmployee : Form
    {
        private MyDbContext db = new MyDbContext();
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        public AddEmployee()
        {
            InitializeComponent();
            SetupForm();
            LoadDepartments();
        }

        private void SetupForm()
        {
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
            this.btnClose.Click += (s, e) => this.Close();
            this.btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            // Button events
            this.btnAdd.Click += BtnAdd_Click;
            this.btnClear.Click += BtnClear_Click;
            this.btnCancel.Click += (s, e) => this.Close();

            // Hover effects
            this.btnAdd.MouseEnter += (s, e) => btnAdd.BackColor = Color.FromArgb(41, 128, 185);
            this.btnAdd.MouseLeave += (s, e) => btnAdd.BackColor = Color.FromArgb(52, 152, 219);

            this.btnClear.MouseEnter += (s, e) => btnClear.BackColor = Color.FromArgb(243, 156, 18);
            this.btnClear.MouseLeave += (s, e) => btnClear.BackColor = Color.FromArgb(241, 196, 15);

            this.btnCancel.MouseEnter += (s, e) => btnCancel.BackColor = Color.FromArgb(192, 57, 43);
            this.btnCancel.MouseLeave += (s, e) => btnCancel.BackColor = Color.FromArgb(231, 76, 60);

            // Input validation
            this.txtSalary.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar == '.' && (s as TextBox).Text.Contains('.'))
                    e.Handled = true;
            };

            this.txtPhone.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };
        }

        private void LoadDepartments()
        {
            try
            {
                var departments = db.Departments.Select(d => d.Name).ToList();
                if (departments.Any())
                    cmbDepartment.DataSource = departments;
                else
                    cmbDepartment.Items.AddRange(new[] { "HR", "IT", "Finance", "Marketing", "Sales", "Management" });
            }
            catch
            {
                cmbDepartment.Items.AddRange(new[] { "HR", "IT", "Finance", "Marketing", "Sales", "Management" });
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Name is required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider.SetError(txtPhone, "Phone is required");
                isValid = false;
            }
            else if (txtPhone.Text.Length < 10)
            {
                errorProvider.SetError(txtPhone, "Invalid phone number");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Email is required");
                isValid = false;
            }
            else if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                errorProvider.SetError(txtEmail, "Invalid email format");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtRole.Text))
            {
                errorProvider.SetError(txtRole, "Role is required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtSalary.Text))
            {
                errorProvider.SetError(txtSalary, "Salary is required");
                isValid = false;
            }

            if (cmbDepartment.SelectedItem == null)
            {
                errorProvider.SetError(cmbDepartment, "Please select a department");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Password is required");
                isValid = false;
            }
            else if (txtPassword.Text.Length < 6)
            {
                errorProvider.SetError(txtPassword, "Password must be at least 6 characters");
                isValid = false;
            }

            return isValid;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                {
                    MessageBox.Show("Please fix the errors before continuing", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string name = txtName.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string email = txtEmail.Text.Trim();
                string role = txtRole.Text.Trim();
                decimal salary = decimal.Parse(txtSalary.Text);
                string department = cmbDepartment.SelectedItem.ToString();
                string password = txtPassword.Text;

                var departmentEntity = db.Departments.FirstOrDefault(x => x.Name == department);

                if (departmentEntity == null)
                {
                    MessageBox.Show("Selected department not found", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (db.Employees.Any(x => x.Email == email))
                {
                    MessageBox.Show("Email already exists", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Employee newEmployee = new Employee
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Role = role,
                    Salary = salary,
                    DepartmentId = departmentEntity.DepartmentId,
                    Password = password
                };

                db.Employees.Add(newEmployee);
                db.SaveChanges();

                MessageBox.Show($"Employee {name} added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                var result = MessageBox.Show("Do you want to add another employee?", "Add Another",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    ClearFields();
                else
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtRole.Clear();
            txtSalary.Clear();
            txtPassword.Clear();
            cmbDepartment.SelectedIndex = -1;
            errorProvider.Clear();
            txtName.Focus();
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}