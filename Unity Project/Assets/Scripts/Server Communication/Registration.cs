using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Registration : MonoBehaviour
{
    /* Variables for the register system are located here
     */
    public InputField nameField;
    public InputField passwordField;
    public TextMeshProUGUI Output;
    public GameObject animator;

    public Button submitButton;

    /* Call this function to initiate the register procces
     */
    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    /*This is the register function. It passes the contents on to the php files and then checks for the return.
     * If the return in 0 or null we accept the user into the system and notify the user that their registration was succesfull.
     * if the server returns any error code we give it back to the game and display the error.
     */
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://192.168.2.47/unity/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            animator.GetComponent<AnimTest>().CheckTag();
            Output.text = "<action=talk>Je staat bij deze in mijn boekje";
        }
        else
        {
            Output.text = "<action=talk>User creation failed. Error #" + www.text;
        }
    }

    /* This function checks if the input fields have content corresponding with the set specifications
     * if it does, we make the submit button interactable
     */
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }

}
