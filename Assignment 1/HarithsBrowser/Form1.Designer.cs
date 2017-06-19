namespace HarithsBrowser
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.encrypt_button = new System.Windows.Forms.Button();
            this.lblencrypted = new System.Windows.Forms.Label();
            this.lblconfirmation = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbldecrypted = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_stock = new System.Windows.Forms.Button();
            this.lblstockInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(-1, 43);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(2406, 904);
            this.webBrowser1.TabIndex = 0;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(12, 6);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(2321, 31);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Text = "http://";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2339, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 978);
            this.textBox1.MaxLength = 250;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(520, 31);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 950);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please type message:";
            // 
            // encrypt_button
            // 
            this.encrypt_button.Location = new System.Drawing.Point(555, 973);
            this.encrypt_button.Name = "encrypt_button";
            this.encrypt_button.Size = new System.Drawing.Size(132, 40);
            this.encrypt_button.TabIndex = 5;
            this.encrypt_button.Text = "Encrypt";
            this.encrypt_button.UseVisualStyleBackColor = true;
            this.encrypt_button.Click += new System.EventHandler(this.encrypt_button_Click);
            // 
            // lblencrypted
            // 
            this.lblencrypted.AutoSize = true;
            this.lblencrypted.Location = new System.Drawing.Point(10, 1058);
            this.lblencrypted.MaximumSize = new System.Drawing.Size(720, 1300);
            this.lblencrypted.Name = "lblencrypted";
            this.lblencrypted.Size = new System.Drawing.Size(0, 25);
            this.lblencrypted.TabIndex = 6;
            // 
            // lblconfirmation
            // 
            this.lblconfirmation.AutoSize = true;
            this.lblconfirmation.Location = new System.Drawing.Point(10, 1026);
            this.lblconfirmation.Name = "lblconfirmation";
            this.lblconfirmation.Size = new System.Drawing.Size(0, 25);
            this.lblconfirmation.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(761, 981);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Decrypted Message:";
            // 
            // lbldecrypted
            // 
            this.lbldecrypted.AutoSize = true;
            this.lbldecrypted.Location = new System.Drawing.Point(766, 1026);
            this.lbldecrypted.MaximumSize = new System.Drawing.Size(720, 0);
            this.lbldecrypted.Name = "lbldecrypted";
            this.lbldecrypted.Size = new System.Drawing.Size(0, 25);
            this.lbldecrypted.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1633, 985);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 31);
            this.textBox2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1427, 988);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Enter stock symbol:";
            // 
            // button_stock
            // 
            this.button_stock.Location = new System.Drawing.Point(1749, 981);
            this.button_stock.Name = "button_stock";
            this.button_stock.Size = new System.Drawing.Size(101, 39);
            this.button_stock.TabIndex = 12;
            this.button_stock.Text = "Enter";
            this.button_stock.UseVisualStyleBackColor = true;
            this.button_stock.Click += new System.EventHandler(this.button_stock_Click);
            // 
            // lblstockInfo
            // 
            this.lblstockInfo.AutoSize = true;
            this.lblstockInfo.Location = new System.Drawing.Point(1605, 1058);
            this.lblstockInfo.Name = "lblstockInfo";
            this.lblstockInfo.Size = new System.Drawing.Size(0, 25);
            this.lblstockInfo.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2417, 1212);
            this.Controls.Add(this.lblstockInfo);
            this.Controls.Add(this.button_stock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lbldecrypted);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblconfirmation);
            this.Controls.Add(this.lblencrypted);
            this.Controls.Add(this.encrypt_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Form1";
            this.Text = "Harith\'s Browser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button encrypt_button;
        private System.Windows.Forms.Label lblencrypted;
        private System.Windows.Forms.Label lblconfirmation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbldecrypted;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_stock;
        private System.Windows.Forms.Label lblstockInfo;
    }
}

