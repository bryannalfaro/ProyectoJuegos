using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loaderScript : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 0.75f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    //Coroutine
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
