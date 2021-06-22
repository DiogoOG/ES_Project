namespace ClinicInterface
{
    partial class FormCreatePrescription
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.patientsList = new System.Windows.Forms.ListBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(411, 280);
            this.nameBox.Name = "nameBox";
            this.nameBox.PlaceholderText = " Name";
            this.nameBox.Size = new System.Drawing.Size(262, 27);
            this.nameBox.TabIndex = 1;
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "Medication",
            "Exercise",
            "Treatment"});
            this.typeBox.Location = new System.Drawing.Point(411, 12);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(262, 28);
            this.typeBox.TabIndex = 3;
            this.typeBox.Text = "Medication";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(411, 325);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(127, 29);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(546, 325);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(127, 29);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Go Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click_1);
            // 
            // patientsList
            // 
            this.patientsList.FormattingEnabled = true;
            this.patientsList.ItemHeight = 20;
            this.patientsList.Location = new System.Drawing.Point(12, 12);
            this.patientsList.Name = "patientsList";
            this.patientsList.Size = new System.Drawing.Size(371, 424);
            this.patientsList.TabIndex = 7;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(411, 175);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 20);
            this.errorLabel.TabIndex = 8;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(411, 52);
            this.datePicker.Name = "datePicker";
            this.datePicker.TabIndex = 9;
            // 
            // FormCreatePrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 453);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.patientsList);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.nameBox);
            this.Name = "FormCreatePrescription";
            this.Text = "FormTherapist";
            this.Load += new System.EventHandler(this.FormTherapist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ListBox patientsList;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.MonthCalendar datePicker;
    }
}