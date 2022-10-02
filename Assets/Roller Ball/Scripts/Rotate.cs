using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
