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
            this.logoutButton = new System.Windows.Forms.Button();
            this.patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medication = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prescriptionsTable = new System.Windows.Forms.DataGridView();
            this.editButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.prescriptionsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prescriptions";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(597, 407);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(168, 29);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.button1_Click);
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
            // medication
            // 
            this.medication.HeaderText = "Medication";
            this.medication.MinimumWidth = 6;
            this.medication.Name = "medication";
            this.medication.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.medication.Width = 125;
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
            this.medication,
            this.schedule});
            this.prescriptionsTable.GridColor = System.Drawing.SystemColors.Control;
            this.prescriptionsTable.Location = new System.Drawing.Point(12, 32);
            this.prescriptionsTable.Name = "prescriptionsTable";
            this.prescriptionsTable.RowHeadersWidth = 51;
            this.prescriptionsTable.Size = new System.Drawing.Size(579, 404);
            this.prescriptionsTable.TabIndex = 4;
            this.prescriptionsTable.Text = "dataGridView1";
            this.prescriptionsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.prescriptionsTable_CellContentClick);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(598, 68);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(167, 29);
            this.editButton.TabIndex = 5;
            this.editButton.Text = "Edit Prescription";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // FormTherapist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 453);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.prescriptionsTable);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.createPrescriptionButton);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.DataGridView prescriptionsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn medication;
        private System.Windows.Forms.DataGridViewTextBoxColumn schedule;
        private System.Windows.Forms.Button editButton;
    }
}