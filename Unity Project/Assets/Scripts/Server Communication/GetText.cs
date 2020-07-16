using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class GetText : MonoBehaviour {
    /* Variables storage
     */

    public GameObject gui;
    public TextMeshProUGUI textbox;
    public string URL;

    //Yes no buttons
    public GameObject b1;
    public GameObject b2;
    public TextMeshProUGUI bu1;
    public TextMeshProUGUI bu2;
    public bool answer;

    //Multiple Choice Data
    public GameObject mb1;
    public GameObject mb2;
    public GameObject mb3;
    public GameObject mb4;
    public TextMeshProUGUI mbu1;
    public TextMeshProUGUI mbu2;
    public TextMeshProUGUI mbu3;
    public TextMeshProUGUI mbu4;
    public int manswer;


    //Game data
    public int QuestionNumber;
    public string[] Question;

    public TurnCounter ActivePlayer;


    /* Starts coroutine
     */
    public void getquestion()
    {
        StartCoroutine(getText());
    }

    /* Sends a webrequest to a url specified in the url variable.
     * Once the request is complete it takes the text from the text file and prints it
     * into the textbox specified in the textbox variable
     */
    IEnumerator getText()
{
        QuestionNumber = Random.Range(1, 5);
        Debug.Log(QuestionNumber);
        Debug.Log("Reroll question Number");

        switch (QuestionNumber)
        {
            case 1:
                URL = "http://192.168.2.47/unity/Questions/Q1.php";
                break;
            case 2:
                URL = "http://192.168.2.47/unity/Questions/Q2.php";
                break;
            case 3:
                URL = "http://192.168.2.47/unity/Questions/Q3.php";
                break;
            case 4:
                URL = "http://192.168.2.47/unity/Questions/Q4.php";
                break;
            case 5:
                URL = "http://192.168.2.47/unity/Questions/Q5.php";
                break;
            case 6:
                URL = "http://192.168.2.47/unity/Questions/Q6.php";
                break;
            case 7:
                URL = "http://192.168.2.47/unity/Questions/Q7.php";
                break;
            case 8:
                URL = "http://192.168.2.47/unity/Questions/Q8.php";
                break;
            case 9:
                URL = "http://192.168.2.47/unity/Questions/Q9.php";
                break;
            case 10:
                URL = "http://192.168.2.47/unity/Questions/Q10.php";
                break;
        }

        WWW request = new WWW(URL);
        yield return request;
        string[] webResults = request.text.Split('\t');

        if (webResults[0] == "yn")
        {
            Debug.Log("Yes No Question");
            //Set buttons and activate them
            bu1.text = webResults[3];
            bu2.text = webResults[4];
            b1.SetActive(true);
            b2.SetActive(true);
            textbox.text = webResults[1];
            Debug.Log(webResults[1]);
            //Sets the anwser key
            if (webResults[2] == "yes")
            {
                answer = true;
            }
            else
            {
                answer = false;
            }
        }
        if (webResults[0] == "mpc")
        {
            Debug.Log("Multiple Choice Question");
            textbox.text = webResults[1];
            Debug.Log(webResults[1]);
            mbu1.text = webResults[3];
            mbu2.text = webResults[4];
            mbu3.text = webResults[5];
            mbu4.text = webResults[6];
            mb1.SetActive(true);
            mb2.SetActive(true);
            mb3.SetActive(true);
            mb4.SetActive(true);
            if (webResults[2] == "1")
            {
                manswer = 1;
            }
            else if (webResults[2] == "2")
            {
                manswer = 2;
            }
            else if (webResults[2] == "3")
            {
                manswer = 3;
            }
            else if (webResults[2] == "4")
            {
                manswer = 4;
            }

        }
        //else
        //{
        //    Debug.Log("Failure");
        //}

        yield break;
        }

    //Button actions for yes no questions
    public void yes()
    {
        if(answer == true)
        {
            ActivePlayer.CurrentPlayer.Coins = ActivePlayer.CurrentPlayer.Coins + 3;
            ActivePlayer.CurrentPlayer.UpdateScore();
            ActivePlayer.SwitchTurn();
            uiedit();
        }
        else
        {
            ActivePlayer.CurrentPlayer.Coins = ActivePlayer.CurrentPlayer.Coins + 0;
            ActivePlayer.CurrentPlayer.UpdateScore();
            ActivePlayer.SwitchTurn();
            uiedit();
        }
    }

    public void no()
    {
        if(answer == false)
        {
            ActivePlayer.CurrentPlayer.Coins = ActivePlayer.CurrentPlayer.Coins + 3;
            ActivePlayer.CurrentPlayer.UpdateScore();
            ActivePlayer.SwitchTurn();
            uiedit();
        }
        else
        {
            ActivePlayer.CurrentPlayer.Coins = ActivePlayer.CurrentPlayer.Coins + 0;
            ActivePlayer.CurrentPlayer.UpdateScore();
            ActivePlayer.SwitchTurn();
            uiedit();
        }
    }

    public void one()
    {
        if (manswer == 1)
        {
            ActivePlayer.CurrentPlayer.Coins = ActivePlayer.CurrentPlayer.Coins + 3;
            ActivePlayer.CurrentPlayer.UpdateScore();
            ActivePlayer.SwitchTurn();
            uiedit();
        }
        else
        {
            ActivePlayer.CurrentPlayer.Coins = ActivePlayer.CurrentPlayer.Coins + 0;
            ActivePlayer.CurrentPlayer.UpdateScore();
            ActivePlayer.SwitchTurn();
            uiedit();
        }
    }
    public void two()
    {
        if (manswer == 2)
        {
            ActivePlayer.CurrentPlayer.Coins = ActivePlayer.CurrentPlayer.Coins + 3;
            ActivePlayer.CurrentPlayer.UpdateScore();
            ActivePlayer.SwitchTurn();
            uiedit();
        }
        else
        {
            ActivePlayer.CurrentPlayer.Coins = ActivePlayer.CurrentPlayer.Coins + 0;
            ActivePlayer.CurrentPlayer.UpdateScore();
            ActivePlayer.SwitchTurn();
            uiedit();
        }
    }
    public void three()
    {
        if (manswer == 3)
        {
            ActivePlayer.CurrentPlayer.Coins = ActivePlayer.CurrentPlayer.Coins + 3;
            ActivePlayer.CurrentPlayer.UpdateScore();
            ActivePlayer.SwitchTurn();
            uiedit();
        }
        else
        {
            ActivePlayer.CurrentPlayer.Coins = ActivePlayer.CurrentPlayer.Coins + 0;
            ActivePlayer.CurrentPlayer.UpdateScore();
            ActivePlayer.SwitchTurn();
            uiedit();
        }
    }
    public void four()
    {
        if (manswer == 4)
        {
            ActivePlayer.CurrentPlayer.Coins = ActivePlayer.CurrentPlayer.Coins + 3;
            ActivePlayer.CurrentPlayer.UpdateScore();
            ActivePlayer.SwitchTurn();
            uiedit();
        }
        else
        {
            ActivePlayer.CurrentPlayer.Coins = ActivePlayer.CurrentPlayer.Coins + 0;
            ActivePlayer.CurrentPlayer.UpdateScore();
            ActivePlayer.SwitchTurn();
            uiedit();
        }
    }

    public void uiedit()
    {
        b1.SetActive(false);
        b2.SetActive(false);
        gui.SetActive(false);
        mb1.SetActive(false);
        mb2.SetActive(false);
        mb3.SetActive(false);
        mb4.SetActive(false);
    }


}

