
namespace PasswordGenerator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.passwords1 = new System.Windows.Forms.RichTextBox();
            this.passwords2 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBarResult = new System.Windows.Forms.ProgressBar();
            this.progressBarDigit = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // passwords1
            // 
            this.passwords1.Location = new System.Drawing.Point(12, 12);
            this.passwords1.Name = "passwords1";
            this.passwords1.Size = new System.Drawing.Size(160, 253);
            this.passwords1.TabIndex = 0;
            this.passwords1.Text = "";
            // 
            // passwords2
            // 
            this.passwords2.Location = new System.Drawing.Point(178, 12);
            this.passwords2.Name = "passwords2";
            this.passwords2.Size = new System.Drawing.Size(160, 253);
            this.passwords2.TabIndex = 1;
            this.passwords2.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(326, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generate and save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 289);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(160, 23);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(178, 289);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 22);
            this.button2.TabIndex = 4;
            this.button2.Text = "Generate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Digits count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "STATUS: Not generated";
            // 
            // progressBarResult
            // 
            this.progressBarResult.Location = new System.Drawing.Point(8, 430);
            this.progressBarResult.Maximum = 99999;
            this.progressBarResult.Name = "progressBarResult";
            this.progressBarResult.Size = new System.Drawing.Size(322, 23);
            this.progressBarResult.TabIndex = 7;
            // 
            // progressBarDigit
            // 
            this.progressBarDigit.Location = new System.Drawing.Point(12, 318);
            this.progressBarDigit.Maximum = 99999;
            this.progressBarDigit.Name = "progressBarDigit";
            this.progressBarDigit.Size = new System.Drawing.Size(322, 15);
            this.progressBarDigit.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 465);
            this.Controls.Add(this.progressBarDigit);
            this.Controls.Add(this.progressBarResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passwords2);
            this.Controls.Add(this.passwords1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[PassGen]";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox passwords1;
        private System.Windows.Forms.RichTextBox passwords2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ProgressBar progressBarResult;
        public System.Windows.Forms.ProgressBar progressBarDigit;
    }
}

