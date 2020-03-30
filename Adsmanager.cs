using UnityEngine;
using UnityEngine.Advertisements;

public class Adsmanager : MonoBehaviour , IUnityAdsListener
{
    private string playStoreID = "3514256";
    private string appStoreID = "3514257";
    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool isTestAd;

    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
    }

    private void InitializeAdvertisement()
    {
        if(isTargetPlayStore){Advertisement.Initialize(playStoreID, isTestAd); return;}
        Advertisement.Initialize(playStoreID, isTestAd);
    }

    public void PlayinterstitialAd()
    {
        if(!Advertisement.IsReady(interstitialAd)) {return;}
        Advertisement.Show(interstitialAd);
    }

    public void PlayRewardedVideoAd()
    {
        if(!Advertisement.IsReady(rewardedVideoAd)) {return;}
        Advertisement.Show(rewardedVideoAd);
    }
    
    public void OnUnityAdsReady(string placementId){

    }

    public void OnUnityAdsDidError(string message){

    }

    public void OnUnityAdsDidStart(string placementId){

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult){
        switch(showResult){
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId == rewardedVideoAd) {Debug.Log("Reward The Player");}
                if(placementId == interstitialAd) {Debug.Log("Finished interstitial");}
                break;
        }
    }
}
