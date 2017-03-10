using System;
using System.ComponentModel;
using Prism.Events;
using Tch.Uwp.TabControlSpike.View.Service;
using System.Threading.Tasks;

namespace Tch.Uwp.TabControlSpike.ViewModel
{
  public class FriendDetailViewModel : DetailViewModelBase
  {
    private string _firstName;
    private string _lastName;
    private bool _hasChanges;
    private IMessageDialogService _messageDialogService;

    public FriendDetailViewModel(IEventAggregator eventAggregator, IMessageDialogService messageDialogService) : base(eventAggregator)
    {
      _messageDialogService = messageDialogService;
    }

    public string FirstName
    {
      get { return _firstName; }
      set
      {
        _firstName = value;
        OnPropertyChanged();
        HasChanges = true;
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
        HasChanges = true;
        UpdateTitle();
      }
    }

    public bool HasChanges
    {
      get { return _hasChanges; }
      set
      {
        _hasChanges = value;
        OnPropertyChanged();
      }
    }

    protected async override Task OnCloseDetailAsync(CancelEventArgs args)
    {
      if (HasChanges)
      {
        var result = await _messageDialogService.ShowOkCancelDialogAsync("You'll loose your changes when you close this tab (Yeah, I know, there's no save-button yet ;-)). Continue?");
        args.Cancel = result == MessageDialogResult.Cancel;
      }
    }

    private void UpdateTitle()
    {
      Title = $"{FirstName} {LastName}";
    }
  }
}
