using System.Text.Json;

namespace Guirbaden.Tools
{
    static class Network
    {
        static public string GetData(HttpClient client)
        {
            string data = string.Empty; 

            NetworkAccess accessType = Connectivity.Current.NetworkAccess;

            if (accessType == NetworkAccess.Internet)
            {
                HttpResponseMessage response = client.GetAsync(string.Empty).Result;
                if (response.IsSuccessStatusCode)
                {
                     data = response.Content.ReadAsStringAsync().Result;
                    //data = JsonSerializer.Deserialize<T>(result);
                }
            }
            return data;
        }
    }
}
