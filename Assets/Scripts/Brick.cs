using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public float movespeed = 1f;
    public float deadZone = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

 
    void Update()
    {
        transform.position = transform.position + Vector3.left * movespeed * Time.deltaTime;
        if (transform.position.x < -deadZone)
        {
            Debug.Log("destroyPipe");
            Destroy(this.gameObject);
        }
    }
}
