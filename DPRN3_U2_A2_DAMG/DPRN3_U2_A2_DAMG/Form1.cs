using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace DPRN3_U2_A2_DAMG
{
    public partial class Form1 : Form
    {
        string conexion = "server=localhost;database=coworking;user=root;password=;";
        bool cargando = true;

        public Form1()
        {
            InitializeComponent();
        }
        void Combos()
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                con.Open();
                //Tipo de espacio 
                var DTipo = new MySqlDataAdapter("SELECT IDTipoEspacio, TipoEspacio FROM TipoEspacio", con);
                DataTable Tipo = new DataTable();
                DTipo.Fill(Tipo);
                comboBox1.DataSource = Tipo;
                comboBox1.DisplayMember = "TipoEspacio";
                comboBox1.ValueMember = "IDTipoEspacio";

                //Sucursal
                var dSucursal = new MySqlDataAdapter("SELECT IDSucursal, NombreSucursal FROM Sucursal", con);
                DataTable suc = new DataTable();
                dSucursal.Fill(suc);
                comboBox2.DataSource = suc;
                comboBox2.DisplayMember = "NombreSucursal";
                comboBox2.ValueMember = "IDSucursal";
            }
        }
        void EspacioDisponible()
        {
            if (cargando) return;
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1) return;
            DateTime Fecha = dateTimePicker1.Value;
            Fecha = new DateTime(Fecha.Year, Fecha.Month, Fecha.Day, Fecha.Hour, Fecha.Minute, 0);
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                con.Open();
                string sql = @"SELECT e.IDEspacio, e.NombreEspacio FROM Espacio e WHERE e.IDTipoEspacio = @t
                AND e.IDSucursal = @s AND e.IDEspacio NOT IN(SELECT IDEspacio FROM Reservacion WHERE Fecha =@f)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@t", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@s", comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@f", Fecha);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                comboBox3.DataSource = null;
                if (dataTable.Rows.Count > 0)
                {
                    comboBox3.DataSource = dataTable;
                    comboBox3.DisplayMember = "NombreEspacio";
                    comboBox3.ValueMember = "IDEspacio";
                    comboBox3.Enabled = true;
                }
                else
                {
                    comboBox3.Enabled = false;
                }
            }
        }
        int Capacidad(int IDEspacio)
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                con.Open();
                string sql = @"SELECT Capacidad FROM Espacio WHERE IDEspacio = @e";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@e", IDEspacio);
                object result = cmd.ExecuteScalar();
                if (result != null) return Convert.ToInt32(result);
                else return 0;
            }
        }
        void Calendario()
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                con.Open();
                string sql = @"SELECT r.IDReservacion, c.Nombre AS Cliente, e.NombreEspacio,t.TipoEspacio,
                s.NombreSucursal,r.Fecha, r.Comentarios FROM Reservacion r JOIN Cliente c ON r.IDCliente = c.IDCliente
                JOIN Espacio e ON r.IDEspacio = e.IDEspacio JOIN TipoEspacio t ON e.IDTipoEspacio = t.IDTipoEspacio 
                JOIN Sucursal s ON e.IDSucursal =s.IDSucursal";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
        void TES()
        {
            string Tipo = comboBox1.Text;
            if (Tipo.Contains("Sala") ||
                Tipo.Contains("Oficina"))
                numericUpDown1.Visible = true;
            else
                numericUpDown1.Visible = false;
        }
        bool validar()
        {
            if (!Regex.IsMatch(textBox1.Text.Trim(), @"^[a-zA-Z·ÈÌÛ˙¡…Õ”⁄Ò—\s]{3,100}$"))
            {
                MessageBox.Show("El nombre debe de tener mas de 3 caracteres y solo letras");
                return false;
            }
            if (!Regex.IsMatch(textBox2.Text.Trim(), @"^\d{10}$"))
            {
                MessageBox.Show("Se requiere que el telefono tenga 10 digitos numericos ");
                return false;
            }
            if (!Regex.IsMatch(textBox3.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El correo no es valido");
                return false;
            }
            if (dateTimePicker1.Value <= DateTime.Now)
            {
                MessageBox.Show("La fecha y hora deben ser futuras");
                return false;
            }
            if (numericUpDown1.Visible && numericUpDown1.Value <= 0)
            {
                MessageBox.Show("La capacidad debe ser mayor a 0");
                return false;
            }

            if (comboBox1.SelectedIndex == -1 ||
                comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una opcion");
                return false;
            }
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un espacio");
                return false;
            }
            return true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            EspacioDisponible();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Combos();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker1.ShowUpDown = true;
            numericUpDown1.Visible = false;
            radioButton2.Checked = true;
            comboBox3.Enabled = false;
            cargando = false;
            EspacioDisponible();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Calendario();
            dataGridView1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            numericUpDown1.Value = 0;
            radioButton2.Checked = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TES();
            EspacioDisponible();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validar()) return;
            int IDEspacio = Convert.ToInt32(comboBox3.SelectedValue);
            DateTime Fecha = dateTimePicker1.Value;
            Fecha = new DateTime(Fecha.Year, Fecha.Month, Fecha.Day, Fecha.Hour, Fecha.Minute, 0);
            int capcidadS = (int)numericUpDown1.Value;
            int capacidadEs = Capacidad(IDEspacio);
            if (numericUpDown1.Visible && capcidadS > capacidadEs)
            {
                MessageBox.Show($"La capacidad del espacio es de {capacidadEs} personas");
                return;
            }
            try
            {
                using (MySqlConnection con = new MySqlConnection(conexion))
                {
                    con.Open();

                    // Insertar Cliente
                    var cmd = new MySqlCommand(@"INSERT INTO Cliente(Nombre, Telefono, Correo) VALUES (@n,@t,@c); SELECT LAST_INSERT_ID();", con);
                    cmd.Parameters.AddWithValue("@n", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@t", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@c", textBox3.Text.Trim());

                    int IDCliente = Convert.ToInt32(cmd.ExecuteScalar());

                    // Insertar ReservaciÛn
                    var cmdr = new MySqlCommand(@"INSERT INTO Reservacion (IDCliente, IDEspacio, Fecha, Comentarios ,Notificacion) VALUES (@cli, @esp, @f, @com, @not)", con);
                    cmdr.Parameters.AddWithValue("@cli", IDCliente);
                    cmdr.Parameters.AddWithValue("@esp", IDEspacio);
                    cmdr.Parameters.AddWithValue("@f", Fecha);
                    cmdr.Parameters.AddWithValue("@com", textBox4.Text.Trim());
                    cmdr.Parameters.AddWithValue("@not", radioButton1.Checked ? 1 : 0);
                    cmdr.ExecuteNonQuery();
                }
                MessageBox.Show("ReservaciÛn guardada correctamente");
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Ese espacio ya est· reservado en esa fecha y hora.");
                }
                else
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            EspacioDisponible();
        }

    }
}
