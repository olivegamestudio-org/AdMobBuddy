using Android.Gms.Ads;
using Android.Gms.Ads.Interstitial;
using System;
using System.Diagnostics;

namespace AdMobBuddy.Android
{
	internal class InterstitialLoadCallback : InterstitialAdLoadCallback
	{
		#region Properties

		public event EventHandler OnInterstitialLoaded;

		private AdMobAdapter Adapter { get; set; }

		#endregion //Properties

		#region Methods

		public InterstitialLoadCallback(AdMobAdapter adpater)
		{
			Adapter = adpater;
		}

		public override void OnAdLoaded(Java.Lang.Object p0)
		{
			Debug.WriteLine("Interstitial ad received and ready to be displayed.");

			base.OnAdLoaded(p0);

			Adapter.OnInterstitialLoaded(p0);
			OnInterstitialLoaded?.Invoke(p0, new EventArgs());
		}

		public override void OnAdFailedToLoad(LoadAdError error)
		{
			Debug.WriteLine($"Interstitial ad failed to load, error code: {error.Code}, {error.Message}");

			base.OnAdFailedToLoad(error);
		}

		#endregion //Methods
	}
}
