namespace ClinicInterface
{
    partial class FormSessions
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
            this.patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sessionsTable = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sessionsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // patient
            // 
            this.patient.HeaderText = "Patient";
            this.patient.MinimumWidth = 6;
            this.patient.Name = "patient";
            this.patient.ReadOnly = true;
            this.patient.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.patient.Width = 125;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.name.Width = 125;
            // 
            // schedule
            // 
            this.schedule.HeaderText = "Schedule";
            this.schedule.MinimumWidth = 6;
            this.schedule.Name = "schedule";
            this.schedule.ReadOnly = true;
            this.schedule.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.schedule.Width = 160;
            // 
            // note
            // 
            this.note.HeaderText = "Note";
            this.note.MinimumWidth = 6;
            this.note.Name = "note";
            this.note.ReadOnly = true;
            this.note.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.note.Width = 313;
            // 
            // sessionsTable
            // 
            this.sessionsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sessionsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patient,
            this.name,
            this.schedule,
            this.note});
            this.sessionsTable.Location = new System.Drawing.Point(12, 12);
            this.sessionsTable.Name = "sessionsTable";
            this.sessionsTable.ReadOnly = true;
            this.sessionsTable.RowHeadersWidth = 51;
            this.sessionsTable.Size = new System.Drawing.Size(776, 386);
            this.sessionsTable.TabIndex = 0;
            this.sessionsTable.Text = "dataGridView1";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(694, 409);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(94, 29);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Go back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // FormSessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.sessionsTable);
            this.Name = "FormSessions";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormSessions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sessionsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn patient;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn schedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.DataGridView sessionsTable;
        private System.Windows.Forms.Button backButton;
    }
}