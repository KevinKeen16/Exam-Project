using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using TMPro;

public class Dialog : MonoBehaviour
{
    /* Variables storage
     */
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public string[] tags;
    private int index;
    public float typingSpeed;
    public GameObject animator;

    public void Awake()
    {
        textPaste();
    }

    /* Pastes the text into the textDisplay Variable
     */
    public void textPaste()
    {
        Debug.Log("Pasting Tekst");
        textDisplay.text = sentences[index];
        animator.GetComponent<AnimTest>().CheckTag();
    }

    /* Moves to the next senctence in the array
     */
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
