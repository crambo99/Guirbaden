using CommunityToolkit.Mvvm.ComponentModel;

namespace Guirbaden.Viewmodel
{
	public partial class ParamViewModel : ObservableObject
	{
		[ObservableProperty]
		DateTime lastParamDate;
		public ParamViewModel()
		{
			LastParamDate = DateTime.Parse(new StreamReader(FileSystem.OpenAppPackageFileAsync("version.txt").Result).ReadToEnd());
        }
	}
}