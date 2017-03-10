using Prism.Events;
using System.ComponentModel;
using System.Threading.Tasks;
using Tch.Uwp.TabControlSpike.Event;

namespace Tch.Uwp.TabControlSpike.ViewModel
{
  public class DetailViewModelBase : ViewModelBase
  {
    private string _title;
    private IEventAggregator _eventAggregator;

    public DetailViewModelBase(IEventAggregator eventAggregator)
    {
      _eventAggregator = eventAggregator;
    }

    public string Title
    {
      get { return _title; }
      set
      {
        _title = value;
        OnPropertyChanged();
      }
    }

    public void Select()
    {
        _eventAggregator.GetEvent<SelectTabItemEvent>().Publish(this);
    }

    public async void Close()
    {
      var args = new CancelEventArgs();
      await OnCloseDetailAsync(args);

      if (!args.Cancel)
      {
        _eventAggregator.GetEvent<CloseTabItemEvent>().Publish(this);
      }
    }

    protected virtual Task OnCloseDetailAsync(CancelEventArgs args) { return Task.FromResult(0); }
  }
}
