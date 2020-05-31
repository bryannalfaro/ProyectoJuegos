using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ActivateSelectionChar : MonoBehaviour
{
    public GameObject[] charactersP1;
    public GameObject[] charactersP2;
    private bool isReady1 = false;
    private bool isReady2 = false;
    public loaderScript loader;

    public void activeCharacter(int position, int player)
    {
        if (player == 1)
        {
            for (int i = 0; i < 6; i++)
                charactersP1[i].SetActive(false);
            charactersP1[position].SetActive(true);
        }
        else
        {
            for (int i = 0; i < 6; i++)
                charactersP2[i].SetActive(false);
            charactersP2[position].SetActive(true);
        }
    }

    public void isReady(bool isReady, int player)
    {
        if (player == 1)
            isReady1 = isReady;
        else
            isReady2 = isReady;
    }

    public void startGame()
    {
        if (isReady1 & isReady2)
        {
            StartCoroutine(stopSongs());
            loader.LoadNextLevel();
        }
    }

    IEnumerator stopSongs()
    {
        yield return new WaitForSeconds(0.75f);
        AudioManager am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        am.Stop("Song1");
        am.Stop("Song2");
    }

}
