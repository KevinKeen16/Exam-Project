using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeftRight : MonoBehaviour
{
    public LeanTweenType inType;
    public LeanTweenType outType;
    public float duration;
    public float delay;
    public int Y;

    public void OnEnable()
    {
        LeanTween.rotateY(gameObject, Y, duration).setDelay(delay).setEase(inType).setLoopPingPong();
    }
}
