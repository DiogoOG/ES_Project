namespace ClinicInterface
{
    partial class FormTherapist
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
            this.createPrescriptionButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.newNameBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.newDatePicker = new System.Windows.Forms.DateTimePicker();
            this.patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prescriptionsTable = new System.Windows.Forms.DataGridView();
            this.logoutButton = new System.Windows.Forms.Button();
            this.newTypeBox = new System.Windows.Forms.ComboBox();
            this.showButton = new System.Windows.Forms.Button();
            this.sessionButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.prescriptionsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prescriptions";
            // 
            // createPrescriptionButton
            // 
            this.createPrescriptionButton.Location = new System.Drawing.Point(597, 32);
            this.createPrescriptionButton.Name = "createPrescriptionButton";
            this.createPrescriptionButton.Size = new System.Drawing.Size(168, 29);
            this.createPrescriptionButton.TabIndex = 2;
            this.createPrescriptionButton.Text = "Create Prescription";
            this.createPrescriptionButton.UseVisualStyleBackColor = true;
            this.createPrescriptionButton.Click += new System.EventHandler(this.createPrescriptionButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(597, 190);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(167, 29);
            this.editButton.TabIndex = 5;
            this.editButton.Text = "Edit Prescription";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // newNameBox
            // 
            this.newNameBox.Location = new System.Drawing.Point(599, 259);
            this.newNameBox.Name = "newNameBox";
            this.newNameBox.PlaceholderText = "New name";
            this.newNameBox.Size = new System.Drawing.Size(167, 27);
            this.newNameBox.TabIndex = 7;
            this.newNameBox.Visible = false;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(597, 321);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(83, 29);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(684, 321);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(82, 29);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // newDatePicker
            // 
            this.newDatePicker.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newDatePicker.Location = new System.Drawing.Point(598, 292);
            this.newDatePicker.Name = "newDatePicker";
            this.newDatePicker.Size = new System.Drawing.Size(167, 23);
            this.newDatePicker.TabIndex = 11;
            this.newDatePicker.Visible = false;
            // 
            // patient
            // 
            this.patient.HeaderText = "Patient";
            this.patient.MinimumWidth = 6;
            this.patient.Name = "patient";
            this.patient.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.patient.Width = 120;
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.MinimumWidth = 6;
            this.type.Name = "type";
            this.type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.type.Width = 120;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.name.Width = 125;
            // 
            // schedule
            // 
            this.schedule.HeaderText = "Schedule";
            this.schedule.MinimumWidth = 6;
            this.schedule.Name = "schedule";
            this.schedule.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.schedule.Width = 160;
            // 
            // prescriptionsTable
            // 
            this.prescriptionsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prescriptionsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patient,
            this.type,
            this.name,
            this.schedule});
            this.prescriptionsTable.GridColor = System.Drawing.SystemColors.Control;
            this.prescriptionsTable.Location = new System.Drawing.Point(12, 32);
            this.prescriptionsTable.Name = "prescriptionsTable";
            this.prescriptionsTable.RowHeadersWidth = 51;
            this.prescriptionsTable.Size = new System.Drawing.Size(579, 404);
            this.prescriptionsTable.TabIndex = 4;
            this.prescriptionsTable.Text = "dataGridView1";
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(599, 407);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(166, 29);
            this.logoutButton.TabIndex = 12;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // newTypeBox
            // 
            this.newTypeBox.FormattingEnabled = true;
            this.newTypeBox.Items.AddRange(new object[] {
            "Medication",
            "Exercise",
            "Treatment"});
            this.newTypeBox.Location = new System.Drawing.Point(598, 225);
            this.newTypeBox.Name = "newTypeBox";
            this.newTypeBox.Size = new System.Drawing.Size(167, 28);
            this.newTypeBox.TabIndex = 3;
            this.newTypeBox.Text = "Medication";
            this.newTypeBox.Visible = false;
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(599, 67);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(167, 29);
            this.showButton.TabIndex = 13;
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // sessionButton
            // 
            this.sessionButton.Location = new System.Drawing.Point(599, 103);
            this.sessionButton.Name = "sessionButton";
            this.sessionButton.Size = new System.Drawing.Size(166, 29);
            this.sessionButton.TabIndex = 14;
            this.sessionButton.Text = "Create Session";
            this.sessionButton.UseVisualStyleBackColor = true;
            this.sessionButton.Click += new System.EventHandler(this.sessionButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(606, 135);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(156, 40);
            this.errorLabel.TabIndex = 15;
            this.errorLabel.Text = "  Select a treatment to\r\n     create a session";
            this.errorLabel.Visible = false;
            // 
            // FormTherapist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 453);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.sessionButton);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.newTypeBox);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.prescriptionsTable);
            this.Controls.Add(this.createPrescriptionButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.newDatePicker);
            this.Controls.Add(this.newNameBox);
            this.Name = "FormTherapist";
            this.Text = "FormTherapist";
            this.Load += new System.EventHandler(this.FormTherapist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prescriptionsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createPrescriptionButton;
        private System.Windows.Forms.DataGridView prescriptionsTable;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.TextBox newNameBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DateTimePicker newDatePicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn schedule;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.ComboBox newTypeBox;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Button sessionButton;
        private System.Windows.Forms.Label errorLabel;
    }
}