using MySql.Data.MySqlClient;
using System.Data;

namespace DPRN3_U2_EA_DAMG
{
    public partial class Form1 : Form
    {
        //Conexión a la base de datos
        string Conexion = "server=localhost; database=SIGA; user=root; password=;";
        //Variables para almacenar las pestañas
        TabPage tabGestionEsudiantes;
        TabPage tabInscripciones;
        TabPage TabServicios;
        TabPage TabFinanzas;
        TabPage tabReportes;
        public Form1()
        {
            InitializeComponent();
        }
        //Métodos para cargar datos en los controles
        private void CargarRoles()
        {
            // Cargar los roles en el ComboBox
            using (MySqlConnection con = new MySqlConnection(Conexion))
            {
                con.Open();
                string sql = "SELECT TipoRol FROM Roles";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                CamRol.Items.Clear();
                while (reader.Read())
                {
                    CamRol.Items.Add(reader["TipoRol"].ToString());
                }
            }
        }
        // Método para cargar estudiantes en el DataGridView
        private void CargarEstudiantes()
        {
            // Cargar los estudiantes en el DataGridView
            using (MySqlConnection con = new MySqlConnection(Conexion))
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM Estudiantes", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataEstudiantes.DataSource = dt;
            }
        }
        // Método para cargar estatus en el ComboBox
        private void CamEstatus()
        {
            // Cargar los estatus en el ComboBox
            using (MySqlConnection con = new MySqlConnection(Conexion))
            {
                con.Open();
                string sql = "SELECT IDEstatus, NombreEstatus FROM Estatus";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Estatus.DataSource = dt;
                Estatus.DisplayMember = "NombreEstatus";
                Estatus.ValueMember = "IDEstatus";
            }
        }
        // Método para cargar tipos de servicios en el ComboBox
        private void CargarServicios()
        {
            // Cargar los tipos de servicios en el ComboBox
            using (MySqlConnection con = new MySqlConnection(Conexion))
            {
                con.Open();
                string sql = "SELECT IDTipoServicio, NombreServicio FROM TipoServicios";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "NombreServicio";
                comboBox1.ValueMember = "IDTipoServicio";

            }
        }
        // Método para cargar estados de servicios en el ComboBox
        private void EstadoServicios()
        {
            // Cargar los estados de servicios en el ComboBox
            using (MySqlConnection con = new MySqlConnection(Conexion))
            {
                con.Open();
                string sql = "SELECT IDEstadoServicio, NombreEstado FROM EstadoServicio";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "NombreEstado";
                comboBox2.ValueMember = "IDEstadoServicio";
            }
        }
        // Evento para el botón de ingreso
        private void button1_Click(object sender, EventArgs e)
        {
            // Validar que el usuario, la contraseña y el rol no estén vacíos
            if (InUsuario.Text == "" || InContraseña.Text == "" || CamRol.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            // Validar que el usuario y la contraseña sean correctos y obtener el rol del usuario
            using (MySqlConnection con = new MySqlConnection(Conexion))
            {
                con.Open();
                string sql = @"SELECT r.TipoRol FROM Usuarios u INNER JOIN Roles r on u.IDRol = r.IDRol
                WHERE u.Usuario =@u AND u.Contraseña=@c";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@u", InUsuario.Text);
                cmd.Parameters.AddWithValue("@c", InContraseña.Text);
                object rol = cmd.ExecuteScalar();
                // Validar que se haya encontrado un rol para el usuario ingresado
                if (rol == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                    return;
                }
                if (CamRol.Text != rol.ToString())
                {
                    MessageBox.Show("El rol seleccionado no coincide con el rol del usuario.");
                    return;
                }
                InUsuario.Visible = false;
                InContraseña.Visible = false;
                CamRol.Visible = false;
                Ingresar.Visible = false;
                Usuario.Visible = false;
                Contraseña.Visible = false;
                Rol.Visible = false;

                tabControl2.Visible = true;
                tabControl2.BringToFront();
                tabControl2.TabPages.Clear();
                switch (rol.ToString())
                {
                    case "Docente":
                        tabControl2.TabPages.Add(tabGestionEsudiantes);
                        tabControl2.SelectedTab = tabGestionEsudiantes;
                        break;
                    case "Administrativo":
                        tabControl2.TabPages.Add(tabGestionEsudiantes);
                        tabControl2.TabPages.Add(tabInscripciones);
                        tabControl2.TabPages.Add(TabServicios);
                        tabControl2.SelectedTab = tabGestionEsudiantes;
                        break;
                    case "Finanzas":
                        tabControl2.TabPages.Add(TabFinanzas);
                        tabControl2.TabPages.Add(tabReportes);
                        tabControl2.SelectedTab = TabFinanzas;
                        break;
                }
            }
        }
        // Evento para cargar datos al iniciar el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CamEstatus();
            CargarServicios();
            EstadoServicios();

            tabGestionEsudiantes = GestionEsudiantes;
            tabInscripciones = InsAgenda;
            TabServicios = Servicios;
            TabFinanzas = Finanzas;
            tabReportes = Reportes;
            tabControl2.TabPages.Clear();
            tabControl2.Visible = false;
            InSub.ReadOnly = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        // Evento para registrar un nuevo estudiante
        private void Registrar_Click(object sender, EventArgs e)
        {
            // Validar que la matricula, el nombre, la carrera y el estatus no estén vacíos
            using (MySqlConnection con = new MySqlConnection(Conexion))
            {
                con.Open();
                string sql = @"INSERT INTO Estudiantes (Matricula, NombreEstudiante, Carrera, IDEstatus) VALUES
                (@m, @n, @c, @e)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@m", InMatricula.Text);
                cmd.Parameters.AddWithValue("@n", InNombre.Text);
                cmd.Parameters.AddWithValue("@c", InCarrera.Text);
                cmd.Parameters.AddWithValue("@e", Estatus.SelectedValue);
                cmd.ExecuteNonQuery();
            }
            CargarEstudiantes();
            MessageBox.Show("Estudiante registrado exitosamente.");

        }
        private void Estatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Evento para registrar una nueva inscripción
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Validar que la matricula, materia y horario no estén vacíos
            if (InsMatri.Text == "" || InsMateria.Text == "" || InsHorario.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            string estatus = "";
            // Validar que la matricula exista y obtener su estatus
            using (MySqlConnection con = new MySqlConnection(Conexion))
            {
                con.Open();
                string sqlEstatus = @"SELECT e.NombreEstatus FROM Estudiantes es INNER JOIN Estatus e ON es.IDEstatus = e.IDEstatus
                WHERE es.Matricula = @m";
                MySqlCommand cmd = new MySqlCommand(sqlEstatus, con);
                cmd.Parameters.AddWithValue("@m", InsMatri.Text);
                object res = cmd.ExecuteScalar();
                if (res == null)
                {
                    MessageBox.Show("La matricula no existe");
                    return;
                }
                estatus = res.ToString();
            }
            // Validar que el estatus del estudiante sea activo para poder inscribirse
            if (estatus != "Activo")
            {
                MessageBox.Show("El estudiante no tiene estatus activo para inscribirse");
                return;
            }
            // Registrar la inscripción en la base de datos
            using (MySqlConnection con = new MySqlConnection(Conexion))
            {
                con.Open();
                string sql = @"INSERT INTO Inscripciones (Matricula, Materia, Horario) VALUES (@m, @ma, @h)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@m", InsMatri.Text);
                cmd.Parameters.AddWithValue("@ma", InsMateria.Text);
                cmd.Parameters.AddWithValue("@h", InsHorario.Text);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Inscripción registrada exitosamente.");
        }
        // Evento para registrar un nuevo pago
        private void GuardarPago_Click(object sender, EventArgs e)
        {
            // Validar que la matricula y el total sean correctos
            if (MatriculaPago.Text == "")
            {
                MessageBox.Show("Por favor, ingrese una matricula.");
                return;
            }
            // Validar que el total calculado sea un número válido y mayor a cero
            if (!decimal.TryParse(TextTotal.Text, out decimal Total) || Total <= 0)
            {
                MessageBox.Show("El total calculado no es válido. Por favor, revise los cálculos.");
                return;
            }
            // Validar que la matricula exista
            using (MySqlConnection con = new MySqlConnection(Conexion))
            {
                con.Open();
                string sql = @"INSERT INTO Pagos (Matricula, SubTotal,IVA, ISR, Total, Fecha)
                VALUES (@m, @s, @i, @r, @t, CURDATE())";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@m", MatriculaPago.Text);
                cmd.Parameters.AddWithValue("@s", Convert.ToDecimal(InSub.Text));
                cmd.Parameters.AddWithValue("@i", Convert.ToDecimal(TexIva.Text));
                cmd.Parameters.AddWithValue("@r", Convert.ToDecimal(TextISR.Text));
                cmd.Parameters.AddWithValue("@t", Convert.ToDecimal(TextTotal.Text));
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Pago Registrado");
        }
        
        private void FechIn_Click(object sender, EventArgs e)
        {

        }
        // Evento para calcular el total a pagar
        private void button1_Click_2(object sender, EventArgs e)
        {
            decimal SubTotal = 0;
            decimal TotalAdmin = 0;
            // Validar que la matricula sea correcta
            if (MatriculaPago.Text == "")
            {
                MessageBox.Show("Por favor, ingrese una matricula.");
                return;
            }
            // Obtener el subtotal y el total de servicios administrativos para la matricula ingresada
            using (MySqlConnection con = new MySqlConnection(Conexion))
            {
                con.Open();
                string sql = @"SELECT IFNULL(SUM(Costo),0) AS SubTotal, IFNULL (SUM(CASE WHEN ClaficacionServicio=1
                THEN Costo ELSE 0 END),0) AS TotalAdmin FROM Servicios WHERE Matricula = @m";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@m", MatriculaPago.Text);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        SubTotal = Convert.ToDecimal(dr["SubTotal"]);
                        TotalAdmin = Convert.ToDecimal(dr["TotalAdmin"]);
                    }
                }
            }
            // Validar que la matricula tenga servicios registrados
            if (SubTotal == 0)
            {
                MessageBox.Show("La matricula no tiene servicios registrados");
                return;
            }
            InSub.Text = SubTotal.ToString("0.00");
            decimal IVA = 0;
            decimal ISR = 0;
            decimal Total = 0;
            // Calcular el IVA, ISR y total a pagar dependiendo de los servicios registrados y si el estudiante tiene beca
            if (CheckAdmin.Checked)
            {
                IVA = TotalAdmin * 0.16m;
            }
            if (checkbeca.Checked)
            {
                Total = SubTotal * 0.09m;
                IVA = 0;
                ISR = 0;
            }
            else
            {
                ISR = SubTotal * 0.10m;
                Total = SubTotal + IVA + ISR;
            }
            TexIva.Text = IVA.ToString("0.00");
            TextISR.Text = ISR.ToString("0.00");
            TextTotal.Text = Total.ToString("0.00");
        }
        // Evento para generar un reporte de pagos entre dos fechas
        private void GenerarRepor_Click(object sender, EventArgs e)
        {
            // Validar que las fechas sean correctas
            using (MySqlConnection con = new MySqlConnection(Conexion))
            {
                string sql = @"SELECT Fecha, COUNT(*) AS CantidadPagos, SUM(Total) AS TotalIngresos FROM Pagos WHERE
                Fecha BETWEEN @inicio AND @fin";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@inicio", DateInicio.Value.Date);
                da.SelectCommand.Parameters.AddWithValue("@fin", DateFin.Value.Date);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataReportes.DataSource = dt;
            }
        }
        private void DateInicio_ValueChanged(object sender, EventArgs e)
        {

        }
        // Evento para registrar un nuevo servicio para un estudiante
        private void RegistrarSer_Click(object sender, EventArgs e)
        {
            // Validar que se hayan seleccionado un servicio, un estado y que la matricula no esté vacía
            if (textBox1.Text == "" || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            bool esAdmin = false;
            decimal costo = 0;
            // Obtener la información del servicio seleccionado
            using (MySqlConnection con = new MySqlConnection(Conexion))
            {
                con.Open();
                string sqlT = @"SELECT EsAdministrativo, Costo FROM TipoServicios WHERE IDTipoServicio = @id";
                MySqlCommand cmdT = new MySqlCommand(sqlT, con);
                cmdT.Parameters.AddWithValue("@id", comboBox1.SelectedValue);
                using (MySqlDataReader dr = cmdT.ExecuteReader())
                {
                    // Validar que se haya encontrado el servicio seleccionado
                    if (dr.Read())
                    {
                        esAdmin = Convert.ToBoolean(dr["EsAdministrativo"]);
                        costo = Convert.ToDecimal(dr["Costo"]);
                    }
                    else
                    {
                        MessageBox.Show("No se encontro el servicio selecionado");
                        return;
                    }
                }
            }
            // Verificar que la matricula exista
            using (MySqlConnection con = new MySqlConnection(Conexion))
            {
                con.Open();
                string sqlI = @"INSERT INTO Servicios (Matricula, Tipo, ClaficacionServicio, Costo, Estado) VALUES
                (@m, @t, @c,@co, @e)";
                MySqlCommand cmdI = new MySqlCommand(sqlI, con);
                cmdI.Parameters.AddWithValue("@m", textBox1.Text);
                cmdI.Parameters.AddWithValue("@t", comboBox1.Text);
                cmdI.Parameters.AddWithValue("@c", esAdmin);
                cmdI.Parameters.AddWithValue("@co", costo);
                cmdI.Parameters.AddWithValue("@e", comboBox2.Text);
                cmdI.ExecuteNonQuery();
            }
            MessageBox.Show("Servicio registrado exitosamente.");
        }
    }
}
