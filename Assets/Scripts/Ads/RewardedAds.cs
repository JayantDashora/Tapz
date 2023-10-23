using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public string rewardedAndroidAdUnitId;
    public string rewardediosAdUnitId;

    string rewardedAdUnitId;

    void Awake()
    {
#if UNITY_ANDROID
        rewardedAdUnitId = rewardedAndroidAdUnitId;
#elif UNITY_IOS
        rewardedAdUnit = rewardediOSAdUnitId;
#elif UNITY_EDITOR
        rewardedAdUnitId = rewardedAndriodAdUnitId;
#endif
    }

    public void LoadRewardedAd()
    {
        print("Loading Rewarded!!");
        Advertisement.Load(rewardedAdUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId.Equals(rewardedAdUnitId))
        {
            print("Rewarded loaded!!");
            //ShowRewardedAd();
            Advertisement.Show(rewardedAdUnitId, this);
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print("Rewarded failed to load");
    }



    public void ShowRewardedAd()
    {
        print("showing Rewarded ad!!");
        LoadRewardedAd();
        Advertisement.Show(rewardedAdUnitId, this);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        print("Rewarded clicked");
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(rewardedAdUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("----------------------------------------------------------------------------------");
            PlayerPrefs.SetInt("HIGHSCORE", PlayerPrefs.GetInt("HIGHSCORE") + 10);
        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print("Rewarded show failure");

    }

    public void OnUnityAdsShowStart(string placementId)
    {
        print("Rewarded show start");

    }
}