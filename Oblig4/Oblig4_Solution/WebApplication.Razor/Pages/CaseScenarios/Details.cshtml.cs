using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Objects;
using System.Text.Json;

public class DetailsModel : PageModel
{
    private readonly HttpClient _httpClient;

    public CaseScenario? CaseScenario { get; set; }

    public bool IsTeacher { get; set; } // 👈 NY

    public DetailsModel(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient();
    }

    public async Task<IActionResult> OnGet(int id)
    {
        // 👇 Hent rolle fra session
        var role = HttpContext.Session.GetInt32("Role");
        IsTeacher = role == 1;

        var response = await _httpClient.GetAsync($"https://localhost:7120/api/CaseScenario/{id}");

        if (!response.IsSuccessStatusCode)
        {
            return NotFound();
        }

        var json = await response.Content.ReadAsStringAsync();

        CaseScenario = JsonSerializer.Deserialize<CaseScenario>(json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        return Page();
    }
}