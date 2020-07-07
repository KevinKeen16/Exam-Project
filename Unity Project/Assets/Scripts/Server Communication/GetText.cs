using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetText : MonoBehaviour {
    /* Variables storage
     */
    public Text textbox;
    public string URL;

    /* Starts coroutine
     */
    void Start()
    {
    StartCoroutine(getText());
    }

    /* Sends a webrequest to a url specified in the url variable.
     * Once the request is complete it takes the text from the text file and prints it
     * into the textbox specified in the textbox variable
     */
IEnumerator getText()
{
    UnityWebRequest www = UnityWebRequest.Get(URL);
    yield return www.SendWebRequest();

    if (www.isNetworkError || www.isHttpError)
    {
        Debug.Log(www.error);
    }
    else
    {
        // Show results as text
        Debug.Log(www.downloadHandler.text);

        // Or retrieve results as binary data
        byte[] results = www.downloadHandler.data;
            textbox.text = www.downloadHandler.text;
    }
}
}
