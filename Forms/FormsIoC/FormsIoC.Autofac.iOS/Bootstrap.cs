using Autofac;

namespace FormsIoC.Autofac.iOS
{
	public static class Bootstrap
	{
		public static void Run ()
		{
			// ISettings will be a dependency of FormsIoC.Autofac.ServiceProvider
			FormsIoC.Autofac.Bootstrap.SharedContainer.Register (c => new Settings ()).As<ISettings> ();

			FormsIoC.Autofac.Bootstrap.Run ();
		}
	}
}