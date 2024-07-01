using CommunityToolkit.Mvvm.ComponentModel;
using Guirbaden.Viewmodel;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Guirbaden.Pages;

public partial class Animations : ContentPage
{
    public Animations(AnimationViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

