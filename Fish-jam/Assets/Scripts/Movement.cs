using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb;

    public Vector2 vel;


    private float horizontal;
    private float vertical;

    private float z;
    public float speed;

    private bool lookRight;

    private bool lookUp;
    public Vector2 lsnz;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        vel = new Vector2(horizontal * speed, vertical * speed);
        if (vel.magnitude > 10) vel = vel.normalized * 10;

        Vector2 vector2raw = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (vector2raw.magnitude != 0)
        {
            lsnz = vel;
        }
    }

    private void FixedUpdate()
    {
        
        rb.velocity = vel;

        

        lookRight = lsnz.x==0?lookRight: lsnz.x>0;
        lookUp = lsnz.y==0?lookUp: lsnz.y>0;

        Vector3 ls = transform.localScale;

        ls = new Vector3(lookRight?1:-1,ls.y,ls.z);
        
        transform.localScale = ls;


        if(lsnz.x==0){
            z = lookUp?Mathf.PI/2:-Mathf.PI/2;
            z = lookRight?z:-z;
        }else{
            z = Mathf.Atan(lsnz.y / lsnz.x);
        }

        transform.eulerAngles = new Vector3(0, 0, z * 180 / Mathf.PI);


    }
}
