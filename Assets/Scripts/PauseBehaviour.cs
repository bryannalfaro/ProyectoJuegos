using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBehaviour: MonoBehaviour


{
    public GameObject pauseMenu;
    private bool isPaused = false;
    public GameObject obstacles;

    // Start is called before the first frame update
    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            TogglePause();
        }
    }

    public void TogglePause()
    {

        pauseMenu.SetActive(!isPaused);
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0.0f : 1.0f;

    }


    public void BackMenu()
    {
        Time.timeScale = 1f;
        AudioManager am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        am.Stop("InGameSound");
        am.playRandomToMainMenu();
        SceneManager.LoadScene("MainMenu");
    }

    public void enableObstacles(bool state)
    {
        obstacles.SetActive(state);
    }


}
