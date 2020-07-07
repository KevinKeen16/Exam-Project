using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogInTest : MonoBehaviour
{
    public GameObject NonLog;
    public GameObject LoggedId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.LoggedIn == true)
        {
            NonLog.SetActive(false);
            LoggedId.SetActive(true);
        }
        else
        {

        }
    }
}
