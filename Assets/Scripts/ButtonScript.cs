using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ButtonScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Button button;

    public void Setup(string option, string isCorrect, UnityAction<string> buttonCallback)
    {
        button.onClick.AddListener(() =>
        {
            buttonCallback(isCorrect);
        });
        text.text = option;
    }

    public void DestroyButton()
    {
        button.onClick.RemoveAllListeners();
        Destroy(gameObject);
    }

}