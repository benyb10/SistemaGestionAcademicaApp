namespace SistemaGestionAcademicaApp
{
    partial class Secretaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Secretaria));
            this.btnGestionEstudiantes = new System.Windows.Forms.Button();
            this.btnGestionMatriculas = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGestionEstudiantes
            // 
            this.btnGestionEstudiantes.Location = new System.Drawing.Point(52, 84);
            this.btnGestionEstudiantes.Name = "btnGestionEstudiantes";
            this.btnGestionEstudiantes.Size = new System.Drawing.Size(235, 23);
            this.btnGestionEstudiantes.TabIndex = 0;
            this.btnGestionEstudiantes.Text = "Gestion de Estudiantes";
            this.btnGestionEstudiantes.UseVisualStyleBackColor = true;
            this.btnGestionEstudiantes.Click += new System.EventHandler(this.btnGestionEstudiantes_Click);
            // 
            // btnGestionMatriculas
            // 
            this.btnGestionMatriculas.Location = new System.Drawing.Point(52, 125);
            this.btnGestionMatriculas.Name = "btnGestionMatriculas";
            this.btnGestionMatriculas.Size = new System.Drawing.Size(235, 23);
            this.btnGestionMatriculas.TabIndex = 1;
            this.btnGestionMatriculas.Text = "Gestion de Matriculas";
            this.btnGestionMatriculas.UseVisualStyleBackColor = true;
            this.btnGestionMatriculas.Click += new System.EventHandler(this.btnGestionMatriculas_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(117, 19);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 21);
            this.btnCerrar.TabIndex = 15;
            this.btnCerrar.Text = "Cerrar Sesion";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Maroon;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(1, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 57);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(48, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "BIENVENID@ TU ROL ES SECRETARI@";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Maroon;
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Location = new System.Drawing.Point(1, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 57);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // Secretaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(334, 220);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGestionMatriculas);
            this.Controls.Add(this.btnGestionEstudiantes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Secretaria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secretaria";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGestionEstudiantes;
        private System.Windows.Forms.Button btnGestionMatriculas;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}