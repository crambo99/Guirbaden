using Guirbaden.Tools;

namespace Guirbaden.Pages;

using Guirbaden.Model;
using Guirbaden.Tools;
using Guirbaden.Viewmodel;

public partial class Param : ContentPage
{
    private static string filePath = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "anim.json");
    private readonly IHttpClientFactory _httpClientFactory;

    public Param(IHttpClientFactory httpClientFactory,ParamViewModel vm)
    {
        InitializeComponent();

        _httpClientFactory = httpClientFactory;
        BindingContext = vm;
    }

    private void Refresh(object sender, EventArgs e)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri("https://crambo99.github.io/Pages/anim.json");

        string json = Network.GetData(client).Replace("\n","\r\n");

        if (!string.IsNullOrEmpty(json))
        {
            using StreamWriter streamWriter = new StreamWriter(System.IO.File.OpenWrite(filePath));
            streamWriter.Write(json);
        }
    }
}