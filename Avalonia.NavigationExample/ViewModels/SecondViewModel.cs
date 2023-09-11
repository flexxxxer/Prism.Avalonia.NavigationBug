using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Avalonia.NavigationBug.Values;
using Avalonia.NavigationBug.Views;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Regions;

namespace Avalonia.NavigationBug.ViewModels;

// ReSharper disable once ClassNeverInstantiated.Global
public partial class SecondViewModel : ViewModelBase
{
  [ObservableProperty] string _textValue = "";
  [ObservableProperty] ObservableCollection<ThemeVariant> _themeVariants = new();
  [ObservableProperty] ThemeVariant _selectedThemeVariant = ThemeVariant.Default;
  readonly IRegionManager _regionManager = null!;
  IRegionNavigationJournal? _journal = null;
  
  [Obsolete]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public SecondViewModel()
  { }

  public SecondViewModel(IRegionManager regionManager)
  {
    _regionManager = regionManager;
    _themeVariants.Add(ThemeVariant.Dark);
    _themeVariants.Add(ThemeVariant.Light);
    _themeVariants.Add(ThemeVariant.Default);
  }

  partial void OnSelectedThemeVariantChanged(ThemeVariant value)
  {
    if (Application.Current is {} app)
    {
      app.RequestedThemeVariant = value;
    }
  }

  [RelayCommand]
  void GoBack()
  {
    if (_journal is { CanGoBack: true })
    {
      _journal.GoBack();
    }
  }
  
  [RelayCommand]
  void GoNext()
  {
    _regionManager.RequestNavigate(RegionNames.Content, nameof(ThirdView));
  }

  public override void OnNavigatedTo(NavigationContext navigationContext)
  {
    _journal = navigationContext.NavigationService.Journal;
  }
}