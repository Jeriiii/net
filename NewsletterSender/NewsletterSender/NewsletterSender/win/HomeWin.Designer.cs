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
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Skupiny";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(25, 410);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(145, 38);
			this.button1.TabIndex = 2;
			this.button1.Text = "Odeslat email";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(408, 55);
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
			this.groupsList.Location = new System.Drawing.Point(25, 55);
			this.groupsList.Name = "groupsList";
			this.groupsList.Size = new System.Drawing.Size(364, 342);
			this.groupsList.TabIndex = 5;
			this.groupsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.groupsList_MouseDoubleClick);
			// 
			// HomeWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(572, 540);
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
	}
}