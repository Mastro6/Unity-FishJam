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
    Vector2 lsnz;

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

        if(vel.magnitude != 0) lsnz = vel;



        lookRight = lsnz.x==0?lookRight: lsnz.x>0;
        lookUp = lsnz.y==0?lookUp: lsnz.y>0;

        Vector3 ls = transform.localScale;

        ls = new Vector3(lookRight?1:-1,ls.y,ls.z);
        
        transform.localScale = ls;


        if(lsnz.x==0 && lsnz.y==0){
            z = 0;
        }else if(lsnz.x==0){
            z = lookUp?Mathf.PI/2:-Mathf.PI/2;
        }else{
            z = Mathf.Atan(lsnz.y / lsnz.x);
        }

        transform.eulerAngles = new Vector3(0, 0, z * 180 / Mathf.PI);


    }
}
