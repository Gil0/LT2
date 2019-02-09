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
            this.datos = new System.Windows.Forms.GroupBox();
            this.labelResultado = new System.Windows.Forms.GroupBox();
            this.abrir = new System.Windows.Forms.Button();
            this.ejecutar = new System.Windows.Forms.Button();
            this.textboxDatos = new System.Windows.Forms.RichTextBox();
            this.textboxResultado = new System.Windows.Forms.RichTextBox();
            this.opciones.SuspendLayout();
            this.datos.SuspendLayout();
            this.labelResultado.SuspendLayout();
            this.SuspendLayout();
            // 
            // opciones
            // 
            this.opciones.Controls.Add(this.ejecutar);
            this.opciones.Controls.Add(this.abrir);
            this.opciones.Location = new System.Drawing.Point(32, 24);
            this.opciones.Name = "opciones";
            this.opciones.Size = new System.Drawing.Size(734, 55);
            this.opciones.TabIndex = 0;
            this.opciones.TabStop = false;
            this.opciones.Text = "Opciones";
            this.opciones.Enter += new System.EventHandler(this.opciones_Enter);
            // 
            // datos
            // 
            this.datos.Controls.Add(this.textboxDatos);
            this.datos.Location = new System.Drawing.Point(32, 85);
            this.datos.Name = "datos";
            this.datos.Size = new System.Drawing.Size(734, 210);
            this.datos.TabIndex = 1;
            this.datos.TabStop = false;
            this.datos.Text = "Datos";
            this.datos.Enter += new System.EventHandler(this.datos_Enter);
            // 
            // labelResultado
            // 
            this.labelResultado.Controls.Add(this.textboxResultado);
            this.labelResultado.Location = new System.Drawing.Point(32, 304);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(734, 134);
            this.labelResultado.TabIndex = 2;
            this.labelResultado.TabStop = false;
            this.labelResultado.Text = "Resultado";
            this.labelResultado.Enter += new System.EventHandler(this.resultado_Enter);
            // 
            // abrir
            // 
            this.abrir.Location = new System.Drawing.Point(15, 19);
            this.abrir.Name = "abrir";
            this.abrir.Size = new System.Drawing.Size(75, 23);
            this.abrir.TabIndex = 0;
            this.abrir.Text = "Abrir Archivo";
            this.abrir.UseVisualStyleBackColor = true;
            this.abrir.Click += new System.EventHandler(this.abrir_Click);
            // 
            // ejecutar
            // 
            this.ejecutar.Location = new System.Drawing.Point(96, 19);
            this.ejecutar.Name = "ejecutar";
            this.ejecutar.Size = new System.Drawing.Size(75, 23);
            this.ejecutar.TabIndex = 1;
            this.ejecutar.Text = "Ejecutar";
            this.ejecutar.UseVisualStyleBackColor = true;
            this.ejecutar.Click += new System.EventHandler(this.ejecutar_Click);
            // 
            // textboxDatos
            // 
            this.textboxDatos.Location = new System.Drawing.Point(15, 28);
            this.textboxDatos.Name = "textboxDatos";
            this.textboxDatos.Size = new System.Drawing.Size(703, 162);
            this.textboxDatos.TabIndex = 0;
            this.textboxDatos.Text = "";
            this.textboxDatos.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // textboxResultado
            // 
            this.textboxResultado.Location = new System.Drawing.Point(15, 28);
            this.textboxResultado.Name = "textboxResultado";
            this.textboxResultado.Size = new System.Drawing.Size(703, 88);
            this.textboxResultado.TabIndex = 0;
            this.textboxResultado.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelResultado);
            this.Controls.Add(this.datos);
            this.Controls.Add(this.opciones);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.opciones.ResumeLayout(false);
            this.datos.ResumeLayout(false);
            this.labelResultado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox opciones;
        private System.Windows.Forms.GroupBox datos;
        private System.Windows.Forms.GroupBox labelResultado;
        private System.Windows.Forms.Button ejecutar;
        private System.Windows.Forms.Button abrir;
        private System.Windows.Forms.RichTextBox textboxDatos;
        private System.Windows.Forms.RichTextBox textboxResultado;
    }
}

