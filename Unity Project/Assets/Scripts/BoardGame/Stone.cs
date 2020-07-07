using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stone : MonoBehaviour
{
    public Route currentRoute;

    public int routePosition;

    public int steps;
    public int Coins;

    public bool isMoving;
    public bool StartTurn;

    public TextMeshProUGUI dice;
    public TextMeshProUGUI CoinDP;


    private void Start()
    {
        StartTurn = true;
        Coins = 0;
        CoinDP.text = Coins.ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isMoving && StartTurn)
        {
            int total = routePosition + steps;
            steps = Random.Range(1, 7);
            dice.text = ("Dice Roll: " + steps.ToString());
            Debug.Log("Dice rolled: " + steps);
            StartCoroutine(Move());

            //if (routePosition + steps < currentRoute.childNodeList.Count)
            //{
            //    StartCoroutine(Move());

            //}
            //else
            //{
            //    Debug.Log("Rolled number is to high");
            //                    Debug.Log("total is: " + total);
            //    Debug.Log("max spaces is: " + currentRoute.childNodeList.Count);
            //}
        }
    }

    public void UpdateScore()
    {
        CoinDP.text = Coins.ToString();
    }

    public void ConMove()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (steps > 0)
        {
            routePosition++;
            routePosition %= currentRoute.childNodeList.Count;

            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
            while (MoveToNextNode(nextPos))
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.1f);
            steps--;
            //routePosition++;
        }
        StartTurn = false;
        isMoving = false;
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 8f * Time.deltaTime));
    }

}
