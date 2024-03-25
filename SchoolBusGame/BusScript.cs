using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BusScript : MonoBehaviour
{
    public GameObject children;
    public AudioSource audioSource;
    public AudioSource audio2;
    public Text busText;
    public Text countText;
    float busHealth = 50;
    float count = 0;

    // Start is called before the first frame update
    void Start()
    {
        busText.text = "Bus Health: " + busHealth.ToString();
        countText.text = "Students: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        busText.text = "Bus Health: " + busHealth.ToString();
        countText.text = "Students: " + count.ToString();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(-1.2f, 0, 0);
            audioSource.Play();
            audioSource.UnPause();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 1.0f, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -1.0f, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(1.2f, 0, 0);
        }

        if (Input.GetKey(KeyCode.H))
        {
            audio2.Play();
        }

        Vector3 busPosition = transform.position;
        if (busPosition.z > 950)
        {
            busPosition.z = -60;
            transform.position = busPosition;
        }
        if (busPosition.z < -65)
        {
            busPosition.z = -60;
            transform.position = busPosition;
        }
        if (busPosition.x < -325)
        {
            busPosition.x = 325;
            transform.position = busPosition;
        }
        if (busPosition.x > 325)
        {
            busPosition.x = -325;
            transform.position = busPosition;
        }

        if (busHealth <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Car"))
        {
            busHealth -= 10;
        }
        if (collision.gameObject.name.StartsWith("Building"))
        {
            busHealth -= 5;
        }
        if (collision.gameObject.name.StartsWith("Bus"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                count += 5;
                Destroy(children.gameObject);
            }
        }
    }
}
