using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string interstitialAndroidAdUnitId;
    [SerializeField] private string interstitialiosAdUnitId;

    private string interstitialAdUnitId;

    void Awake() {
#if UNITY_ANDROID
        interstitialAdUnitId = interstitialAndroidAdUnitId;
#elif UNITY_IOS
        interstitialAdUnit = interstitialiOSAdUnitId;
#elif UNITY_EDITOR
        interstitialAdUnitId = interstitialAndriodAdUnitId;
#endif

    }

    public void LoadAd() {
        print("Loading interstitial!!");
        Advertisement.Load(interstitialAdUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        print("interstitial loaded!!");
        Advertisement.Show(interstitialAdUnitId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print("interstitial failed to load");
    }



    public void ShowInterstitialAd() {
        print("showing ad!!");
        LoadAd();
        Advertisement.Show(interstitialAdUnitId, this);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        print("interstitial clicked");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        print("interstitial show complete");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print("interstitial show failure");

    }

    public void OnUnityAdsShowStart(string placementId)
    {
        print("interstitial show start");

    }
}