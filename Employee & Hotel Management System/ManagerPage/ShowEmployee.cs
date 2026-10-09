using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp2.Models;

namespace WinFormsApp2.ManagerPage
{
    public partial class ShowEmployee : Form
    {
        private MyDbContext db = new MyDbContext();
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);
        private int? depid;

        public ShowEmployee(int? d)
        {
            depid = d;
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

            this.Load += ShowEmployee_Load;
        }

        private void ShowEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                // Get employees in the department excluding managers
                var employees = db.Employees
                    .Where(x => x.DepartmentId == depid && x.Role != "Manager")
                    .ToList();

                // Get department name
                var department = db.Departments.FirstOrDefault(x => x.DepartmentId == depid);
                string departmentName = department?.Name ?? "Unknown Department";

                // Create employee list with department name
                var employeesWithDepartmentName = employees.Select(emp => new
                {
                    ID = emp.EmployeeId,
                    Name = emp.Name,
                    Phone = emp.Phone,
                    Email = emp.Email,
                    Role = emp.Role,
                    Salary = emp.Salary,
                    Department = departmentName
                }).ToList();

                dataGridView1.DataSource = employeesWithDepartmentName;

                // Format the DataGridView
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                // Set column headers
                dataGridView1.Columns["ID"].HeaderText = "ID";
                dataGridView1.Columns["Name"].HeaderText = "Name";
                dataGridView1.Columns["Phone"].HeaderText = "Phone";
                dataGridView1.Columns["Email"].HeaderText = "Email";
                dataGridView1.Columns["Role"].HeaderText = "Role";
                dataGridView1.Columns["Salary"].HeaderText = "Salary";
                dataGridView1.Columns["Department"].HeaderText = "Department";

                // Set column widths
                dataGridView1.Columns["ID"].Width = 80;
                dataGridView1.Columns["Name"].Width = 180;
                dataGridView1.Columns["Phone"].Width = 150;
                dataGridView1.Columns["Email"].Width = 220;
                dataGridView1.Columns["Role"].Width = 120;
                dataGridView1.Columns["Salary"].Width = 120;
                dataGridView1.Columns["Department"].Width = 150;

                // Center align specific columns
                dataGridView1.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Role"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Salary"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Format salary as currency
                dataGridView1.Columns["Salary"].DefaultCellStyle.Format = "C";

                // Make email column fill remaining space
                dataGridView1.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}