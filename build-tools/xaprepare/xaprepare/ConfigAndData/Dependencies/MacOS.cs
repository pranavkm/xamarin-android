using System;
using System.Collections.Generic;

namespace Xamarin.Android.Prepare
{
	partial class MacOS
	{
		static readonly List<Program> programs = new List<Program> {
			new HomebrewProgram ("autoconf"),
			new HomebrewProgram ("automake"),
			new HomebrewProgram ("ccache"),
			new HomebrewProgram ("cmake"),

			new HomebrewProgram ("git") {
				MinimumVersion = "2.20.0",
			},

			new HomebrewProgram ("make"),

			new HomebrewProgram ("ninja"),
			new HomebrewProgram ("p7zip", "7za"),

			new MonoPkgProgram ("Mono", "com.xamarin.mono-MDK.pkg", new Uri (Context.Instance.Properties.GetRequiredValue (KnownProperties.MonoDarwinPackageUrl))) {
				MinimumVersion = Context.Instance.Properties.GetRequiredValue (KnownProperties.MonoRequiredMinimumVersion),
				MaximumVersion = Context.Instance.Properties.GetRequiredValue (KnownProperties.MonoRequiredMaximumVersion),
			},
		};

		static readonly HomebrewProgram mingw = new HomebrewProgram ("mingw-w64") {
			MinimumVersion = "7.0.0_2",
		};

		protected override void InitializeDependencies ()
		{
			Dependencies.AddRange (programs);
			if (!Context.Instance.NoMingwW64)
				Dependencies.Add (mingw);
		}
	}
}
