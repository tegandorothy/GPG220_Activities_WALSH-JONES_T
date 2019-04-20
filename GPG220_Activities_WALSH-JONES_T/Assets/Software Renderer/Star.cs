using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star
{
    public Vector3 position;
    
    void Start()
    {
        
    }

    void Update()
    {
        position.x += 1 * Time.deltaTime;
        position.y += 1 * Time.deltaTime;
        position.z += 1 * Time.deltaTime;
    }
}
