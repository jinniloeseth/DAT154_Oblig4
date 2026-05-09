using SharedLibrary.Objects;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Threading;

namespace DesktopApp.WPF
{
    public partial class CaseWindow : Window
    {
        private CaseScenario _case;

        private HttpClient _http = new HttpClient();

        private DispatcherTimer _refreshTimer;

        private bool _isRefreshing = false;

        public CaseWindow(CaseScenario caseData)
        {
            InitializeComponent();

            _case = caseData;

            Loaded += CaseWindow_Loaded;

            Title = $"Student Application - {_case.Title}";

            _case.ActionLogs = new List<ActionLog>();

            CaseTitle.Text = _case.Title;

            PatientName.Text =
                $"Name: {_case.Patient?.FullName}";

            AgeText.Text =
                $"Age: {_case.Patient?.Age}";

            RoomText.Text =
                $"Room: {_case.Patient?.Room}";

            DiagnosisText.Text =
                $"Diagnosis: {_case.Patient?.AdmittingDiagnosis}";

            UpdateVitalsDisplay();

            LoadVitalsHistory();

            LoadActionHistory();

            _refreshTimer = new DispatcherTimer();

            _refreshTimer.Interval =
                TimeSpan.FromSeconds(1);

            _refreshTimer.Tick += RefreshTimer_Tick;

            _refreshTimer.Start();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _refreshTimer?.Stop();

            this.Close();
        }

        // -----------------------------
        // ACTION BUTTONS
        // -----------------------------

        private async void GiveOxygen2_Click(
            object sender,
            RoutedEventArgs e)
        {
            await LogAction("Administered Oxygen 2L");

            await CreateUpdatedVitals(
                hrChange: 0,
                sysPressChange: 0,
                diaPressChange: 0,
                tempChange: 0,
                oxygenChange: 1,
                respChange: 0);

            // evt legg inn andre effekter av oksygen
        }

        private async void GiveOxygen5_Click(
            object sender,
            RoutedEventArgs e)
        {
            await LogAction("Administered Oxygen 5L");

            await CreateUpdatedVitals(
                hrChange: 0,
                sysPressChange: 0,
                diaPressChange: 0,
                tempChange: 0,
                oxygenChange: 3,
                respChange: -1);

            // evt legg inn andre effekter av oksygen
        }

        private async void Morphine2_Click(
            object sender,
            RoutedEventArgs e)
        {
            await LogAction("Administered Morphine 2mg");

            await CreateUpdatedVitals(
                hrChange: -3,
                sysPressChange: -5,
                diaPressChange: -2,
                tempChange: 0,
                oxygenChange: 0,
                respChange: -1);

            // evt legg inn andre effekter av morfin
        }

        private async void Morphine5_Click(
            object sender,
            RoutedEventArgs e)
        {
            await LogAction("Administered Morphine 5mg");

            await CreateUpdatedVitals(
                hrChange: -6,
                sysPressChange: -10,
                diaPressChange: -5,
                tempChange: 0,
                oxygenChange: 0,
                respChange: -2);

            // evt legg inn andre effekter av morfin
        }

        private async void GiveIVFluids_Click(
            object sender,
            RoutedEventArgs e)
        {
            await LogAction("Administered IV Fluids 500mL");

            await CreateUpdatedVitals(
                hrChange: -2,
                sysPressChange: 8,
                diaPressChange: 4,
                tempChange: 0,
                oxygenChange: 0,
                respChange: 0);

            // evt legg inn andre effekter av væske
        }

        private async void Paracetamol_Click(
            object sender,
            RoutedEventArgs e)
        {
            await LogAction("Administered Paracetamol 1g");

            await CreateUpdatedVitals(
                hrChange: -1,
                sysPressChange: 0,
                diaPressChange: 0,
                tempChange: -0.5,
                oxygenChange: 0,
                respChange: 0);

            // evt legg inn andre effekter av paracetamol
        }

        // -----------------------------
        // ACTION LOG
        // -----------------------------

        private async Task LogAction(string actionText)
        {
            var action = new ActionLog
            {
                Action = actionText,
                Timestamp = DateTime.Now,
                CaseScenarioId = _case.Id
            };

            _case.ActionLogs.Add(action);

            await _http.PostAsJsonAsync(
                "https://localhost:7120/api/ActionLogs",
                action);

            ActionLogList.Items.Add(
                $"{action.Timestamp:T} - {action.Action}");

            ActionLogList.ScrollIntoView(
                ActionLogList.Items[
                    ActionLogList.Items.Count - 1]);
        }

        private void LoadActionHistory()
        {
            ActionLogList.Items.Clear();

            foreach (var action in _case.ActionLogs
                         .OrderBy(a => a.Timestamp))
            {
                ActionLogList.Items.Add(
                    $"{action.Timestamp:T} - {action.Action}");
            }
        }

        // -----------------------------
        // VITALS
        // -----------------------------

        private void UpdateVitalsDisplay()
        {
            var latest = GetCurrentVitals();

            HeartRateText.Text =
                $"HR: {latest.HeartRate}";

            BpText.Text =
                $"BP: {latest.SystolicPressure}/{latest.DiastolicPressure}";

            OxygenText.Text =
                $"SpO2: {latest.OxygenSaturation}%";

            TempText.Text =
                $"Temp: {latest.Temperature}";
        }

        private VitalSigns GetCurrentVitals()
        {
            return _case.VitalSignsHistory
                .OrderBy(v => v.TimeStamp)
                .Last();
        }

        private void LoadVitalsHistory()
        {
            VitalsHistoryList.Items.Clear();

            foreach (var vital in _case.VitalSignsHistory
                         .OrderBy(v => v.TimeStamp))
            {
                VitalsHistoryList.Items.Add(
                    $"{vital.TimeStamp:T} | " +
                    $"HR: {vital.HeartRate} | " +
                    $"BP: {vital.SystolicPressure}/{vital.DiastolicPressure} | " +
                    $"SpO2: {vital.OxygenSaturation}% | " +
                    $"Temp: {vital.Temperature}");
            }

            if (VitalsHistoryList.Items.Count > 0)
            {
                VitalsHistoryList.ScrollIntoView(
                    VitalsHistoryList.Items[
                        VitalsHistoryList.Items.Count - 1]);
            }
        }

        private async Task CreateUpdatedVitals(
            int hrChange,
            int sysPressChange,
            int diaPressChange,
            double tempChange,
            int oxygenChange,
            int respChange)
        {
            var latest = GetCurrentVitals();

            var futureHeartRate =
                latest.HeartRate + hrChange;

            var futureSys =
                latest.SystolicPressure + sysPressChange;

            var futureTemp =
                latest.Temperature + tempChange;

            var futureOxygen =
                latest.OxygenSaturation + oxygenChange;

            var futureResp =
                latest.RespiratoryRate + respChange;

            // SAFETY RULES

            if (futureSys < 80)
            {
                MessageBox.Show(
                    "Warning: Blood pressure critically low!");

                return;
            }

            if (futureOxygen < 85)
            {
                MessageBox.Show(
                    "Warning: Oxygen saturation critically low!");

                return;
            }

            if (futureHeartRate < 40)
            {
                MessageBox.Show(
                    "Warning: Severe bradycardia detected!");

                return;
            }

            if (futureHeartRate > 180)
            {
                MessageBox.Show(
                    "Warning: Severe tachycardia detected!");

                return;
            }

            if (futureTemp > 41)
            {
                MessageBox.Show(
                    "Warning: Hyperthermia detected!");

                return;
            }

            if (futureResp < 6)
            {
                MessageBox.Show(
                    "Warning: Respiratory depression!");

                return;
            }

            // CREATE NEW VITALS

            var newVital = new VitalSigns
            {
                CaseScenarioId = _case.Id,

                HeartRate =
                    latest.HeartRate + hrChange,

                SystolicPressure =
                    latest.SystolicPressure + sysPressChange,

                DiastolicPressure =
                    latest.DiastolicPressure + diaPressChange,

                Temperature =
                    latest.Temperature + tempChange,

                OxygenSaturation =
                    latest.OxygenSaturation + oxygenChange,

                RespiratoryRate =
                    latest.RespiratoryRate + respChange,

                TimeStamp = DateTime.Now
            };

            _case.VitalSignsHistory.Add(newVital);

            var response = await _http.PostAsJsonAsync(
                "https://localhost:7120/api/VitalSigns",
                newVital);

            UpdateVitalsDisplay();

            LoadVitalsHistory();
        }
        private async void CaseWindow_Loaded(
    object sender,
    RoutedEventArgs e)
        {

            var updatedCase =
                await _http.GetFromJsonAsync<CaseScenario>(
                    $"https://localhost:7120/api/CaseScenario/{_case.Id}");

            if (updatedCase != null)
            {
                _case = updatedCase;

                UpdateVitalsDisplay();

                LoadVitalsHistory();

                LoadActionHistory();
            }
        }

        private async void RefreshTimer_Tick(
            object? sender,
            EventArgs e)
        {
            if (_isRefreshing)
                return;

            _isRefreshing = true;

            try
            {
                var updatedCase =
                    await _http.GetFromJsonAsync<CaseScenario>(
                        $"https://localhost:7120/api/CaseScenario/{_case.Id}");

                if (updatedCase == null)
                    return;

                _case = updatedCase;

                UpdateVitalsDisplay();

                LoadVitalsHistory();

                LoadActionHistory();
            }
            finally
            {
                _isRefreshing = false;
            }
        }
    }
}