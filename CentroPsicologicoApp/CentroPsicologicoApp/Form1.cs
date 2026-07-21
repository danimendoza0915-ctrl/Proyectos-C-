using MySql.Data.MySqlClient;

namespace CentroPsicologicoApp
{
    public partial class Form1 : Form
    {
        string Conexion = "server=localhost;database=CentroPsicologicoDB;user=root;password=;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(Conexion);
                conexion.Open();
                MessageBox.Show("Conexion Exitosa");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Conexion: " + ex.Message);
            }

        }
    }
}
