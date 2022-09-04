namespace GeneratePatterns
{
    partial class Form1
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
            this.b_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(13, 13);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(392, 51);
            this.b_save.TabIndex = 0;
            this.b_save.Text = "Save new pattern";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 74);
            this.Controls.Add(this.b_save);
            this.Name = "Form1";
            this.Text = "Generate new patterns";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_save;
    }
}

