namespace DapperApp
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
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnPerro = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGetPerson = new System.Windows.Forms.Button();
            this.btnOneToManyPerson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(12, 12);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(476, 20);
            this.txtInfo.TabIndex = 0;
            // 
            // btnPerro
            // 
            this.btnPerro.Location = new System.Drawing.Point(12, 75);
            this.btnPerro.Name = "btnPerro";
            this.btnPerro.Size = new System.Drawing.Size(184, 23);
            this.btnPerro.TabIndex = 1;
            this.btnPerro.Text = "llamar metodo perro";
            this.btnPerro.UseVisualStyleBackColor = true;
            this.btnPerro.Click += new System.EventHandler(this.btnPerro_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 137);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(489, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnGetPerson
            // 
            this.btnGetPerson.Location = new System.Drawing.Point(242, 75);
            this.btnGetPerson.Name = "btnGetPerson";
            this.btnGetPerson.Size = new System.Drawing.Size(184, 23);
            this.btnGetPerson.TabIndex = 3;
            this.btnGetPerson.Text = "Obtiene Person";
            this.btnGetPerson.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGetPerson.UseVisualStyleBackColor = true;
            this.btnGetPerson.Click += new System.EventHandler(this.btnGetPerson_Click);
            // 
            // btnOneToManyPerson
            // 
            this.btnOneToManyPerson.Location = new System.Drawing.Point(446, 75);
            this.btnOneToManyPerson.Name = "btnOneToManyPerson";
            this.btnOneToManyPerson.Size = new System.Drawing.Size(184, 23);
            this.btnOneToManyPerson.TabIndex = 4;
            this.btnOneToManyPerson.Text = "Obtiene muchas personas";
            this.btnOneToManyPerson.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOneToManyPerson.UseVisualStyleBackColor = true;
            this.btnOneToManyPerson.Click += new System.EventHandler(this.btnOneToManyPerson_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOneToManyPerson);
            this.Controls.Add(this.btnGetPerson);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnPerro);
            this.Controls.Add(this.txtInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btnPerro;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGetPerson;
        private System.Windows.Forms.Button btnOneToManyPerson;
    }
}

