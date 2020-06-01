using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float time = 2f; //Seconds to read the text
    private GameObject readyText;
    private TextMeshProUGUI text;
    public GameObject ball;
    private Rigidbody rbBall;
    public AudioSource managerAudio;
    public AudioSource managerAudio2;
    public AudioClip ready;
    public AudioClip go;

    public GameObject startImage;


    void Start()
    {
        Time.timeScale = 0.0f;
        readyText = GameObject.FindWithTag("Text");
        text = readyText.GetComponent<TextMeshProUGUI>();
        rbBall = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1.0f;
            startImage.SetActive(false);
            managerAudio.PlayOneShot(ready);
            Invoke("ChangeText", time);
        }
    }

    void ChangeText()
    {
        text.text = "GO!";
        rbBall.useGravity = true;
        managerAudio2.PlayOneShot(go);
        Destroy(gameObject, time);
    }
}
