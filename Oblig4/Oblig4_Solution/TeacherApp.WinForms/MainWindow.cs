using SharedLibrary.Objects;
using System.Net.Http.Json;

namespace TeacherApp.WinForms
{
    public partial class MainWindow : Form
    {
        private HttpClient _http = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();

            LoadCases();
        }

        private async void LoadCases()
        {
            var cases =
                await _http.GetFromJsonAsync<List<CaseScenario>>(
                    "https://localhost:7120/api/CaseScenario");

            CaseListBox.DataSource = cases;

            CaseListBox.DisplayMember = "Title";
        }

        private void CaseListBox_DoubleClick(
            object sender,
            EventArgs e)
        {
            if (CaseListBox.SelectedItem is CaseScenario selected)
            {
                var window = new TeacherCaseWindow(selected);

                window.Show();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void SimulationCaseList_Click(object sender, EventArgs e)
        {

        }
    }
}