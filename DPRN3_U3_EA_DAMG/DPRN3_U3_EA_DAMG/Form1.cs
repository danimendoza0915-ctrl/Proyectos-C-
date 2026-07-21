using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace DPRN3_U3_EA_DAMG
{
    public partial class Form1 : Form
    {
        //conexion a la base de datos
        private string conexion = "server=localhost; database=AeroAssit; user=root; password=;";

        private int IDAgente = 1;
        public Form1()
        {
            InitializeComponent();
        }
        //metodo para mostrar las alertas en el datagridview
        private void MostrarAlertas()
        {
            //conexion a la base de datos y consulta para obtener las alertas no resueltas
            using var con = new MySqlConnection(conexion);
            var da = new MySqlDataAdapter("SELECT Descripcion, Zona, Nivel FROM Incidentes WHERE Resuelto=0  ", con);
            var dt = new DataTable();
            da.Fill(dt);
            DataAlertas.DataSource = dt;
        }
        //metodo para mostrar los vuelos en el datagridview
        private void MostrarVuelos()
        {
            //conexion a la base de datos y consulta para obtener los vuelos
            using var con = new MySqlConnection(conexion);
            var da = new MySqlDataAdapter("SELECT NumeroVuelo, Destino, Puerta, Horario, Estatus FROM Vuelos", con);
            var dt = new DataTable();
            da.Fill(dt);
            DataVuelos.DataSource = dt;
        }
        //metodo para mostrar las tareas en el datagridview
        private void MostrarTareas()
        {
            //conexion a la base de datos y consulta para obtener las tareas del agente
            using var con = new MySqlConnection(conexion);
            var da = new MySqlDataAdapter("SELECT IDTarea,Descripcion, Prioridad, Estado FROM Tareas WHERE IDAgente= 1 AND Estado ='Pendiente'", con);
            var dt = new DataTable();
            da.Fill(dt);
            DataTareas.DataSource = dt;
        }
        //metodo para actualizar la informacion en los datagridview
        private void Actualizar()
        {
            //llama a los metodos para mostrar las alertas, vuelos y tareas
            MostrarAlertas();
            MostrarVuelos();
            MostrarTareas();
            MotorML();
            DAnomalias();

        }
        //evento que se ejecuta al cargar el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            //llama al metodo para actualizar la informacion al cargar el formulario
            Actualizar();
        }
        //metodo que implementa un motor de recomendaciones basico basado en las alertas y vuelos
        private void MotorML()
        {
            //limpia las sugerencias anteriores
            Sugerencias.Items.Clear();
            int VIncidentes = 0;
            int VVuelos = 0;
            string MensajeIncidentes = "";
            string MensajeeVuelos = "";

            //analiza las alertas para asignar puntos segun el nivel de la alerta
            foreach (DataGridViewRow Fila in DataAlertas.Rows)
            {
                //si el nivel de la alerta es alto, se asignan 50 puntos, si es medio 25 puntos y si es bajo 13 puntos
                if (Fila.Cells["Nivel"].Value == null) continue;
                string Nivel = Fila.Cells["Nivel"].Value.ToString();
                if (Nivel == "Alto") VIncidentes += 50;
                else if (Nivel == "Medio") VIncidentes += 25;
                else if (Nivel == "Bajo") VIncidentes += 13;
            }
            //analiza los vuelos para asignar puntos por cada vuelo retrasado
            foreach (DataGridViewRow Fila in DataVuelos.Rows)
            {
                if (Fila.Cells["Estatus"].Value?.ToString() == "Retrasado") VVuelos += 60;
            }
            using var con = new MySqlConnection(conexion);
            con.Open();
            //si se han asignado puntos por incidentes, se genera una recomendacion para priorizar la atencion en las zonas afectadas
            if (VIncidentes > 0)
            {

                MensajeIncidentes = $"Se han reportado {VIncidentes} puntos de incidentes puntos. Se recomienda priorizar la atención en las zonas afectadas.";
                Sugerencias.Items.Add(MensajeIncidentes);

                var cmd = new MySqlCommand(@"INSERT INTO Recomendaciones (IDAgente, Mensaje, Valor) VALUES
                (@id, @m, @s)", con);
                cmd.Parameters.AddWithValue("@id", IDAgente);
                cmd.Parameters.AddWithValue("@m", MensajeIncidentes);
                cmd.Parameters.AddWithValue("@s", VIncidentes);
                cmd.ExecuteNonQuery();
            }
            //si se han asignado puntos por vuelos retrasados, se genera una recomendacion para coordinar con el personal de tierra para gestionar los retrasos
            if (VVuelos > 0)
            {
                MensajeeVuelos = $"Se han detectado {VVuelos} puntos por vuelos retrasado puntos. Se recomienda coordinar con el personal de tierra para gestionar los retrasos.";
                Sugerencias.Items.Add(MensajeeVuelos);

                var cmd = new MySqlCommand(@"INSERT INTO Recomendaciones (IDAgente, Mensaje, Valor) VALUES
                (@id, @m, @s)", con);
                cmd.Parameters.AddWithValue("@id", IDAgente);
                cmd.Parameters.AddWithValue("@m", MensajeeVuelos);
                cmd.Parameters.AddWithValue("@s", VVuelos);
                cmd.ExecuteNonQuery();
            }
            //si no se han asignado puntos por incidentes ni por vuelos retrasados, se genera una recomendacion indicando que la operacion es estable
            if (VIncidentes == 0 && VVuelos == 0)
            {
                Sugerencias.Items.Add("Operacion estable");
            }
        }
        //metodo para detectar anomalias basico que alerta al agente si se detecta una alerta de nivel alto
        private void DAnomalias()
        {
            int incidentesA = 0;
            //analiza las alertas para contar cuantas alertas de nivel alto hay
            foreach (DataGridViewRow Fila in DataAlertas.Rows)
            {
                if (Fila.Cells["Nivel"].Value?.ToString() == "Alto") incidentesA++;
            }
            //si se detecta al menos una alerta de nivel alto, se muestra un mensaje de alerta al agente
            if (incidentesA > 0)
            {
                MessageBox.Show($"Anomalia detectada", "Alerta IA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //evento que se ejecuta al hacer clic en el boton de actualizar
        private void button1_Click(object sender, EventArgs e)
        {
            //llama al metodo para actualizar la informacion en los datagridview
            Actualizar();
        }
        //evento que se ejecuta al hacer clic en el boton de asignar tarea
        private void BotonAsignar_Click(object sender, EventArgs e)
        {
            //si el campo de texto para la nueva tarea esta vacio, no se asigna la tarea
            if (string.IsNullOrWhiteSpace(TextNuevaTarea.Text)) return;
            string Descripcion = TextNuevaTarea.Text.ToLower();
            string Prioridad = "Normal";
            //analiza la descripcion de la tarea para asignar una prioridad segun las palabras clave que se encuentren en la descripcion
            if (Descripcion.Contains("urgente") || Descripcion.Contains("inmediato") ||
                Descripcion.Contains("discapacidad") || Descripcion.Contains("emergencia"))
            {
                Prioridad = "Alta";
            }
            //si se encuentran palabras clave relacionadas con la rapidez, el equipaje, la puerta o el abordaje, se asigna una prioridad media
            else if (Descripcion.Contains("pronto") || Descripcion.Contains("rápido") ||
                     Descripcion.Contains("equipaje") || Descripcion.Contains("puerta") ||
                     Descripcion.Contains("abordaje"))
            {
                Prioridad = "Media";

            }
            //si se encuentran palabras clave relacionadas con consultas, informacion o preguntas, se asigna una prioridad baja
            else if (Descripcion.Contains("consulta") || Descripcion.Contains("informacion") ||
                     Descripcion.Contains("Preguntas"))
            {
                Prioridad = "Baja";
            }
            //conexion a la base de datos y consulta para insertar la nueva tarea asignada al agente con la prioridad determinada
            using var con = new MySqlConnection(conexion);
            con.Open();
            var cmd = new MySqlCommand(@"INSERT INTO Tareas (IDAgente, Descripcion, Prioridad, Estado) VALUES
            (@id, @d, @p, 'Pendiente')", con);
            cmd.Parameters.AddWithValue("@id", IDAgente);
            cmd.Parameters.AddWithValue("@d", TextNuevaTarea.Text);
            cmd.Parameters.AddWithValue("@p", Prioridad);
            cmd.ExecuteNonQuery();
            MessageBox.Show($"Tarea asignada con prioridad {Prioridad}");
            TextNuevaTarea.Clear();
            MostrarTareas();
        }
        //evento que se ejecuta al hacer clic en el boton de completar tarea
        private void BotonComple_Click(object sender, EventArgs e)
        {
            //si no se ha seleccionado ninguna tarea en el datagridview, no se completa ninguna tarea
            if (DataTareas.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(DataTareas.SelectedRows[0].Cells["IDTarea"].Value);
            using var con = new MySqlConnection(conexion);
            con.Open();
            var cmd = new MySqlCommand("UPDATE Tareas SET Estado='Completada' WHERE IDTarea=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MostrarTareas();
        }
        //evento que se ejecuta al hacer clic en el boton de resolver alerta
        private void BotonResolver_Click(object sender, EventArgs e)
        {
            //  si no se ha seleccionado ninguna alerta en el datagridview, no se resuelve ninguna alerta
            if (DataAlertas.SelectedRows.Count ==0) return;
            string descripcion = DataAlertas.SelectedRows[0].Cells["Descripcion"].Value.ToString();
            using var con = new MySqlConnection(conexion);
            con.Open();
            var cmd = new MySqlCommand("UPDATE Incidentes SET Resuelto=1 WHERE Descripcion=@d", con);
            cmd.Parameters.AddWithValue("@d", descripcion);
            cmd.ExecuteNonQuery();
            MostrarAlertas();
        }
    }
}
