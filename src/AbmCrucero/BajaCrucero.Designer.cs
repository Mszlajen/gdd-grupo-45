namespace FrbaCrucero.AbmCrucero
{
    partial class BajaCrucero
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
            this.baja = new System.Windows.Forms.CheckBox();
            this.regresa = new System.Windows.Forms.CheckBox();
            this.permanente = new System.Windows.Forms.CheckBox();
            this.fechaRegreso = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.fechaBaja = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // baja
            // 
            this.baja.AutoSize = true;
            this.baja.Location = new System.Drawing.Point(12, 12);
            this.baja.Name = "baja";
            this.baja.Size = new System.Drawing.Size(81, 17);
            this.baja.TabIndex = 53;
            this.baja.Text = "Dar de baja";
            this.baja.UseVisualStyleBackColor = true;
            this.baja.CheckedChanged += new System.EventHandler(this.baja_CheckedChanged);
            // 
            // regresa
            // 
            this.regresa.AutoSize = true;
            this.regresa.Location = new System.Drawing.Point(16, 74);
            this.regresa.Name = "regresa";
            this.regresa.Size = new System.Drawing.Size(66, 17);
            this.regresa.TabIndex = 52;
            this.regresa.Text = "Regresa";
            this.regresa.UseVisualStyleBackColor = true;
            // 
            // permanente
            // 
            this.permanente.AutoSize = true;
            this.permanente.Location = new System.Drawing.Point(97, 12);
            this.permanente.Name = "permanente";
            this.permanente.Size = new System.Drawing.Size(83, 17);
            this.permanente.TabIndex = 51;
            this.permanente.Text = "Permanente";
            this.permanente.UseVisualStyleBackColor = true;
            this.permanente.CheckedChanged += new System.EventHandler(this.permanente_CheckedChanged);
            // 
            // fechaRegreso
            // 
            this.fechaRegreso.Location = new System.Drawing.Point(16, 110);
            this.fechaRegreso.Name = "fechaRegreso";
            this.fechaRegreso.Size = new System.Drawing.Size(200, 20);
            this.fechaRegreso.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Fecha de Regreso:";
            // 
            // fechaBaja
            // 
            this.fechaBaja.Location = new System.Drawing.Point(16, 48);
            this.fechaBaja.Name = "fechaBaja";
            this.fechaBaja.Size = new System.Drawing.Size(200, 20);
            this.fechaBaja.TabIndex = 48;
            this.fechaBaja.ValueChanged += new System.EventHandler(this.fechaBaja_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Fecha de Baja:";
            // 
            // BajaCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.baja);
            this.Controls.Add(this.regresa);
            this.Controls.Add(this.permanente);
            this.Controls.Add(this.fechaRegreso);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fechaBaja);
            this.Controls.Add(this.label8);
            this.Name = "BajaCrucero";
            this.Text = "BajaCrucero";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox baja;
        private System.Windows.Forms.CheckBox regresa;
        private System.Windows.Forms.CheckBox permanente;
        private System.Windows.Forms.DateTimePicker fechaRegreso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker fechaBaja;
        private System.Windows.Forms.Label label8;
    }
}