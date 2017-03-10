using Prism.Events;
using System.ComponentModel;
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

    public void Close()
    {
      var args = new CancelEventArgs();
      OnCloseDetail(args);

      if (!args.Cancel)
      {
        _eventAggregator.GetEvent<CloseTabItemEvent>().Publish(this);
      }
    }

    protected virtual void OnCloseDetail(CancelEventArgs args) { }
  }
}
