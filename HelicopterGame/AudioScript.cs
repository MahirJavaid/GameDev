using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioScript : MonoBehaviour
{
    public GameObject mutebutton;
    public GameObject unmutebutton;

    public static bool muteflag;

    // Start is called before the first frame update
    void Start()
    {
        if (muteflag == true)
        {
            AudioListener.volume = 0;
            mutebutton.SetActive(false);
        }

        if (muteflag == false)
        {
            AudioListener.volume = 1;
            unmutebutton.SetActive(false);
        }
    }

    public void mutegame()
    {
        AudioListener.volume = 0;
        mutebutton.SetActive(false);
        unmutebutton.SetActive(true);
        muteflag = true;
    }
    public void unmutegame()
    {
        if (muteflag == true)
        {
            AudioListener.volume = 1;
            mutebutton.SetActive(true);
            unmutebutton.SetActive(false);
            muteflag = false;
        }
    }

    public void play()
    {
        SceneManager.LoadScene("HeliScene2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
