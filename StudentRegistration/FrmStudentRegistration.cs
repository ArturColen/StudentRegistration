using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistration
{
    public partial class FrmStudentRegistration : Form
    {
        public FrmStudentRegistration()
        {
            InitializeComponent();
        }

        StudentConnection db = new StudentConnection();

        // Enter data into the database
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string insert;
            int test;
            string unit = rdbBarroca.Checked ? "Barroca" : "Floresta";
            string serie = rdbFirst.Checked ? "1ª" : rdbSecond.Checked ? "2ª" : "3ª";
            string classes = cbxClasses.Text;

            if (txtName.Text != "" && int.TryParse(txtAge.Text, out test) && (rdbBarroca.Checked || rdbFloresta.Checked != false) && (rdbFirst.Checked || rdbSecond.Checked || rdbThird.Checked != false) && cbxClasses.Text != "")
            {
                insert = String.Format("insert into students (name, age, unit, serie, class) values ('{0}', '{1}', '{2}', '{3}', '{4}')", txtName.Text, txtAge.Text, unit, serie, classes);
                db.executeCommands(insert);
                txtName.Clear();
                txtAge.Clear();
                rdbBarroca.Checked = false;
                rdbFloresta.Checked = false;
                rdbFirst.Checked = false;
                rdbSecond.Checked = false;
                rdbThird.Checked = false;
                cbxClasses.Text = "";
                txtName.Focus();
            }
            else
            {
                MessageBox.Show("Informação Inválida!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Change the data of the database
        private void btnChange_Click(object sender, EventArgs e)
        {
            string change;
            string unit = rdbBarroca.Checked ? "Barroca" : "Floresta";
            string serie = rdbFirst.Checked ? "1ª" : rdbSecond.Checked ? "2ª" : "3ª";
            string classes = cbxClasses.Text;

            if (txtName.Text != "")
            {
                change = string.Format("update students set name = '{0}', age = '{1}', unit = '{2}', serie = '{3}', class = '{4}' where id = '{5}'", txtName.Text, txtAge.Text, unit, serie, classes, txtID.Text);
                db.executeCommands(change);

            }
            else
            {
                MessageBox.Show("Informação inválida", "Confirmação ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Show database data to the user
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string select = "select * from students order by name";
            DataTable dt = db.executeQuery(select);
            dt.AsDataView();
            dtgStudent.DataSource = dt;
        }

        // Method for closing the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Delete user data
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string delete;

            if (txtName.Text != "")
            {
                delete = string.Format("delete from students where id = '{0}'", txtID.Text);
                db.executeCommands(delete);
                txtID.Clear();
                txtName.Clear();
                txtAge.Clear();
                rdbBarroca.Checked = false;
                rdbFloresta.Checked = false;
                rdbFirst.Checked = false;
                rdbSecond.Checked = false;
                rdbThird.Checked = false;
                cbxClasses.Text = "";
                txtName.Focus();
            }
            else
            {
                MessageBox.Show("Informação inválida!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Insert the data from the database into the form fields
        private void dtgStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dtgStudent.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dtgStudent.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtAge.Text = dtgStudent.Rows[e.RowIndex].Cells[2].Value.ToString();
            string unit = dtgStudent.Rows[e.RowIndex].Cells[3].Value.ToString();
            string serie = dtgStudent.Rows[e.RowIndex].Cells[4].Value.ToString();
            cbxClasses.Text = dtgStudent.Rows[e.RowIndex].Cells[5].Value.ToString();

            if (unit == "Barroca")
            {
                rdbBarroca.Checked = true;
            }
            else
            {
                rdbFloresta.Checked = true;
            }

            if (serie == "1ª")
            {
                rdbFirst.Checked = true;
            }
            else if(serie == "2ª")
            {
                rdbSecond.Checked = true;
            }
            else
            {
                rdbThird.Checked = true;
            }
        }
    }
}
