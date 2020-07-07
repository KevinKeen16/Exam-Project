using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using TMPro;

public class AnimTest : MonoBehaviour
{
    /* Variables storage
     */
    public Animator animator;
    public TextMeshProUGUI text;

    public GameObject Pic;


    /* Check for tags in the text of the text variable.
     * If the tags contains "<action=name>" it runs the correct coroutine
     */
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

        if (text.text.Contains(@"<action=movepictureF>"))
        {
            Debug.Log("Picture tag");
            //animator.SetBool("Talking", true);
            Pic.SetActive(true);
        }
        else
        {
            //Debug.Log("Empty Tag");
        }

        if (text.text.Contains(@"<action=movepictureD>"))
        {
            Debug.Log("Picture tag");
            //animator.SetBool("Talking", true);
            Pic.SetActive(false);
        }
        else
        {
            //Debug.Log("Empty Tag");
        }

        if (text.text.Contains(@"<action=normal>"))
        {
            Debug.Log("Talk Tag");
            //animator.SetBool("Talking", true);
            StartCoroutine(Normal());
        }
        else
        {
            //Debug.Log("Empty Tag");
        }
    }

    /* sets the needed variables for the correct animation state
     * waits and return it to default
     */
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

    /* sets the needed variables for the correct animation state
     * waits and return it to default
     */
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

    public IEnumerator Normal()
    {
        Debug.Log("Anim Right Start");
        animator.SetBool("Normal", true);
        animator.SetBool("Idle", false);
        yield return new WaitForSeconds(0.01f);
        animator.SetBool("Normal", false);
        animator.SetBool("Idle", true);
        StopCoroutine(AnimRight());
    }

}
