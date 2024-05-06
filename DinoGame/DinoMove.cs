using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DinoMove : MonoBehaviour
{
    Animator anim;
    public CharacterController2D controller;
    float leftHorizontalMove = -30f;
    float rightHorizontalMove = 30f;
    bool jump = false;
    bool crouch = false;
    public Text ScoreText;
    public Text HealthText;
    public float score = 0;
    public float health = 100;
    public GameObject Cloud;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        HealthText.text = "Health: " + health.ToString();
        ScoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector2.up * 6 * Time.fixedDeltaTime);
        }
        
        if (transform.position.y < -5)
        {
            anim.SetTrigger("dead");
            StartCoroutine(LoadGameOverSceneAfterDelay());
        }
    }

    private IEnumerator LoadGameOverSceneAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameOverScene");
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            controller.Move(rightHorizontalMove * Time.fixedDeltaTime, crouch, jump);
            anim.SetTrigger("walk");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            controller.Move(leftHorizontalMove * Time.fixedDeltaTime, crouch, jump);
            anim.SetTrigger("walk");
        }
        else
        {
            anim.SetTrigger("idle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Cloud"))
        {
            transform.gameObject.transform.parent = Cloud.transform;
        }
        
        if (!collision.gameObject.name.StartsWith("Cloud"))
        {
            transform.gameObject.transform.parent = null;
        }

        if (collision.gameObject.name.StartsWith("Coin"))
        {
            score += 10;
            ScoreText.text = "Score: " + score.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name.StartsWith("Apple"))
        {
            if(health < 100)
            {
                health += 10;
                HealthText.text = "Health: " + health.ToString();
                healthBar.value = health;
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name.StartsWith("Saw"))
        {
            health -= 20;
            healthBar.value = health;
            HealthText.text = "Health: " + health.ToString();
            if (health <= 0)
            {
                anim.SetTrigger("dead");
                StartCoroutine(LoadGameOverSceneAfterDelay());
            }
        }

        if (score >= 100)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
