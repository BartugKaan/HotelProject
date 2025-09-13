using HotelProject.WebUI.Dtos.SendMessageDto;

namespace HotelProject.WebUI.Services
{
    public class SendMessageApiService : ApiService<ResultSendMessageDto>
    {
        public SendMessageApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "SendMessage")
        {
        }
    }

    public class CreateSendMessageApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public CreateSendMessageApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"] + "/SendMessage";
        }

        public async Task<bool> CreateAsync(CreateSendMessageDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/AddMessageWithEmail", dto);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}