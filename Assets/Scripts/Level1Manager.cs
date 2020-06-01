using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public GameObject canvasUI;
    private AudioManager audioManager;
    private ChargeCharacter chargeCharacter;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        chargeCharacter = GameObject.Find("SelectedCharacters").GetComponent<ChargeCharacter>();
        audioManager.Play("InGameSound");
        StartCoroutine(activeUI());
    }

    IEnumerator activeUI()
    {
        yield return new WaitForSeconds(0.75f);
        canvasUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
