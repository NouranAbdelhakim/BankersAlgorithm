using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        public int X = new int();
        public int Y = new int();
        public DataTable table1 = new DataTable();
        public DataTable table2 = new DataTable();
        public DataTable table3 = new DataTable();
        public DataTable table4 = new DataTable();
        public DataTable amount = new DataTable();

        public Form3(int X, int Y, DataTable table1, DataTable table2, DataTable table3, DataTable table4)
        {
            InitializeComponent();
            //textBox4.Text = table2.Rows[0][1].ToString();
            this.X = X;
            this.Y = Y;
            this.table1 = table1;
            this.table2 = table2;
            this.table3 = table3;
            this.table4 = table4;
        }
        public void Form3_Load(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Missing Information", "Warning!!", MessageBoxButtons.OK);
            }
            else
            {
                int Proc_req = int.Parse(textBox1.Text);


                this.Hide();
                Form4 f4 = new Form4(Proc_req, amount, X, Y, table1, table2, table3, table4);
                f4.ShowDialog();
            }
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            for (int col = 1; col <= Y; col++)
            {
                string columnName = "Resource " + col;
                amount.Columns.Add(columnName, typeof(string));
            }
            DataRow dataRow = amount.NewRow();
            for (int col = 1; col <= Y; col++)
            {
                // Prompt the user to enter a value for the current cell
                string cellValue = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter a value for Recource " + col,
                    "Enter Cell Value",
                    "");
                while (cellValue == "")
                {
                    MessageBox.Show("Missing Value In ToTal Resources Table", "Warning!!", MessageBoxButtons.OK);
                    cellValue = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter a value for Recource " + col,
                    "Enter Cell Value", "");

                }

                // Set the value of the current cell to the user's input
                dataRow[col - 1] = cellValue;
            }
            amount.Rows.Add(dataRow);
            dataGridView1.DataSource = amount;
        }

        
    }
}
