using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Objects;
using System.Net.Http.Json;

namespace WebApp.Razor.Pages.CaseScenarios
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _http;

        [BindProperty]
        public CaseScenario CaseScenario { get; set; }
            = new();

        public EditModel(IHttpClientFactory factory)
        {
            _http = factory.CreateClient();
        }

        public async Task OnGetAsync(int id)
        {
            var result =
                await _http.GetFromJsonAsync<CaseScenario>(
                    $"https://localhost:7120/api/CaseScenario/{id}");

            if (result != null)
            {
                CaseScenario = result;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response =
                await _http.PutAsJsonAsync(
                    $"https://localhost:7120/api/CaseScenario/{CaseScenario.Id}",
                    CaseScenario);

            if (!response.IsSuccessStatusCode)
            {
                return Page();
            }

            return RedirectToPage("/CaseScenarios/Index");
        }
    }
}