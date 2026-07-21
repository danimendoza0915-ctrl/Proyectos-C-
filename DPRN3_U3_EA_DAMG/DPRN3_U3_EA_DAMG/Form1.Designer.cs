namespace DPRN3_U3_EA_DAMG
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
            GroupAlertas = new GroupBox();
            DataAlertas = new DataGridView();
            GroupVuelos = new GroupBox();
            DataVuelos = new DataGridView();
            label1 = new Label();
            GroupTareas = new GroupBox();
            DataTareas = new DataGridView();
            groupSugerncias = new GroupBox();
            Sugerencias = new ListBox();
            BotonComple = new Button();
            BotonResolver = new Button();
            BotonAsignar = new Button();
            TextNuevaTarea = new TextBox();
            TextAsigIA = new Label();
            BotonActualizar = new Button();
            GroupAlertas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataAlertas).BeginInit();
            GroupVuelos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataVuelos).BeginInit();
            GroupTareas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataTareas).BeginInit();
            groupSugerncias.SuspendLayout();
            SuspendLayout();
            // 
            // GroupAlertas
            // 
            GroupAlertas.Controls.Add(DataAlertas);
            GroupAlertas.Location = new Point(493, 270);
            GroupAlertas.Name = "GroupAlertas";
            GroupAlertas.Size = new Size(409, 190);
            GroupAlertas.TabIndex = 0;
            GroupAlertas.TabStop = false;
            GroupAlertas.Text = "Alertas activas ";
            // 
            // DataAlertas
            // 
            DataAlertas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataAlertas.Location = new Point(6, 22);
            DataAlertas.Name = "DataAlertas";
            DataAlertas.Size = new Size(396, 161);
            DataAlertas.TabIndex = 5;
            // 
            // GroupVuelos
            // 
            GroupVuelos.Controls.Add(DataVuelos);
            GroupVuelos.Location = new Point(929, 270);
            GroupVuelos.Name = "GroupVuelos";
            GroupVuelos.Size = new Size(522, 190);
            GroupVuelos.TabIndex = 1;
            GroupVuelos.TabStop = false;
            GroupVuelos.Text = "Estado de Vuelos ";
            // 
            // DataVuelos
            // 
            DataVuelos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataVuelos.Location = new Point(6, 22);
            DataVuelos.Name = "DataVuelos";
            DataVuelos.Size = new Size(510, 161);
            DataVuelos.TabIndex = 0;
            DataVuelos.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(599, 1);
            label1.Name = "label1";
            label1.Size = new Size(186, 42);
            label1.TabIndex = 2;
            label1.Text = "AeroAssit";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // GroupTareas
            // 
            GroupTareas.Controls.Add(DataTareas);
            GroupTareas.Location = new Point(12, 281);
            GroupTareas.Name = "GroupTareas";
            GroupTareas.Size = new Size(443, 179);
            GroupTareas.TabIndex = 3;
            GroupTareas.TabStop = false;
            GroupTareas.Text = "Tareas Asignadas";
            // 
            // DataTareas
            // 
            DataTareas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataTareas.Location = new Point(12, 22);
            DataTareas.Name = "DataTareas";
            DataTareas.Size = new Size(425, 150);
            DataTareas.TabIndex = 0;
            // 
            // groupSugerncias
            // 
            groupSugerncias.Controls.Add(Sugerencias);
            groupSugerncias.Location = new Point(272, 39);
            groupSugerncias.Name = "groupSugerncias";
            groupSugerncias.Size = new Size(987, 179);
            groupSugerncias.TabIndex = 4;
            groupSugerncias.TabStop = false;
            groupSugerncias.Text = "Acciones sugreridas";
            // 
            // Sugerencias
            // 
            Sugerencias.FormattingEnabled = true;
            Sugerencias.Location = new Point(17, 24);
            Sugerencias.Name = "Sugerencias";
            Sugerencias.Size = new Size(943, 154);
            Sugerencias.TabIndex = 0;
            // 
            // BotonComple
            // 
            BotonComple.Location = new Point(599, 481);
            BotonComple.Name = "BotonComple";
            BotonComple.Size = new Size(129, 23);
            BotonComple.TabIndex = 5;
            BotonComple.Text = "Completar Tarea";
            BotonComple.UseVisualStyleBackColor = true;
            BotonComple.Click += BotonComple_Click;
            // 
            // BotonResolver
            // 
            BotonResolver.Location = new Point(807, 481);
            BotonResolver.Name = "BotonResolver";
            BotonResolver.Size = new Size(129, 23);
            BotonResolver.TabIndex = 6;
            BotonResolver.Text = "Resolver Incidente";
            BotonResolver.UseVisualStyleBackColor = true;
            BotonResolver.Click += BotonResolver_Click;
            // 
            // BotonAsignar
            // 
            BotonAsignar.Location = new Point(395, 481);
            BotonAsignar.Name = "BotonAsignar";
            BotonAsignar.Size = new Size(129, 23);
            BotonAsignar.TabIndex = 7;
            BotonAsignar.Text = "Asignar tarea Con IA";
            BotonAsignar.UseVisualStyleBackColor = true;
            BotonAsignar.Click += BotonAsignar_Click;
            // 
            // TextNuevaTarea
            // 
            TextNuevaTarea.Location = new Point(49, 482);
            TextNuevaTarea.Name = "TextNuevaTarea";
            TextNuevaTarea.Size = new Size(261, 23);
            TextNuevaTarea.TabIndex = 8;
            // 
            // TextAsigIA
            // 
            TextAsigIA.AutoSize = true;
            TextAsigIA.Location = new Point(49, 463);
            TextAsigIA.Name = "TextAsigIA";
            TextAsigIA.Size = new Size(120, 15);
            TextAsigIA.TabIndex = 9;
            TextAsigIA.Text = "Ingrese la asignación:";
            // 
            // BotonActualizar
            // 
            BotonActualizar.Location = new Point(1061, 480);
            BotonActualizar.Name = "BotonActualizar";
            BotonActualizar.Size = new Size(125, 23);
            BotonActualizar.TabIndex = 10;
            BotonActualizar.Text = "Actualizar";
            BotonActualizar.UseVisualStyleBackColor = true;
            BotonActualizar.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1511, 556);
            Controls.Add(BotonActualizar);
            Controls.Add(TextAsigIA);
            Controls.Add(TextNuevaTarea);
            Controls.Add(BotonAsignar);
            Controls.Add(BotonResolver);
            Controls.Add(BotonComple);
            Controls.Add(groupSugerncias);
            Controls.Add(GroupTareas);
            Controls.Add(label1);
            Controls.Add(GroupVuelos);
            Controls.Add(GroupAlertas);
            Name = "Form1";
            Text = "AeroAssist";
            Load += Form1_Load;
            GroupAlertas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataAlertas).EndInit();
            GroupVuelos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataVuelos).EndInit();
            GroupTareas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataTareas).EndInit();
            groupSugerncias.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox GroupAlertas;
        private GroupBox GroupVuelos;
        private Label label1;
        private GroupBox GroupTareas;
        private GroupBox groupSugerncias;
        private DataGridView DataAlertas;
        private DataGridView DataVuelos;
        private DataGridView DataTareas;
        private ListBox Sugerencias;
        private Button BotonComple;
        private Button BotonResolver;
        private Button BotonAsignar;
        private TextBox TextNuevaTarea;
        private Label TextAsigIA;
        private Button BotonActualizar;
    }
}
