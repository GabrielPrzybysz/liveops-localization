using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLocalize : MonoBehaviour
{
   [SerializeField] private string _keyToLocalize;

   private void Start()
   {
      gameObject.GetComponent<Text>().text = LocalizationController.Instance.Localize(_keyToLocalize);
   }
}
