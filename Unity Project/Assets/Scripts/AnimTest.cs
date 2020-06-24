using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;
using TMPro;

public class AnimTest : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //if (text.text.Contains(@"<action>"))
        //{
        //    Debug.Log("Talk Tag");
        //    //animator.SetBool("Talking", true);
        //    StartCoroutine(Anim());
        //}
        //else
        //{
        //    //Debug.Log("Empty Tag");
        //}
    }

    public void CheckTag()
    {

        if (text.text.Contains(@"<action=talk>"))
        {
            Debug.Log("Talk Tag");
            //animator.SetBool("Talking", true);
            StartCoroutine(AnimTalk());
        }
        else
        {
            //Debug.Log("Empty Tag");
        }

        if (text.text.Contains(@"<action=moveright>"))
        {
            Debug.Log("Talk Tag");
            //animator.SetBool("Talking", true);
            StartCoroutine(AnimRight());
        }
        else
        {
            //Debug.Log("Empty Tag");
        }
    }

    public IEnumerator AnimTalk()
    {
        Debug.Log("Anim Talk Start");
        animator.SetBool("Talking", true);
        animator.SetBool("Idle", false);
        yield return new WaitForSeconds(0.01f);
        animator.SetBool("Talking", false);
        animator.SetBool("Idle", true);
        StopCoroutine(AnimTalk());
    }

    public IEnumerator AnimRight()
    {
        Debug.Log("Anim Right Start");
        animator.SetBool("MoveRight", true);
        animator.SetBool("Idle", false);
        yield return new WaitForSeconds(0.01f);
        animator.SetBool("MoveRight", false);
        animator.SetBool("Idle", true);
        StopCoroutine(AnimRight());
    }
}
