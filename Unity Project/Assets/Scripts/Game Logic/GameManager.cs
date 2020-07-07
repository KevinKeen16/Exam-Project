using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/* This is the game manager
 * it keeps track of most of the variables needed for most universal systems
 */

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;

    /* All the login system variables are located here.
     * This also checks if a users is logged in or not.
     */
    public string Username;
    public bool LoggedIn;

    /* On awake of this script it instanciates the game manager
     * and loads the main menu of the game with a persistent scene behind it.
     * This scene contains the game manager and loading screen.
     */
    private void Awake()
    {
        instance = this;

        SceneManager.LoadSceneAsync((int)SceneIndexes.TITLE_SCREEN, LoadSceneMode.Additive);
    }

    /*This is a list for async operations
     */
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    /* When the load game is called it sets de loading screen to active and 
     * adds the needed scenes to the operations list.
     * After that is starts the coroutine for checking how far along the loading procces the game is
     */
    public void LoadGame()
    {
        loadingScreen.gameObject.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.TITLE_SCREEN));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEARNING, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());
    }

    /* This is the checker to see how far along the loading procces is.
     * Once this procces is done we set the loading screen to non active and show the in game scene
     */
    public IEnumerator GetSceneLoadProgress()
    {
        for(int i=0; i<scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;

            }
        }

        loadingScreen.gameObject.SetActive(false);
    }
}
