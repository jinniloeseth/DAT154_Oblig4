using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Objects;
using System.Text;
using System.Text.Json;

public class LoginModel : PageModel
{
    private readonly HttpClient _httpClient;

    public string? Message { get; set; }

    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public LoginModel(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient();
    }

    public async Task<IActionResult> OnPost()
    {
        var user = new User
        {
            Username = Username,
            Password = Password
        };

        var json = JsonSerializer.Serialize(user);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://localhost:7120/api/User/login", content);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var loggedInUser = JsonSerializer.Deserialize<User>(jsonResponse,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (loggedInUser == null)
            {
                Message = "Feil ved parsing av bruker";
                return Page();
            }

            HttpContext.Session.SetString("Username", loggedInUser.Username);
            HttpContext.Session.SetInt32("Role", (int)loggedInUser.Role);

            return RedirectToPage("CaseScenarios/Index");
        }

        Message = "Feil brukernavn eller passord";
        return Page();
    }
}