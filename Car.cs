using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float speed = 1f;
    private Vector3 exit { get; set; }

    public void Create (Vector3 _exit)
    {
        exit = _exit;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, exit, speed * Time.deltaTime);
        if (transform.position == exit)
        {
            Destroy(gameObject);
        }
    }
}
