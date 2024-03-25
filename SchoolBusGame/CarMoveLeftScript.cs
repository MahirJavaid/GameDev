using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.8f, 0, 0);

        Vector3 carPosition = transform.position;
        if (carPosition.x < -325)
        {
            carPosition.x = 325;
            transform.position = carPosition;
        }
    }
}
