using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    public string andriodGameId;
    public string iOSGameId;
    [HideInInspector] public string gameId;
    [SerializeField] private bool isInTestingMode;
    public static AdsManager instance;

    private BannerAds bannerAds;
    private InterstitialAds interstitialAds;
    private RewardedAds rewardedAds;
    private void Awake() {

        if(instance != null && instance != this){
            Destroy(this);
        }
        else{
            InitializeAds();
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start() {
        // Take reference for the other scripts on the gameobject

        bannerAds =  GetComponent<BannerAds>();
        interstitialAds = GetComponent<InterstitialAds>();
        rewardedAds = GetComponent<RewardedAds>();


        // Start showing the banner ad

        bannerAds.ShowBannerAd();



    }

    private void InitializeAds(){

#if UNITY_ANDROID
        gameId = andriodGameId;
#elif UNITY_IOS
        gameId = iOSGameId;
#elif UNITY_EDITOR
        gameId = andriodGameId;
#endif

        if(!Advertisement.isInitialized){
            Advertisement.Initialize(gameId,isInTestingMode,this);
        }
        
    }
    
    public void OnInitializationComplete(){
        Debug.Log("Ad Inititalization Succesful.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message){
        Debug.Log("Ad Initialization Failed");
    }

    // Banner Ads functions

    // Interstitial Ads functions
    public void ShowInterstitialAd(){
        interstitialAds.ShowInterstitialAd();
    }

    // Rewarded Ads function

    public void ShowRewardedAd(){
        rewardedAds.ShowRewardedAd();
    }




}
