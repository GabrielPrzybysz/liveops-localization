using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour
{
    [SerializeField] private GameObject SpeechOne;
    
    IEnumerator Start()
    {
        yield return new WaitUntil(() => LocalizationDownloader.IsLoading == false);

        yield return new WaitForSeconds(0.3f);
        
        SpeechOne.SetActive(true);
    }
}
