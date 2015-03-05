using System;
using Autofac;
using Xamarin.Forms.Labs.Services;

namespace FormsIoC.Autofac.iOS
{
	public static class Bootstrap
	{
		public static void Run ()
		{

			var builder = new ContainerBuilder (); 

			builder.Register (c => new Settings ()).As<ISettings> ();

			builder.Build ();

			//builder.Update (Xamarin.Forms.Labs.Services.Resolver);
		}
	}
}