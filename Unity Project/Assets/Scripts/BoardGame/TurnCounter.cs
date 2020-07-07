using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCounter : MonoBehaviour
{

    public Stone Player1;
    public Stone Player2;
    public Stone CurrentPlayer;
    public bool p1;
    public bool p2;
    // Start is called before the first frame update
    void Start()
    {
        p1 = true;
        p2 = false;
        CurrentPlayer = Player1;
    }

    private void Update()
    {
        if (p1 == true && p2 == false)
        {
            CurrentPlayer = Player1;
        }
        else
        {
            CurrentPlayer = Player2;
        }
    }

    // Update is called once per frame
    public void SwitchTurn()
    {
        if(p1 == true && p2 == false)
        {
            CurrentPlayer = Player1;
            Player1.GetComponent<Stone>().enabled = false;
            Player2.GetComponent<Stone>().enabled = true;
            Player1.tag = "Player";
            Player2.tag = "CurrentPlayer";
            p1 = false;
            p2 = true;
            Player2.StartTurn = true;
            Player1.StartTurn = false;
            Debug.Log("Player 1 turn end, start turn player 2");
        }
        //if(p1 == false && p2 == true)
        else
        {
            CurrentPlayer = Player2;
            Player2.GetComponent<Stone>().enabled = false;
            Player1.GetComponent<Stone>().enabled = true;
            Player2.tag = "Player";
            Player1.tag = "CurrentPlayer";
            p1 = true;
            p2 = false;
            Player1.StartTurn = true;
            Player2.StartTurn = false;
            Debug.Log("Player 2 turn end, start turn player 1");
        }
        
    }
}
