using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject helicopter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 0.8f);
        transform.LookAt(helicopter.transform);
    }
}
