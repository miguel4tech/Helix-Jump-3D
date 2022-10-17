using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdManager : MonoBehaviour
{
    private BannerView bannerAd;
    static bool bannerAdRequested = false;

    private InterstitialAd interstitial;
    #region  SOME USELESS RewardBasedVideo Ad code Variables that didn't work
    /// private RewardBasedVideoAd rewardBasedVideo;
    /// bool isRewarded = false;
    #endregion

    public static AdManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        #region  SOME USELESS RewardBasedVideo Ad code that didn't work
        // Get singleton reward based video ad reference.
        ///this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
        /// this.rewardBasedVideo.OnAdRewarded += this.HandleRewardBasedVideoRewarded;
        /// this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;

        ///this.RequestRewardBasedVideo();
        #endregion

        if (bannerAdRequested)
            return;

        this.RequestBanner();
        bannerAdRequested = true;
    }
    private void Update()
    {
        #region  SOME USELESS RewardBasedVideo Ad code that didn't work
        /// if (isRewarded)
        // {
        //     isRewarded = false;
        //     FindObjectOfType<CharacterSelector>().UnlockRandom();
        // }
        #endregion
    }
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }
    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        this.bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Clean up banner ad before creating a new one.
        if (this.bannerAd != null)
        {
            this.bannerAd.Destroy();
        }

        // Create a 320x50 banner at the top of the screen.
        this.bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Load a banner ad.
        this.bannerAd.LoadAd(this.CreateAdRequest());
    }
    public void RequestInterstitial()
    {

        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
            this.interstitial.Destroy();

        // Create an interstitial.
        this.interstitial = new InterstitialAd(adUnitId);

        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    public void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            Debug.Log("Inerstitial Ad is not ready yet");
        }
    }
#region  SOME USELESS RewardBasedVideo Ad code that didn't work
    /// public void RequestRewardBasedVideo()
    // {
    //     string adUnitId = "ca-app-pub-3940256099942544/5224354917";

    //     this.rewardBasedVideo.LoadAd(this.CreateAdRequest(), adUnitId);
    // }
    // public void ShowRewardBasedVideo()
    // {
    //     if (this.rewardBasedVideo.IsLoaded())
    //     {
    //         this.rewardBasedVideo.Show();
    //     }
    /// }

    /// #region RewardBasedVideo callback handlers

    // public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    // {
    //     this.RequestRewardBasedVideo();
    // }

    // public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    // {
    //     isRewarded = true;
    // }

    /// #endregion
#endregion
}
