using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Regions;

namespace Avalonia.NavigationBug.ViewModels;

// ReSharper disable once ClassNeverInstantiated.Global
public partial class ThirdViewModel : ViewModelBase
{
  [ObservableProperty]
  [NotifyPropertyChangedFor(nameof(ButtonMessage))]
  bool _state = false;
  
  readonly IRegionManager _regionManager = null!;
  IRegionNavigationJournal? _journal;

  [Obsolete]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public ThirdViewModel()
  { }

  public ThirdViewModel(IRegionManager regionManager)
  {
    _regionManager = regionManager;
  }

  public string ButtonMessage => State.ToString();
  
  [RelayCommand]
  void GoBack()
  {
    if (_journal is { CanGoBack: true })
    {
      _journal.GoBack();
    }
  }
  
  [RelayCommand]
  void NegateState() => State = !State;

  public override void OnNavigatedTo(NavigationContext navigationContext)
  {
    _journal = navigationContext.NavigationService.Journal;
  }
}