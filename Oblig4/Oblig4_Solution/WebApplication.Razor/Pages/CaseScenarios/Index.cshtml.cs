using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Objects;
using System.Text.Json;

public class CaseScenariosIndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public List<CaseScenario> CaseScenarios { get; set; } = new();

    public CaseScenariosIndexModel(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient();
    }

    public async Task OnGet()
    {
        var response = await _httpClient.GetAsync("https://localhost:7120/api/CaseScenario");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();

            CaseScenarios = JsonSerializer.Deserialize<List<CaseScenario>>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();
        }
    }
}