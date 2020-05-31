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
    void Start()
    {
        readyText = GameObject.FindWithTag("Text");
        text = readyText.GetComponent<TextMeshProUGUI>();
        rbBall = ball.GetComponent<Rigidbody>();
        Invoke("ChangeText", time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeText()
    {
        text.text = "GO!";
        rbBall.useGravity = true;
        Destroy(gameObject, time);
    }
}
