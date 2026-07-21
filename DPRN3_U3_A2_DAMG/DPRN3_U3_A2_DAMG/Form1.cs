using MySql.Data.MySqlClient;
using System.Data;

namespace DPRN3_U3_A2_DAMG
{
    public partial class Form1 : Form
    {
        string conexion = "server=localhost; database=Vizcaya; user=root; password=;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT e.Nombre AS Estudiantes, m.Materia AS Materia, c.Calificacion AS Calificacion
            FROM Calificaciones c INNER JOIN Estudiantes e ON c.IDEstudiante = e.IDEstudiante INNER JOIN Materias m
            ON c.IDMateria  = m.IDMateria";

            DataSet dataSet = new DataSet();
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(dataSet, "Form1");
            }
            dataGridView1.DataSource = dataSet.Tables["Form1"];

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
