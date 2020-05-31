using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImage : MonoBehaviour
{
    public Sprite[] coverImages;
    // Start is called before the first frame update
    void Start()
    {
        int randomCover = Random.Range(0, 3);
        gameObject.GetComponent<Image>().sprite = coverImages[randomCover];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
