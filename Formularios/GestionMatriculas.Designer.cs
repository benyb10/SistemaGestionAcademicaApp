namespace SistemaGestionAcademicaApp.Formularios
{
    partial class GestionMatriculas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionMatriculas));
            this.cmbRepiteMateria = new System.Windows.Forms.ComboBox();
            this.cmbMaterias = new System.Windows.Forms.ComboBox();
            this.cmbSemestres = new System.Windows.Forms.ComboBox();
            this.dataGridMatriculas = new System.Windows.Forms.DataGridView();
            this.button_Matricular = new System.Windows.Forms.Button();
            this.button_Modificar = new System.Windows.Forms.Button();
            this.button_Eliminar = new System.Windows.Forms.Button();
            this.txtBuscarCedula = new System.Windows.Forms.TextBox();
            this.btnBuscarEstudiante = new System.Windows.Forms.Button();
            this.dataGridEstudiantes = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportarMatriculas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMatriculas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstudiantes)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRepiteMateria
            // 
            this.cmbRepiteMateria.FormattingEnabled = true;
            this.cmbRepiteMateria.Location = new System.Drawing.Point(397, 126);
            this.cmbRepiteMateria.Name = "cmbRepiteMateria";
            this.cmbRepiteMateria.Size = new System.Drawing.Size(114, 21);
            this.cmbRepiteMateria.TabIndex = 0;
            // 
            // cmbMaterias
            // 
            this.cmbMaterias.FormattingEnabled = true;
            this.cmbMaterias.Location = new System.Drawing.Point(188, 126);
            this.cmbMaterias.Name = "cmbMaterias";
            this.cmbMaterias.Size = new System.Drawing.Size(164, 21);
            this.cmbMaterias.TabIndex = 1;
            // 
            // cmbSemestres
            // 
            this.cmbSemestres.FormattingEnabled = true;
            this.cmbSemestres.Location = new System.Drawing.Point(12, 126);
            this.cmbSemestres.Name = "cmbSemestres";
            this.cmbSemestres.Size = new System.Drawing.Size(159, 21);
            this.cmbSemestres.TabIndex = 2;
            // 
            // dataGridMatriculas
            // 
            this.dataGridMatriculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMatriculas.Location = new System.Drawing.Point(393, 175);
            this.dataGridMatriculas.Name = "dataGridMatriculas";
            this.dataGridMatriculas.Size = new System.Drawing.Size(395, 204);
            this.dataGridMatriculas.TabIndex = 5;
            this.dataGridMatriculas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMatriculas_CellClick);
            // 
            // button_Matricular
            // 
            this.button_Matricular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Matricular.ForeColor = System.Drawing.SystemColors.Control;
            this.button_Matricular.Location = new System.Drawing.Point(89, 16);
            this.button_Matricular.Name = "button_Matricular";
            this.button_Matricular.Size = new System.Drawing.Size(105, 23);
            this.button_Matricular.TabIndex = 6;
            this.button_Matricular.Text = "Matricular";
            this.button_Matricular.UseVisualStyleBackColor = true;
            this.button_Matricular.Click += new System.EventHandler(this.button_Matricular_Click);
            // 
            // button_Modificar
            // 
            this.button_Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Modificar.ForeColor = System.Drawing.SystemColors.Control;
            this.button_Modificar.Location = new System.Drawing.Point(217, 16);
            this.button_Modificar.Name = "button_Modificar";
            this.button_Modificar.Size = new System.Drawing.Size(105, 23);
            this.button_Modificar.TabIndex = 7;
            this.button_Modificar.Text = "Modificar";
            this.button_Modificar.UseVisualStyleBackColor = true;
            this.button_Modificar.Click += new System.EventHandler(this.button_Modificar_Click);
            // 
            // button_Eliminar
            // 
            this.button_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Eliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.button_Eliminar.Location = new System.Drawing.Point(344, 16);
            this.button_Eliminar.Name = "button_Eliminar";
            this.button_Eliminar.Size = new System.Drawing.Size(105, 23);
            this.button_Eliminar.TabIndex = 8;
            this.button_Eliminar.Text = "Eliminar";
            this.button_Eliminar.UseVisualStyleBackColor = true;
            this.button_Eliminar.Click += new System.EventHandler(this.button_Eliminar_Click);
            // 
            // txtBuscarCedula
            // 
            this.txtBuscarCedula.Location = new System.Drawing.Point(12, 77);
            this.txtBuscarCedula.Name = "txtBuscarCedula";
            this.txtBuscarCedula.Size = new System.Drawing.Size(114, 20);
            this.txtBuscarCedula.TabIndex = 9;
            // 
            // btnBuscarEstudiante
            // 
            this.btnBuscarEstudiante.Location = new System.Drawing.Point(167, 77);
            this.btnBuscarEstudiante.Name = "btnBuscarEstudiante";
            this.btnBuscarEstudiante.Size = new System.Drawing.Size(105, 20);
            this.btnBuscarEstudiante.TabIndex = 10;
            this.btnBuscarEstudiante.Text = "Buscar";
            this.btnBuscarEstudiante.UseVisualStyleBackColor = true;
            this.btnBuscarEstudiante.Click += new System.EventHandler(this.btnBuscarEstudiante_Click);
            // 
            // dataGridEstudiantes
            // 
            this.dataGridEstudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEstudiantes.Location = new System.Drawing.Point(4, 175);
            this.dataGridEstudiantes.Name = "dataGridEstudiantes";
            this.dataGridEstudiantes.Size = new System.Drawing.Size(379, 204);
            this.dataGridEstudiantes.TabIndex = 11;
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(476, 16);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(105, 23);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "Regresar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Buscar por Cedula:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Semestres:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Materias:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Repite la Materia:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Estudiantes:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(390, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Matriculas:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Maroon;
            this.groupBox2.Controls.Add(this.lblNombreCompleto);
            this.groupBox2.Location = new System.Drawing.Point(0, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(802, 48);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCompleto.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNombreCompleto.Location = new System.Drawing.Point(16, 16);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(0, 16);
            this.lblNombreCompleto.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Maroon;
            this.groupBox1.Controls.Add(this.btnExportarMatriculas);
            this.groupBox1.Controls.Add(this.button_Matricular);
            this.groupBox1.Controls.Add(this.button_Modificar);
            this.groupBox1.Controls.Add(this.button_Eliminar);
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Location = new System.Drawing.Point(-1, 388);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 48);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // btnExportarMatriculas
            // 
            this.btnExportarMatriculas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarMatriculas.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExportarMatriculas.Location = new System.Drawing.Point(601, 16);
            this.btnExportarMatriculas.Name = "btnExportarMatriculas";
            this.btnExportarMatriculas.Size = new System.Drawing.Size(134, 23);
            this.btnExportarMatriculas.TabIndex = 14;
            this.btnExportarMatriculas.Text = "Exportar Matriculas";
            this.btnExportarMatriculas.UseVisualStyleBackColor = true;
            this.btnExportarMatriculas.Click += new System.EventHandler(this.btnExportarMatriculas_Click);
            // 
            // GestionMatriculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 439);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridEstudiantes);
            this.Controls.Add(this.btnBuscarEstudiante);
            this.Controls.Add(this.txtBuscarCedula);
            this.Controls.Add(this.dataGridMatriculas);
            this.Controls.Add(this.cmbSemestres);
            this.Controls.Add(this.cmbMaterias);
            this.Controls.Add(this.cmbRepiteMateria);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GestionMatriculas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionMatriculas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMatriculas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstudiantes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRepiteMateria;
        private System.Windows.Forms.ComboBox cmbMaterias;
        private System.Windows.Forms.ComboBox cmbSemestres;
        private System.Windows.Forms.DataGridView dataGridMatriculas;
        private System.Windows.Forms.Button button_Matricular;
        private System.Windows.Forms.Button button_Modificar;
        private System.Windows.Forms.Button button_Eliminar;
        private System.Windows.Forms.TextBox txtBuscarCedula;
        private System.Windows.Forms.Button btnBuscarEstudiante;
        private System.Windows.Forms.DataGridView dataGridEstudiantes;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExportarMatriculas;
    }
}