using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocalizationDownloader : MonoBehaviour
{
    private const string CSV_URL = "";
    
    private static string _rawLocalizationCsv;
    
    private static readonly int Loading = Animator.StringToHash("loading");
    
    [SerializeField]
    private Animator _loadingAnimator;

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
            
            _loadingAnimator.SetBool(Loading, true);
            
            yield return new WaitUntil(() => result.isDone);
            
            _loadingAnimator.SetBool(Loading, false);
            
            _rawLocalizationCsv = result.webRequest.downloadHandler.text;
        }
    }
}
