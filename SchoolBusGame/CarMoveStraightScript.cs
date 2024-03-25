using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 0.8f);

        Vector3 carPosition = transform.position;
        if (carPosition.z > 950)
        {
            carPosition.z = -60;
            transform.position = carPosition;
        }
    }
}
