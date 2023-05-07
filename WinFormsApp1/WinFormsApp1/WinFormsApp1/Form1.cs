namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Missing Information", "Warning!!", MessageBoxButtons.OK);
            }
            else
            {
                int X = int.Parse(textBox1.Text);
                int Y = int.Parse(textBox2.Text);
                this.Hide();
                Form2 f2 = new Form2(X,Y);
                f2.ShowDialog();
                
            }
        }
    }
}