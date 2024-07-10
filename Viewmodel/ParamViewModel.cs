using CommunityToolkit.Mvvm.ComponentModel;

namespace Guirbaden.Viewmodel
{
    public partial class ParamViewModel : ObservableObject
    {
        [ObservableProperty]
        DateTime localParamDate;

        [ObservableProperty]
        DateTime serverParamDate = default;

        [ObservableProperty]
        bool hasNewNetworkData = false;

        public string serverDate = string.Empty;

        private static string versionFilePath = Path.Combine(FileSystem.Current.AppDataDirectory, "version.txt");

        public ParamViewModel(IHttpClientFactory httpClientFactory)
        {
            if (File.Exists(versionFilePath))
            {
                LocalParamDate = DateTime.Parse(File.ReadAllText(versionFilePath));
            }
            else
            {
                LocalParamDate = DateTime.Parse(new StreamReader(FileSystem.OpenAppPackageFileAsync("version.txt").Result).ReadToEnd());
            }

            NetworkAccess accessType = Connectivity.Current.NetworkAccess;
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                HttpClient client = httpClientFactory.CreateClient();
                client.BaseAddress = new Uri("https://crambo99.github.io/Pages/version.txt");
                HttpResponseMessage response = client.GetAsync(string.Empty).Result;
                if (response.IsSuccessStatusCode)
                {
                    serverDate = response.Content.ReadAsStringAsync().Result;
                    ServerParamDate = DateTime.Parse(serverDate);
                    hasNewNetworkData = ServerParamDate > localParamDate;
                }
            }
        }
    }
}