namespace FrbaCrucero.AbmCrucero
{
    partial class ModificacionCrucero
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
            this.limpiar = new System.Windows.Forms.Button();
            this.guardar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.identificador = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.marca = new System.Windows.Forms.ComboBox();
            this.servicio = new System.Windows.Forms.ComboBox();
            this.cabinas = new System.Windows.Forms.DataGridView();
            this.agregarCabina = new System.Windows.Forms.Button();
            this.fabricante = new System.Windows.Forms.ComboBox();
            this.modelo = new System.Windows.Forms.ComboBox();
            this.borrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cabinas)).BeginInit();
            this.SuspendLayout();
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(160, 279);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 31;
            this.limpiar.Text = "Borrar";
            this.limpiar.UseVisualStyleBackColor = true;
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(79, 279);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 30;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Modelo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Fabricante:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Servicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Marca:";
            // 
            // identificador
            // 
            this.identificador.Location = new System.Drawing.Point(8, 29);
            this.identificador.Name = "identificador";
            this.identificador.Size = new System.Drawing.Size(201, 20);
            this.identificador.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Identificador:";
            // 
            // marca
            // 
            this.marca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.marca.FormattingEnabled = true;
            this.marca.Location = new System.Drawing.Point(8, 71);
            this.marca.Name = "marca";
            this.marca.Size = new System.Drawing.Size(121, 21);
            this.marca.TabIndex = 38;
            // 
            // servicio
            // 
            this.servicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.servicio.FormattingEnabled = true;
            this.servicio.Location = new System.Drawing.Point(135, 71);
            this.servicio.Name = "servicio";
            this.servicio.Size = new System.Drawing.Size(121, 21);
            this.servicio.TabIndex = 39;
            // 
            // cabinas
            // 
            this.cabinas.AllowUserToAddRows = false;
            this.cabinas.AllowUserToDeleteRows = false;
            this.cabinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cabinas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.borrar,
            this.editar});
            this.cabinas.Location = new System.Drawing.Point(330, 31);
            this.cabinas.Name = "cabinas";
            this.cabinas.Size = new System.Drawing.Size(310, 206);
            this.cabinas.TabIndex = 40;
            this.cabinas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cabinas_CellContentClick);
            // 
            // agregarCabina
            // 
            this.agregarCabina.Location = new System.Drawing.Point(330, 244);
            this.agregarCabina.Name = "agregarCabina";
            this.agregarCabina.Size = new System.Drawing.Size(310, 23);
            this.agregarCabina.TabIndex = 41;
            this.agregarCabina.Text = "Agregar Cabina";
            this.agregarCabina.UseVisualStyleBackColor = true;
            // 
            // fabricante
            // 
            this.fabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fabricante.FormattingEnabled = true;
            this.fabricante.Location = new System.Drawing.Point(8, 111);
            this.fabricante.Name = "fabricante";
            this.fabricante.Size = new System.Drawing.Size(121, 21);
            this.fabricante.TabIndex = 42;
            // 
            // modelo
            // 
            this.modelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelo.FormattingEnabled = true;
            this.modelo.Location = new System.Drawing.Point(135, 111);
            this.modelo.Name = "modelo";
            this.modelo.Size = new System.Drawing.Size(121, 21);
            this.modelo.TabIndex = 43;
            // 
            // borrar
            // 
            this.borrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.borrar.HeaderText = "Borrar";
            this.borrar.Name = "borrar";
            this.borrar.Width = 41;
            // 
            // editar
            // 
            this.editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.editar.HeaderText = "Editar";
            this.editar.Name = "editar";
            this.editar.Width = 40;
            // 
            // ModificacionCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 315);
            this.Controls.Add(this.modelo);
            this.Controls.Add(this.fabricante);
            this.Controls.Add(this.agregarCabina);
            this.Controls.Add(this.cabinas);
            this.Controls.Add(this.servicio);
            this.Controls.Add(this.marca);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.identificador);
            this.Controls.Add(this.label2);
            this.Name = "ModificacionCrucero";
            this.Text = "Modificacion de Crucero";
            this.Load += new System.EventHandler(this.ModificacionCrucero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cabinas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox identificador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox marca;
        private System.Windows.Forms.ComboBox servicio;
        private System.Windows.Forms.DataGridView cabinas;
        private System.Windows.Forms.Button agregarCabina;
        private System.Windows.Forms.ComboBox fabricante;
        private System.Windows.Forms.ComboBox modelo;
        private System.Windows.Forms.DataGridViewButtonColumn borrar;
        private System.Windows.Forms.DataGridViewButtonColumn editar;
    }
}