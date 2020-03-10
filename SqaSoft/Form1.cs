using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqaSoft
{
    public partial class Form1 : Form
    {
        Employee employee = new Employee();
        Parse p = new Parse();
        EmptyString E = new EmptyString();
        CalculateCurrentSalary C = new CalculateCurrentSalary();
        CalculateTotalSalary c = new CalculateTotalSalary();
        

        public Form1()
        {
            InitializeComponent();
            PopulateDataGridView();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
            Clear();
            PopulateDataGridView();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            textName.Text = textAge.Text = textContact.Text = textSalary.Text = textMonth.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            employee.EmployeeID = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure to Delete this Record ?", "EF CRUD Operation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                using (EmployeeDbEntities db = new EmployeeDbEntities())
                {
                    var entry = db.Entry(employee);
                    if (entry.State == EntityState.Detached)
                        db.Employees.Attach(employee);
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    PopulateDataGridView();
                    Clear();
                    MessageBox.Show("Deleted Successfully");
                }

            }
        }

       
            private void btnSave_Click(object sender, EventArgs e)
            {
                if(E.isEmptyString(textName.Text) || E.isEmptyString(textAge.Text) || E.isEmptyString(textSalary.Text) || E.isEmptyString(textMonth.Text) || E.isEmptyString(textContact.Text))
                {
                    MessageBox.Show("You Can't keep empty any field");
                    return; 
                }
                else if(p.TooLong(textAge.Text) || p.TooLong(textSalary.Text) || p.TooLong(textMonth.Text))
                {
                    MessageBox.Show("Invalid Field");
                    return;
                }

               
                employee.Name = textName.Text.Trim();

                int x = p.StringToInt(textAge.Text);

                employee.Age = Convert.ToInt32(x);

                employee.Contact = textContact.Text.Trim();
                
                int y = p.StringToInt(textSalary.Text);
                
                employee.InitialSalary = Convert.ToInt32(y);

                int z = p.StringToInt(textMonth.Text);

                employee.WorkingMonth = Convert.ToInt32(z);
                
                if(x == -1 || y == -1 || z == -1)
                {
                    MessageBox.Show("Wrong Input(Data Type)");
                    return;
                }
                


                using (EmployeeDbEntities db = new EmployeeDbEntities())
                {
                    if (employee.EmployeeID == 0)
                    {
                        db.Employees.Add(employee);
                    }
                    else
                    {
                       db.Entry(employee).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                }

                Clear();
                PopulateDataGridView();
                MessageBox.Show("Submitted Successfully");
            }

            void PopulateDataGridView()
            {
                dgvEmployee.AutoGenerateColumns = true;
                textCurrentSalary.Text = "";
                using (EmployeeDbEntities db = new EmployeeDbEntities())
                {
                    dgvEmployee.DataSource = db.Employees.ToList<Employee>();
                }
            }

       

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEmployee_DoubleClick(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow.Index != -1)
            {
                employee.EmployeeID = Convert.ToInt32(dgvEmployee.CurrentRow.Cells["EmployeeID"].Value);

                using (EmployeeDbEntities db = new EmployeeDbEntities())
                {
                    employee = db.Employees.Where(x => x.EmployeeID == employee.EmployeeID).FirstOrDefault();
                    textName.Text = employee.Name;
                    textContact.Text = employee.Contact;

                    textAge.Text = Convert.ToString(employee.Age);
                    textSalary.Text = Convert.ToString(employee.InitialSalary);
                    textMonth.Text = Convert.ToString(employee.WorkingMonth);
                }

                btnSave.Text = "Update";
                btnDelete.Enabled = true;
                textCurrentSalary.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int initialSalary = Convert.ToInt32(dgvEmployee.CurrentRow.Cells["InitialSalary"].Value);
            int workingMonth = Convert.ToInt32(dgvEmployee.CurrentRow.Cells["WorkingMonth"].Value);

            int workingYear = workingMonth / 12;

            double currentSalary = initialSalary;

            
            int sal = C.Calculate(initialSalary,workingYear);

            textCurrentSalary.Text = Convert.ToString(sal);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lebel2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void btnTotalSalary_Click(object sender, EventArgs e)
        {
            
            using (EmployeeDbEntities db = new EmployeeDbEntities())
            {
                List<Employee> li = db.Employees.ToList<Employee>();

                int ans = c.calculate(li);

                showTotalSalary.Text = Convert.ToString(ans);

                textCurrentSalary.Text = "";
            }
        }
    }
}
