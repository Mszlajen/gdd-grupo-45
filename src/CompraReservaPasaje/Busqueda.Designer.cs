namespace FrbaCrucero.CompraReservaPasaje
{
    partial class Busqueda
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
            this.label3 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.origen = new System.Windows.Forms.ComboBox();
            this.destino = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grilla = new System.Windows.Forms.DataGridView();
            this.comprar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Origen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parada en";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(16, 30);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(200, 20);
            this.fecha.TabIndex = 3;
            // 
            // origen
            // 
            this.origen.FormattingEnabled = true;
            this.origen.Location = new System.Drawing.Point(16, 70);
            this.origen.Name = "origen";
            this.origen.Size = new System.Drawing.Size(121, 21);
            this.origen.TabIndex = 4;
            // 
            // destino
            // 
            this.destino.FormattingEnabled = true;
            this.destino.Location = new System.Drawing.Point(176, 70);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(121, 21);
            this.destino.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grilla
            // 
            this.grilla.AllowUserToAddRows = false;
            this.grilla.AllowUserToDeleteRows = false;
            this.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.comprar});
            this.grilla.Location = new System.Drawing.Point(16, 98);
            this.grilla.Name = "grilla";
            this.grilla.ReadOnly = true;
            this.grilla.Size = new System.Drawing.Size(411, 150);
            this.grilla.TabIndex = 7;
            this.grilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grilla_CellContentClick);
            // 
            // comprar
            // 
            this.comprar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.comprar.HeaderText = "Comprar";
            this.comprar.Name = "comprar";
            this.comprar.ReadOnly = true;
            this.comprar.Width = 52;
            // 
            // Busqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 261);
            this.Controls.Add(this.grilla);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.destino);
            this.Controls.Add(this.origen);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Busqueda";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.ComboBox origen;
        private System.Windows.Forms.ComboBox destino;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView grilla;
        private System.Windows.Forms.DataGridViewButtonColumn comprar;
    }
}