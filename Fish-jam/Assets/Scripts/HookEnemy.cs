using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookEnemy : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D hookCollider;

    public Vector3 hookPoint;
    public float frequency;
    public float amplitude;

    // Start is called before the first frame update
    void Start()
    {
        print("hook spawned");
        hookCollider = GetComponentInChildren<CircleCollider2D>();

        hookPoint = transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        float bobbingY = Mathf.Sin(Time.time * frequency) * amplitude + hookPoint.y;
        transform.position = new Vector3(hookPoint.x, bobbingY, hookPoint.z);
    }
}
