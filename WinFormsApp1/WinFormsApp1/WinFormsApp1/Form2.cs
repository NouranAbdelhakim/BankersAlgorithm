using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public int X;
        public int Y;
        public DataTable table1 = new DataTable();
        public DataTable table2 = new DataTable();
        public DataTable table3 = new DataTable();
        public DataTable table4 = new DataTable();


        public Form2(int X, int Y)
        {
            InitializeComponent();
            this.X = X;
            this.Y = Y;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            // Create a new DataTable object

            // Add column for row number
            table1.Columns.Add(" ", typeof(string));

            // Dynamically add c//olumns to the DataTable based on user input

            for (int col = 1; col <= Y; col++)
            {
                string columnName = "Resource " + col;
                table1.Columns.Add(columnName, typeof(string));
            }

            // Dynamically add rows to the DataTable based on user input

            for (int row = 1; row <= X; row++)
            {
                DataRow dataRow = table1.NewRow();

                // Set the row number
                dataRow[0] = "Process " + row;

                for (int col = 1; col <= Y; col++)
                {
                    // Prompt the user to enter a value for the current cell
                    string cellValue = Microsoft.VisualBasic.Interaction.InputBox(
                        "Enter a value for Process " + row + " ,Resource " + col,
                        "Enter Cell Value",
                        "");
                    while (cellValue == "")
                    {
                        MessageBox.Show("Missing Value In Allocation Table", "Warning!!", MessageBoxButtons.OK);
                        cellValue = Microsoft.VisualBasic.Interaction.InputBox(
                        "Enter a value for Process " + row + " ,Resource " + col,
                        "Enter Cell Value",
                        "");

                    }
                    // Set the value of the current cell to the user's input
                    dataRow[col] = cellValue;
                }
                table1.Rows.Add(dataRow);
            }

            // Display the populated DataTable in the DataGridView
            dataGridView1.DataSource = table1;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            // Create a new DataTable object
            // DataTable table2 = new DataTable();

            // Add column for row number
            table2.Columns.Add(" ", typeof(string));

            // Dynamically add c//olumns to the DataTable based on user input

            for (int col = 1; col <= Y; col++)
            {
                string columnName = "Resource " + col;
                table2.Columns.Add(columnName, typeof(string));
            }

            // Dynamically add rows to the DataTable based on user input

            for (int row = 1; row <= X; row++)
            {
                DataRow dataRow = table2.NewRow();

                // Set the row number
                dataRow[0] = "Process " + row;

                for (int col = 1; col <= Y; col++)
                {
                    // Prompt the user to enter a value for the current cell
                    string cellValue = Microsoft.VisualBasic.Interaction.InputBox(
                        "Enter a value for Process " + row + " ,Resource " + col,
                        "Enter Cell Value",
                        "");
                    while (cellValue == "")
                    {
                        MessageBox.Show("Missing Value In Maximum Allocation Table", "Warning!!", MessageBoxButtons.OK);
                        cellValue = Microsoft.VisualBasic.Interaction.InputBox(
                        "Enter a value for Process " + row + " ,Resource " + col,
                        "Enter Cell Value",
                        "");

                    }
                    // Set the value of the current cell to the user's input
                    dataRow[col] = cellValue;
                }
                table2.Rows.Add(dataRow);
            }

            // Display the populated DataTable in the DataGridView
            dataGridView2.DataSource = table2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void button3_Click(object sender, EventArgs e)
        {
            // Create a new DataTable object
            //DataTable table3 = new DataTable();
            for (int col = 1; col <= Y; col++)
            {
                string columnName = "Resource " + col;
                table3.Columns.Add(columnName, typeof(string));
            }
            DataRow dataRow = table3.NewRow();
            for (int col = 1; col <= Y; col++)
            {
                // Prompt the user to enter a value for the current cell
                string cellValue = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter a value for Recource " + col,
                    "Enter Cell Value",
                    "");
                while (cellValue == "")
                {
                    MessageBox.Show("Missing Value In Maximum Available Table", "Warning!!", MessageBoxButtons.OK);
                    cellValue = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter a value for Recource " + col,
                    "Enter Cell Value", "");

                }

                // Set the value of the current cell to the user's input
                dataRow[col - 1] = cellValue;
            }
            table3.Rows.Add(dataRow);
            dataGridView3.DataSource = table3;

        }

        public void button4_Click(object sender, EventArgs e)
        {
            // Create a new DataTable object
            // DataTable table4 = new DataTable();
            for (int col = 1; col <= Y; col++)
            {
                string columnName = "Resource " + col;
                table4.Columns.Add(columnName, typeof(string));
            }
            DataRow dataRow = table4.NewRow();
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
            table4.Rows.Add(dataRow);
            dataGridView4.DataSource = table4;

        }

        public void button5_Click(object sender, EventArgs e)
        {
            if (table4.Rows.Count == 0 || table3.Rows.Count == 0 || table2.Rows.Count == 0 || table1.Rows.Count == 0)
            {
                MessageBox.Show("Missing Table", "Warning!!", MessageBoxButtons.OK);

            }
            else
            {
                this.Hide();
                Form3 f3 = new Form3(X, Y, table1, table2, table3, table4);
                f3.ShowDialog();
            }
        }
    }
}

