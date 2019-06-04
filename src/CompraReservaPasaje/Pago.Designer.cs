namespace FrbaCrucero.CompraReservaPasaje
{
    partial class Pago
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
            this.formas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numTarjeta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.codSeguridad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pagarButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.vencMes = new System.Windows.Forms.NumericUpDown();
            this.vencAnio = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.vencMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vencAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forma de pago";
            // 
            // formas
            // 
            this.formas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formas.FormattingEnabled = true;
            this.formas.Location = new System.Drawing.Point(16, 30);
            this.formas.Name = "formas";
            this.formas.Size = new System.Drawing.Size(121, 21);
            this.formas.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero de tarjeta";
            // 
            // numTarjeta
            // 
            this.numTarjeta.Location = new System.Drawing.Point(16, 75);
            this.numTarjeta.Name = "numTarjeta";
            this.numTarjeta.Size = new System.Drawing.Size(256, 20);
            this.numTarjeta.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Codigo de seguridad";
            // 
            // codSeguridad
            // 
            this.codSeguridad.Location = new System.Drawing.Point(16, 119);
            this.codSeguridad.Name = "codSeguridad";
            this.codSeguridad.Size = new System.Drawing.Size(103, 20);
            this.codSeguridad.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Vencimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Año";
            // 
            // pagarButton
            // 
            this.pagarButton.Location = new System.Drawing.Point(13, 226);
            this.pagarButton.Name = "pagarButton";
            this.pagarButton.Size = new System.Drawing.Size(75, 23);
            this.pagarButton.TabIndex = 11;
            this.pagarButton.Text = "Pagar";
            this.pagarButton.UseVisualStyleBackColor = true;
            this.pagarButton.Click += new System.EventHandler(this.pagarButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(196, 225);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // vencMes
            // 
            this.vencMes.Location = new System.Drawing.Point(15, 186);
            this.vencMes.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.vencMes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vencMes.Name = "vencMes";
            this.vencMes.Size = new System.Drawing.Size(50, 20);
            this.vencMes.TabIndex = 13;
            this.vencMes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // vencAnio
            // 
            this.vencAnio.Location = new System.Drawing.Point(86, 185);
            this.vencAnio.Name = "vencAnio";
            this.vencAnio.Size = new System.Drawing.Size(50, 20);
            this.vencAnio.TabIndex = 14;
            this.vencAnio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Pago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.vencAnio);
            this.Controls.Add(this.vencMes);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pagarButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.codSeguridad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numTarjeta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.formas);
            this.Controls.Add(this.label1);
            this.Name = "Pago";
            this.Text = "Pago";
            ((System.ComponentModel.ISupportInitialize)(this.vencMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vencAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox formas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numTarjeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox codSeguridad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button pagarButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown vencMes;
        private System.Windows.Forms.NumericUpDown vencAnio;
    }
}