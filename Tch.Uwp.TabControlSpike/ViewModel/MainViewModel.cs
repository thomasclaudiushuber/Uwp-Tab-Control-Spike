using Prism.Events;
using System;
using System.Collections.ObjectModel;
using Tch.Uwp.TabControlSpike.Event;

namespace Tch.Uwp.TabControlSpike.ViewModel
{
  public class MainViewModel : ViewModelBase
  {
    private DetailViewModelBase _selectedDetail;
    private int _newItemCounter = 1;
    private IEventAggregator _eventAggregator;
    private Func<FriendDetailViewModel> _friendDetailCreator;
    private Func<BookDetailViewModel> _bookDetailCreator;

    public MainViewModel(IEventAggregator eventAggregator,
      Func<FriendDetailViewModel> friendDetailCreator,
      Func<BookDetailViewModel> bookDetailCreator)
    {
      _eventAggregator = eventAggregator;
      _eventAggregator.GetEvent<CloseTabItemEvent>().Subscribe(CloseDetail);
      _friendDetailCreator = friendDetailCreator;
      _bookDetailCreator = bookDetailCreator;

      Details = new ObservableCollection<DetailViewModelBase>();
    }

    public ObservableCollection<DetailViewModelBase> Details { get; }

    public DetailViewModelBase SelectedDetail
    {
      get { return _selectedDetail; }
      set
      {
        _selectedDetail = value;
        OnPropertyChanged();
      }
    }

    public void OpenNewFriendDetail()
    {
      var item = _friendDetailCreator();
      item.FirstName = "Thomas";
      item.LastName = "Huber " + _newItemCounter++;
      Details.Add(item);
      SelectedDetail = item;
    }

    public void OpenNewBookDetail()
    {
      var item = _bookDetailCreator();
      item.Title = "Book " + _newItemCounter++;
      Details.Add(item);
      SelectedDetail = item;
    }

    private void CloseDetail(DetailViewModelBase item)
    {
      Details.Remove(item);
      if (item == SelectedDetail)
      {
        SelectedDetail = null;
      }
    }
  }
}
