using System.Collections;
using System.Collections.Generic;
using Unity.RemoteConfig;
using UnityEngine;
using TMPro;

public class Log : MonoBehaviour
{
    public struct userAttributes { }
    public struct appAttributes { }

    public TMP_Text title;
    public TMP_Text log;

    void Awake()
    {
        ConfigManager.FetchCompleted += setLog;
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    void setLog(ConfigResponse response)
    {
        if(ConfigManager.appConfig.GetString("LogTitle").Length > 1 && ConfigManager.appConfig.GetString("LogText").Length > 1)
        {
            title.text = ConfigManager.appConfig.GetString("LogTitle");
            log.text = ConfigManager.appConfig.GetString("LogText").Replace("/n", "<br><br>");
        }
    }

    private void OnDestroy()
    {
        ConfigManager.FetchCompleted -= setLog;
    }
}
