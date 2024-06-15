namespace DynamicsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await DynamicsClient.Accounts.GetCollectionAsync();
        }
    }
}
