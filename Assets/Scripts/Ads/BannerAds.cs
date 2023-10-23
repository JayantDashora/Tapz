using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{

    [SerializeField] private string bannerAndriodAdUnitId;
    [SerializeField] private string banneriOSAdUnitId;
    private string bannerAdUnitId;
    BannerPosition bannerPosition = BannerPosition.BOTTOM_CENTER;
    private void Awake() 
    {
#if UNITY_ANDROID
        bannerAdUnitId = bannerAndriodAdUnitId;
#elif UNITY_IOS
        bannerAdUnit = banneriOSAdUnitId;
#elif UNITY_EDITOR
        bannerAdUnitId = bannerAndriodAdUnitId;
#endif
    }
    private void Start() {
        Advertisement.Banner.SetPosition(bannerPosition);
        Invoke("ShowBannerAd",3f);
    }

    void OnBannerLoaded() 
    {
        print("Banner Loaded!!");
        ShowBannerAd();
    }
    void OnBannerLoadError(string error) 
    {
        print("Banner failed to load "+error);
    }


    public void ShowBannerAd() 
    {
        BannerOptions options = new BannerOptions
        {
            showCallback=OnBannerShown,
            clickCallback=OnBannerClicked,
            hideCallback=OnBannerHidden
            
        };

        Advertisement.Banner.Show(bannerAdUnitId, options);
        

        
    }

    void OnBannerShown() { }
    void OnBannerClicked() { }
    void OnBannerHidden() { }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

}

