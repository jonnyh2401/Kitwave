using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;
using AppointmentPlanner.Client;

public class UserSessionService
{
    private readonly IJSRuntime _js;
    private const string UserKey = "currentUser";
    public User CurrentUser { get; private set; }
    public bool IsLoggedIn => CurrentUser != null;

    public UserSessionService(IJSRuntime js)
    {
        _js = js;
    }

    // Call this after a successful login API call, passing the user object returned by the server
    public async Task Login(User user)
    {
        if (user != null)
        {
            CurrentUser = user;
            var json = JsonSerializer.Serialize(user);
            await _js.InvokeVoidAsync("localStorage.setItem", UserKey, json);
        }
    }

    public async Task Logout()
    {
        CurrentUser = null;
        await _js.InvokeVoidAsync("localStorage.removeItem", UserKey);
    }

    public async Task LoadSession()
    {
        var json = await _js.InvokeAsync<string>("localStorage.getItem", UserKey);
        if (!string.IsNullOrEmpty(json))
        {
            try
            {
                CurrentUser = JsonSerializer.Deserialize<User>(json);
            }
            catch
            {
                CurrentUser = null;
            }
        }
        else
        {
            CurrentUser = null;
        }
    }

    public string Username => CurrentUser?.Username;
    public string FirstName => CurrentUser?.FirstName;
    public string LastName => CurrentUser?.LastName;
    public string AccessLevel => CurrentUser?.AccessLevel;
    public string ImageUrl => CurrentUser?.ImageUrl;
}