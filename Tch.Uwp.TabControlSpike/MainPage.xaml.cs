using Tch.Uwp.TabControlSpike.ViewModel;
using Windows.UI.Xaml.Controls;

namespace Tch.Uwp.TabControlSpike
{
  public sealed partial class MainPage : Page
  {
    public MainPage(MainViewModel viewModel)
    {
      this.InitializeComponent();
      ViewModel = viewModel;
    }

    public MainViewModel ViewModel { get; }
  }
}
