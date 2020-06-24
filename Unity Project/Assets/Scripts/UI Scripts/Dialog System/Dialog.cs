using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public string[] tags;
    private int index;
    public float typingSpeed;
    public GameObject animator;

    private void Start()
    {

    }

    public void textPaste()
    {
        Debug.Log("Pasting Tekst");
        textDisplay.text = sentences[index];
        animator.GetComponent<AnimTest>().CheckTag();
    }


    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            textPaste();
        }
        else {
            textDisplay.text = "";
                }
    }

}
