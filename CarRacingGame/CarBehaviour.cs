using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarBehaviour : MonoBehaviour
{
    public Text fuelText;
    public Text lowFuelText;
    public AudioSource audioSource;
    float fuelValue = 500;

    // Start is called before the first frame update
    void Start()
    {
        fuelText.text = " Fuel is: " + fuelValue.ToString();
        lowFuelText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (fuelValue < 50)
        {
            lowFuelText.text = " Fuel is low ";
            audioSource.Play();
        }

        if (fuelValue != 0)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, 0, 0.8f);
                fuelValue -= 5;
                fuelText.text = " Fuel is: " + fuelValue.ToString();
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

            Vector3 carpos = transform.position;
            if (carpos.z > 0)
            {
                carpos.z = -90;
                transform.position = carpos;
            }
            if (carpos.z < -95)
            {
                carpos.z = -90;
                transform.position = carpos;
            }
            if(fuelValue <= 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Drum"))
        {
            fuelValue = 500;
            fuelText.text = " Fuel is: " + fuelValue.ToString();
            lowFuelText.text = "";
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.StartsWith("Buildings"))
        {
            fuelValue -= 5;
        }
        Debug.Log("collided");
    }
}
