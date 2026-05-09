namespace TeacherApp.WinForms
{
    partial class MainWindow
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
            CaseListBox = new ListBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // CaseListBox
            // 
            CaseListBox.FormattingEnabled = true;
            CaseListBox.Location = new Point(12, 52);
            CaseListBox.Name = "CaseListBox";
            CaseListBox.Size = new Size(724, 319);
            CaseListBox.TabIndex = 1;
            CaseListBox.DoubleClick += CaseListBox_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 20);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 2;
            label1.Text = "Simulation case list";
            label1.Click += SimulationCaseList_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(CaseListBox);
            Name = "MainWindow";
            Text = "MainWindow";
            Load += MainWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox CaseListBox;
        private Label label1;
    }
}