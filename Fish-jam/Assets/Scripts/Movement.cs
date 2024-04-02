using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody2D rb;

    Vector2 vel;


    private float horizontal;
    private float vertical;

    private float z;
    private float speed;

    private bool lookRight;

    private bool lookUp;
    Vector2 notZero;

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


        lookRight = vel.x==0?lookRight:vel.x>0;
        lookUp = vel.y==0?lookUp:vel.y>0;

        Vector3 ls = transform.localScale;

        ls = new Vector3(lookRight?1:-1,ls.y,ls.z);
        
        transform.localScale = ls;


        if(vel.x==0 && vel.y==0){
            z = 0;
        }else if(vel.x==0){
            z = lookUp?Mathf.PI/2:-Mathf.PI/2;
        }else{
            z = Mathf.Atan(vel.y / vel.x);
        }

        transform.eulerAngles = new Vector3(0, 0, z * 180 / Mathf.PI);


    }
}
