namespace ClinicInterface
{
    partial class FormCreateSession
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
            this.patientBox = new System.Windows.Forms.TextBox();
            this.typeBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.dateBox = new System.Windows.Forms.TextBox();
            this.notesBox = new System.Windows.Forms.RichTextBox();
            this.Notes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // patientBox
            // 
            this.patientBox.Location = new System.Drawing.Point(28, 32);
            this.patientBox.Name = "patientBox";
            this.patientBox.ReadOnly = true;
            this.patientBox.Size = new System.Drawing.Size(215, 27);
            this.patientBox.TabIndex = 0;
            // 
            // typeBox
            // 
            this.typeBox.Location = new System.Drawing.Point(28, 65);
            this.typeBox.Name = "typeBox";
            this.typeBox.ReadOnly = true;
            this.typeBox.Size = new System.Drawing.Size(215, 27);
            this.typeBox.TabIndex = 1;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(28, 98);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(215, 27);
            this.nameBox.TabIndex = 2;
            // 
            // dateBox
            // 
            this.dateBox.Location = new System.Drawing.Point(28, 131);
            this.dateBox.Name = "dateBox";
            this.dateBox.ReadOnly = true;
            this.dateBox.Size = new System.Drawing.Size(215, 27);
            this.dateBox.TabIndex = 3;
            // 
            // notesBox
            // 
            this.notesBox.Location = new System.Drawing.Point(268, 32);
            this.notesBox.Name = "notesBox";
            this.notesBox.Size = new System.Drawing.Size(402, 391);
            this.notesBox.TabIndex = 4;
            this.notesBox.Text = "";
            // 
            // Notes
            // 
            this.Notes.AutoSize = true;
            this.Notes.Location = new System.Drawing.Point(445, 9);
            this.Notes.Name = "Notes";
            this.Notes.Size = new System.Drawing.Size(48, 20);
            this.Notes.TabIndex = 5;
            this.Notes.Text = "Notes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Prescription";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(28, 174);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(101, 29);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(142, 174);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(101, 29);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Go Back";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(81, 219);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(104, 20);
            this.errorLabel.TabIndex = 9;
            this.errorLabel.Text = "Session saved!";
            // 
            // FormCreateSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Notes);
            this.Controls.Add(this.notesBox);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.patientBox);
            this.Name = "FormCreateSession";
            this.Text = "FormCreateSession";
            this.Load += new System.EventHandler(this.FormCreateSession_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox patientBox;
        private System.Windows.Forms.TextBox typeBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox dateBox;
        private System.Windows.Forms.RichTextBox notesBox;
        private System.Windows.Forms.Label Notes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label errorLabel;
    }
}