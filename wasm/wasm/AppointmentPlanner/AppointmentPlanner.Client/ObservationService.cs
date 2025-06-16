using AppointmentPlanner.Client.Pages.Observations;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AppointmentPlanner.Client
{
    public class ObservationService
    {
        private readonly HttpClient _httpClient;
        public ObservationService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<List<Observation>> GetAll() =>
            await _httpClient.GetFromJsonAsync<List<Observation>>("api/observations");

        public async Task<Observation?> GetObservationById(int id) =>
            await _httpClient.GetFromJsonAsync<Observation>($"api/observations/{id}");

        public async Task Add(Observation observation) =>
            await _httpClient.PostAsJsonAsync("api/observations", observation);

        public async Task Update(Observation observation) =>
            await _httpClient.PutAsJsonAsync($"api/observations/{observation.ObservationId}", observation);

        public async Task Delete(int id) =>
            await _httpClient.DeleteAsync($"api/observations/{id}");
    }

}
