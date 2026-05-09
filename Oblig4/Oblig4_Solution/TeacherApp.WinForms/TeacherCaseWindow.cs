using SharedLibrary.Objects;
using System.Net.Http;
using System.Net.Http.Json;

namespace TeacherApp.WinForms
{
    public partial class TeacherCaseWindow : Form
    {
        private CaseScenario _case;

        private System.Windows.Forms.Timer _refreshTimer;

        private HttpClient _http = new HttpClient();

        public TeacherCaseWindow(CaseScenario caseData)
        {
            InitializeComponent();

            _case = caseData;

            Text = $"Teacher Application - {_case.Title}";

            LoadCaseData();

            LoadTeacherComments();

            _refreshTimer = new System.Windows.Forms.Timer();

            _refreshTimer.Interval = 1000;

            _refreshTimer.Tick += RefreshTimer_Tick;

            _refreshTimer.Start();
        }

        private void LoadCaseData()
        {
            // CASE TITLE
            CaseTitleLabel.Text = _case.Title;

            // PATIENT INFO
            PatientNameLabel.Text =
                $"Patient: {_case.Patient?.FullName}";

            AgeLabel.Text =
                $"Age: {_case.Patient?.Age}";

            RoomLabel.Text =
                $"Room: {_case.Patient?.Room}";

            DiagnosisLabel.Text =
                $"Diagnosis: {_case.Patient?.AdmittingDiagnosis}";


            // CURRENT VITALS
            var latest =
                _case.VitalSignsHistory
                    .OrderBy(v => v.TimeStamp)
                    .LastOrDefault();

            if (latest != null)
            {
                HeartRateLabel.Text =
                    $"HR: {latest.HeartRate}";

                BloodPressureLabel.Text =
                    $"BP: {latest.SystolicPressure}/{latest.DiastolicPressure}";

                OxygenLabel.Text =
                    $"SpO2: {latest.OxygenSaturation}%";

                TemperatureLabel.Text =
                    $"Temp: {latest.Temperature}";
            }


            // ACTION LOGS
            ActionLogListBox.Items.Clear();

            foreach (var action in _case.ActionLogs
                         .OrderBy(a => a.Timestamp))
            {
                ActionLogListBox.Items.Add(
                    $"{action.Timestamp:T} - {action.Action}");
            }


            // VITALS HISTORY
            VitalsHistoryListBox.Items.Clear();

            foreach (var vital in _case.VitalSignsHistory
                         .OrderBy(v => v.TimeStamp))
            {
                VitalsHistoryListBox.Items.Add(
                    $"{vital.TimeStamp:T} | " +
                    $"HR {vital.HeartRate} | " +
                    $"BP {vital.SystolicPressure}/{vital.DiastolicPressure} | " +
                    $"SpO2 {vital.OxygenSaturation}% | " +
                    $"Temp {vital.Temperature}");
            }


            // AUTO SCROLL
            if (ActionLogListBox.Items.Count > 0)
            {
                ActionLogListBox.TopIndex =
                    ActionLogListBox.Items.Count - 1;
            }

            if (VitalsHistoryListBox.Items.Count > 0)
            {
                VitalsHistoryListBox.TopIndex =
                    VitalsHistoryListBox.Items.Count - 1;
            }
        }

        private async void SaveCommentButton_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                TeacherCommentTextBox.Text))
            {
                return;
            }

            var observation =
                new TeacherObservation
                {
                    Observation =
                        TeacherCommentTextBox.Text,

                    Timestamp = DateTime.Now,

                    CaseScenarioId = _case.Id
                };

            await _http.PostAsJsonAsync(
                "https://localhost:7120/api/TeacherObservations",
                observation);

            TeacherCommentTextBox.Clear();

            await LoadTeacherComments();
        }

        private async Task LoadTeacherComments()
        {
            var comments =
                await _http.GetFromJsonAsync<
                    List<TeacherObservation>>(
                    "https://localhost:7120/api/TeacherObservations");

            TeacherCommentsListBox.Items.Clear();

            foreach (var comment in comments
                         .Where(c => c.CaseScenarioId == _case.Id)
                         .OrderBy(c => c.Timestamp))
            {
                TeacherCommentsListBox.Items.Add(
                    $"{comment.Timestamp:T} - {comment.Observation}");
            }

            if (TeacherCommentsListBox.Items.Count > 0)
            {
                TeacherCommentsListBox.TopIndex =
                    TeacherCommentsListBox.Items.Count - 1;
            }
        }

        private async void RefreshTimer_Tick(
            object? sender,
            EventArgs e)
        {
            var updatedCase =
                await _http.GetFromJsonAsync<CaseScenario>(
                    $"https://localhost:7120/api/CaseScenario/{_case.Id}");

            if (updatedCase == null)
                return;

            // UPDATE LOCAL CASE FIRST
            _case = updatedCase;

            // REFRESH UI AFTER DATA UPDATE
            LoadCaseData();

            await LoadTeacherComments();
        }

        private async void ResetSimulationButton_Click(
            object sender,
            EventArgs e)
        {
            var response =
                await _http.PostAsync(
                    $"https://localhost:7120/api/CaseScenario/reset/{_case.Id}",
                    null);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Simulation reset.");

                var updatedCase =
                    await _http.GetFromJsonAsync<CaseScenario>(
                        $"https://localhost:7120/api/CaseScenario/{_case.Id}");

                if (updatedCase != null)
                {
                    _case = updatedCase;

                    LoadCaseData();

                    await LoadTeacherComments();
                }
            }
        }
    }
}