using System;
using System.ComponentModel;
using Avalonia.NavigationBug.Values;
using Avalonia.NavigationBug.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Regions;

namespace Avalonia.NavigationBug.ViewModels;

// ReSharper disable once ClassNeverInstantiated.Global
public partial class FirstViewModel : ViewModelBase
{
  [ObservableProperty] string _textValue = "";
  readonly IRegionManager _regionManager = null!;
  
  [Obsolete]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public FirstViewModel()
  { }

  public FirstViewModel(IRegionManager regionManager)
  {
    _regionManager = regionManager;
  }
  
  [RelayCommand]
  void GoNext()
  {
    _regionManager.RequestNavigate(RegionNames.Content, nameof(SecondView));
  }
}