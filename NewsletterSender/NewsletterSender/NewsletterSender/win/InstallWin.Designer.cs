namespace NewsletterSender.win
{
	partial class InstallWin
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
			this.host = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.port = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.formAdderssLabel = new System.Windows.Forms.Label();
			this.fromNameLabel = new System.Windows.Forms.Label();
			this.fromAdderss = new System.Windows.Forms.TextBox();
			this.fromName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// host
			// 
			this.host.Location = new System.Drawing.Point(12, 294);
			this.host.Name = "host";
			this.host.Size = new System.Drawing.Size(295, 20);
			this.host.TabIndex = 17;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 278);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Host";
			// 
			// port
			// 
			this.port.Location = new System.Drawing.Point(9, 249);
			this.port.Name = "port";
			this.port.Size = new System.Drawing.Size(100, 20);
			this.port.TabIndex = 15;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 233);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Port";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(6, 203);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(177, 16);
			this.label1.TabIndex = 13;
			this.label1.Text = "SMTP server (pokročilé)";
			// 
			// formAdderssLabel
			// 
			this.formAdderssLabel.AutoSize = true;
			this.formAdderssLabel.Location = new System.Drawing.Point(6, 143);
			this.formAdderssLabel.Name = "formAdderssLabel";
			this.formAdderssLabel.Size = new System.Drawing.Size(95, 13);
			this.formAdderssLabel.TabIndex = 12;
			this.formAdderssLabel.Text = "Adresa odesílatele";
			// 
			// fromNameLabel
			// 
			this.fromNameLabel.AutoSize = true;
			this.fromNameLabel.Location = new System.Drawing.Point(6, 92);
			this.fromNameLabel.Name = "fromNameLabel";
			this.fromNameLabel.Size = new System.Drawing.Size(93, 13);
			this.fromNameLabel.TabIndex = 11;
			this.fromNameLabel.Text = "Jméno odesílatele";
			// 
			// fromAdderss
			// 
			this.fromAdderss.Location = new System.Drawing.Point(9, 159);
			this.fromAdderss.Name = "fromAdderss";
			this.fromAdderss.Size = new System.Drawing.Size(304, 20);
			this.fromAdderss.TabIndex = 10;
			// 
			// fromName
			// 
			this.fromName.Location = new System.Drawing.Point(9, 108);
			this.fromName.Name = "fromName";
			this.fromName.Size = new System.Drawing.Size(304, 20);
			this.fromName.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 46);
			this.label4.Name = "label4";
			this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label4.Size = new System.Drawing.Size(280, 13);
			this.label4.TabIndex = 18;
			this.label4.Text = "před spuštění programu prosím vyplňte následující údaje.";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label5.Location = new System.Drawing.Point(9, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(265, 16);
			this.label5.TabIndex = 19;
			this.label5.Text = "Vítejte v programu Newsletter Sender";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 344);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(171, 34);
			this.button1.TabIndex = 20;
			this.button1.Text = "Dokončit";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// InstallWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(489, 413);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.host);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.port);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.formAdderssLabel);
			this.Controls.Add(this.fromNameLabel);
			this.Controls.Add(this.fromAdderss);
			this.Controls.Add(this.fromName);
			this.Name = "InstallWin";
			this.Text = "Vítejte";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox host;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox port;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label formAdderssLabel;
		private System.Windows.Forms.Label fromNameLabel;
		private System.Windows.Forms.TextBox fromAdderss;
		private System.Windows.Forms.TextBox fromName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
	}
}