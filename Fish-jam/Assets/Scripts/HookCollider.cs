using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCollider : MonoBehaviour
{
    [SerializeField]
    private HookEnemy parentScript;
    


    // Start is called before the first frame update
    void Start()
    {
        parentScript = GetComponentInParent<HookEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("trigger");
        print(other.name + " has collided with " + transform.parent.name);
    }
}
