using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp2.Models;

namespace WinFormsApp2.ManagerPage
{
    public partial class EditEmployee : Form
    {
        private MyDbContext db = new MyDbContext();
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        private int? depid;
        private int currentEmployeeId;

        public EditEmployee(int? depid)
        {
            this.depid = depid;
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
            this.btnClose.Click += (s, e) => this.Close();
            this.btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            // Button events
            this.btnShowDetails.Click += BtnShowDetails_Click;
            this.btnSave.Click += BtnSave_Click;

            // Hover effects
            this.btnShowDetails.MouseEnter += (s, e) => btnShowDetails.BackColor = Color.FromArgb(41, 128, 185);
            this.btnShowDetails.MouseLeave += (s, e) => btnShowDetails.BackColor = Color.FromArgb(52, 152, 219);

            this.btnSave.MouseEnter += (s, e) => btnSave.BackColor = Color.FromArgb(39, 174, 96);
            this.btnSave.MouseLeave += (s, e) => btnSave.BackColor = Color.FromArgb(46, 204, 113);

            // Phone validation (only numbers)
            this.txtPhone.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            // Salary validation (only numbers and decimal)
            this.txtSalary.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar == '.' && (s as TextBox).Text.Contains('.'))
                    e.Handled = true;
            };

            this.Load += EditEmployee_Load;
        }

        private void EditEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                var employees = db.Employees
                    .Where(x => x.DepartmentId == depid && x.Role != "Manager")
                    .ToList();

                cmbEmployee.DataSource = employees;
                cmbEmployee.DisplayMember = "Name";
                cmbEmployee.ValueMember = "EmployeeId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnShowDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmployee.SelectedValue == null)
                {
                    MessageBox.Show("Please select an employee first.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentEmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
                var employee = db.Employees.FirstOrDefault(x => x.EmployeeId == currentEmployeeId);

                if (employee != null)
                {
                    panelEmployeeInfo.Visible = true;
                    btnSave.Visible = true;

                    // Set values
                    lblNameValue.Text = employee.Name;

                    // Get department name
                    var department = db.Departments.FirstOrDefault(x => x.DepartmentId == employee.DepartmentId);
                    txtDepartment.Text = department?.Name ?? "Not Assigned";
                    txtPhone.Text = employee.Phone;
                    txtSalary.Text = employee.Salary.ToString();
                }
                else
                {
                    MessageBox.Show("Employee not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Phone number is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                if (txtPhone.Text.Length < 10)
                {
                    MessageBox.Show("Please enter a valid phone number (at least 10 digits).", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSalary.Text))
                {
                    MessageBox.Show("Salary is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSalary.Focus();
                    return;
                }

                var employee = db.Employees.FirstOrDefault(x => x.EmployeeId == currentEmployeeId);

                if (employee != null)
                {
                    // Update employee data
                    employee.Phone = txtPhone.Text.Trim();

                    if (decimal.TryParse(txtSalary.Text, out decimal newSalary))
                    {
                        employee.Salary = newSalary;
                    }
                    else
                    {
                        MessageBox.Show("Invalid salary value. Please enter a valid number.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Update department if changed
                    var department = db.Departments.FirstOrDefault(d => d.Name == txtDepartment.Text.Trim());
                    if (department != null)
                    {
                        employee.DepartmentId = department.DepartmentId;
                    }

                    db.SaveChanges();

                    MessageBox.Show($"Employee data updated successfully!\n\nName: {employee.Name}\nPhone: {employee.Phone}\nSalary: {employee.Salary:C}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the employee list
                    LoadEmployees();

                    // Clear and hide fields
                    panelEmployeeInfo.Visible = false;
                    btnSave.Visible = false;
                    cmbEmployee.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Employee not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowDetails_Click_1(object sender, EventArgs e)
        {

        }
    }
}