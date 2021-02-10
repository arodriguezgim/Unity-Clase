using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Has pulsado PLAY BUTTON");
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.R)){
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            this.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            this.GetComponent<SpriteRenderer>().color = Color.cyan;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
