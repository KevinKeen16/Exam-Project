using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public TurnCounter turns;
    public GameObject GenUI;
    public GameObject FInishUI;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        turns.CurrentPlayer.steps = 0;
        GenUI.SetActive(false);
        FInishUI.SetActive(true);
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(true);
        
    }
}
