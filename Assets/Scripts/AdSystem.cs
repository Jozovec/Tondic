using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;
using UnityEngine.Monetization;
using Unity.RemoteConfig;

public class AdSystem : MonoBehaviour
{
    public struct userAttributes { }
    public struct appAttributes { }


    public bool testMode = true;
    string gameId = "3674517";

    bool ready = true;
    void Awake()
    {
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }

    private void Update()
    {
        if (ready)
        {
            if (ConfigManager.appConfig.GetInt("TimeBetweenAds") > 0)
            {
                StartCoroutine(adTimer());
            }
        }
    }

    public void showAd()
    {
        Advertisement.Show();
    }

    IEnumerator adTimer()
    {
        ready = false;
        yield return new WaitForSeconds(ConfigManager.appConfig.GetInt("TimeBetweenAds"));
        showAd();
        ready = true;
    }
}