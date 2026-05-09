using SharedLibrary.Objects;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http.Json;


namespace DesktopApp.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadCases();
        }

        private async void LoadCases()
        {
            var http = new HttpClient();

            var cases = await http.GetFromJsonAsync<List<CaseScenario>>(
                "https://localhost:7120/api/CaseScenario");

            CaseList.ItemsSource = cases;
        }

        private void CaseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CaseList.SelectedItem is CaseScenario selected)
            {
                var window = new CaseWindow(selected);
                window.Show();

                CaseList.SelectedItem = null;
            }
        }
    }
}