using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Registration : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField nameField;
    public InputField passwordField;
    public TextMeshProUGUI Output;
    public GameObject animator;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

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
            Output.text = "<action=talk>User created succesfully";
        }
        else
        {
            Output.text = "<action=talk>User creation failed. Error #" + www.text;
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }

}
