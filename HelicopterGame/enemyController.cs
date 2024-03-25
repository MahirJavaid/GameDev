using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 9; i++)
        {
            Vector3 enemypos = new Vector3(Random.Range(100, 2000), Random.Range(10, 200), Random.Range(100, 1500));
            Instantiate(enemy, enemypos, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
