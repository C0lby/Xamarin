using Autofac;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs.Services.Autofac;

namespace FormsIoC.Autofac
{
	public static class Bootstrap
	{
		static ContainerBuilder sharedContainer;

		public static ContainerBuilder SharedContainer {
			get {
				return sharedContainer ?? (sharedContainer = new ContainerBuilder ());
			}
			set {
				sharedContainer = value;
			}
		}

		public static void Run ()
		{
			SharedContainer.RegisterType<ServicesProxy> ();

			// ServiceProxy will be dependency of ServiceProvider
			SharedContainer.RegisterType<ServicesProvider> ();

			// Create the container
			var container = SharedContainer.Build ();

			// Once the container is set you can create IResolver instance of
			// it using the plugin libraries
			var resolver = new AutofacResolver (container);


			// Set the IResolver instance to a static wrapper class that 
			// allows easy access to our DI container IResolver implementation
			Resolver.SetResolver (resolver);
		}
	}
}