using Guirbaden.Tools;

namespace Guirbaden.Pages;

using Guirbaden.Model;
using Guirbaden.Tools;
using Guirbaden.Viewmodel;

public partial class Param : ContentPage
{
    private static string animFilePath = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "anim.json");
    private static string versionFilePath = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "version.txt");


    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ParamViewModel _viewModel;

    public Param(IHttpClientFactory httpClientFactory,ParamViewModel vm)
    {
        InitializeComponent();

        _httpClientFactory = httpClientFactory;
        _viewModel = vm;
        BindingContext = vm;
    }

    private void Refresh(object sender, EventArgs e)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri("https://crambo99.github.io/Pages/anim.json");

        string json = Network.GetData(client).Replace("\n","\r\n");

        if (!string.IsNullOrEmpty(json))
        {
            using StreamWriter streamWriter = new StreamWriter(System.IO.File.OpenWrite(animFilePath));
            streamWriter.Write(json);

            using StreamWriter versionStreamWriter = new StreamWriter(System.IO.File.OpenWrite(versionFilePath));
            versionStreamWriter.Write(_viewModel.serverDate);
        }
    }
}