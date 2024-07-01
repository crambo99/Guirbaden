using CommunityToolkit.Mvvm.ComponentModel;
using Guirbaden.Model;
using System.Collections.ObjectModel;
using System.Text.Json;

//https://crambo99.github.io/Pages/page.html

namespace Guirbaden.Viewmodel
{
    public partial class AnimationViewModel : ObservableObject
    {
        private static string filePath = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "anim.json");

        [ObservableProperty]
        ObservableCollection<Event> infos = new ObservableCollection<Event>();

        public AnimationViewModel()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    using StreamWriter streamWriter = new StreamWriter(System.IO.File.OpenWrite(filePath));
                    streamWriter.Write(new StreamReader(FileSystem.OpenAppPackageFileAsync("anim.json").Result).ReadToEnd());
                }
                string json = File.ReadAllText(filePath);
                Events events = JsonSerializer.Deserialize<Events>(json)!;

                foreach (Event item in events.events)
                {
                    Infos.Add(item);
                }
            }
            catch (Exception e)
            {
                ;
            }
        }
    }
}
