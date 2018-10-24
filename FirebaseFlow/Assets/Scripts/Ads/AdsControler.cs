using System;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;


public class AdsControler : MonoBehaviour
{
    public bool adsEnabled = true;
    public bool bannerEnabled;
    public bool interstitialEnabled;
    public bool rewardedEnabled;

    public List<UnityEvent> rewardedEvents;
    public string adMobAndroidAppId;
    public string adMobIOSAppId;
    public string adMobAndroidBannerId;
    public string adMobIOSBannerId;
    public string adMobIOSInterstitialId;
    public string adMobAndroidInterstitialId;
    public string adMobAndroidRewardedId;
    public string adMobIOSRewardedId;


    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;


    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.

        #if UNITY_ANDROID
            MobileAds.Initialize(adMobAndroidAppId);

        #elif UNITY_IPHONE
            MobileAds.Initialize(adMobIOSAppId);
#else
            MobileAds.Initialize("unexpected_platform");
#endif

        if (bannerEnabled)
        {
            this.RequestBanner();
        }

        if (rewardedEnabled)
        {
            // Get singleton reward based video ad reference.
            this.rewardBasedVideo = RewardBasedVideoAd.Instance;

            // Called when an ad request has successfully loaded.
            rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
            // Called when an ad request failed to load.
            rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
            // Called when an ad is shown.
            rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
            // Called when the ad starts to play.
            rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
            // Called when the user should be rewarded for watching a video.
            rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
            // Called when the ad is closed.
            rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
            // Called when the ad click caused the user to leave the application.
            rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

            this.RequestRewardBasedVideo();
        }

        if(interstitialEnabled){
            RequestInterstitial();
        }

    }


    private void RequestRewardBasedVideo()
    {

        AdRequest request = new AdRequest.Builder().Build();
#if UNITY_ANDROID
        this.rewardBasedVideo.LoadAd(request, adMobAndroidRewardedId);

#elif UNITY_IPHONE
        this.rewardBasedVideo.LoadAd(request, adMobIOSRewardedId);

#else
        this.rewardBasedVideo.LoadAd(request, "unexpected_platform");
#endif

    }


    private void RequestBanner(AdPosition position = AdPosition.Top)
    {
#if UNITY_ANDROID
                // Create a 320x50 banner at the top of the screen.
                bannerView = new BannerView(adMobAndroidBannerId, AdSize.SmartBanner, position);
#elif UNITY_IPHONE
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adMobIOSBannerId, AdSize.SmartBanner, position);
#else
                                   // Create a 320x50 banner at the top of the screen.
                        bannerView = new BannerView("unexpected_platform", AdSize.SmartBanner, position);
#endif

        // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        bannerView.OnAdOpening += HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        bannerView.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    public void ShowUnityAdsRewarded()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = RewardedShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void ShowUnityAdsInterstitial(){
        if (Advertisement.IsReady("interstitial"))
        {
            var options = new ShowOptions { resultCallback = InterstitialShowResult };
            Advertisement.Show("interstitial", options);
        }
    }

    private void RewardedShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                foreach (UnityEvent e in rewardedEvents)
                    e.Invoke();
                //Nagradtiti igraca

                break;
            case ShowResult.Skipped:
                //TODO: Popup
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                //todo: popup
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    private void InterstitialShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    public void RequestInterstitial()
    {
#if UNITY_ANDROID
            //Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adMobAndroidInterstitialId);
#elif UNITY_IPHONE
        interstitial = new InterstitialAd(adMobIOSInterstitialId);
#else
        interstitial = new InterstitialAd("unexpected_platform");
#endif

        // Called when an ad request has successfully loaded.
        interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        // Create an empty ad request.

        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);

    }

    public void ShowAdMobInterstitial(){
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void DestroyBanner(){
        bannerView.Destroy();
    }

    public void DestroyInterstitial(){
        interstitial.Destroy();
    }


    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        this.RequestRewardBasedVideo();
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        foreach (UnityEvent e in rewardedEvents)
            e.Invoke();

        MonoBehaviour.print(
            "HandleRewardBasedVideoRewarded event received");
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }

    public void ShowAdMobRewarded(){
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
    }
}
