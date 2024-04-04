using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : MonoBehaviour
{
    public float timer;

    public Vector2 swimDurationRange;
    public float swimDuration;

    public Vector3 swimDirection;
   
    public float swimSpeed = 2.0f;
    public float speedRotation;

    public bool isRotating;

    private Rigidbody2D rb;

    public Box box;

    public float fdsaixedDeltaTime;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        box = GameObject.FindGameObjectWithTag("Box").GetComponent<Box>();

        PickNewDirection();

    }


    private void FixedUpdate()
    {

        timer += Time.fixedDeltaTime;

        if (timer >= swimDuration)
        {
            PickNewDirection();
            timer = 0f;
        }

        if (isRotating)
        {
            RotateTowardsDirection(swimDirection);

        } else
        {
            rb.MovePosition(transform.position + swimDirection * swimSpeed * Time.fixedDeltaTime);
        }

        fdsaixedDeltaTime = Time.fixedDeltaTime;

    }

    void PickNewDirection()
    {
        
        //pick random direction, maybe better a vector that points toward inside the map
        float randomAngle = Random.Range(0, 360);
        //swimDirection = new Vector3(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad), 0);

        Vector2 randomPointInBox = box.chooseRandomPointInBox();

        Vector3 jellyFishPosition = transform.position;

        swimDirection = (Vector3)randomPointInBox - jellyFishPosition;
        swimDirection = swimDirection.normalized;

        timer = 0f;
        swimDuration = Random.Range(swimDurationRange.x, swimDurationRange.y);

        isRotating = true;
    }


    void RotateTowardsDirection(Vector3 targetDirection)
    {
        
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, targetDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, speedRotation * Time.fixedDeltaTime);

        if (Quaternion.Angle(transform.rotation, toRotation) < 1.0f)
        {
            isRotating = false;
        }
        
    }
}
