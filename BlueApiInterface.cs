using System.Net.Http.Headers;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

namespace FrcScouting;

public static class BlueApiInterface
{
    public static HttpClient HttpClient = new HttpClient();
    static BlueApiInterface()
    {
        HttpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("X-TBA-Auth-Key", File.ReadAllText("tbakey"));
    }
}