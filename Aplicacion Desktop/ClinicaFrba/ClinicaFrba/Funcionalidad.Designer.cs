namespace ClinicaFrba
{
    partial class FrmFuncionalidad
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
            this.cmbFuncionalidades = new System.Windows.Forms.ComboBox();
            this.lblFunc = new System.Windows.Forms.Label();
            this.btnFunc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbFuncionalidades
            // 
            this.cmbFuncionalidades.FormattingEnabled = true;
            this.cmbFuncionalidades.Location = new System.Drawing.Point(190, 32);
            this.cmbFuncionalidades.Name = "cmbFuncionalidades";
            this.cmbFuncionalidades.Size = new System.Drawing.Size(193, 21);
            this.cmbFuncionalidades.TabIndex = 0;
            // 
            // lblFunc
            // 
            this.lblFunc.AutoSize = true;
            this.lblFunc.Location = new System.Drawing.Point(33, 35);
            this.lblFunc.Name = "lblFunc";
            this.lblFunc.Size = new System.Drawing.Size(126, 13);
            this.lblFunc.TabIndex = 1;
            this.lblFunc.Text = "Seleccione funcionalidad";
            // 
            // btnFunc
            // 
            this.btnFunc.Location = new System.Drawing.Point(143, 122);
            this.btnFunc.Name = "btnFunc";
            this.btnFunc.Size = new System.Drawing.Size(75, 23);
            this.btnFunc.TabIndex = 2;
            this.btnFunc.Text = "Seleccionar";
            this.btnFunc.UseVisualStyleBackColor = true;
            this.btnFunc.Click += new System.EventHandler(this.btnFunc_Click);
            // 
            // FrmFuncionalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 296);
            this.Controls.Add(this.btnFunc);
            this.Controls.Add(this.lblFunc);
            this.Controls.Add(this.cmbFuncionalidades);
            this.Name = "FrmFuncionalidad";
            this.Text = "Funcionalidad";
            this.Load += new System.EventHandler(this.Funcionalidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFuncionalidades;
        private System.Windows.Forms.Label lblFunc;
        private System.Windows.Forms.Button btnFunc;
    }
}