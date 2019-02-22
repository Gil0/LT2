namespace AFN_T2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.opciones = new System.Windows.Forms.GroupBox();
            this.ejecutar = new System.Windows.Forms.Button();
            this.abrir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cadena = new System.Windows.Forms.RichTextBox();
            this.datos = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.opciones.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.datos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // opciones
            // 
            this.opciones.Controls.Add(this.ejecutar);
            this.opciones.Controls.Add(this.abrir);
            this.opciones.Location = new System.Drawing.Point(32, 12);
            this.opciones.Name = "opciones";
            this.opciones.Size = new System.Drawing.Size(734, 55);
            this.opciones.TabIndex = 0;
            this.opciones.TabStop = false;
            this.opciones.Text = "Opciones";
            this.opciones.Enter += new System.EventHandler(this.opciones_Enter);
            // 
            // ejecutar
            // 
            this.ejecutar.Location = new System.Drawing.Point(136, 19);
            this.ejecutar.Name = "ejecutar";
            this.ejecutar.Size = new System.Drawing.Size(116, 23);
            this.ejecutar.TabIndex = 1;
            this.ejecutar.Text = "Analizar Código";
            this.ejecutar.UseVisualStyleBackColor = true;
            this.ejecutar.Click += new System.EventHandler(this.ejecutar_Click);
            // 
            // abrir
            // 
            this.abrir.Location = new System.Drawing.Point(15, 19);
            this.abrir.Name = "abrir";
            this.abrir.Size = new System.Drawing.Size(115, 23);
            this.abrir.TabIndex = 0;
            this.abrir.Text = "Agregar Lenguaje";
            this.abrir.UseVisualStyleBackColor = true;
            this.abrir.Click += new System.EventHandler(this.abrir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cadena);
            this.groupBox1.Location = new System.Drawing.Point(32, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 165);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entrada";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cadena
            // 
            this.cadena.AcceptsTab = true;
            this.cadena.Location = new System.Drawing.Point(15, 19);
            this.cadena.Name = "cadena";
            this.cadena.Size = new System.Drawing.Size(703, 140);
            this.cadena.TabIndex = 0;
            this.cadena.Text = "";
            // 
            // datos
            // 
            this.datos.Controls.Add(this.dataGridView1);
            this.datos.Location = new System.Drawing.Point(32, 255);
            this.datos.Name = "datos";
            this.datos.Size = new System.Drawing.Size(734, 279);
            this.datos.TabIndex = 1;
            this.datos.TabStop = false;
            this.datos.Text = "Panel de Salida";
            this.datos.Enter += new System.EventHandler(this.datos_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.Size = new System.Drawing.Size(703, 253);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 546);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.datos);
            this.Controls.Add(this.opciones);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.opciones.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.datos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox opciones;
        private System.Windows.Forms.Button ejecutar;
        private System.Windows.Forms.Button abrir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox cadena;
        private System.Windows.Forms.GroupBox datos;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

