using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextReveal : MonoBehaviour
{
    public  TextMeshProUGUI textgui;


    //void Start()
    //{
    //    textgui = gameObject.GetComponent<TextMeshProUGUI>();
    //    Debug.Log(textgui.text.Length);
    //}

    IEnumerator Start()
    {
        textgui = gameObject.GetComponent<TextMeshProUGUI>();
        //Debug.Log("Typewriter Started");

        //Debug.Log("Typing");
        int totalVisibleCharacters = textgui.text.Length;
        //Debug.Log(totalVisibleCharacters);
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);

            textgui.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
                //Debug.Log("Typewriter Finished, restarting");
            Debug.Log(visibleCount);
            yield return new WaitForSeconds(0.05f);

            counter += 1;

            yield return new WaitForSeconds(1.0f);
        }
    }
}
