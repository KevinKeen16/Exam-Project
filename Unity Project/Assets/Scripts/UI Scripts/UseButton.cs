using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseButton : MonoBehaviour
{

    /* Starts the game if called
     */
    public void StartGame()
    {
        GameManager.instance.LoadGame();
    }
}
