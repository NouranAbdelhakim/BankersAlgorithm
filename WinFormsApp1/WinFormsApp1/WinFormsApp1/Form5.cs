using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        public int Proc_req = new int();
        public DataTable amount = new DataTable();
        public int X = new int();
        public int Y = new int();
        public DataTable table1 = new DataTable();
        public DataTable table2 = new DataTable();
        public DataTable table3 = new DataTable();
        public DataTable table4 = new DataTable();
        public DataTable needed = new DataTable();
      //  public DataTable work = new DataTable();
        public bool[] check;
        public int[] seq;
        public int s = 0;
        public int l = 0;

        string str = "Process";
        public Form5(int Proc_req, DataTable amount, int X, int Y, DataTable table1,
            DataTable table2, DataTable table3, DataTable table4, DataTable needed)
        {
            InitializeComponent();
            this.Proc_req = Proc_req;
            this.amount = amount;
            this.X = X;
            this.Y = Y;
            this.table1 = table1;
            this.table2 = table2;
            this.table3 = table3;
            this.table4 = table4;
            this.needed = needed;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dataRow2 = table3.NewRow();
           
            for (int i = 0; i < Y; i++)
            {

                table3.Rows[0][i] = (int.Parse(table3.Rows[0][i].ToString()) - int.Parse(amount.Rows[0][i].ToString())).ToString();
                table1.Rows[Proc_req - 1][i + 1] = (int.Parse(table1.Rows[Proc_req - 1][i + 1].ToString()) + int.Parse(amount.Rows[0][i].ToString())).ToString();
                needed.Rows[Proc_req - 1][i + 1] = (int.Parse(needed.Rows[Proc_req - 1][i + 1].ToString()) - int.Parse(amount.Rows[0][i].ToString())).ToString();
            }
    
            dataGridView1.DataSource = table1;
            dataGridView2.DataSource = table3;
            dataGridView3.DataSource = needed;
            DataTable work = table3.Clone();
            work.Rows.Clear();

            // iterate through each row of table3
            foreach (DataRow row in table3.Rows)
            {
                // create a new DataRow
                DataRow newRow = work.NewRow();

                // copy the values from the old row to the new row
                for (int i = 0; i < table3.Columns.Count; i++)
                {
                    newRow[i] = row[i];
                }

                // add the new row to the new DataTable
                work.Rows.Add(newRow);
            }
            check = new bool[X];
            seq = new int[X];

            for (int i = 0; i < X; i++)
            {
                check[i] = false;
            }
            for (int k = 0; k < X; k++)
            {

                for (int i = 0; i < X; i++)
                {
                    if (check[i] == false)
                    {
                        int Flag = 0;
                        for (int j = 0; j < Y; j++)
                        {

                            if (int.Parse(work.Rows[l][j].ToString()) < int.Parse(needed.Rows[i][j + 1].ToString()))
                            {
                                Flag = 1;
                                break;
                            }
                        }
                        if (Flag == 0)
                        {
                            check[i] = true;
                            seq[s++] = i + 1;
                            DataRow dataRow1 = work.NewRow();
                            int val;

                            for (int m = 0; m < Y; m++)
                            {
                                val = int.Parse(work.Rows[l][m].ToString()) + int.Parse(table1.Rows[i][m + 1].ToString());
                                dataRow1[m] = val;
                               

                            }
                            work.Rows.Add(dataRow1);
                          
                            l++;

                        }
                    }

                }
            }
            dataGridView4.DataSource = work;
            int f = 1;

            for (int i = 0; i < X; i++)
            {
                
                if (check[i] == false )
                {
                    str = " The following system is not safe";
                    label6.Text = str;
                    f = 0;
                    break;
                }
            }
            if (f == 1)
            {

                for (int i = 0; i < Y; i++)
                {

                    if (table4.Rows[0][i].ToString() != work.Rows[X][i].ToString())
                    {
                        str = " The following system is not safe it's not equal the Total Resource";
                        label6.Text = str;
                        f = 0;
                        break;
                    }
                }
            }

            if (f == 1)
            {
                str = "Following is the SAFE Sequence:\n";
                for (int i = 0; i < X - 1; i++)
                {
                    str += "Process" + seq[i] + "->";
                }
                str += "Process" + seq[X - 1];
                label6.Text = str;
            }

        }
    }
}
