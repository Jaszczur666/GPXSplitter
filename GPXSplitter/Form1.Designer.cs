namespace GPXSplitter
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
            this.button1 = new System.Windows.Forms.Button();
            this.Pathin = new System.Windows.Forms.TextBox();
            this.Pathout = new System.Windows.Forms.TextBox();
            this.loadinbutton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Split";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Pathin
            // 
            this.Pathin.BackColor = System.Drawing.SystemColors.Menu;
            this.Pathin.Location = new System.Drawing.Point(21, 35);
            this.Pathin.Name = "Pathin";
            this.Pathin.Size = new System.Drawing.Size(221, 20);
            this.Pathin.TabIndex = 1;
            this.Pathin.TextChanged += new System.EventHandler(this.Pathin_TextChanged);
            // 
            // Pathout
            // 
            this.Pathout.BackColor = System.Drawing.SystemColors.Menu;
            this.Pathout.Location = new System.Drawing.Point(21, 71);
            this.Pathout.Name = "Pathout";
            this.Pathout.Size = new System.Drawing.Size(221, 20);
            this.Pathout.TabIndex = 2;
            // 
            // loadinbutton
            // 
            this.loadinbutton.Location = new System.Drawing.Point(248, 34);
            this.loadinbutton.Name = "loadinbutton";
            this.loadinbutton.Size = new System.Drawing.Size(32, 23);
            this.loadinbutton.TabIndex = 3;
            this.loadinbutton.Text = "...";
            this.loadinbutton.UseVisualStyleBackColor = true;
            this.loadinbutton.Click += new System.EventHandler(this.loadinbutton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.gpx";
            this.openFileDialog1.Filter = "GPX file|*.gpx";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 136);
            this.Controls.Add(this.loadinbutton);
            this.Controls.Add(this.Pathout);
            this.Controls.Add(this.Pathin);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Pathin;
        private System.Windows.Forms.TextBox Pathout;
        private System.Windows.Forms.Button loadinbutton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

