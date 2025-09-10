using M2Corte2025.FormationFred.Services;

namespace M2Corte2025.FormationFred.Ihm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Factory.Instance?.GetAll();
        }
    }
}
