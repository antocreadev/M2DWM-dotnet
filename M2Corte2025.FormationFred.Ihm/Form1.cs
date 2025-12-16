using Flurl.Http;
using M2Corte2025.FormationFred.DataContracts;
using Newtonsoft.Json;

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

        private async void button1_Click_1(object sender, EventArgs e)
        {
            var url = "http://localhost:5204/api/Recipes";
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                dataGridView1.DataSource = await url.GetJsonAsync<List<Recipe>>();
                //dataGridView1.DataSource = Factory.Instance?.GetAll();
            }
            else
            {
                //dataGridView1.DataSource = Factory.Instance?.GetByTitle(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var recipes = Factory.Instance?.GetAll();

            //var json = JsonConvert.SerializeObject(recipes);

            //using (var sw = File.CreateText("recipes.json"))
            //{
            //    sw.WriteLine(json);
            //}       
        }
    }
}
