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
            this.permanente = new System.Windows.Forms.CheckBox();
            this.fechaRegreso = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.fechaBaja = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.corrimiento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // permanente
            // 
            this.permanente.AutoSize = true;
            this.permanente.Location = new System.Drawing.Point(15, 51);
            this.permanente.Name = "permanente";
            this.permanente.Size = new System.Drawing.Size(83, 17);
            this.permanente.TabIndex = 51;
            this.permanente.Text = "Permanente";
            this.permanente.UseVisualStyleBackColor = true;
            this.permanente.CheckedChanged += new System.EventHandler(this.permanente_CheckedChanged);
            // 
            // fechaRegreso
            // 
            this.fechaRegreso.Location = new System.Drawing.Point(15, 86);
            this.fechaRegreso.Name = "fechaRegreso";
            this.fechaRegreso.Size = new System.Drawing.Size(200, 20);
            this.fechaRegreso.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Fecha de Regreso:";
            // 
            // fechaBaja
            // 
            this.fechaBaja.Location = new System.Drawing.Point(16, 25);
            this.fechaBaja.Name = "fechaBaja";
            this.fechaBaja.Size = new System.Drawing.Size(200, 20);
            this.fechaBaja.TabIndex = 48;
            this.fechaBaja.ValueChanged += new System.EventHandler(this.fechaBaja_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Fecha de Baja:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 54;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // corrimiento
            // 
            this.corrimiento.Location = new System.Drawing.Point(16, 129);
            this.corrimiento.Name = "corrimiento";
            this.corrimiento.Size = new System.Drawing.Size(100, 20);
            this.corrimiento.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Corrimiento:";
            // 
            // BajaCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 163);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.corrimiento);
            this.Controls.Add(this.button1);
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

        private System.Windows.Forms.CheckBox permanente;
        private System.Windows.Forms.DateTimePicker fechaRegreso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker fechaBaja;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox corrimiento;
        private System.Windows.Forms.Label label1;
    }
}