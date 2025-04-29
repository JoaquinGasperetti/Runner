using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class AdManager : MonoBehaviour
{
    [Header("IDs de AdMob")]
    public string bannerAdUnitId = "ca-app-pub-2266949018056491/3860018339";
    public string interstitialAdUnitId = "ca-app-pub-2266949018056491/6039459113";

    private BannerView bannerView;
    private InterstitialAd interstitialAd;

    void Start()
    {
        MobileAds.Initialize(initStatus => {
            RequestBanner();
            RequestInterstitial();
        });
    }

    void RequestBanner()
    {
        bannerView = new BannerView(bannerAdUnitId, AdSize.Banner, AdPosition.Bottom);

        AdRequest adRequest = new AdRequest();
        bannerView.LoadAd(adRequest);
    }

    void RequestInterstitial()
    {
        var adRequest = new AdRequest();

        InterstitialAd.Load(interstitialAdUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("Error al cargar el Interstitial: " + error);
                    return;
                }
                interstitialAd = ad;
            });
    }

    public void ShowInterstitial()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        }
        else
        {
            Debug.Log("El interstitial no está listo todavía.");
        }
    }

    private void OnDestroy()
    {
        bannerView?.Destroy();
        interstitialAd?.Destroy();
    }
}
