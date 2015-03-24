namespace NewsletterSender.win
{
	partial class ImportContactsMySQLWin
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
			this.label2 = new System.Windows.Forms.Label();
			this.dbName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.user = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.password = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tableName = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.columName = new System.Windows.Forms.TextBox();
			this.import = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.host = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(18, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Z MySQL";
			// 
			// dbName
			// 
			this.dbName.Location = new System.Drawing.Point(112, 80);
			this.dbName.Name = "dbName";
			this.dbName.Size = new System.Drawing.Size(100, 20);
			this.dbName.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Název DB";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Jméno";
			// 
			// user
			// 
			this.user.Location = new System.Drawing.Point(112, 120);
			this.user.Name = "user";
			this.user.Size = new System.Drawing.Size(100, 20);
			this.user.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 162);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Heslo";
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(112, 162);
			this.password.Name = "password";
			this.password.Size = new System.Drawing.Size(100, 20);
			this.password.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(18, 201);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Název tabulky";
			// 
			// tableName
			// 
			this.tableName.Location = new System.Drawing.Point(112, 198);
			this.tableName.Name = "tableName";
			this.tableName.Size = new System.Drawing.Size(100, 20);
			this.tableName.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(18, 237);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(78, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Název sloupce";
			// 
			// columName
			// 
			this.columName.Location = new System.Drawing.Point(112, 237);
			this.columName.Name = "columName";
			this.columName.Size = new System.Drawing.Size(100, 20);
			this.columName.TabIndex = 11;
			// 
			// import
			// 
			this.import.Location = new System.Drawing.Point(23, 285);
			this.import.Name = "import";
			this.import.Size = new System.Drawing.Size(75, 23);
			this.import.TabIndex = 13;
			this.import.Text = "Načíst";
			this.import.UseVisualStyleBackColor = true;
			this.import.Click += new System.EventHandler(this.import_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(20, 46);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(29, 13);
			this.label7.TabIndex = 14;
			this.label7.Text = "Host";
			// 
			// host
			// 
			this.host.Location = new System.Drawing.Point(112, 39);
			this.host.Name = "host";
			this.host.Size = new System.Drawing.Size(100, 20);
			this.host.TabIndex = 15;
			// 
			// ImportContactsMySQL
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(253, 354);
			this.Controls.Add(this.host);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.import);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.columName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tableName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.password);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.user);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dbName);
			this.Controls.Add(this.label2);
			this.Name = "ImportContactsMySQL";
			this.Text = "Vložit kontakty";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox dbName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox user;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tableName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox columName;
		private System.Windows.Forms.Button import;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox host;
	}
}