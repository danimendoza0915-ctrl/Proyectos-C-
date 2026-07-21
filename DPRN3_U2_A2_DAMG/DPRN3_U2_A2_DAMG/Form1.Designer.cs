namespace DPRN3_U2_A2_DAMG
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
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            comboBox3 = new ComboBox();
            textBox4 = new TextBox();
            label8 = new Label();
            comboBox2 = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            numericUpDown1 = new NumericUpDown();
            comboBox1 = new ComboBox();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            groupBox3 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label9 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            dataGridView1 = new DataGridView();
            mySqlCommand2 = new MySql.Data.MySqlClient.MySqlCommand();
            label10 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(614, 160);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 119);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 5;
            label3.Text = "Correo electrónico:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 72);
            label2.Name = "label2";
            label2.Size = new Size(122, 15);
            label2.TabIndex = 4;
            label2.Text = "Teléfono de contacto:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 30);
            label1.Name = "label1";
            label1.Size = new Size(172, 15);
            label1.TabIndex = 3;
            label1.Text = "Nombre del cliente o empresa: ";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(200, 116);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(304, 23);
            textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(200, 64);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(304, 23);
            textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(200, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(304, 23);
            textBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(comboBox3);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(numericUpDown1);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(dateTimePicker1);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(13, 178);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(613, 257);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos de la reservación";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(288, 188);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(274, 23);
            comboBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(288, 217);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(274, 23);
            textBox4.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 225);
            label8.Name = "label8";
            label8.Size = new Size(81, 15);
            label8.TabIndex = 8;
            label8.Text = "Comentarios: ";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(288, 152);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(274, 23);
            comboBox2.TabIndex = 7;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 155);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 6;
            label7.Text = "Sucursal: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 115);
            label6.Name = "label6";
            label6.Size = new Size(248, 15);
            label6.TabIndex = 5;
            label6.Text = "Capacidad requeridad (numero de personas): ";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(288, 107);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(274, 23);
            numericUpDown1.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(288, 65);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(274, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 73);
            label5.Name = "label5";
            label5.Size = new Size(150, 15);
            label5.TabIndex = 2;
            label5.Text = "Tipo de espacio solicitado: ";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(288, 22);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(274, 23);
            dateTimePicker1.TabIndex = 1;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 28);
            label4.Name = "label4";
            label4.Size = new Size(171, 15);
            label4.TabIndex = 0;
            label4.Text = "Fecha y hora de la reservación: ";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(radioButton2);
            groupBox3.Controls.Add(radioButton1);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(13, 441);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(613, 100);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Notificación";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(406, 54);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(41, 19);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "No";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(213, 54);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(34, 19);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "Si";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(213, 19);
            label9.Name = "label9";
            label9.Size = new Size(234, 15);
            label9.TabIndex = 0;
            label9.Text = "¿Desea notificación por correo electrónico?";
            // 
            // button1
            // 
            button1.Location = new Point(32, 603);
            button1.Name = "button1";
            button1.Size = new Size(137, 23);
            button1.TabIndex = 4;
            button1.Text = "Guardar reservación";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(287, 603);
            button2.Name = "button2";
            button2.Size = new Size(123, 23);
            button2.TabIndex = 5;
            button2.Text = "Limpiar formulario";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(531, 603);
            button3.Name = "button3";
            button3.Size = new Size(95, 23);
            button3.TabIndex = 6;
            button3.Text = "Ver calendario";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 642);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1296, 150);
            dataGridView1.TabIndex = 7;
            dataGridView1.Visible = false;
            // 
            // mySqlCommand2
            // 
            mySqlCommand2.CacheAge = 0;
            mySqlCommand2.Connection = null;
            mySqlCommand2.EnableCaching = false;
            mySqlCommand2.Transaction = null;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(21, 196);
            label10.Name = "label10";
            label10.Size = new Size(59, 15);
            label10.TabIndex = 10;
            label10.Text = "Easpacio: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1296, 792);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Sistema de Reservaciones para el Centro de Coworking “Espacio Conecta”";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private GroupBox groupBox2;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private Label label6;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox1;
        private Label label7;
        private Label label8;
        private ComboBox comboBox2;
        private TextBox textBox4;
        private GroupBox groupBox3;
        private Label label9;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button1;
        private Button button2;
        private Button button3;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private DataGridView dataGridView1;
        private ComboBox comboBox3;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand2;
        private Label label10;
    }
}
