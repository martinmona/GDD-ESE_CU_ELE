namespace ClinicaFrba.Pedir_Turno
{
    partial class frmPedirTurno
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.cmbProfesional = new System.Windows.Forms.ComboBox();
            this.dgHorarios = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDia = new System.Windows.Forms.DateTimePicker();
            this.lblAfiliado = new System.Windows.Forms.Label();
            this.cbAfiliado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgHorarios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Especialidad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Profesional:";
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.DropDownWidth = 128;
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(124, 93);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(147, 21);
            this.cmbEspecialidad.TabIndex = 2;
            this.cmbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cmbEspecialidad_SelectedIndexChanged_1);
            // 
            // cmbProfesional
            // 
            this.cmbProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesional.DropDownWidth = 128;
            this.cmbProfesional.FormattingEnabled = true;
            this.cmbProfesional.Location = new System.Drawing.Point(124, 148);
            this.cmbProfesional.Name = "cmbProfesional";
            this.cmbProfesional.Size = new System.Drawing.Size(147, 21);
            this.cmbProfesional.TabIndex = 3;
            this.cmbProfesional.SelectedIndexChanged += new System.EventHandler(this.cmbProfesional_SelectedIndexChanged_1);
            // 
            // dgHorarios
            // 
            this.dgHorarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHorarios.Location = new System.Drawing.Point(420, 107);
            this.dgHorarios.MultiSelect = false;
            this.dgHorarios.Name = "dgHorarios";
            this.dgHorarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHorarios.Size = new System.Drawing.Size(176, 266);
            this.dgHorarios.TabIndex = 5;
            this.dgHorarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTurnos_CellDoubleClick);
            this.dgHorarios.DoubleClick += new System.EventHandler(this.dgHorarios_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Seleccione dia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Haga doble click para reservar turno";
            // 
            // dtpDia
            // 
            this.dtpDia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDia.Location = new System.Drawing.Point(71, 232);
            this.dtpDia.Name = "dtpDia";
            this.dtpDia.Size = new System.Drawing.Size(107, 20);
            this.dtpDia.TabIndex = 8;
            this.dtpDia.ValueChanged += new System.EventHandler(this.dtpDia_ValueChanged);
            // 
            // lblAfiliado
            // 
            this.lblAfiliado.AutoSize = true;
            this.lblAfiliado.Location = new System.Drawing.Point(37, 43);
            this.lblAfiliado.Name = "lblAfiliado";
            this.lblAfiliado.Size = new System.Drawing.Size(41, 13);
            this.lblAfiliado.TabIndex = 9;
            this.lblAfiliado.Text = "Afiliado";
            // 
            // cbAfiliado
            // 
            this.cbAfiliado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAfiliado.FormattingEnabled = true;
            this.cbAfiliado.Location = new System.Drawing.Point(124, 43);
            this.cbAfiliado.Name = "cbAfiliado";
            this.cbAfiliado.Size = new System.Drawing.Size(147, 21);
            this.cbAfiliado.TabIndex = 10;
            this.cbAfiliado.SelectedIndexChanged += new System.EventHandler(this.cbAfiliado_SelectedIndexChanged);
            // 
            // frmPedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 506);
            this.Controls.Add(this.cbAfiliado);
            this.Controls.Add(this.lblAfiliado);
            this.Controls.Add(this.dtpDia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgHorarios);
            this.Controls.Add(this.cmbProfesional);
            this.Controls.Add(this.cmbEspecialidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmPedirTurno";
            this.Text = "Pedido de Turno";
            this.Load += new System.EventHandler(this.Turno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgHorarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.ComboBox cmbProfesional;
        private System.Windows.Forms.DataGridView dgHorarios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDia;
        private System.Windows.Forms.Label lblAfiliado;
        private System.Windows.Forms.ComboBox cbAfiliado;
    }
}