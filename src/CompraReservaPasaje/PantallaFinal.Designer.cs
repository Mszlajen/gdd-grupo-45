namespace FrbaCrucero.CompraReservaPasaje
{
    partial class PantallaFinal
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
            this.voucher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.crucero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cabinas = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.puertos = new System.Windows.Forms.DataGridView();
            this.puerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.salida = new System.Windows.Forms.TextBox();
            this.llegada = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tipo = new System.Windows.Forms.TextBox();
            this.costo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cabinas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puertos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voucher";
            // 
            // voucher
            // 
            this.voucher.Location = new System.Drawing.Point(16, 30);
            this.voucher.Name = "voucher";
            this.voucher.ReadOnly = true;
            this.voucher.Size = new System.Drawing.Size(100, 20);
            this.voucher.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Crucero";
            // 
            // crucero
            // 
            this.crucero.Location = new System.Drawing.Point(16, 73);
            this.crucero.Name = "crucero";
            this.crucero.ReadOnly = true;
            this.crucero.Size = new System.Drawing.Size(100, 20);
            this.crucero.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cabinas";
            // 
            // cabinas
            // 
            this.cabinas.AllowUserToAddRows = false;
            this.cabinas.AllowUserToDeleteRows = false;
            this.cabinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cabinas.Location = new System.Drawing.Point(15, 117);
            this.cabinas.Name = "cabinas";
            this.cabinas.ReadOnly = true;
            this.cabinas.Size = new System.Drawing.Size(240, 150);
            this.cabinas.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Puertos";
            // 
            // puertos
            // 
            this.puertos.AllowUserToAddRows = false;
            this.puertos.AllowUserToDeleteRows = false;
            this.puertos.AllowUserToResizeColumns = false;
            this.puertos.AllowUserToResizeRows = false;
            this.puertos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.puertos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.puerto});
            this.puertos.Location = new System.Drawing.Point(299, 117);
            this.puertos.Name = "puertos";
            this.puertos.Size = new System.Drawing.Size(240, 150);
            this.puertos.TabIndex = 7;
            // 
            // puerto
            // 
            this.puerto.HeaderText = "Puerto";
            this.puerto.Name = "puerto";
            this.puerto.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha de salida";
            // 
            // salida
            // 
            this.salida.Location = new System.Drawing.Point(299, 30);
            this.salida.Name = "salida";
            this.salida.ReadOnly = true;
            this.salida.Size = new System.Drawing.Size(136, 20);
            this.salida.TabIndex = 9;
            // 
            // llegada
            // 
            this.llegada.Location = new System.Drawing.Point(299, 73);
            this.llegada.Name = "llegada";
            this.llegada.ReadOnly = true;
            this.llegada.Size = new System.Drawing.Size(136, 20);
            this.llegada.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fecha de llegada";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(123, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tipo";
            // 
            // tipo
            // 
            this.tipo.Location = new System.Drawing.Point(126, 30);
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Size = new System.Drawing.Size(100, 20);
            this.tipo.TabIndex = 13;
            // 
            // costo
            // 
            this.costo.Location = new System.Drawing.Point(126, 73);
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            this.costo.Size = new System.Drawing.Size(100, 20);
            this.costo.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(122, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Costo ($)";
            // 
            // PantallaFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 292);
            this.Controls.Add(this.costo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tipo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.llegada);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.salida);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.puertos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cabinas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.crucero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.voucher);
            this.Controls.Add(this.label1);
            this.Name = "PantallaFinal";
            this.Text = "PantallaFinal";
            ((System.ComponentModel.ISupportInitialize)(this.cabinas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puertos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox voucher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox crucero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView cabinas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView puertos;
        private System.Windows.Forms.DataGridViewTextBoxColumn puerto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox salida;
        private System.Windows.Forms.TextBox llegada;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tipo;
        private System.Windows.Forms.TextBox costo;
        private System.Windows.Forms.Label label8;
    }
}