namespace ClinicaFrba.Compra_Bono
{
    partial class frmCompraBono
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
            this.components = new System.ComponentModel.Container();
            this.cmbAfiliado = new System.Windows.Forms.ComboBox();
            this.gD2C2016DataSet = new ClinicaFrba.GD2C2016DataSet();
            this.personaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personaTableAdapter = new ClinicaFrba.GD2C2016DataSetTableAdapters.PersonaTableAdapter();
            this.txtPlan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.dudCantidad = new System.Windows.Forms.DomainUpDown();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnComprar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAfiliado
            // 
            this.cmbAfiliado.FormattingEnabled = true;
            this.cmbAfiliado.Location = new System.Drawing.Point(59, 64);
            this.cmbAfiliado.Name = "cmbAfiliado";
            this.cmbAfiliado.Size = new System.Drawing.Size(181, 21);
            this.cmbAfiliado.TabIndex = 0;
            // 
            // gD2C2016DataSet
            // 
            this.gD2C2016DataSet.DataSetName = "GD2C2016DataSet";
            this.gD2C2016DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // personaBindingSource
            // 
            this.personaBindingSource.DataMember = "Persona";
            this.personaBindingSource.DataSource = this.gD2C2016DataSet;
            // 
            // personaTableAdapter
            // 
            this.personaTableAdapter.ClearBeforeFill = true;
            // 
            // txtPlan
            // 
            this.txtPlan.Enabled = false;
            this.txtPlan.Location = new System.Drawing.Point(359, 64);
            this.txtPlan.Name = "txtPlan";
            this.txtPlan.Size = new System.Drawing.Size(100, 20);
            this.txtPlan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Afiliado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Plan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Costo unitario bono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Cantidad de bonos";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Total a pagar";
            // 
            // txtCosto
            // 
            this.txtCosto.Enabled = false;
            this.txtCosto.Location = new System.Drawing.Point(65, 207);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(100, 20);
            this.txtCosto.TabIndex = 7;
            // 
            // dudCantidad
            // 
            this.dudCantidad.Items.Add("1");
            this.dudCantidad.Items.Add("2");
            this.dudCantidad.Items.Add("3");
            this.dudCantidad.Items.Add("4");
            this.dudCantidad.Items.Add("5");
            this.dudCantidad.Items.Add("6");
            this.dudCantidad.Items.Add("7");
            this.dudCantidad.Items.Add("8");
            this.dudCantidad.Items.Add("9");
            this.dudCantidad.Items.Add("10");
            this.dudCantidad.Items.Add("11");
            this.dudCantidad.Items.Add("12");
            this.dudCantidad.Items.Add("13");
            this.dudCantidad.Items.Add("14");
            this.dudCantidad.Items.Add("15");
            this.dudCantidad.Items.Add("16");
            this.dudCantidad.Items.Add("17");
            this.dudCantidad.Items.Add("18");
            this.dudCantidad.Items.Add("19");
            this.dudCantidad.Items.Add("20");
            this.dudCantidad.Location = new System.Drawing.Point(359, 208);
            this.dudCantidad.Name = "dudCantidad";
            this.dudCantidad.Size = new System.Drawing.Size(100, 20);
            this.dudCantidad.TabIndex = 8;
            this.dudCantidad.Text = "domainUpDown1";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(219, 304);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 9;
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(415, 300);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(105, 49);
            this.btnComprar.TabIndex = 10;
            this.btnComprar.Text = "Comprar Bono";
            this.btnComprar.UseVisualStyleBackColor = true;
            // 
            // frmCompraBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 657);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.dudCantidad);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPlan);
            this.Controls.Add(this.cmbAfiliado);
            this.Name = "frmCompraBono";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAfiliado;
        private GD2C2016DataSet gD2C2016DataSet;
        private System.Windows.Forms.BindingSource personaBindingSource;
        private GD2C2016DataSetTableAdapters.PersonaTableAdapter personaTableAdapter;
        private System.Windows.Forms.TextBox txtPlan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.DomainUpDown dudCantidad;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnComprar;
    }
}