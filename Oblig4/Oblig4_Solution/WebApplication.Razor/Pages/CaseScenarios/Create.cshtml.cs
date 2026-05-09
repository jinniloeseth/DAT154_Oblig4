using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Objects;
using System.Net.Http.Json;

namespace WebApp.Razor.Pages.CaseScenarios
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _http;

        [BindProperty]
        public CaseScenario CaseScenario { get; set; }
            = new()
            {
                Patient = new Patient()
            };

        public CreateModel(IHttpClientFactory factory)
        {
            _http = factory.CreateClient();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response =
                await _http.PostAsJsonAsync(
                    "https://localhost:7120/api/CaseScenario",
                    CaseScenario);

            if (!response.IsSuccessStatusCode)
            {
                return Page();
            }

            return RedirectToPage("/CaseScenarios/Index");
        }
    }
}