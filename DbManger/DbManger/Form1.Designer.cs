namespace DbManger
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RegistoLi = new System.Windows.Forms.GroupBox();
            this.BotonCargarLibro = new System.Windows.Forms.Button();
            this.InEjem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InAutor = new System.Windows.Forms.TextBox();
            this.TextAu = new System.Windows.Forms.Label();
            this.InTitulo = new System.Windows.Forms.TextBox();
            this.TextTi = new System.Windows.Forms.Label();
            this.ListaLibros = new System.Windows.Forms.GroupBox();
            this.BotonMostrar = new System.Windows.Forms.Button();
            this.EliminarPres = new System.Windows.Forms.GroupBox();
            this.BotonEliminar = new System.Windows.Forms.Button();
            this.InIDPres = new System.Windows.Forms.TextBox();
            this.TextId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.RegistoLi.SuspendLayout();
            this.ListaLibros.SuspendLayout();
            this.EliminarPres.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(417, 156);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // RegistoLi
            // 
            this.RegistoLi.Controls.Add(this.BotonCargarLibro);
            this.RegistoLi.Controls.Add(this.InEjem);
            this.RegistoLi.Controls.Add(this.label1);
            this.RegistoLi.Controls.Add(this.InAutor);
            this.RegistoLi.Controls.Add(this.TextAu);
            this.RegistoLi.Controls.Add(this.InTitulo);
            this.RegistoLi.Controls.Add(this.TextTi);
            this.RegistoLi.Location = new System.Drawing.Point(43, 25);
            this.RegistoLi.Name = "RegistoLi";
            this.RegistoLi.Size = new System.Drawing.Size(453, 164);
            this.RegistoLi.TabIndex = 1;
            this.RegistoLi.TabStop = false;
            this.RegistoLi.Text = "Registrar libro ";
            this.RegistoLi.Enter += new System.EventHandler(this.RegistoLi_Enter);
            // 
            // BotonCargarLibro
            // 
            this.BotonCargarLibro.Location = new System.Drawing.Point(178, 135);
            this.BotonCargarLibro.Name = "BotonCargarLibro";
            this.BotonCargarLibro.Size = new System.Drawing.Size(102, 23);
            this.BotonCargarLibro.TabIndex = 7;
            this.BotonCargarLibro.Text = "Cargar Libro";
            this.BotonCargarLibro.UseVisualStyleBackColor = true;
            this.BotonCargarLibro.Click += new System.EventHandler(this.BotonCargarLibro_Click);
            // 
            // InEjem
            // 
            this.InEjem.Location = new System.Drawing.Point(178, 92);
            this.InEjem.Name = "InEjem";
            this.InEjem.Size = new System.Drawing.Size(213, 20);
            this.InEjem.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ejemplares disponbiles: ";
            // 
            // InAutor
            // 
            this.InAutor.Location = new System.Drawing.Point(178, 54);
            this.InAutor.Name = "InAutor";
            this.InAutor.Size = new System.Drawing.Size(213, 20);
            this.InAutor.TabIndex = 4;
            // 
            // TextAu
            // 
            this.TextAu.AutoSize = true;
            this.TextAu.Location = new System.Drawing.Point(42, 61);
            this.TextAu.Name = "TextAu";
            this.TextAu.Size = new System.Drawing.Size(38, 13);
            this.TextAu.TabIndex = 3;
            this.TextAu.Text = "Autor: ";
            // 
            // InTitulo
            // 
            this.InTitulo.Location = new System.Drawing.Point(178, 19);
            this.InTitulo.Name = "InTitulo";
            this.InTitulo.Size = new System.Drawing.Size(213, 20);
            this.InTitulo.TabIndex = 2;
            this.InTitulo.TextChanged += new System.EventHandler(this.InTitulo_TextChanged);
            // 
            // TextTi
            // 
            this.TextTi.AutoSize = true;
            this.TextTi.Location = new System.Drawing.Point(42, 26);
            this.TextTi.Name = "TextTi";
            this.TextTi.Size = new System.Drawing.Size(39, 13);
            this.TextTi.TabIndex = 1;
            this.TextTi.Text = "Titulo: ";
            // 
            // ListaLibros
            // 
            this.ListaLibros.Controls.Add(this.BotonMostrar);
            this.ListaLibros.Controls.Add(this.dataGridView1);
            this.ListaLibros.Location = new System.Drawing.Point(43, 204);
            this.ListaLibros.Name = "ListaLibros";
            this.ListaLibros.Size = new System.Drawing.Size(453, 258);
            this.ListaLibros.TabIndex = 2;
            this.ListaLibros.TabStop = false;
            this.ListaLibros.Text = "Lista de libros ";
            this.ListaLibros.Enter += new System.EventHandler(this.ListaLibros_Enter);
            // 
            // BotonMostrar
            // 
            this.BotonMostrar.Location = new System.Drawing.Point(164, 203);
            this.BotonMostrar.Name = "BotonMostrar";
            this.BotonMostrar.Size = new System.Drawing.Size(116, 23);
            this.BotonMostrar.TabIndex = 1;
            this.BotonMostrar.Text = "Mostrar Libros ";
            this.BotonMostrar.UseVisualStyleBackColor = true;
            this.BotonMostrar.Click += new System.EventHandler(this.BotonMostrar_Click);
            // 
            // EliminarPres
            // 
            this.EliminarPres.Controls.Add(this.BotonEliminar);
            this.EliminarPres.Controls.Add(this.InIDPres);
            this.EliminarPres.Controls.Add(this.TextId);
            this.EliminarPres.Location = new System.Drawing.Point(43, 468);
            this.EliminarPres.Name = "EliminarPres";
            this.EliminarPres.Size = new System.Drawing.Size(453, 100);
            this.EliminarPres.TabIndex = 4;
            this.EliminarPres.TabStop = false;
            this.EliminarPres.Text = "Eliminar Prestamo";
            // 
            // BotonEliminar
            // 
            this.BotonEliminar.Location = new System.Drawing.Point(178, 71);
            this.BotonEliminar.Name = "BotonEliminar";
            this.BotonEliminar.Size = new System.Drawing.Size(116, 23);
            this.BotonEliminar.TabIndex = 2;
            this.BotonEliminar.Text = "Eliminar prestamo ";
            this.BotonEliminar.UseVisualStyleBackColor = true;
            this.BotonEliminar.Click += new System.EventHandler(this.BotonEliminar_Click);
            // 
            // InIDPres
            // 
            this.InIDPres.Location = new System.Drawing.Point(178, 22);
            this.InIDPres.Name = "InIDPres";
            this.InIDPres.Size = new System.Drawing.Size(213, 20);
            this.InIDPres.TabIndex = 8;
            // 
            // TextId
            // 
            this.TextId.AutoSize = true;
            this.TextId.Location = new System.Drawing.Point(41, 29);
            this.TextId.Name = "TextId";
            this.TextId.Size = new System.Drawing.Size(87, 13);
            this.TextId.TabIndex = 2;
            this.TextId.Text = "ID del prestamo: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 632);
            this.Controls.Add(this.EliminarPres);
            this.Controls.Add(this.ListaLibros);
            this.Controls.Add(this.RegistoLi);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.RegistoLi.ResumeLayout(false);
            this.RegistoLi.PerformLayout();
            this.ListaLibros.ResumeLayout(false);
            this.EliminarPres.ResumeLayout(false);
            this.EliminarPres.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox RegistoLi;
        private System.Windows.Forms.TextBox InTitulo;
        private System.Windows.Forms.Label TextTi;
        private System.Windows.Forms.TextBox InAutor;
        private System.Windows.Forms.Label TextAu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InEjem;
        private System.Windows.Forms.Button BotonCargarLibro;
        private System.Windows.Forms.GroupBox ListaLibros;
        private System.Windows.Forms.Button BotonMostrar;
        private System.Windows.Forms.GroupBox EliminarPres;
        private System.Windows.Forms.Button BotonEliminar;
        private System.Windows.Forms.TextBox InIDPres;
        private System.Windows.Forms.Label TextId;
    }
}

