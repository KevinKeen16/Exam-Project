using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteChange : MonoBehaviour
{
    public Stone player;
    public GameObject canvas;
    public Route UpR;
    public Route LeftR;
    public int oldsteps;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //Debug.Log("trigger has been activated");
            oldsteps = (player.steps - 1);
            if(oldsteps == 0)
            {
                oldsteps = 1;
            }
            //oldsteps = player.steps;
            player.steps = 1;
            //Debug.Log("Oldsteps: " + oldsteps);
            //Debug.Log("Current Steps" + player.steps);
            canvas.SetActive(true);
        }
    }

    public void Up()
    {
        player.currentRoute = UpR;
        player.steps = oldsteps;
        canvas.SetActive(false);
        player.ConMove();
    }
    public void Left()
    {
        player.currentRoute = LeftR;
        player.steps = oldsteps;
        canvas.SetActive(false);
        player.ConMove();
    }
}
