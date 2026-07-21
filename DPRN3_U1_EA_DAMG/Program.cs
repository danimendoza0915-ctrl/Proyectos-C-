//DANIEL MENDOZA GUTIERREZ ES231109257
using System;
using MySql.Data.MySqlClient;

class Programa
{
    //Es la cadena principal la cual nos permitep pdoer realizar la conexioon con la base de datos 
    static string conexion = "server=localhost;database=TecnoFix;user=root;password=;";

    //Dentro de este metodo podrmeos realizar la captura de los datos de los clientes
    static void RegistroClientes()
    {
        Console.WriteLine("\n====================== Registro de Cliente ======================");
        Console.WriteLine("=================== Datos y direccion del Cliente ==================");
        Console.Write("Nombre completo del Cliente: ");
        string NombreCLi = Console.ReadLine();
        Console.Write("Nombre de la calle: ");
        string CalleCli = Console.ReadLine();
        Console.Write("Numero: ");
        string NumeroCli = Console.ReadLine();
        Console.Write("Colonia: ");
        string coloniaCli = Console.ReadLine();
        Console.Write("Codigo Postal: ");
        string CPCli = Console.ReadLine();
        Console.Write("Telefono: ");
        string TelefonoCli = Console.ReadLine();
        Console.WriteLine("======================================================================");
        //Se realiza la conexion con la base de datos
        using (MySqlConnection conn = new MySqlConnection(conexion))
        {
            try
            {
                conn.Open();
                string sql = @"INSERT INTO Clientes (NombreCompleto, Calle, Numero, Colonia, CodigoPostal, telefono) 
                VALUES (@NC, @Ca, @Nu, @Co, @CP, @Te)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NC", NombreCLi);
                cmd.Parameters.AddWithValue("@Ca", CalleCli);
                cmd.Parameters.AddWithValue("@Nu", NumeroCli);
                cmd.Parameters.AddWithValue("@Co", coloniaCli);
                cmd.Parameters.AddWithValue("@CP", CPCli);
                cmd.Parameters.AddWithValue("@Te", TelefonoCli);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Se realizo el registrtro de forma correcta");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eror al guardar los datos: " + ex.Message);
            }
        }

    }
    //Dentro de este metodo podremos realziar la busqueda de los clientes que se encuentren registrados dentro de la base de datos
    static void BuscarCliente()
    {
        Console.WriteLine("\n======================= Bucar clientes =======================");
        Console.Write("Ingrese el nombre o el telefono del cliente: ");
        string Info = Console.ReadLine();
        Console.WriteLine("======================================================================");
        using (MySqlConnection conn = new MySqlConnection(conexion))
        {
            try
            {
                conn.Open();
                string sql = @"SELECT IDCliente, NombreCompleto, Calle, Numero, Colonia,  CodigoPostal, telefono
                FROM Clientes WHERE NombreCompleto = @dato OR telefono =  @dato";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@dato", Info);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\n======================= INFORMACION DEL CLIENTE =======================");
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["IDCliente"]}");
                                Console.WriteLine($"Nombre: {reader["NombreCompleto"]}");
                                Console.WriteLine($"Calle: {reader["Calle"]}");
                                Console.WriteLine($"Numero: {reader["Numero"]}");
                                Console.WriteLine($"Colonia: {reader["Colonia"]}");
                                Console.WriteLine($"Codigo Postal: {reader["CodigoPostal"]}");
                                Console.WriteLine($"telefono: {reader["telefono"]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontro el cliente");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Eror: " + ex.Message);
            }
        }
    }
    //Dentro de este metodo podrmeos realizar la captura de los datos de los tecnicos 
    static void RegistrarTecnico()
    {
        Console.WriteLine("\n====================== Registro de Tecnicos ======================");
        Console.WriteLine("========================= Datos del Tecnico ========================");
        Console.Write("Nombre completo del tecnico: ");
        string NombreTec = Console.ReadLine();
        Console.Write("Telefono: ");
        string telefonoTec = Console.ReadLine();
        Console.Write("Especialidad (Hardware, software o redes): ");
        string Espe = Console.ReadLine();

        using (MySqlConnection conn = new MySqlConnection(conexion))
        {
            //Se guarda la informacion del tecnico con estado inicial de "disponible"
            try
            {
                conn.Open();
                string sql = @"INSERT INTO Tecnico (NombreTecnico, Telefono, Especialidad, Estado)
                VALUES (@NT, @TeT, @Es, 'Disponible')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NT", NombreTec);
                cmd.Parameters.AddWithValue("@TeT", telefonoTec);
                cmd.Parameters.AddWithValue("@Es", Espe);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Se realizo el registro de forma correctra");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eror al guardar los datos: " + ex.Message);
            }
        }
    }
    //Dentro de este metodo podemo ver y realizar el cambio del estado de los tecnicos que se encuentren registrados
    static void VerYcambiarEstadoTec()
    {
        int Idt;
        using MySqlConnection con = new MySqlConnection(conexion);
        con.Open();
        string sql = @"SELECT IDTecnico, NombreTecnico, Telefono, Especialidad, Estado FROM Tecnico";
        MySqlCommand cmd = new MySqlCommand(sql, con);
        MySqlDataReader reader = cmd.ExecuteReader();
        Console.WriteLine("========================= Estado de Tecnicos ========================");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["IDTecnico"]} | " +
            $"Nombre: {reader["NombreTecnico"]} | " +
            $"Telefono: {reader["Telefono"]} |" +
            $"Especialidad: {reader["Especialidad"]} | " +
            $"Estado: {reader["Estado"]}");
        }
        reader.Close();
        Console.WriteLine("======================================================================");
        Console.Write("¿Quiere cambiar el estado de un tecnico? (S/N): ");
        string Respuesta = Console.ReadLine().Trim().ToLower();
        if (Respuesta != "s") return;
        Console.WriteLine("========================= Cambio de Estado de Tecnicos ========================");
        Console.Write("Ingrese el ID del tecnico: ");
        if (!int.TryParse(Console.ReadLine(), out Idt))
        {
            Console.WriteLine("No es valido");
            return;
        }
        Console.WriteLine("========================= Opciones de cambio ========================");
        Console.WriteLine("1. Disponible");
        Console.WriteLine("2. En Servicio");
        Console.WriteLine("3. No Disponible");
        Console.Write("Selccione una opcion: ");
        int opci = int.Parse(Console.ReadLine());
        string Estado = "";
        if (opci == 1) Estado = "Disponible";
        if (opci == 2) Estado = "En Servicio";
        if (opci == 3) Estado = "No Disponible";
        string UPDATE = " UPDATE Tecnico SET Estado= @E WHERE IDTecnico =@Idt";
        MySqlCommand UP = new MySqlCommand(UPDATE, con);
        UP.Parameters.AddWithValue("@E", Estado);
        UP.Parameters.AddWithValue("@Idt", Idt);
        int filas = UP.ExecuteNonQuery();
        if (filas == 0)
        {
            Console.WriteLine("El tecnico no ese ID no existe");
        }
        else
        {
            Console.WriteLine("Se realizo el cambio de forma correcta");
        }
    }
    //Dentro de este metodo se realiza el calculo de la distancia aproximada entre las dos ubicaciones la del usuario y la base de Tecnofix
    //Para estimar el tiempo de llegada del tecnico al cliente
    static double CalcularDistancia(double lat1, double long1, double lat2, double long2)
    {
        double r = 6371;
        double dlat = (lat2 - lat1) * Math.PI / 180;
        double dlon = (long2 - long1) * Math.PI / 180;
        double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
        Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) * Math.Sin(dlon / 2) * Math.Sin(dlon / 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return r * c;
    }
    //Dentro de este metodo se podra realizar la creacion de cada una de las solicitudes 
    static void Solicitudes()
    {
        using MySqlConnection con = new MySqlConnection(conexion);
        con.Open();
        int idTeC = 0;
        Console.WriteLine("=================== Asignacion de tecnico ==================");
        Console.WriteLine("1. Forma automatica");
        Console.WriteLine("2. Forma Manual");
        Console.Write("Selccione una opcion: ");
        int opcion = int.Parse(Console.ReadLine());

        if (opcion == 1)
        {
            string sql = "SELECT IDTecnico FROM Tecnico WHERE Estado= 'Disponible' LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            object resultado = cmd.ExecuteScalar();
            if (resultado == null)
            {
                Console.WriteLine("Por el momento no hay tecnicos disponibles");
                return;
            }
            idTeC = Convert.ToInt32(resultado);
        }
        else
        {
            string sql = @"SELECT IDTecnico, NombreTecnico, Telefono, Especialidad, Estado FROM Tecnico";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("========================= Estado de Tecnicos ========================");
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["IDTecnico"]} | " +
                $"Nombre: {reader["NombreTecnico"]} | " +
                $"Telefono: {reader["Telefono"]} |" +
                $"Especialidad: {reader["Especialidad"]} | " +
                $"Estado: {reader["Estado"]}");
            }
            reader.Close();
            Console.Write("Ingrese el ID del tecnico: ");
            idTeC = int.Parse(Console.ReadLine());
            string validarTec = "SELECT Estado FROM Tecnico WHERE IDTecnico=@id";
            MySqlCommand cmdT = new MySqlCommand(validarTec, con);
            cmdT.Parameters.AddWithValue("@id", idTeC);
            string esta = cmdT.ExecuteScalar()?.ToString().Trim().ToLower();
            if (esta != "disponible")
            {
                Console.WriteLine("El tecnico no esta diponible");
                return;
            }
        }

        int idcliente;
        string colonia = "";
        string cp = "";
        while (true)
        {
            Console.WriteLine("========================= Datos del Cliente ========================");
            Console.Write(" Ingrese el ID del cliente: ");
            if (!int.TryParse(Console.ReadLine(), out idcliente))
            {
                Console.WriteLine("No es valido");
                return;
            }
            bool Existe = false;
            string sql = "SELECT Colonia, CodigoPostal From Clientes WHERE IDCliente=@id";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", idcliente);
            using var r = cmd.ExecuteReader();
            if (r.Read())
            {
                colonia = r["Colonia"].ToString();
                cp = r["CodigoPostal"].ToString();
                Existe = true;
            }
            r.Close();
            if (!Existe)
            {
                Console.WriteLine("El cliente no existe");
                return;
            }
            else
            {
                break;
            }
        }
        //Es un diccionario dentro del cual se asocial prefijos de los codigo postales con coordenadas para poder realizar el calculo
        //De la ubicacion del cliente y de esta forma poder calcular de una mejor forma la distancia
        var zonas = new Dictionary<string, (double Latitud, double longitud)>
        {
            {"01",(19.4327, -99.1333)},
            {"23",(19.4328, -99.1334)},
            {"46",(19.4329, -99.1335)},
            {"60",(19.4330, -99.1336)},
            {"90",(19.4331, -99.1337)},
        };

        double latBase = 19.4326;
        double longBase = -99.1332;
        string Prefijo = cp.Substring(0, 2);

        (double lat, double lon) coorCliente;
        if (zonas.ContainsKey(Prefijo))
        {
            coorCliente = zonas[Prefijo];
        }
        else
        {
            Console.WriteLine("Zona no encontrada se realizara uuso de una distancia aproximada");
            coorCliente = (19.4320, -99.1330);
        }
        double distnacia = CalcularDistancia(latBase, longBase, coorCliente.lat, coorCliente.lon);
        double Tiempo = distnacia / 70;
        DateTime horadellegada = DateTime.Now.AddHours(Tiempo);
        double tiempohoras = Tiempo * 60;

        Console.WriteLine("========================= Datos del Servicio ========================");
        Console.Write("Ingrese el tipo de servicio: ");
        string Tipo = Console.ReadLine();
        Console.Write("Ingrese una descripcion de la situacion: ");
        string des = Console.ReadLine();
        Console.Write("Ingrese el costo: ");
        decimal costo = decimal.Parse(Console.ReadLine());
        Console.WriteLine("======================================================================");
        DateTime fecha = DateTime.Now;
        string EstadoSer = "Asignado";

        string sqlS = @"INSERT INTO Servicio(FechaHoraSolicitud, TipoDeServicio, Descripcion, costo, Estado, 
    DistanciaKm, TiempoEstimadohoras, HoraEstimadaLlegada, IDCliente, IDTecnico) VALUES (@fecha, @tipo, @des,
    @costo, @estado, @dist, @tiempo, @hora, @cli, @tec)";
        MySqlCommand ins = new MySqlCommand(sqlS, con);
        ins.Parameters.AddWithValue("@fecha", fecha);
        ins.Parameters.AddWithValue("@tipo", Tipo);
        ins.Parameters.AddWithValue("@des", des);
        ins.Parameters.AddWithValue("@costo", costo);
        ins.Parameters.AddWithValue("@estado", EstadoSer);
        ins.Parameters.AddWithValue("@dist", distnacia);
        ins.Parameters.AddWithValue("@tiempo", tiempohoras);
        ins.Parameters.AddWithValue("@hora", horadellegada);
        ins.Parameters.AddWithValue("@cli", idcliente);
        ins.Parameters.AddWithValue("@tec", idTeC);
        ins.ExecuteNonQuery();
        string CTec = "Update Tecnico SET Estado = 'En Servicio' WHERE IDTecnico=@id";
        MySqlCommand Cdm = new MySqlCommand(CTec, con);
        Cdm.Parameters.AddWithValue("@id", idTeC);
        Cdm.ExecuteNonQuery();

        string NombreTecni = "";
        string SqlN = "SELECT NombreTecnico FROM Tecnico WHERE IDTecnico=@id";
        MySqlCommand cmdN = new MySqlCommand(SqlN, con);
        cmdN.Parameters.AddWithValue("@id", idTeC);
        NombreTecni = cmdN.ExecuteScalar()?.ToString();

        Console.WriteLine("========================= Solicitud del Servicio registrada ========================");
        Console.WriteLine($"Tecnico asignado: {NombreTecni} - Con Id: {idTeC}");
        Console.WriteLine($"Distancia {distnacia:F2} KM");
        Console.WriteLine($"Timpo Estimado: {tiempohoras:F2} horas");
        Console.WriteLine($"Fecha y hora de solicitud {fecha}");
        Console.WriteLine($"Hora estida de llegada: {horadellegada}");
        Console.WriteLine("======================================================================");
    }
    //Dentro de este metodo podremos actualizar el estado de cada uno de los servicios que se encuentren registrados dentro
    //De la base de datos 
    static void ActualizarEstado()
    {
        int IdServicio;
        using MySqlConnection con = new MySqlConnection(conexion);
        con.Open();
        string sql = "SELECT IDServicio, TipoDeServicio, Estado, IDTecnico FROM Servicio";
        MySqlCommand cmd = new MySqlCommand(sql, con);
        MySqlDataReader reader = cmd.ExecuteReader();
        Console.WriteLine("========================= Actualizacion de estado ========================");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["IDServicio"]} |" +
            $"Servicio: {reader["TipoDeServicio"]} |" +
            $"Estado: {reader["Estado"]} | " +
            $"Tecinico: {reader["IDTecnico"]} ");
        }
        reader.Close();
        Console.WriteLine("======================================================================");
        Console.Write("Ingrese el ID del servicio que desea actualizar: ");
        if (!int.TryParse(Console.ReadLine(), out IdServicio))
        {
            Console.WriteLine("Valor no valido");
            return;
        }
        string validacion = "SELECT COUNT(*) FROM Servicio WHERE IDServicio=@id";
        MySqlCommand cmdV = new MySqlCommand(validacion, con);
        cmdV.Parameters.AddWithValue("@id", IdServicio);
        int existe = Convert.ToInt32(cmdV.ExecuteScalar());
        if (existe == 0)
        {
            Console.WriteLine("El servicio no existe");
            return;
        }
        Console.WriteLine("========================= Opciones de cambio ========================");
        Console.WriteLine("1. Pendiente");
        Console.WriteLine("2. Asignado");
        Console.WriteLine("3. En proceso");
        Console.WriteLine("4. Finalizado");
        Console.WriteLine("5. Cancelado");
        Console.Write("Seleccione una opcion: ");
        int Opc = int.Parse(Console.ReadLine());
        string NuevoE = "";
        if (Opc == 1) NuevoE = "Pendiente";
        if (Opc == 2) NuevoE = "Asignado";
        if (Opc == 3) NuevoE = "En proceso";
        if (Opc == 4) NuevoE = "Finalizado";
        if (Opc == 5) NuevoE = "Cancelado";
        string UPDATE = " UPDATE Servicio SET Estado= @E WHERE IDServicio =@Idt";
        MySqlCommand UP = new MySqlCommand(UPDATE, con);
        UP.Parameters.AddWithValue("@E", NuevoE);
        UP.Parameters.AddWithValue("@Idt", IdServicio);
        int filas = UP.ExecuteNonQuery();
        if (filas == 0)
        {
            Console.WriteLine("No se pudo realizzar la actualizacion");
        }
        else
        {
            Console.WriteLine("Se realizo el cambio de forma correcta");
        }
    }
    //Dentro de este metodo podremos observar el histrial de cadau an ode los servicios que se encuentren registraods dependiendo
    //El tipo de filtro que se este ocupando 
    static void Historial()
    {
        using MySqlConnection con = new MySqlConnection(conexion);
        con.Open();
        Console.WriteLine("================== Historial de servicios ==================");
        Console.WriteLine("1. Realizar busqueda por cliente");
        Console.WriteLine("2. Realizar busqueda por tecnico");
        Console.WriteLine("3. Realizar busqueda por rango de fechas");
        Console.Write("Seleccione una opcion: ");
        int op = int.Parse(Console.ReadLine());
        string sql = "";
        MySqlCommand cmd;
        if (op == 1)
        {
            Console.Write("Ingrese el ID del cleinte: ");
            int idCliente = int.Parse(Console.ReadLine());
            sql = "SELECT * FROM Servicio WHERE IDCliente=@id";
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", idCliente);
        }
        else if (op == 2)
        {
            Console.Write("Ingrese el ID del tecnico: ");
            int idTecnico = int.Parse(Console.ReadLine());
            sql = "SELECT * FROM Servicio WHERE IDTecnico=@id";
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", idTecnico);
        }
        else if (op == 3)
        {
            Console.Write("Ingrese la fecha de inicio con el siguiente formato: (YYYY-MM-DD hh:mm:ss): ");
            string f1 = Console.ReadLine();
            Console.Write("Ingrese la fecha fin con el siguiente formato: (YYYY-MM-DD hh:mm:ss): ");
            string f2 = Console.ReadLine();
            sql = "SELECT * FROM Servicio WHERE FechaHoraSolicitud BETWEEN @f1 AND @f2";
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@f1", f1);
            cmd.Parameters.AddWithValue("@f2", f2);
        }
        else
        {
            Console.WriteLine("La opcion ingresada no es valida");
            return;
        }
        MySqlDataReader reader = cmd.ExecuteReader();
        Console.WriteLine("======================================================================");
        if (!reader.HasRows)
        {
            Console.WriteLine("No hay registros diposnibles");
            reader.Close();
            return;
        }
        while (reader.Read())
        {
            Console.WriteLine("================== Resultado ==================");
            Console.WriteLine($"ID Servicio: {reader["IDServicio"]}");
            Console.WriteLine($"Fecha: {reader["FechaHoraSolicitud"]}");
            Console.WriteLine($"Servicio: {reader["TipoDeServicio"]}");
            Console.WriteLine($"Descripcion: {reader["Descripcion"]}");
            Console.WriteLine($"Estado: {reader["Estado"]}");
            Console.WriteLine($"Costo: {reader["Costo"]}");
            Console.WriteLine($"ID del cliente: {reader["IDCliente"]}");
            Console.WriteLine($"ID del Tecnico: {reader["IDTecnico"]}");
        }
        reader.Close();
        Console.WriteLine("======================================================================");
    }

    static void Main()
    {
        //SE realiza el control del menu principal 
        int opcion;
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("===================Sistema “TecnoFix”==================");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Buscar clientes");
            Console.WriteLine("3. Registrar tecnicos");
            Console.WriteLine("4. Ver los tecnicos disponibles y cambiar estado");
            Console.WriteLine("5. Crear solicitudes");
            Console.WriteLine("6. Actaulizar estado del servicio");
            Console.WriteLine("7. Revisar historial de servicios");
            Console.WriteLine("8. Salir");
            Console.WriteLine("=======================================================");
            Console.Write("Selecciones una opcion: ");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine("=======================================================");
            switch (opcion)
            {
                case 1:
                    RegistroClientes(); break;
                case 2:
                    BuscarCliente(); break;
                case 3:
                    RegistrarTecnico(); break;
                case 4:
                    VerYcambiarEstadoTec(); break;
                case 5:
                    Solicitudes(); break;
                case 6:
                    ActualizarEstado(); break;
                case 7:
                    Historial(); break;
                case 8:
                    salir = true;
                    Console.WriteLine("==========Cerrando programa=========="); break;
                default:
                    Console.WriteLine("Opcion no validad"); break;
            }

        }

    }
}

