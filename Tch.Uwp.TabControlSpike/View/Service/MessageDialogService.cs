using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Tch.Uwp.TabControlSpike.View.Service
{
  public interface IMessageDialogService
  {
    Task<MessageDialogResult> ShowOkCancelDialogAsync(string content);
  }
  public class MessageDialogService : IMessageDialogService
  {
    public async Task<MessageDialogResult> ShowOkCancelDialogAsync(string content)
    {
      var dialog = new MessageDialog(content);
      dialog.Commands.Add(new UICommand("OK", null, 1));
      dialog.Commands.Add(new UICommand("Cancel", null, 2));
      var command = await dialog.ShowAsync();
      return (int)command.Id == 1
        ? MessageDialogResult.OK
        : MessageDialogResult.Cancel;
    }
  }
  public enum MessageDialogResult
  {
    OK,
    Cancel
  }
}
