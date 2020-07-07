using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    /* Variables for the login system are located here
     */
    public InputField nameField;
    public InputField passwordField;

    public TextMeshProUGUI Output;
    public Button submitButton;

    /* Call this function to initiate the login procces
     */
    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    /* This function checks if the input fields have content corresponding with the set specifications
     * if it does, we make the submit button interactable
     */
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }

    /*This is the login function. It passes the contents on to the php files and then checks for the return.
     * If the return in 0 or null we accept the users login details and notify the user that their login attempt was succesfull.
     * On a succesfull login we tell the gamemanager that someone is logged in and store the username for future reference
     * if the server returns any error code we give it back to the game and display the error.
     */
    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://192.168.2.47/unity/login.php", form);
        yield return www;
        if(www.text[0] == '0')
        {
            GameManager.instance.LoggedIn = true;
            GameManager.instance.Username = nameField.text;
            Output.text = "<action=talk>Welkom terug " + GameManager.instance.Username  + " goed om je weer te zien";
            Debug.Log("User logged in");
        }
        else
        {
            Debug.Log("User login failed. Error#" + www.text);
        }
    }
}
