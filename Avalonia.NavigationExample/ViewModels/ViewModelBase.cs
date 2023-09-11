using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Regions;

namespace Avalonia.NavigationBug.ViewModels;

public abstract class ViewModelBase : ObservableObject, INavigationAware
{
  public virtual void OnNavigatedTo(NavigationContext navigationContext)
  {
  }

  public virtual void OnNavigatedFrom(NavigationContext navigationContext)
  {
  }
  
  public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;
}
