using Autofac;
using Prism.Events;
using Tch.Uwp.TabControlSpike.View.Service;
using Tch.Uwp.TabControlSpike.ViewModel;

namespace Tch.Uwp.TabControlSpike.Startup
{
  public  class Bootstrapper
  {
    public IContainer Bootstrap()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
      builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();

      builder.RegisterType<MainPage>();
      builder.RegisterType<MainViewModel>();
      builder.RegisterType<FriendDetailViewModel>();
      builder.RegisterType<BookDetailViewModel>();
      

      return builder.Build();
    }
  }
}
