using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.NavigationBug.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
  [ObservableProperty] ISolidColorBrush _brush = Brushes.Blue;
}