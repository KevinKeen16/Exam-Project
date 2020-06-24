using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetText : MonoBehaviour {

    public Text textbox;
    public string URL;

    void Start() {
    StartCoroutine(getText());
}

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
