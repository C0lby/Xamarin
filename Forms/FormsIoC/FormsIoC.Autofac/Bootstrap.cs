using Autofac;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs.Services.Autofac;

namespace FormsIoC.Autofac
{
	public static class Bootstrap
	{
		public static void Run ()
		{

			var builder = new ContainerBuilder ();


			builder.RegisterType<ServicesProxy> ();


			// ServiceProxy is a dependency of ServiceProvider
			builder.RegisterType<ServicesProvider> ();


			// Create the container
			var container = builder.Build ();


			// Once the container is set you can create IResolver instance of
			// it using the plugin libraries
			var resolver = new AutofacResolver (container);


			// Set the IResolver instance to a static wrapper class that 
			// allows easy access to our DI container IResolver implementation
			Resolver.SetResolver (resolver);
		}
	}
}