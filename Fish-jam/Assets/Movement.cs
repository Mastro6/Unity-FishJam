using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody2D rb;

    Vector2 vel;


    private float horizontal;
    private float vertical;

    private float speed;

    private bool lookright;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        vel = new Vector2(horizontal * speed, vertical * speed);
        rb.velocity = vel;
        float z = Mathf.Acos(vel.y / vel.x);

        print(z);


        transform.eulerAngles = new Vector3(0, 0, z * 180 / Mathf.PI);



    }
}
