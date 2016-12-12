namespace ClinicaFrba.Listados
{
    partial class frmListados
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
            this.dgListados = new System.Windows.Forms.DataGridView();
            this.dtpAno = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbListado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpMes = new System.Windows.Forms.DateTimePicker();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblEspe = new System.Windows.Forms.Label();
            this.cbEspecialidad = new System.Windows.Forms.ComboBox();
            this.cbPlan = new System.Windows.Forms.ComboBox();
            this.rdPrimerSemestre = new System.Windows.Forms.RadioButton();
            this.rbSegundoSemestre = new System.Windows.Forms.RadioButton();
            this.rbMes = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgListados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgListados
            // 
            this.dgListados.AllowUserToAddRows = false;
            this.dgListados.AllowUserToDeleteRows = false;
            this.dgListados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListados.Location = new System.Drawing.Point(85, 282);
            this.dgListados.Name = "dgListados";
            this.dgListados.ReadOnly = true;
            this.dgListados.Size = new System.Drawing.Size(814, 299);
            this.dgListados.TabIndex = 0;
            // 
            // dtpAno
            // 
            this.dtpAno.CustomFormat = "yyyy";
            this.dtpAno.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAno.Location = new System.Drawing.Point(189, 31);
            this.dtpAno.Name = "dtpAno";
            this.dtpAno.ShowUpDown = true;
            this.dtpAno.Size = new System.Drawing.Size(80, 20);
            this.dtpAno.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Año";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(643, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Consultar Estadísticas";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cbListado
            // 
            this.cbListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListado.FormattingEnabled = true;
            this.cbListado.Items.AddRange(new object[] {
            "Especialidades con más cancelaciones",
            "Profesionales más consultados",
            "Profesionales con menos horas trabajadas",
            "Afiliados con más bonos comprados",
            "Especialidades con más bonos"});
            this.cbListado.Location = new System.Drawing.Point(209, 205);
            this.cbListado.Name = "cbListado";
            this.cbListado.Size = new System.Drawing.Size(293, 21);
            this.cbListado.TabIndex = 5;
            this.cbListado.SelectedIndexChanged += new System.EventHandler(this.cbListado_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Listado";
            // 
            // dtpMes
            // 
            this.dtpMes.CustomFormat = "MM";
            this.dtpMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMes.Location = new System.Drawing.Point(114, 87);
            this.dtpMes.Name = "dtpMes";
            this.dtpMes.ShowUpDown = true;
            this.dtpMes.Size = new System.Drawing.Size(80, 20);
            this.dtpMes.TabIndex = 7;
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(507, 50);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(28, 13);
            this.lblPlan.TabIndex = 8;
            this.lblPlan.Text = "Plan";
            // 
            // lblEspe
            // 
            this.lblEspe.AutoSize = true;
            this.lblEspe.Location = new System.Drawing.Point(507, 126);
            this.lblEspe.Name = "lblEspe";
            this.lblEspe.Size = new System.Drawing.Size(67, 13);
            this.lblEspe.TabIndex = 9;
            this.lblEspe.Text = "Especialidad";
            // 
            // cbEspecialidad
            // 
            this.cbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEspecialidad.FormattingEnabled = true;
            this.cbEspecialidad.Location = new System.Drawing.Point(643, 124);
            this.cbEspecialidad.Name = "cbEspecialidad";
            this.cbEspecialidad.Size = new System.Drawing.Size(156, 21);
            this.cbEspecialidad.TabIndex = 10;
            // 
            // cbPlan
            // 
            this.cbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlan.FormattingEnabled = true;
            this.cbPlan.Location = new System.Drawing.Point(643, 47);
            this.cbPlan.Name = "cbPlan";
            this.cbPlan.Size = new System.Drawing.Size(156, 21);
            this.cbPlan.TabIndex = 11;
            // 
            // rdPrimerSemestre
            // 
            this.rdPrimerSemestre.AutoSize = true;
            this.rdPrimerSemestre.Checked = true;
            this.rdPrimerSemestre.Location = new System.Drawing.Point(27, 19);
            this.rdPrimerSemestre.Name = "rdPrimerSemestre";
            this.rdPrimerSemestre.Size = new System.Drawing.Size(101, 17);
            this.rdPrimerSemestre.TabIndex = 12;
            this.rdPrimerSemestre.TabStop = true;
            this.rdPrimerSemestre.Text = "Primer Semestre";
            this.rdPrimerSemestre.UseVisualStyleBackColor = true;
            this.rdPrimerSemestre.CheckedChanged += new System.EventHandler(this.rdPrimerSemestre_CheckedChanged);
            // 
            // rbSegundoSemestre
            // 
            this.rbSegundoSemestre.AutoSize = true;
            this.rbSegundoSemestre.Location = new System.Drawing.Point(27, 54);
            this.rbSegundoSemestre.Name = "rbSegundoSemestre";
            this.rbSegundoSemestre.Size = new System.Drawing.Size(115, 17);
            this.rbSegundoSemestre.TabIndex = 13;
            this.rbSegundoSemestre.Text = "Segundo Semestre";
            this.rbSegundoSemestre.UseVisualStyleBackColor = true;
            this.rbSegundoSemestre.CheckedChanged += new System.EventHandler(this.rbSegundoSemestre_CheckedChanged);
            // 
            // rbMes
            // 
            this.rbMes.AutoSize = true;
            this.rbMes.Location = new System.Drawing.Point(27, 87);
            this.rbMes.Name = "rbMes";
            this.rbMes.Size = new System.Drawing.Size(45, 17);
            this.rbMes.TabIndex = 14;
            this.rbMes.TabStop = true;
            this.rbMes.Text = "Mes";
            this.rbMes.UseVisualStyleBackColor = true;
            this.rbMes.CheckedChanged += new System.EventHandler(this.rbMes_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdPrimerSemestre);
            this.groupBox1.Controls.Add(this.rbMes);
            this.groupBox1.Controls.Add(this.dtpMes);
            this.groupBox1.Controls.Add(this.rbSegundoSemestre);
            this.groupBox1.Location = new System.Drawing.Point(141, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 124);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rango";
            // 
            // frmListados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 624);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbPlan);
            this.Controls.Add(this.cbEspecialidad);
            this.Controls.Add(this.lblEspe);
            this.Controls.Add(this.lblPlan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbListado);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpAno);
            this.Controls.Add(this.dgListados);
            this.Name = "frmListados";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmListados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgListados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgListados;
        private System.Windows.Forms.DateTimePicker dtpAno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbListado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpMes;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lblEspe;
        private System.Windows.Forms.ComboBox cbEspecialidad;
        private System.Windows.Forms.ComboBox cbPlan;
        private System.Windows.Forms.RadioButton rdPrimerSemestre;
        private System.Windows.Forms.RadioButton rbSegundoSemestre;
        private System.Windows.Forms.RadioButton rbMes;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}