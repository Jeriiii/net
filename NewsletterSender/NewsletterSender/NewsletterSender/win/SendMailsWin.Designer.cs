namespace NewsletterSender
{
	partial class SendMailsWin
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
			this.subject = new System.Windows.Forms.TextBox();
			this.body = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.idBodyHTML = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.fromName = new System.Windows.Forms.TextBox();
			this.fromAdderss = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(33, 477);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(99, 39);
			this.button1.TabIndex = 0;
			this.button1.Text = "Odeslat";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// subject
			// 
			this.subject.Location = new System.Drawing.Point(33, 74);
			this.subject.Name = "subject";
			this.subject.Size = new System.Drawing.Size(573, 20);
			this.subject.TabIndex = 1;
			// 
			// body
			// 
			this.body.Location = new System.Drawing.Point(33, 123);
			this.body.Multiline = true;
			this.body.Name = "body";
			this.body.Size = new System.Drawing.Size(573, 299);
			this.body.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Předmět";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(30, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Tělo";
			// 
			// idBodyHTML
			// 
			this.idBodyHTML.AutoSize = true;
			this.idBodyHTML.Location = new System.Drawing.Point(33, 440);
			this.idBodyHTML.Name = "idBodyHTML";
			this.idBodyHTML.Size = new System.Drawing.Size(91, 17);
			this.idBodyHTML.TabIndex = 5;
			this.idBodyHTML.Text = "Tělo je HTML";
			this.idBodyHTML.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(33, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Od (jméno)";
			// 
			// fromName
			// 
			this.fromName.Location = new System.Drawing.Point(97, 23);
			this.fromName.Name = "fromName";
			this.fromName.Size = new System.Drawing.Size(207, 20);
			this.fromName.TabIndex = 7;
			// 
			// fromAdderss
			// 
			this.fromAdderss.Location = new System.Drawing.Point(398, 23);
			this.fromAdderss.Name = "fromAdderss";
			this.fromAdderss.Size = new System.Drawing.Size(207, 20);
			this.fromAdderss.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(334, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Od (email)";
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(155, 484);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(449, 22);
			this.progressBar.TabIndex = 10;
			// 
			// SendMailsWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(649, 552);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.fromAdderss);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.fromName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.idBodyHTML);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.body);
			this.Controls.Add(this.subject);
			this.Controls.Add(this.button1);
			this.Name = "SendMailsWin";
			this.Text = "SendMails";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox subject;
		private System.Windows.Forms.TextBox body;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox idBodyHTML;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox fromName;
		private System.Windows.Forms.TextBox fromAdderss;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ProgressBar progressBar;

	}
}

