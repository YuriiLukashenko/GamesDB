/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:GamesDB_MVVMLight_EntityFramework.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using GamesDB_MVVMLight_EntityFramework.Model;
using GamesDB_MVVMLight_EntityFramework.ViewModels;

namespace GamesDB_MVVMLight_EntityFramework.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ValetViewModel>();
            SimpleIoc.Default.Register<MutViewModel>();
            SimpleIoc.Default.Register<NiceViewModel>();
            SimpleIoc.Default.Register<ThousandViewModel>();
            SimpleIoc.Default.Register<DyrViewModel>();
            SimpleIoc.Default.Register<GameDayViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]


        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public ValetViewModel ValetViewModel => ServiceLocator.Current.GetInstance<ValetViewModel>();

        public MutViewModel MutViewModel => ServiceLocator.Current.GetInstance<MutViewModel>();

        public NiceViewModel NiceViewModel => ServiceLocator.Current.GetInstance<NiceViewModel>();

        public ThousandViewModel ThousandViewModel => ServiceLocator.Current.GetInstance<ThousandViewModel>();

        public DyrViewModel DyrViewModel => ServiceLocator.Current.GetInstance<DyrViewModel>();

        public GameDayViewModel GameDayViewModel => ServiceLocator.Current.GetInstance<GameDayViewModel>();
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}