using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.NavigationBug.Values;
using Avalonia.NavigationBug.Views;
using Avalonia.Styling;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Regions;

namespace Avalonia.NavigationBug;

public class App : PrismApplication
{
  static bool IsDesignMode => Controls.Design.IsDesignMode;
  
  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);
    base.Initialize();
  }

  public override void OnFrameworkInitializationCompleted()
  {
    // Line below is needed to remove Avalonia data validation.
    // Without this line you will get duplicate validations from both Avalonia and CT
    BindingPlugins.DataValidators.RemoveAt(0);

    if(IsDesignMode) RequestedThemeVariant = ThemeVariant.Dark;

    base.OnFrameworkInitializationCompleted();
  }

  protected override AvaloniaObject CreateShell() =>
    ApplicationLifetime switch
    {
      IClassicDesktopStyleApplicationLifetime => Container.Resolve<MainWindow>(),
      ISingleViewApplicationLifetime => Container.Resolve<MainView>(),
      _ => null!
    };

  protected override void RegisterTypes(IContainerRegistry container)
  {
    container.RegisterForNavigation<FirstView>();
    container.RegisterForNavigation<SecondView>();
    container.RegisterForNavigation<ThirdView>();
  }

  protected override void OnInitialized()
  {
    var regionManager = Container.Resolve<IRegionManager>();
    regionManager.RegisterViewWithRegion<FirstView>(RegionNames.Content);
    
    base.OnInitialized();
  }
}