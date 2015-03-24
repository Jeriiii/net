namespace NewsletterSender
{
    partial class EditGroupWin
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
			this.label1 = new System.Windows.Forms.Label();
			this.groupNameBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.contactsBox = new System.Windows.Forms.ListBox();
			this.deleteEmailBtn = new System.Windows.Forms.Button();
			this.importContactBtn = new System.Windows.Forms.Button();
			this.importContactsDBBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Emaily";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Název";
			// 
			// groupNameBox
			// 
			this.groupNameBox.Location = new System.Drawing.Point(26, 47);
			this.groupNameBox.Name = "groupNameBox";
			this.groupNameBox.Size = new System.Drawing.Size(330, 20);
			this.groupNameBox.TabIndex = 7;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(375, 44);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(152, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Uložit";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// contactsBox
			// 
			this.contactsBox.FormattingEnabled = true;
			this.contactsBox.Location = new System.Drawing.Point(25, 99);
			this.contactsBox.Name = "contactsBox";
			this.contactsBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.contactsBox.Size = new System.Drawing.Size(327, 264);
			this.contactsBox.TabIndex = 10;
			// 
			// deleteEmailBtn
			// 
			this.deleteEmailBtn.Location = new System.Drawing.Point(375, 99);
			this.deleteEmailBtn.Name = "deleteEmailBtn";
			this.deleteEmailBtn.Size = new System.Drawing.Size(152, 23);
			this.deleteEmailBtn.TabIndex = 11;
			this.deleteEmailBtn.Text = "Smazat";
			this.deleteEmailBtn.UseVisualStyleBackColor = true;
			this.deleteEmailBtn.Click += new System.EventHandler(this.button2_Click);
			// 
			// importContactBtn
			// 
			this.importContactBtn.Location = new System.Drawing.Point(375, 141);
			this.importContactBtn.Name = "importContactBtn";
			this.importContactBtn.Size = new System.Drawing.Size(152, 23);
			this.importContactBtn.TabIndex = 12;
			this.importContactBtn.Text = "Vložit nové kontakty";
			this.importContactBtn.UseVisualStyleBackColor = true;
			this.importContactBtn.Click += new System.EventHandler(this.importContactBtn_Click);
			// 
			// importContactsDBBtn
			// 
			this.importContactsDBBtn.Location = new System.Drawing.Point(375, 183);
			this.importContactsDBBtn.Name = "importContactsDBBtn";
			this.importContactsDBBtn.Size = new System.Drawing.Size(152, 23);
			this.importContactsDBBtn.TabIndex = 13;
			this.importContactsDBBtn.Text = "Import z DB";
			this.importContactsDBBtn.UseVisualStyleBackColor = true;
			this.importContactsDBBtn.Click += new System.EventHandler(this.importContactsDBBtn_Click);
			// 
			// EditGroupWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 501);
			this.Controls.Add(this.importContactsDBBtn);
			this.Controls.Add(this.importContactBtn);
			this.Controls.Add(this.deleteEmailBtn);
			this.Controls.Add(this.contactsBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupNameBox);
			this.Controls.Add(this.button1);
			this.Name = "EditGroupWin";
			this.Text = "EditGroup";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox groupNameBox;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox contactsBox;
		private System.Windows.Forms.Button deleteEmailBtn;
		private System.Windows.Forms.Button importContactBtn;
		private System.Windows.Forms.Button importContactsDBBtn;
    }
}