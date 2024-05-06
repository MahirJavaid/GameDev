using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject fpsCam;
    public float range = 500;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shoot();
            anim.SetTrigger("gunmove");
        }
        else
        {
            anim.SetTrigger("idle");
        }
    }

    public void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "enemy")
            {
                EnemyScript enemy = hit.transform.GetComponent<EnemyScript>();
                enemy.die();
            }
        }
    }
}
