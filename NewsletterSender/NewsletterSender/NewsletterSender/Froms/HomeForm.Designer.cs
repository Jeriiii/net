namespace NewsletterSender
{
	partial class HomeWin
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
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupsList = new System.Windows.Forms.ListBox();
			this.settingBtn = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Skupiny";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(25, 422);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(145, 38);
			this.button1.TabIndex = 2;
			this.button1.Text = "Odeslat email";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(408, 67);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(119, 22);
			this.button2.TabIndex = 3;
			this.button2.Text = "Vytvořit skupinu";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupsList
			// 
			this.groupsList.FormattingEnabled = true;
			this.groupsList.Location = new System.Drawing.Point(25, 67);
			this.groupsList.Name = "groupsList";
			this.groupsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.groupsList.Size = new System.Drawing.Size(364, 342);
			this.groupsList.TabIndex = 5;
			this.groupsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.groupsList_MouseDoubleClick);
			// 
			// settingBtn
			// 
			this.settingBtn.Location = new System.Drawing.Point(485, 12);
			this.settingBtn.Name = "settingBtn";
			this.settingBtn.Size = new System.Drawing.Size(75, 23);
			this.settingBtn.TabIndex = 6;
			this.settingBtn.Text = "Nastavení";
			this.settingBtn.UseVisualStyleBackColor = true;
			this.settingBtn.Click += new System.EventHandler(this.button3_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(408, 96);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(119, 23);
			this.button3.TabIndex = 7;
			this.button3.Text = "Smazat skupinu";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click_1);
			// 
			// HomeWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(572, 540);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.settingBtn);
			this.Controls.Add(this.groupsList);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "HomeWin";
			this.Text = "Home";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListBox groupsList;
		private System.Windows.Forms.Button settingBtn;
		private System.Windows.Forms.Button button3;
	}
}