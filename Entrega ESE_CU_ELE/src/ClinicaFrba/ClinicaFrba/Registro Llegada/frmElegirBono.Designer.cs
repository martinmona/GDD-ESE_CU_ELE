namespace ClinicaFrba.Registro_Llegada
{
    partial class frmElegirBono
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
            this.dgvBonos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBonos
            // 
            this.dgvBonos.AllowUserToAddRows = false;
            this.dgvBonos.AllowUserToDeleteRows = false;
            this.dgvBonos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBonos.Location = new System.Drawing.Point(33, 42);
            this.dgvBonos.MultiSelect = false;
            this.dgvBonos.Name = "dgvBonos";
            this.dgvBonos.ReadOnly = true;
            this.dgvBonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBonos.Size = new System.Drawing.Size(510, 235);
            this.dgvBonos.TabIndex = 0;
            this.dgvBonos.DoubleClick += new System.EventHandler(this.dgvBonos_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione un bono haciendo doble click";
            // 
            // frmElegirBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 360);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBonos);
            this.Name = "frmElegirBono";
            this.Text = "frmElegirBono";
            this.Load += new System.EventHandler(this.frmElegirBono_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBonos;
        private System.Windows.Forms.Label label1;
    }
}