namespace NewsletterSender.win
{
	partial class SettingWin
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
			this.fromName = new System.Windows.Forms.TextBox();
			this.fromAdderss = new System.Windows.Forms.TextBox();
			this.fromNameLabel = new System.Windows.Forms.Label();
			this.formAdderssLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.port = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.host = new System.Windows.Forms.TextBox();
			this.save = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// fromName
			// 
			this.fromName.Location = new System.Drawing.Point(12, 44);
			this.fromName.Name = "fromName";
			this.fromName.Size = new System.Drawing.Size(304, 20);
			this.fromName.TabIndex = 0;
			// 
			// fromAdderss
			// 
			this.fromAdderss.Location = new System.Drawing.Point(12, 95);
			this.fromAdderss.Name = "fromAdderss";
			this.fromAdderss.Size = new System.Drawing.Size(304, 20);
			this.fromAdderss.TabIndex = 1;
			// 
			// fromNameLabel
			// 
			this.fromNameLabel.AutoSize = true;
			this.fromNameLabel.Location = new System.Drawing.Point(9, 28);
			this.fromNameLabel.Name = "fromNameLabel";
			this.fromNameLabel.Size = new System.Drawing.Size(93, 13);
			this.fromNameLabel.TabIndex = 2;
			this.fromNameLabel.Text = "Jméno odesílatele";
			// 
			// formAdderssLabel
			// 
			this.formAdderssLabel.AutoSize = true;
			this.formAdderssLabel.Location = new System.Drawing.Point(9, 79);
			this.formAdderssLabel.Name = "formAdderssLabel";
			this.formAdderssLabel.Size = new System.Drawing.Size(95, 13);
			this.formAdderssLabel.TabIndex = 3;
			this.formAdderssLabel.Text = "Adresa odesílatele";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(9, 139);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(177, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "SMTP server (pokročilé)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 169);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Port";
			// 
			// port
			// 
			this.port.Location = new System.Drawing.Point(12, 185);
			this.port.Name = "port";
			this.port.Size = new System.Drawing.Size(100, 20);
			this.port.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 214);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Host";
			// 
			// host
			// 
			this.host.Location = new System.Drawing.Point(15, 230);
			this.host.Name = "host";
			this.host.Size = new System.Drawing.Size(295, 20);
			this.host.TabIndex = 8;
			// 
			// save
			// 
			this.save.Location = new System.Drawing.Point(13, 438);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(122, 36);
			this.save.TabIndex = 9;
			this.save.Text = "Uložit";
			this.save.UseVisualStyleBackColor = true;
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// cancel
			// 
			this.cancel.Location = new System.Drawing.Point(153, 445);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(109, 23);
			this.cancel.TabIndex = 10;
			this.cancel.Text = "Zavřít bez uložení";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// SettingWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(585, 508);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.save);
			this.Controls.Add(this.host);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.port);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.formAdderssLabel);
			this.Controls.Add(this.fromNameLabel);
			this.Controls.Add(this.fromAdderss);
			this.Controls.Add(this.fromName);
			this.Name = "SettingWin";
			this.Text = "SettingWin";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox fromName;
		private System.Windows.Forms.TextBox fromAdderss;
		private System.Windows.Forms.Label fromNameLabel;
		private System.Windows.Forms.Label formAdderssLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox port;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox host;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Button cancel;
	}
}