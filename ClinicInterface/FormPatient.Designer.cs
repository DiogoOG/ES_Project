namespace ClinicInterface
{
    partial class FormPatient
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logoutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.therapist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.permissionButton = new System.Windows.Forms.Button();
            this.prescriptionsTable = new System.Windows.Forms.DataGridView();
            this.permissionList = new System.Windows.Forms.ListBox();
            this.decideButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.prescriptionsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Patient";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(596, 411);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(168, 29);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prescriptions";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Schedule";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.Width = 160;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Medication";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Type";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // therapist
            // 
            this.therapist.HeaderText = "Therapist";
            this.therapist.MinimumWidth = 6;
            this.therapist.Name = "therapist";
            this.therapist.ReadOnly = true;
            this.therapist.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.therapist.Width = 120;
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.MinimumWidth = 6;
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.type.Width = 120;
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
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(596, 36);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(168, 29);
            this.changeButton.TabIndex = 5;
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.makePrivateButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(604, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 6;
            // 
            // permissionButton
            // 
            this.permissionButton.Location = new System.Drawing.Point(596, 71);
            this.permissionButton.Name = "permissionButton";
            this.permissionButton.Size = new System.Drawing.Size(168, 29);
            this.permissionButton.TabIndex = 7;
            this.permissionButton.Text = "Manage permission";
            this.permissionButton.UseVisualStyleBackColor = true;
            this.permissionButton.Click += new System.EventHandler(this.permissionButton_Click);
            // 
            // prescriptionsTable
            // 
            this.prescriptionsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prescriptionsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.therapist,
            this.type,
            this.name,
            this.schedule});
            this.prescriptionsTable.GridColor = System.Drawing.SystemColors.Control;
            this.prescriptionsTable.Location = new System.Drawing.Point(11, 36);
            this.prescriptionsTable.Name = "prescriptionsTable";
            this.prescriptionsTable.ReadOnly = true;
            this.prescriptionsTable.RowHeadersWidth = 51;
            this.prescriptionsTable.Size = new System.Drawing.Size(579, 404);
            this.prescriptionsTable.TabIndex = 4;
            this.prescriptionsTable.Text = "dataGridView1";
            this.prescriptionsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.prescriptionsTable_CellContentClick);
            // 
            // permissionList
            // 
            this.permissionList.FormattingEnabled = true;
            this.permissionList.ItemHeight = 20;
            this.permissionList.Location = new System.Drawing.Point(596, 106);
            this.permissionList.Name = "permissionList";
            this.permissionList.Size = new System.Drawing.Size(168, 224);
            this.permissionList.TabIndex = 8;
            this.permissionList.SelectedIndexChanged += new System.EventHandler(this.permissionList_SelectedIndexChanged);
            // 
            // decideButton
            // 
            this.decideButton.Location = new System.Drawing.Point(596, 337);
            this.decideButton.Name = "decideButton";
            this.decideButton.Size = new System.Drawing.Size(80, 29);
            this.decideButton.TabIndex = 9;
            this.decideButton.UseVisualStyleBackColor = true;
            this.decideButton.Click += new System.EventHandler(this.decideButton_Click);
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(682, 336);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(82, 29);
            this.doneButton.TabIndex = 10;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            // 
            // FormPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 453);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.decideButton);
            this.Controls.Add(this.permissionList);
            this.Controls.Add(this.permissionButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.prescriptionsTable);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.label1);
            this.Name = "FormPatient";
            this.Text = "FormPatient";
            this.Load += new System.EventHandler(this.FormPatient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prescriptionsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.DataGridView prescriptionsTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn therapist;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn schedule;
        private System.Windows.Forms.Button permissionButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button makePrivateButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox permissionList;
        private System.Windows.Forms.Button decideButton;
        private System.Windows.Forms.Button doneButton;
    }
}