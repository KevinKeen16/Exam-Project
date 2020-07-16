using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCounter : MonoBehaviour
{

    public Stone Player1;
    public Stone Player2;
    public Stone CurrentPlayer;
    public GameObject p1c;
    public GameObject p2c;
    public GameObject p1s;
    public GameObject p2s;
    public GameObject Turn1;
    public GameObject Turn2;
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
            //p1s.transform.position = new Vector3(60, 0, 0);
            //p2s.transform.position = new Vector3(-60, 0, 0);

            CurrentPlayer = Player1;
            Player1.GetComponent<Stone>().enabled = false;
            Player2.GetComponent<Stone>().enabled = true;
            Player1.tag = "Player";
            Player2.tag = "CurrentPlayer";
            p1 = false;
            p2 = true;
            Player2.StartTurn = true;
            Player1.StartTurn = false;
            p1c.SetActive(false);
            p2c.SetActive(true);
            Turn1.SetActive(false);
            Turn2.SetActive(true);
            Player1.GetComponent<BoxCollider>().enabled = false;
            Player2.GetComponent<BoxCollider>().enabled = true;
            Debug.Log("Player 1 turn end, start turn player 2");
        }
        //if(p1 == false && p2 == true)
        else
        {
            //p1s.transform.position = new Vector3(-60, 0, 0);
            //p2s.transform.position = new Vector3(60, 0, 0);

            CurrentPlayer = Player2;
            Player2.GetComponent<Stone>().enabled = false;
            Player1.GetComponent<Stone>().enabled = true;
            Player2.tag = "Player";
            Player1.tag = "CurrentPlayer";
            p1 = true;
            p2 = false;
            Player1.StartTurn = true;
            Player2.StartTurn = false;
            p2c.SetActive(false);
            p1c.SetActive(true);
            Turn2.SetActive(false);
            Turn1.SetActive(true);
            Player2.GetComponent<BoxCollider>().enabled = false;
            Player1.GetComponent<BoxCollider>().enabled = true;
            Debug.Log("Player 2 turn end, start turn player 1");
        }
        
    }
}
