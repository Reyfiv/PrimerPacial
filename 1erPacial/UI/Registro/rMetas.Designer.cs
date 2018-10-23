namespace _1erPacial.UI.Registro
{
    partial class rMetas
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
            this.MetaId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MetaIdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DescripcionTextBox = new System.Windows.Forms.TextBox();
            this.CuotaTextBox = new System.Windows.Forms.TextBox();
            this.GuardarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MetaIdNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MetaId
            // 
            this.MetaId.AutoSize = true;
            this.MetaId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MetaId.Location = new System.Drawing.Point(22, 19);
            this.MetaId.Name = "MetaId";
            this.MetaId.Size = new System.Drawing.Size(50, 17);
            this.MetaId.TabIndex = 0;
            this.MetaId.Text = "MetaId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(22, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Decripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(22, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cuota";
            // 
            // MetaIdNumericUpDown
            // 
            this.MetaIdNumericUpDown.Location = new System.Drawing.Point(130, 19);
            this.MetaIdNumericUpDown.Name = "MetaIdNumericUpDown";
            this.MetaIdNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.MetaIdNumericUpDown.TabIndex = 3;
            // 
            // DescripcionTextBox
            // 
            this.DescripcionTextBox.Location = new System.Drawing.Point(130, 62);
            this.DescripcionTextBox.Name = "DescripcionTextBox";
            this.DescripcionTextBox.Size = new System.Drawing.Size(120, 20);
            this.DescripcionTextBox.TabIndex = 4;
            // 
            // CuotaTextBox
            // 
            this.CuotaTextBox.Location = new System.Drawing.Point(130, 100);
            this.CuotaTextBox.Name = "CuotaTextBox";
            this.CuotaTextBox.Size = new System.Drawing.Size(120, 20);
            this.CuotaTextBox.TabIndex = 5;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Image = global::_1erPacial.Properties.Resources.Save_32px;
            this.GuardarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.GuardarButton.Location = new System.Drawing.Point(96, 166);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 52);
            this.GuardarButton.TabIndex = 6;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // rMetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 230);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.CuotaTextBox);
            this.Controls.Add(this.DescripcionTextBox);
            this.Controls.Add(this.MetaIdNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MetaId);
            this.Name = "rMetas";
            this.Text = "rMetas";
            ((System.ComponentModel.ISupportInitialize)(this.MetaIdNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MetaId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown MetaIdNumericUpDown;
        private System.Windows.Forms.TextBox DescripcionTextBox;
        private System.Windows.Forms.TextBox CuotaTextBox;
        private System.Windows.Forms.Button GuardarButton;
    }
}