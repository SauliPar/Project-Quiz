using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;


public class ButtonScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private RectTransform rectTransform;

    [Header("Attributes")]
    [SerializeField] private float hoverEnterScale = 1.2f;
    [SerializeField] private float hoverEnterTime = 0.1f;
    [SerializeField] private float hoverExitTime = 0.1f;

    private void Start()
    {
        ButtonHoverExit();
    }
    public void ButtonHoverEnter()
    {
        rectTransform.DOScale(hoverEnterScale, hoverEnterTime);
    }
    public void ButtonHoverExit()
    {
        rectTransform.DOScale(1f, hoverExitTime);
    }
    private void OnDisable()
    {
        rectTransform.localScale = Vector3.one;
    }
}