namespace SistemaGestionAcademicaApp
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.btnGestionUsuarios = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnGestionMaterias = new System.Windows.Forms.Button();
            this.btnGestionEstudiantes = new System.Windows.Forms.Button();
            this.btnGestionMatriculas = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.Location = new System.Drawing.Point(58, 62);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Size = new System.Drawing.Size(191, 23);
            this.btnGestionUsuarios.TabIndex = 0;
            this.btnGestionUsuarios.Text = "Gestion Usuarios";
            this.btnGestionUsuarios.UseVisualStyleBackColor = true;
            this.btnGestionUsuarios.Click += new System.EventHandler(this.btnGestionUsuarios_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRegresar.Location = new System.Drawing.Point(96, 15);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(113, 23);
            this.btnRegresar.TabIndex = 1;
            this.btnRegresar.Text = "Cerrar Sesion";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnGestionMaterias
            // 
            this.btnGestionMaterias.Location = new System.Drawing.Point(58, 102);
            this.btnGestionMaterias.Name = "btnGestionMaterias";
            this.btnGestionMaterias.Size = new System.Drawing.Size(191, 23);
            this.btnGestionMaterias.TabIndex = 2;
            this.btnGestionMaterias.Text = "Gestion Materias";
            this.btnGestionMaterias.UseVisualStyleBackColor = true;
            this.btnGestionMaterias.Click += new System.EventHandler(this.btnGestionMaterias_Click);
            // 
            // btnGestionEstudiantes
            // 
            this.btnGestionEstudiantes.Location = new System.Drawing.Point(58, 145);
            this.btnGestionEstudiantes.Name = "btnGestionEstudiantes";
            this.btnGestionEstudiantes.Size = new System.Drawing.Size(191, 23);
            this.btnGestionEstudiantes.TabIndex = 3;
            this.btnGestionEstudiantes.Text = "Gestion Estudiantes";
            this.btnGestionEstudiantes.UseVisualStyleBackColor = true;
            this.btnGestionEstudiantes.Click += new System.EventHandler(this.btnGestionEstudiantes_Click);
            // 
            // btnGestionMatriculas
            // 
            this.btnGestionMatriculas.Location = new System.Drawing.Point(58, 183);
            this.btnGestionMatriculas.Name = "btnGestionMatriculas";
            this.btnGestionMatriculas.Size = new System.Drawing.Size(191, 23);
            this.btnGestionMatriculas.TabIndex = 4;
            this.btnGestionMatriculas.Text = "Gestion Matriculas";
            this.btnGestionMatriculas.UseVisualStyleBackColor = true;
            this.btnGestionMatriculas.Click += new System.EventHandler(this.btnGestionMatriculas_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Maroon;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(1, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 48);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "BIENVENID@ TU ROL ES ADMINISTRADOR";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Maroon;
            this.groupBox1.Controls.Add(this.btnRegresar);
            this.groupBox1.Location = new System.Drawing.Point(1, 223);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 48);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(304, 270);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGestionMatriculas);
            this.Controls.Add(this.btnGestionEstudiantes);
            this.Controls.Add(this.btnGestionMaterias);
            this.Controls.Add(this.btnGestionUsuarios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnGestionMaterias;
        private System.Windows.Forms.Button btnGestionEstudiantes;
        private System.Windows.Forms.Button btnGestionMatriculas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}