using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemScaleController : MonoBehaviour
{
    private string _scaleTweenID;
    private void Start()
    {
        _scaleTweenID = GetInstanceID() + "scaleUp";
    }

    public void ScaleTween(Vector3 from, Vector3 to, float duration, float delay = 0)
    {
        DOTween.Kill(_scaleTweenID);
        transform.localScale = from;
        transform.DOScale(to, duration).SetEase(Ease.Linear).SetId(_scaleTweenID).SetDelay(delay);
    }
}
