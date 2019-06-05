namespace FrbaCrucero.AbmCrucero
{
    partial class PantallaInicial
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
            this.grilla = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.identificador = new System.Windows.Forms.TextBox();
            this.buscar = new System.Windows.Forms.Button();
            this.nuevo = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bajar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // grilla
            // 
            this.grilla.AllowUserToAddRows = false;
            this.grilla.AllowUserToDeleteRows = false;
            this.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modificar,
            this.bajar});
            this.grilla.Location = new System.Drawing.Point(16, 56);
            this.grilla.Name = "grilla";
            this.grilla.ReadOnly = true;
            this.grilla.Size = new System.Drawing.Size(615, 150);
            this.grilla.TabIndex = 0;
            this.grilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grilla_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Identificador";
            // 
            // identificador
            // 
            this.identificador.Location = new System.Drawing.Point(16, 30);
            this.identificador.Name = "identificador";
            this.identificador.Size = new System.Drawing.Size(100, 20);
            this.identificador.TabIndex = 2;
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(552, 3);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(75, 47);
            this.buscar.TabIndex = 3;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            // 
            // nuevo
            // 
            this.nuevo.Location = new System.Drawing.Point(16, 213);
            this.nuevo.Name = "nuevo";
            this.nuevo.Size = new System.Drawing.Size(75, 23);
            this.nuevo.TabIndex = 4;
            this.nuevo.Text = "Crear nuevo";
            this.nuevo.UseVisualStyleBackColor = true;
            // 
            // modificar
            // 
            this.modificar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.modificar.HeaderText = "Modificar";
            this.modificar.Name = "modificar";
            this.modificar.ReadOnly = true;
            this.modificar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.modificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.modificar.Width = 75;
            // 
            // bajar
            // 
            this.bajar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.bajar.HeaderText = "Dar de baja";
            this.bajar.Name = "bajar";
            this.bajar.ReadOnly = true;
            this.bajar.Width = 68;
            // 
            // PantallaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 261);
            this.Controls.Add(this.nuevo);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.identificador);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grilla);
            this.Name = "PantallaInicial";
            this.Text = "PantallaInicial";
            this.Load += new System.EventHandler(this.PantallaInicial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox identificador;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button nuevo;
        private System.Windows.Forms.DataGridViewButtonColumn modificar;
        private System.Windows.Forms.DataGridViewButtonColumn bajar;

    }
}