namespace SW.FileHashChecker.WPF.Host
{
	using System;
	using System.Collections.Generic;
	using Caliburn.Micro;
    using SW.FileHashChecker.WPF.Host.Services.Filesystem;
    using SW.FileHashChecker.WPF.Host.Services;
    using SW.FileHashChecker.WPF.Host.Services.Interfaces;

    public class AppBootstrapper : BootstrapperBase
	{
		SimpleContainer container;

		public AppBootstrapper()
		{
			//Start();
		}

		protected override void Configure()
		{
			container = new SimpleContainer();

			container.Singleton<IWindowManager, WindowManager>();
			container.Singleton<IEventAggregator, EventAggregator>();
			container.PerRequest<IShell, ShellViewModel>();

            // Services registrations.
            container.Singleton<IFileSelector, FileSelector>();
            container.Singleton<FileHashGenerator>();
		}

		protected override object GetInstance(Type service, string key)
		{
			var instance = container.GetInstance(service, key);
			if (instance != null)
				return instance;

			throw new InvalidOperationException("Could not locate any instances.");
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return container.GetAllInstances(service);
		}

		protected override void BuildUp(object instance)
		{
			container.BuildUp(instance);
		}

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<IShell>();            
        }
	}
}