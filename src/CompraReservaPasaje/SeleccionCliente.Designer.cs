namespace FrbaCrucero.CompraReservaPasaje
{
    partial class SeleccionCliente
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
            this.seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dniLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // grilla
            // 
            this.grilla.AllowUserToAddRows = false;
            this.grilla.AllowUserToDeleteRows = false;
            this.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seleccionar});
            this.grilla.Location = new System.Drawing.Point(12, 32);
            this.grilla.Name = "grilla";
            this.grilla.ReadOnly = true;
            this.grilla.Size = new System.Drawing.Size(634, 150);
            this.grilla.TabIndex = 0;
            this.grilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grilla_CellContentClick);
            // 
            // seleccionar
            // 
            this.seleccionar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.seleccionar.HeaderText = "Seleccionar";
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.ReadOnly = true;
            this.seleccionar.Width = 69;
            // 
            // dniLabel
            // 
            this.dniLabel.AutoSize = true;
            this.dniLabel.Location = new System.Drawing.Point(12, 13);
            this.dniLabel.Name = "dniLabel";
            this.dniLabel.Size = new System.Drawing.Size(32, 13);
            this.dniLabel.TabIndex = 1;
            this.dniLabel.Text = "DNI: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "No soy ninguno de estos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SeleccionCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 223);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dniLabel);
            this.Controls.Add(this.grilla);
            this.Name = "SeleccionCliente";
            this.Text = "SeleccionCliente";
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grilla;
        private System.Windows.Forms.DataGridViewButtonColumn seleccionar;
        private System.Windows.Forms.Label dniLabel;
        private System.Windows.Forms.Button button1;
    }
}