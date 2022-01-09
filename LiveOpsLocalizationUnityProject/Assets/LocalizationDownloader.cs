using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocalizationDownloader : MonoBehaviour
{
    private const string CSV_URL = "";
    
    private static string _rawLocalizationCsv;

    public static string RawLocalization => _rawLocalizationCsv;

    void OnEnable()
    {
        DontDestroyOnLoad(this);
        StartCoroutine(DownloadLocalization());
    }

    private IEnumerator DownloadLocalization()
    {
        using (UnityWebRequest client = UnityWebRequest.Get(CSV_URL))
        {
            UnityWebRequestAsyncOperation result = client.SendWebRequest();

            // TODO: Start loading screen
            
            yield return new WaitUntil(() => result.isDone);
            
            // TODO: End loading screen
            
            _rawLocalizationCsv = result.webRequest.downloadHandler.text;
        }
    }
}
