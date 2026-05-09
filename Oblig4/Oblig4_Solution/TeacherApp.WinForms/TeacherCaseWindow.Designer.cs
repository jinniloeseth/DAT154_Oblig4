namespace TeacherApp.WinForms
{
    partial class TeacherCaseWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label CaseTitleLabel;

        private Label PatientNameLabel;
        private Label AgeLabel;
        private Label RoomLabel;
        private Label DiagnosisLabel;

        private ListBox ActionLogListBox;

        private Label HeartRateLabel;
        private Label BloodPressureLabel;
        private Label OxygenLabel;
        private Label TemperatureLabel;
        private Label TeacherCommentsLabel;

        private ListBox VitalsHistoryListBox;
        private ListBox TeacherCommentsListBox;

        private TextBox TeacherCommentTextBox;

        private Button SaveCommentButton;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            CaseTitleLabel = new Label();
            PatientNameLabel = new Label();
            AgeLabel = new Label();
            RoomLabel = new Label();
            DiagnosisLabel = new Label();
            ActionLogListBox = new ListBox();
            HeartRateLabel = new Label();
            BloodPressureLabel = new Label();
            OxygenLabel = new Label();
            TemperatureLabel = new Label();
            VitalsHistoryListBox = new ListBox();
            TeacherCommentsLabel = new Label();
            TeacherCommentTextBox = new TextBox();
            SaveCommentButton = new Button();
            TeacherCommentsListBox = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // CaseTitleLabel
            // 
            CaseTitleLabel.AutoSize = true;
            CaseTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            CaseTitleLabel.Location = new Point(20, 20);
            CaseTitleLabel.Name = "CaseTitleLabel";
            CaseTitleLabel.Size = new Size(123, 32);
            CaseTitleLabel.TabIndex = 0;
            CaseTitleLabel.Text = "Case Title";
            // 
            // PatientNameLabel
            // 
            PatientNameLabel.AutoSize = true;
            PatientNameLabel.Location = new Point(20, 80);
            PatientNameLabel.Name = "PatientNameLabel";
            PatientNameLabel.Size = new Size(47, 15);
            PatientNameLabel.TabIndex = 1;
            PatientNameLabel.Text = "Patient:";
            // 
            // AgeLabel
            // 
            AgeLabel.AutoSize = true;
            AgeLabel.Location = new Point(20, 110);
            AgeLabel.Name = "AgeLabel";
            AgeLabel.Size = new Size(31, 15);
            AgeLabel.TabIndex = 2;
            AgeLabel.Text = "Age:";
            // 
            // RoomLabel
            // 
            RoomLabel.AutoSize = true;
            RoomLabel.Location = new Point(20, 140);
            RoomLabel.Name = "RoomLabel";
            RoomLabel.Size = new Size(42, 15);
            RoomLabel.TabIndex = 3;
            RoomLabel.Text = "Room:";
            // 
            // DiagnosisLabel
            // 
            DiagnosisLabel.AutoSize = true;
            DiagnosisLabel.Location = new Point(20, 170);
            DiagnosisLabel.Name = "DiagnosisLabel";
            DiagnosisLabel.Size = new Size(61, 15);
            DiagnosisLabel.TabIndex = 4;
            DiagnosisLabel.Text = "Diagnosis:";
            // 
            // ActionLogListBox
            // 
            ActionLogListBox.Location = new Point(20, 230);
            ActionLogListBox.Name = "ActionLogListBox";
            ActionLogListBox.Size = new Size(420, 244);
            ActionLogListBox.TabIndex = 5;
            // 
            // HeartRateLabel
            // 
            HeartRateLabel.AutoSize = true;
            HeartRateLabel.Location = new Point(500, 80);
            HeartRateLabel.Name = "HeartRateLabel";
            HeartRateLabel.Size = new Size(26, 15);
            HeartRateLabel.TabIndex = 6;
            HeartRateLabel.Text = "HR:";
            // 
            // BloodPressureLabel
            // 
            BloodPressureLabel.AutoSize = true;
            BloodPressureLabel.Location = new Point(500, 110);
            BloodPressureLabel.Name = "BloodPressureLabel";
            BloodPressureLabel.Size = new Size(24, 15);
            BloodPressureLabel.TabIndex = 7;
            BloodPressureLabel.Text = "BP:";
            // 
            // OxygenLabel
            // 
            OxygenLabel.AutoSize = true;
            OxygenLabel.Location = new Point(500, 140);
            OxygenLabel.Name = "OxygenLabel";
            OxygenLabel.Size = new Size(38, 15);
            OxygenLabel.TabIndex = 8;
            OxygenLabel.Text = "SpO2:";
            // 
            // TemperatureLabel
            // 
            TemperatureLabel.AutoSize = true;
            TemperatureLabel.Location = new Point(500, 170);
            TemperatureLabel.Name = "TemperatureLabel";
            TemperatureLabel.Size = new Size(40, 15);
            TemperatureLabel.TabIndex = 9;
            TemperatureLabel.Text = "Temp:";
            // 
            // VitalsHistoryListBox
            // 
            VitalsHistoryListBox.Location = new Point(500, 230);
            VitalsHistoryListBox.Name = "VitalsHistoryListBox";
            VitalsHistoryListBox.Size = new Size(450, 244);
            VitalsHistoryListBox.TabIndex = 10;
            // 
            // TeacherCommentsLabel
            // 
            TeacherCommentsLabel.AutoSize = true;
            TeacherCommentsLabel.Location = new Point(20, 475);
            TeacherCommentsLabel.Name = "TeacherCommentsLabel";
            TeacherCommentsLabel.Size = new Size(113, 15);
            TeacherCommentsLabel.TabIndex = 14;
            TeacherCommentsLabel.Text = "Teacher Comments:";
            // 
            // TeacherCommentTextBox
            // 
            TeacherCommentTextBox.Location = new Point(20, 620);
            TeacherCommentTextBox.Multiline = true;
            TeacherCommentTextBox.Name = "TeacherCommentTextBox";
            TeacherCommentTextBox.Size = new Size(695, 50);
            TeacherCommentTextBox.TabIndex = 11;
            // 
            // SaveCommentButton
            // 
            SaveCommentButton.Location = new Point(736, 620);
            SaveCommentButton.Name = "SaveCommentButton";
            SaveCommentButton.Size = new Size(180, 50);
            SaveCommentButton.TabIndex = 12;
            SaveCommentButton.Text = "Save Comment";
            SaveCommentButton.Click += SaveCommentButton_Click;
            // 
            // TeacherCommentsListBox
            // 
            TeacherCommentsListBox.FormattingEnabled = true;
            TeacherCommentsListBox.Location = new Point(20, 493);
            TeacherCommentsListBox.Name = "TeacherCommentsListBox";
            TeacherCommentsListBox.Size = new Size(471, 109);
            TeacherCommentsListBox.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(882, 20);
            button1.Name = "button1";
            button1.Size = new Size(106, 32);
            button1.TabIndex = 15;
            button1.Text = "Reset Simulation";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ResetSimulationButton_Click;
            // 
            // TeacherCaseWindow
            // 
            ClientSize = new Size(1000, 700);
            Controls.Add(button1);
            Controls.Add(TeacherCommentsListBox);
            Controls.Add(CaseTitleLabel);
            Controls.Add(PatientNameLabel);
            Controls.Add(AgeLabel);
            Controls.Add(RoomLabel);
            Controls.Add(DiagnosisLabel);
            Controls.Add(ActionLogListBox);
            Controls.Add(HeartRateLabel);
            Controls.Add(BloodPressureLabel);
            Controls.Add(OxygenLabel);
            Controls.Add(TemperatureLabel);
            Controls.Add(VitalsHistoryListBox);
            Controls.Add(TeacherCommentTextBox);
            Controls.Add(SaveCommentButton);
            Controls.Add(TeacherCommentsLabel);
            Name = "TeacherCaseWindow";
            Text = "Teacher Case Window";
            ResumeLayout(false);
            PerformLayout();

        #endregion

        }

        private Button button1;
    }
}