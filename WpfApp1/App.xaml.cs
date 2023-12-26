using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp1.ViewModels;
using WpfApp1.Views;

namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			Services = ConfigureServices();
			Startup += App_Startup;
		}

		private void App_Startup(object sender, StartupEventArgs e)
		{
			var mainView = App.Current.Services.GetService<MainView>();
			mainView.Show();
		}

		/// <summary>
		/// Gets the current <see cref="App"/> instance in use
		/// </summary>
		public new static App Current => (App)Application.Current;

		/// <summary>
		/// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
		/// </summary>
		public IServiceProvider Services { get; }

		/// <summary>
		/// Configures the services for the application.
		/// </summary>
		private static IServiceProvider ConfigureServices()
		{
			var services = new ServiceCollection();

			//ViewModels
			services.AddTransient<MainViewModel>();
			services.AddTransient<LoginControlViewModel>();
			services.AddTransient<SignupControlViewModel>();
			services.AddTransient<ChangePwdControlViewModel>();

			// Services
			//services.AddSingleton<ITestService, TestService>();

			// Views
			services.AddSingleton<MainView>();

			return services.BuildServiceProvider();
		}
	}

}
