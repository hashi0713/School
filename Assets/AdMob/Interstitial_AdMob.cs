using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interstitial_AdMob : MonoBehaviour
{
#if UNITY_IPHONE
    private string adUnitId = "ca-app-pub-9946317540781954/3935720436";
#else
    private string adUnitId = "unexpected_platform";
#endif

    public bool start;
    public int select;
    private InterstitialAd interstitial;

    private void Start()
    {
        start = false;
        select = 0;
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        // 広告の初期化などが必要ならばここで行う
        MobileAds.Initialize(initStatus => { });

        // 初回広告の読み込み
        loadInterstitialAd();
    }

    private void Update()
    {
        // キーボードのAキーが押されたら広告を表示
        if (start)
        {
            showInterstitialAd();
            start = false;
        }
    }

    private void loadInterstitialAd()
    {


        // オフラインの場合には広告を読み込ませない
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet connection. Interstitial ad will not be loaded.");
            return;
        }

        InterstitialAd.Load(adUnitId, new AdRequest(),
          (InterstitialAd ad, LoadAdError loadAdError) =>
          {
              if (loadAdError != null)
              {
                  // Interstitial ad failed to load with error
                  interstitial.Destroy();
                  return;
              }
              else if (ad == null)
              {
                  // Interstitial ad failed to load.
                  return;
              }
              ad.OnAdFullScreenContentClosed += () => {
                  HandleOnAdClosed();
              };
              ad.OnAdFullScreenContentFailed += (AdError error) =>
              {
                  HandleOnAdClosed();
              };
              interstitial = ad;
          });
    }

    private void HandleOnAdClosed()
    {
        this.interstitial.Destroy();
        switch (select)
        {
            case 1: SceneManager.LoadScene("Game"); break;
            case 2: SceneManager.LoadScene("Start"); break;
        }

    }

    private void showInterstitialAd()
    {
        if (interstitial != null && interstitial.CanShowAd())
        {
            interstitial.Show();
        }
        else
        {
            Debug.Log("Interstitial Ad not loaded");
        }
    }
}