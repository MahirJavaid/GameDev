using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliScript : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource audio1;
    public AudioSource audio2;
    
    // Start is called before the first frame update
    void Start()
    {
        audio2.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, 0.8f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0.8f, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -0.8f, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -0.8f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0.8f, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -0.8f, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(bullet, transform.position, transform.rotation);
            audio1.Play();
        }
    }
}
