using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuElementScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float growthScale = 1.2f;
    [SerializeField] private float growthTime = .2f;
    [SerializeField] private float shrinkTime = .2f;
    [SerializeField] private float defaultSize = 1f;
    private void Start()
    {
        transform.DOScale(1f, shrinkTime);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IncreaseElementSize();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DOTween.KillAll();
        SetDefaultElementSize();
    }

    private void IncreaseElementSize()
    {
        transform.DOScale(growthScale, growthTime).OnComplete(SetStandardGrowthSize);
    }
    
    private void SetDefaultElementSize()
    {
        transform.DOScale(defaultSize, shrinkTime).OnComplete(SetStandardShrinkSize);
    }

    private void SetStandardGrowthSize()
    {
        transform.DOScale(growthScale - 0.1f, growthTime * 2);
    }

    private void SetStandardShrinkSize()
    {
        transform.DOScale(defaultSize + 0.1f, shrinkTime * 2);
    }

   
}
