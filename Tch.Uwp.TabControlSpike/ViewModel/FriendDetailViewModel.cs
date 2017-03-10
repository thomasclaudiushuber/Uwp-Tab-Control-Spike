using Prism.Events;

namespace Tch.Uwp.TabControlSpike.ViewModel
{
  public class FriendDetailViewModel : DetailViewModelBase
  {
    private string _firstName;
    private string _lastName;

    public FriendDetailViewModel(IEventAggregator eventAggregator) : base(eventAggregator) { }

    public string FirstName
    {
      get { return _firstName; }
      set
      {
        _firstName = value;
        OnPropertyChanged();
        UpdateTitle();
      }
    }

    public string LastName
    {
      get { return _lastName; }
      set
      {
        _lastName = value;
        OnPropertyChanged();
        UpdateTitle();
      }
    }

    private void UpdateTitle()
    {
      Title = $"{FirstName} {LastName}";
    }
  }
}
