using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpDownTween : MonoBehaviour
{
    public LeanTweenType inType;
    public LeanTweenType outType;
    public float duration;
    public float delay;
    public int Y;
    public UnityEvent onCompleteCallback;

    public void OnEnable()
    {
        LeanTween.moveLocalY(gameObject, Y, duration).setDelay(delay).setEase(inType).setLoopPingPong();
    }
}
