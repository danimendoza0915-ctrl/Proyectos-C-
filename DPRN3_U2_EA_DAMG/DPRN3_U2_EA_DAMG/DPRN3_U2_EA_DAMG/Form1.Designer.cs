namespace DPRN3_U2_EA_DAMG
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            tabControl2 = new TabControl();
            GestionEsudiantes = new TabPage();
            RegistroEstu = new GroupBox();
            InNombre = new TextBox();
            LMatriculaG = new Label();
            Registrar = new Button();
            LNombeG = new Label();
            Estatus = new ComboBox();
            LCarreraG = new Label();
            InCarrera = new TextBox();
            LEstatusG = new Label();
            InMatricula = new TextBox();
            DataEstudiantes = new DataGridView();
            InsAgenda = new TabPage();
            InsAcade = new GroupBox();
            InsMateria = new TextBox();
            Regis = new Button();
            LMatriculaIAC = new Label();
            InsHorario = new TextBox();
            LMateriaIAC = new Label();
            LHorarioIAC = new Label();
            InsMatri = new TextBox();
            Servicios = new TabPage();
            SerES = new GroupBox();
            RegistrarSer = new Button();
            comboBox2 = new ComboBox();
            label7 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            Finanzas = new TabPage();
            GruopFinanzas = new GroupBox();
            MatPag = new Label();
            MatriculaPago = new TextBox();
            CalcularPago = new Button();
            TextTotal = new TextBox();
            TextISR = new TextBox();
            GuardarPago = new Button();
            TexIva = new TextBox();
            TTotal = new Label();
            TISR = new Label();
            TIVA = new Label();
            Subtotal = new Label();
            InSub = new TextBox();
            checkbeca = new CheckBox();
            CheckAdmin = new CheckBox();
            Reportes = new TabPage();
            DataReportes = new DataGridView();
            Repor = new GroupBox();
            GenerarRepor = new Button();
            DateFin = new DateTimePicker();
            DateInicio = new DateTimePicker();
            Fechfin = new Label();
            FechIn = new Label();
            CamRol = new ComboBox();
            Rol = new Label();
            Ingresar = new Button();
            InUsuario = new TextBox();
            InContraseña = new TextBox();
            Contraseña = new Label();
            Usuario = new Label();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            panel1.SuspendLayout();
            tabControl2.SuspendLayout();
            GestionEsudiantes.SuspendLayout();
            RegistroEstu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataEstudiantes).BeginInit();
            InsAgenda.SuspendLayout();
            InsAcade.SuspendLayout();
            Servicios.SuspendLayout();
            SerES.SuspendLayout();
            Finanzas.SuspendLayout();
            GruopFinanzas.SuspendLayout();
            Reportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataReportes).BeginInit();
            Repor.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tabControl2);
            panel1.Controls.Add(CamRol);
            panel1.Controls.Add(Rol);
            panel1.Controls.Add(Ingresar);
            panel1.Controls.Add(InUsuario);
            panel1.Controls.Add(InContraseña);
            panel1.Controls.Add(Contraseña);
            panel1.Controls.Add(Usuario);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(978, 636);
            panel1.TabIndex = 0;
            panel1.UseWaitCursor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(GestionEsudiantes);
            tabControl2.Controls.Add(InsAgenda);
            tabControl2.Controls.Add(Servicios);
            tabControl2.Controls.Add(Finanzas);
            tabControl2.Controls.Add(Reportes);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.Location = new Point(0, 0);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(978, 636);
            tabControl2.TabIndex = 7;
            tabControl2.UseWaitCursor = true;
            tabControl2.Visible = false;
            // 
            // GestionEsudiantes
            // 
            GestionEsudiantes.Controls.Add(RegistroEstu);
            GestionEsudiantes.Controls.Add(DataEstudiantes);
            GestionEsudiantes.Location = new Point(4, 24);
            GestionEsudiantes.Name = "GestionEsudiantes";
            GestionEsudiantes.Padding = new Padding(3);
            GestionEsudiantes.Size = new Size(970, 608);
            GestionEsudiantes.TabIndex = 0;
            GestionEsudiantes.Text = "Gestión Esudiantes";
            GestionEsudiantes.UseVisualStyleBackColor = true;
            GestionEsudiantes.UseWaitCursor = true;
            // 
            // RegistroEstu
            // 
            RegistroEstu.Controls.Add(InNombre);
            RegistroEstu.Controls.Add(LMatriculaG);
            RegistroEstu.Controls.Add(Registrar);
            RegistroEstu.Controls.Add(LNombeG);
            RegistroEstu.Controls.Add(Estatus);
            RegistroEstu.Controls.Add(LCarreraG);
            RegistroEstu.Controls.Add(InCarrera);
            RegistroEstu.Controls.Add(LEstatusG);
            RegistroEstu.Controls.Add(InMatricula);
            RegistroEstu.Location = new Point(25, 29);
            RegistroEstu.Name = "RegistroEstu";
            RegistroEstu.Size = new Size(322, 225);
            RegistroEstu.TabIndex = 10;
            RegistroEstu.TabStop = false;
            RegistroEstu.Text = "Registro Estudiantes";
            RegistroEstu.UseWaitCursor = true;
            // 
            // InNombre
            // 
            InNombre.Location = new Point(126, 71);
            InNombre.Name = "InNombre";
            InNombre.Size = new Size(119, 23);
            InNombre.TabIndex = 5;
            InNombre.UseWaitCursor = true;
            // 
            // LMatriculaG
            // 
            LMatriculaG.AutoSize = true;
            LMatriculaG.Location = new Point(37, 24);
            LMatriculaG.Name = "LMatriculaG";
            LMatriculaG.RightToLeft = RightToLeft.Yes;
            LMatriculaG.Size = new Size(60, 15);
            LMatriculaG.TabIndex = 0;
            LMatriculaG.Text = "Matricula ";
            LMatriculaG.UseWaitCursor = true;
            // 
            // Registrar
            // 
            Registrar.Location = new Point(141, 195);
            Registrar.Name = "Registrar";
            Registrar.Size = new Size(75, 23);
            Registrar.TabIndex = 8;
            Registrar.Text = "Registrar";
            Registrar.UseVisualStyleBackColor = true;
            Registrar.UseWaitCursor = true;
            Registrar.Click += Registrar_Click;
            // 
            // LNombeG
            // 
            LNombeG.AutoSize = true;
            LNombeG.Location = new Point(37, 71);
            LNombeG.Name = "LNombeG";
            LNombeG.Size = new Size(51, 15);
            LNombeG.TabIndex = 1;
            LNombeG.Text = "Nombre";
            LNombeG.UseWaitCursor = true;
            // 
            // Estatus
            // 
            Estatus.FormattingEnabled = true;
            Estatus.Location = new Point(124, 151);
            Estatus.Name = "Estatus";
            Estatus.Size = new Size(121, 23);
            Estatus.TabIndex = 7;
            Estatus.UseWaitCursor = true;
            Estatus.SelectedIndexChanged += Estatus_SelectedIndexChanged;
            // 
            // LCarreraG
            // 
            LCarreraG.AutoSize = true;
            LCarreraG.Location = new Point(37, 114);
            LCarreraG.Name = "LCarreraG";
            LCarreraG.Size = new Size(45, 15);
            LCarreraG.TabIndex = 2;
            LCarreraG.Text = "Carrera";
            LCarreraG.UseWaitCursor = true;
            LCarreraG.Click += label3_Click;
            // 
            // InCarrera
            // 
            InCarrera.Location = new Point(126, 111);
            InCarrera.Name = "InCarrera";
            InCarrera.Size = new Size(119, 23);
            InCarrera.TabIndex = 6;
            InCarrera.UseWaitCursor = true;
            // 
            // LEstatusG
            // 
            LEstatusG.AutoSize = true;
            LEstatusG.Location = new Point(37, 151);
            LEstatusG.Name = "LEstatusG";
            LEstatusG.Size = new Size(44, 15);
            LEstatusG.TabIndex = 3;
            LEstatusG.Text = "Estatus";
            LEstatusG.UseWaitCursor = true;
            // 
            // InMatricula
            // 
            InMatricula.Location = new Point(124, 22);
            InMatricula.Name = "InMatricula";
            InMatricula.Size = new Size(121, 23);
            InMatricula.TabIndex = 4;
            InMatricula.UseWaitCursor = true;
            // 
            // DataEstudiantes
            // 
            DataEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataEstudiantes.Location = new Point(450, 39);
            DataEstudiantes.Name = "DataEstudiantes";
            DataEstudiantes.Size = new Size(424, 218);
            DataEstudiantes.TabIndex = 9;
            DataEstudiantes.UseWaitCursor = true;
            // 
            // InsAgenda
            // 
            InsAgenda.Controls.Add(InsAcade);
            InsAgenda.Location = new Point(4, 24);
            InsAgenda.Name = "InsAgenda";
            InsAgenda.Padding = new Padding(3);
            InsAgenda.Size = new Size(970, 608);
            InsAgenda.TabIndex = 1;
            InsAgenda.Text = "Inscripciones y Agenda Academica";
            InsAgenda.UseVisualStyleBackColor = true;
            InsAgenda.UseWaitCursor = true;
            // 
            // InsAcade
            // 
            InsAcade.Controls.Add(InsMateria);
            InsAcade.Controls.Add(Regis);
            InsAcade.Controls.Add(LMatriculaIAC);
            InsAcade.Controls.Add(InsHorario);
            InsAcade.Controls.Add(LMateriaIAC);
            InsAcade.Controls.Add(LHorarioIAC);
            InsAcade.Controls.Add(InsMatri);
            InsAcade.Location = new Point(49, 36);
            InsAcade.Name = "InsAcade";
            InsAcade.Size = new Size(296, 236);
            InsAcade.TabIndex = 7;
            InsAcade.TabStop = false;
            InsAcade.Text = "Inscripcion acdemica";
            InsAcade.UseWaitCursor = true;
            // 
            // InsMateria
            // 
            InsMateria.Location = new Point(121, 72);
            InsMateria.Name = "InsMateria";
            InsMateria.Size = new Size(100, 23);
            InsMateria.TabIndex = 4;
            InsMateria.UseWaitCursor = true;
            // 
            // Regis
            // 
            Regis.Location = new Point(130, 167);
            Regis.Name = "Regis";
            Regis.Size = new Size(75, 23);
            Regis.TabIndex = 6;
            Regis.Text = "Registrar";
            Regis.UseVisualStyleBackColor = true;
            Regis.UseWaitCursor = true;
            Regis.Click += button1_Click_1;
            // 
            // LMatriculaIAC
            // 
            LMatriculaIAC.AutoSize = true;
            LMatriculaIAC.Location = new Point(15, 29);
            LMatriculaIAC.Name = "LMatriculaIAC";
            LMatriculaIAC.Size = new Size(57, 15);
            LMatriculaIAC.TabIndex = 0;
            LMatriculaIAC.Text = "Matricula";
            LMatriculaIAC.UseWaitCursor = true;
            // 
            // InsHorario
            // 
            InsHorario.Location = new Point(121, 115);
            InsHorario.Name = "InsHorario";
            InsHorario.Size = new Size(100, 23);
            InsHorario.TabIndex = 5;
            InsHorario.UseWaitCursor = true;
            // 
            // LMateriaIAC
            // 
            LMateriaIAC.AutoSize = true;
            LMateriaIAC.Location = new Point(15, 72);
            LMateriaIAC.Name = "LMateriaIAC";
            LMateriaIAC.Size = new Size(47, 15);
            LMateriaIAC.TabIndex = 1;
            LMateriaIAC.Text = "Materia";
            LMateriaIAC.UseWaitCursor = true;
            // 
            // LHorarioIAC
            // 
            LHorarioIAC.AutoSize = true;
            LHorarioIAC.Location = new Point(15, 123);
            LHorarioIAC.Name = "LHorarioIAC";
            LHorarioIAC.Size = new Size(47, 15);
            LHorarioIAC.TabIndex = 2;
            LHorarioIAC.Text = "Horario";
            LHorarioIAC.UseWaitCursor = true;
            // 
            // InsMatri
            // 
            InsMatri.Location = new Point(121, 29);
            InsMatri.Name = "InsMatri";
            InsMatri.Size = new Size(100, 23);
            InsMatri.TabIndex = 3;
            InsMatri.UseWaitCursor = true;
            InsMatri.TextChanged += textBox1_TextChanged;
            // 
            // Servicios
            // 
            Servicios.Controls.Add(SerES);
            Servicios.Location = new Point(4, 24);
            Servicios.Name = "Servicios";
            Servicios.Padding = new Padding(3);
            Servicios.Size = new Size(970, 608);
            Servicios.TabIndex = 2;
            Servicios.Text = "Servicios escolares y atención";
            Servicios.UseVisualStyleBackColor = true;
            Servicios.UseWaitCursor = true;
            // 
            // SerES
            // 
            SerES.Controls.Add(RegistrarSer);
            SerES.Controls.Add(comboBox2);
            SerES.Controls.Add(label7);
            SerES.Controls.Add(comboBox1);
            SerES.Controls.Add(label1);
            SerES.Controls.Add(textBox1);
            SerES.Controls.Add(label2);
            SerES.Location = new Point(34, 45);
            SerES.Name = "SerES";
            SerES.Size = new Size(309, 200);
            SerES.TabIndex = 10;
            SerES.TabStop = false;
            SerES.Text = "Servicios Escolares";
            SerES.UseWaitCursor = true;
            // 
            // RegistrarSer
            // 
            RegistrarSer.Location = new Point(121, 165);
            RegistrarSer.Name = "RegistrarSer";
            RegistrarSer.Size = new Size(75, 23);
            RegistrarSer.TabIndex = 11;
            RegistrarSer.Text = "Registrar";
            RegistrarSer.UseVisualStyleBackColor = true;
            RegistrarSer.UseWaitCursor = true;
            RegistrarSer.Click += RegistrarSer_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(110, 127);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 9;
            comboBox2.UseWaitCursor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 40);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 0;
            label7.Text = "Matricula";
            label7.UseWaitCursor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(110, 82);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 8;
            comboBox1.UseWaitCursor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 85);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 1;
            label1.Text = "Servicio";
            label1.UseWaitCursor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(110, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(121, 23);
            textBox1.TabIndex = 3;
            textBox1.UseWaitCursor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 127);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Estado";
            label2.UseWaitCursor = true;
            // 
            // Finanzas
            // 
            Finanzas.Controls.Add(GruopFinanzas);
            Finanzas.Location = new Point(4, 24);
            Finanzas.Name = "Finanzas";
            Finanzas.Padding = new Padding(3);
            Finanzas.Size = new Size(970, 608);
            Finanzas.TabIndex = 3;
            Finanzas.Text = "Pagos y finanzas";
            Finanzas.UseVisualStyleBackColor = true;
            Finanzas.UseWaitCursor = true;
            // 
            // GruopFinanzas
            // 
            GruopFinanzas.Controls.Add(MatPag);
            GruopFinanzas.Controls.Add(MatriculaPago);
            GruopFinanzas.Controls.Add(CalcularPago);
            GruopFinanzas.Controls.Add(TextTotal);
            GruopFinanzas.Controls.Add(TextISR);
            GruopFinanzas.Controls.Add(GuardarPago);
            GruopFinanzas.Controls.Add(TexIva);
            GruopFinanzas.Controls.Add(TTotal);
            GruopFinanzas.Controls.Add(TISR);
            GruopFinanzas.Controls.Add(TIVA);
            GruopFinanzas.Controls.Add(Subtotal);
            GruopFinanzas.Controls.Add(InSub);
            GruopFinanzas.Controls.Add(checkbeca);
            GruopFinanzas.Controls.Add(CheckAdmin);
            GruopFinanzas.Location = new Point(40, 25);
            GruopFinanzas.Name = "GruopFinanzas";
            GruopFinanzas.Size = new Size(341, 288);
            GruopFinanzas.TabIndex = 0;
            GruopFinanzas.TabStop = false;
            GruopFinanzas.Text = "Pagos ";
            GruopFinanzas.UseWaitCursor = true;
            // 
            // MatPag
            // 
            MatPag.AutoSize = true;
            MatPag.Location = new Point(35, 43);
            MatPag.Name = "MatPag";
            MatPag.Size = new Size(57, 15);
            MatPag.TabIndex = 15;
            MatPag.Text = "Matricula";
            MatPag.UseWaitCursor = true;
            // 
            // MatriculaPago
            // 
            MatriculaPago.Location = new Point(139, 35);
            MatriculaPago.Name = "MatriculaPago";
            MatriculaPago.Size = new Size(124, 23);
            MatriculaPago.TabIndex = 14;
            MatriculaPago.UseWaitCursor = true;
            // 
            // CalcularPago
            // 
            CalcularPago.Location = new Point(35, 252);
            CalcularPago.Name = "CalcularPago";
            CalcularPago.Size = new Size(75, 23);
            CalcularPago.TabIndex = 12;
            CalcularPago.Text = "Calcular";
            CalcularPago.UseVisualStyleBackColor = true;
            CalcularPago.UseWaitCursor = true;
            CalcularPago.Click += button1_Click_2;
            // 
            // TextTotal
            // 
            TextTotal.Location = new Point(139, 210);
            TextTotal.Name = "TextTotal";
            TextTotal.Size = new Size(124, 23);
            TextTotal.TabIndex = 11;
            TextTotal.UseWaitCursor = true;
            // 
            // TextISR
            // 
            TextISR.Location = new Point(139, 178);
            TextISR.Name = "TextISR";
            TextISR.Size = new Size(124, 23);
            TextISR.TabIndex = 10;
            TextISR.UseWaitCursor = true;
            // 
            // GuardarPago
            // 
            GuardarPago.Location = new Point(212, 252);
            GuardarPago.Name = "GuardarPago";
            GuardarPago.Size = new Size(75, 23);
            GuardarPago.TabIndex = 9;
            GuardarPago.Text = "Guardar";
            GuardarPago.UseVisualStyleBackColor = true;
            GuardarPago.UseWaitCursor = true;
            GuardarPago.Click += GuardarPago_Click;
            // 
            // TexIva
            // 
            TexIva.Location = new Point(139, 149);
            TexIva.Name = "TexIva";
            TexIva.Size = new Size(124, 23);
            TexIva.TabIndex = 5;
            TexIva.UseWaitCursor = true;
            // 
            // TTotal
            // 
            TTotal.AutoSize = true;
            TTotal.Location = new Point(35, 213);
            TTotal.Name = "TTotal";
            TTotal.Size = new Size(33, 15);
            TTotal.TabIndex = 8;
            TTotal.Text = "Total";
            TTotal.UseWaitCursor = true;
            // 
            // TISR
            // 
            TISR.AutoSize = true;
            TISR.Location = new Point(35, 180);
            TISR.Name = "TISR";
            TISR.Size = new Size(23, 15);
            TISR.TabIndex = 7;
            TISR.Text = "ISR";
            TISR.UseWaitCursor = true;
            // 
            // TIVA
            // 
            TIVA.AutoSize = true;
            TIVA.Location = new Point(35, 152);
            TIVA.Name = "TIVA";
            TIVA.Size = new Size(24, 15);
            TIVA.TabIndex = 6;
            TIVA.Text = "IVA";
            TIVA.UseWaitCursor = true;
            // 
            // Subtotal
            // 
            Subtotal.AutoSize = true;
            Subtotal.Location = new Point(35, 87);
            Subtotal.Name = "Subtotal";
            Subtotal.Size = new Size(51, 15);
            Subtotal.TabIndex = 1;
            Subtotal.Text = "Subtotal";
            Subtotal.UseWaitCursor = true;
            // 
            // InSub
            // 
            InSub.Location = new Point(139, 79);
            InSub.Name = "InSub";
            InSub.Size = new Size(124, 23);
            InSub.TabIndex = 2;
            InSub.UseWaitCursor = true;
            // 
            // checkbeca
            // 
            checkbeca.AutoSize = true;
            checkbeca.Location = new Point(212, 109);
            checkbeca.Name = "checkbeca";
            checkbeca.Size = new Size(51, 19);
            checkbeca.TabIndex = 4;
            checkbeca.Text = "Beca";
            checkbeca.UseVisualStyleBackColor = true;
            checkbeca.UseWaitCursor = true;
            // 
            // CheckAdmin
            // 
            CheckAdmin.AutoSize = true;
            CheckAdmin.Location = new Point(35, 111);
            CheckAdmin.Name = "CheckAdmin";
            CheckAdmin.Size = new Size(107, 19);
            CheckAdmin.TabIndex = 3;
            CheckAdmin.Text = "Administrativo ";
            CheckAdmin.UseVisualStyleBackColor = true;
            CheckAdmin.UseWaitCursor = true;
            // 
            // Reportes
            // 
            Reportes.Controls.Add(DataReportes);
            Reportes.Controls.Add(Repor);
            Reportes.Location = new Point(4, 24);
            Reportes.Name = "Reportes";
            Reportes.Padding = new Padding(3);
            Reportes.Size = new Size(970, 608);
            Reportes.TabIndex = 4;
            Reportes.Text = "Reportes";
            Reportes.UseVisualStyleBackColor = true;
            Reportes.UseWaitCursor = true;
            // 
            // DataReportes
            // 
            DataReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataReportes.Location = new Point(455, 92);
            DataReportes.Name = "DataReportes";
            DataReportes.Size = new Size(348, 221);
            DataReportes.TabIndex = 9;
            DataReportes.UseWaitCursor = true;
            // 
            // Repor
            // 
            Repor.Controls.Add(GenerarRepor);
            Repor.Controls.Add(DateFin);
            Repor.Controls.Add(DateInicio);
            Repor.Controls.Add(Fechfin);
            Repor.Controls.Add(FechIn);
            Repor.Location = new Point(36, 54);
            Repor.Name = "Repor";
            Repor.Size = new Size(385, 277);
            Repor.TabIndex = 0;
            Repor.TabStop = false;
            Repor.Text = "Reportes";
            Repor.UseWaitCursor = true;
            // 
            // GenerarRepor
            // 
            GenerarRepor.Location = new Point(157, 197);
            GenerarRepor.Name = "GenerarRepor";
            GenerarRepor.Size = new Size(75, 23);
            GenerarRepor.TabIndex = 4;
            GenerarRepor.Text = "Generar";
            GenerarRepor.UseVisualStyleBackColor = true;
            GenerarRepor.UseWaitCursor = true;
            GenerarRepor.Click += GenerarRepor_Click;
            // 
            // DateFin
            // 
            DateFin.Location = new Point(157, 111);
            DateFin.Name = "DateFin";
            DateFin.Size = new Size(212, 23);
            DateFin.TabIndex = 3;
            DateFin.UseWaitCursor = true;
            // 
            // DateInicio
            // 
            DateInicio.Location = new Point(157, 38);
            DateInicio.Name = "DateInicio";
            DateInicio.Size = new Size(212, 23);
            DateInicio.TabIndex = 2;
            DateInicio.UseWaitCursor = true;
            DateInicio.ValueChanged += DateInicio_ValueChanged;
            // 
            // Fechfin
            // 
            Fechfin.AutoSize = true;
            Fechfin.Location = new Point(33, 117);
            Fechfin.Name = "Fechfin";
            Fechfin.Size = new Size(71, 15);
            Fechfin.TabIndex = 1;
            Fechfin.Text = "Fecha de fin";
            Fechfin.UseWaitCursor = true;
            // 
            // FechIn
            // 
            FechIn.AutoSize = true;
            FechIn.Location = new Point(33, 44);
            FechIn.Name = "FechIn";
            FechIn.Size = new Size(86, 15);
            FechIn.TabIndex = 0;
            FechIn.Text = "Fecha de inicio";
            FechIn.UseWaitCursor = true;
            FechIn.Click += FechIn_Click;
            // 
            // CamRol
            // 
            CamRol.FormattingEnabled = true;
            CamRol.Location = new Point(303, 231);
            CamRol.Name = "CamRol";
            CamRol.Size = new Size(190, 23);
            CamRol.TabIndex = 6;
            CamRol.UseWaitCursor = true;
            // 
            // Rol
            // 
            Rol.AutoSize = true;
            Rol.Location = new Point(197, 234);
            Rol.Name = "Rol";
            Rol.Size = new Size(24, 15);
            Rol.TabIndex = 5;
            Rol.Text = "Rol";
            Rol.UseWaitCursor = true;
            // 
            // Ingresar
            // 
            Ingresar.Location = new Point(326, 361);
            Ingresar.Name = "Ingresar";
            Ingresar.Size = new Size(113, 23);
            Ingresar.TabIndex = 4;
            Ingresar.Text = "Ingresar";
            Ingresar.UseVisualStyleBackColor = true;
            Ingresar.UseWaitCursor = true;
            Ingresar.Click += button1_Click;
            // 
            // InUsuario
            // 
            InUsuario.Location = new Point(303, 102);
            InUsuario.Name = "InUsuario";
            InUsuario.Size = new Size(190, 23);
            InUsuario.TabIndex = 3;
            InUsuario.UseWaitCursor = true;
            // 
            // InContraseña
            // 
            InContraseña.Location = new Point(303, 157);
            InContraseña.Name = "InContraseña";
            InContraseña.PasswordChar = '*';
            InContraseña.Size = new Size(190, 23);
            InContraseña.TabIndex = 2;
            InContraseña.UseWaitCursor = true;
            // 
            // Contraseña
            // 
            Contraseña.AutoSize = true;
            Contraseña.Location = new Point(197, 165);
            Contraseña.Name = "Contraseña";
            Contraseña.Size = new Size(67, 15);
            Contraseña.TabIndex = 1;
            Contraseña.Text = "Contraseña";
            Contraseña.UseWaitCursor = true;
            // 
            // Usuario
            // 
            Usuario.AutoSize = true;
            Usuario.Location = new Point(197, 110);
            Usuario.Name = "Usuario";
            Usuario.Size = new Size(47, 15);
            Usuario.TabIndex = 0;
            Usuario.Text = "Usuario";
            Usuario.UseWaitCursor = true;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 636);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "SIGA";
            UseWaitCursor = true;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl2.ResumeLayout(false);
            GestionEsudiantes.ResumeLayout(false);
            RegistroEstu.ResumeLayout(false);
            RegistroEstu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataEstudiantes).EndInit();
            InsAgenda.ResumeLayout(false);
            InsAcade.ResumeLayout(false);
            InsAcade.PerformLayout();
            Servicios.ResumeLayout(false);
            SerES.ResumeLayout(false);
            SerES.PerformLayout();
            Finanzas.ResumeLayout(false);
            GruopFinanzas.ResumeLayout(false);
            GruopFinanzas.PerformLayout();
            Reportes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataReportes).EndInit();
            Repor.ResumeLayout(false);
            Repor.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label Contraseña;
        private Label Usuario;
        private TextBox InUsuario;
        private TextBox InContraseña;
        private Button Ingresar;
        private Label Rol;
        private ComboBox CamRol;
        private TabControl tabControl2;
        private TabPage GestionEsudiantes;
        private TabPage InsAgenda;
        private TabPage Servicios;
        private TabPage Finanzas;
        private Button Registrar;
        private ComboBox Estatus;
        private TextBox InCarrera;
        private TextBox InNombre;
        private TextBox InMatricula;
        private Label LEstatusG;
        private Label LCarreraG;
        private Label LNombeG;
        private Label LMatriculaG;
        private DataGridView DataEstudiantes;
        private TabPage Reportes;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private Label LMatriculaIAC;
        private Label LHorarioIAC;
        private Label LMateriaIAC;
        private TextBox InsMatri;
        private TextBox InsHorario;
        private TextBox InsMateria;
        private Label label7;
        private Button Regis;
        private GroupBox RegistroEstu;
        private GroupBox InsAcade;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private ComboBox comboBox2;
        private GroupBox SerES;
        private Button RegistrarSer;
        private GroupBox GruopFinanzas;
        private Label Subtotal;
        private TextBox InSub;
        private CheckBox checkbeca;
        private CheckBox CheckAdmin;
        private TextBox TexIva;
        private Label TIVA;
        private Label TISR;
        private Label TTotal;
        private Button GuardarPago;
        private TextBox TextISR;
        private TextBox TextTotal;
        private GroupBox Repor;
        private Label Fechfin;
        private Label FechIn;
        private DateTimePicker DateFin;
        private DateTimePicker DateInicio;
        private Button GenerarRepor;
        private Button CalcularPago;
        private TextBox MatriculaPago;
        private Label MatPag;
        private DataGridView DataReportes;
    }
}
