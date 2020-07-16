using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Tile : MonoBehaviour
{
    public enum TileType {green, blue, dash, vs, spevent, coin, losecoin, movement}
    public TileType tileType;
    public TurnCounter Turns;
    public Stone player;
    public GameObject DebugUI;
    public GameObject Question;
    public TextMeshProUGUI text;
    public bool onetime;
    public GetText Quest1;


    [Header("Tile Parts")]
    public Renderer TileSprite;
    public GameObject Image;

    [Header("Tile Type Sprites")]
    public Material green;
    public Material blue;
    public Material dash;
    public Material vs;
    public Material spe;
    public Material coin;
    public Material lcoin;
    public Material move;


    void Start()
    {
        SetTile();
    }

    public void ButtonPress()
    {
        //if(Turns.p1 == true && Turns.p2 == false)
        //{
        //    UI.SetActive(false);
        //    text.text = "Next Turn";
        //    Turns.SwitchTurn();
        //}

        onetime = false;

        //if (Turns.p2 == true && Turns.p1 == false)
        //{
        //    UI.SetActive(false);
        //    text.text = "Next Turn";
        //    Turns.p2 = false;
        //    Turns.p1 = true;
        //    player.StartTurn = true;
        //    Turns.SwitchTurn();
        //    Debug.Log("Player 2 turn end, start turn player 1");
        //}

    }

    #region Sprite Setter
    public void SetTile ()
    {

        switch (tileType)
        {
            case TileType.green:
                TileSprite.material = green;
                break;

            case TileType.blue:
                TileSprite.material = blue;
                break;

            case TileType.dash:
                TileSprite.material = dash;
                break;

            case TileType.vs:
                TileSprite.material = vs;
                break;

            case TileType.spevent:
                TileSprite.material = spe;
                break;

            case TileType.coin:
                TileSprite.material = coin;
                break;

            case TileType.losecoin:
                TileSprite.material = lcoin;
                break;

            case TileType.movement:
                TileSprite.material = move;
                break;
        }

    }
    #endregion

    public void Update()
    {
        player = Turns.CurrentPlayer;
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (player.isMoving == false && player.StartTurn == false)
    //    {
    //        TileAction();
    //    }
    //    else
    //    {
    //        Debug.Log("Player had moves left or has not started turn");
    //    }
    //}

    public void OnTriggerStay(Collider other)
    {
        //Debug.Log("Trigger Registers");
        if (player.isMoving == false && player.StartTurn == false && player.tag == "CurrentPlayer" && !onetime)
        {
            TileAction();
            player.GetComponent<BoxCollider>().enabled = false;
            Debug.Log("Triggered Tile");
        }
        else
        {
            //Debug.Log("Player had moves left or has not started turn");
        }
    }

    //public void Ja()
    //{
    //    player.Coins = (player.Coins + 3);
    //    player.UpdateScore();
    //    Question.SetActive(false);
    //    Turns.SwitchTurn();
    //    onetime = false;
    //}

    //public void Nee()
    //{
    //    player.Coins = (player.Coins + 0);
    //    player.UpdateScore();
    //    Question.SetActive(false);
    //    Turns.SwitchTurn();
    //    onetime = false;
    //}

    //public void JaMaarBlauw()
    //{
    //    player.Coins = (player.Coins + 5);
    //    player.UpdateScore();
    //    Question.SetActive(false);
    //    Turns.SwitchTurn();
    //    onetime = false;
    //}

    public void TileAction()
    {
        Debug.Log("Tile Triggerd");
        //onetime = true;
        switch (tileType)
        {
            case TileType.green:
                DebugUI.SetActive(true);
                text.text = "No event";
                //Debug.Log("green tile");
                break;

            case TileType.blue:
                Question.SetActive(true);
                Quest1.getquestion();
                //Debug.Log("blue tile");
                break;

            case TileType.dash:
                DebugUI.SetActive(true);
                text.text = "Trigger Second Dice Roll";
                //Debug.Log("dash tile");
                break;

            case TileType.vs:
                DebugUI.SetActive(true);
                text.text = "Trigger VS Question";
                //Debug.Log("vs Tile");
                break;

            case TileType.spevent:
                DebugUI.SetActive(true);
                text.text = "Trigger Special Event";
                //Debug.Log("special event tile");
                break;

            case TileType.coin:
                DebugUI.SetActive(true);
                player.Coins = (player.Coins + 3);
                text.text = "Trigger Add Coin Event";
                //Debug.Log("add coin tile");
                break;

            case TileType.losecoin:
                DebugUI.SetActive(true);
                player.Coins = (player.Coins - 3);
                text.text = "Trigger Remove Coin Event";
                //Debug.Log("lose coin tile");
                break;

        }
    }

}
