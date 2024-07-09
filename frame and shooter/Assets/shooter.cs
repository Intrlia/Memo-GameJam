using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody2D _rigid;
    [SerializeField]public float speed = 3;
    public float fireRate = 0.1f;
    private float nextFire = 0.0f;

      


    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
     
        float y = Input.GetAxis("Vertical");
        _rigid.velocity = new Vector2(0, y*speed);
        if (Time.time>nextFire)
        {
            
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet,transform.position, transform.rotation);
                nextFire = Time.time + fireRate;
            }
            
        }

        
    }
}

