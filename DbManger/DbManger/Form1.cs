using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace DbManger
{
    public partial class Form1 : Form
    {
        string conexion = "server=localhost;database=BibliotecaDB;user=root;password=;";
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void RegistoLi_Enter(object sender, EventArgs e){ }

        private void ListaLibros_Enter(object sender, EventArgs e){ }

        private void BotonCargarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                string titulo = InTitulo.Text;
                string autor = InAutor.Text;
                int ejemplares = int.Parse(InEjem.Text);

                using (MySqlConnection con = new MySqlConnection(conexion))
                {
                    con.Open();
                    string query = "INSERT INTO Libros (Titulo, Autor, EjemplaresDisponibles) VALUES (@titulo, @autor, @ejemplares)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@autor", autor);
                    cmd.Parameters.AddWithValue("@ejemplares", ejemplares);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Libro cargado exitosamente");
                InTitulo.Clear();
                InAutor.Clear();
                InEjem.Clear();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al cargar el libro: " + ex.Message);

            }
        }
        private void BotonMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (MySqlConnection con = new MySqlConnection(conexion))
                {
                    con.Open();
                    string query = "SELECT LibroID, Titulo, Autor, EjemplaresDisponibles FROM Libros";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                    da.Fill(dataTable);
                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los libros: " + ex.Message);
            }
        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            try 
            {
                int PrestamoID = int.Parse(InIDPres.Text);
                using (MySqlConnection con = new MySqlConnection(conexion))
                {
                    con.Open();
                    string query = "DELETE FROM Prestamos WHERE PrestamoID = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", PrestamoID);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Préstamo eliminado exitosamente");
                InIDPres.Clear();
            }
            catch
            {
                MessageBox.Show("Error al eliminar el préstamo. Asegúrate de ingresar un ID válido.");
            }
        }

        private void InTitulo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
