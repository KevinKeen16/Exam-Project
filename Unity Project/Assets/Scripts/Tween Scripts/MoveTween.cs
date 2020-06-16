using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveTween : MonoBehaviour
{
    public int X;
    public LeanTweenType inType;
    public float duration;
    public float delay;
    public bool Logedin;

    private void OnEnable()
    {
        LeanTween.moveLocalX(gameObject, X, duration).setDelay(delay).setEase(inType);
    }
}
