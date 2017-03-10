using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Tch.Uwp.TabControlSpike.View
{
  public class DetailViewTemplateSelector:DataTemplateSelector
  {
    protected override DataTemplate SelectTemplateCore(object item)
    {
      var viewModelName = item.GetType().Name;
      return App.Current.Resources[viewModelName] as DataTemplate;
    }

    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
      return SelectTemplateCore(item);
    }
  }
}
