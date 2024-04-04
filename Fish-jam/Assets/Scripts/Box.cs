using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public float height;
    public float width;

    public Vector2 center;


    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
        height = transform.localScale.y;
        width = transform.localScale.x;
    }


    public Vector2 chooseRandomPointInBox()
    {
        float x = Random.Range(center.x - width/2, center.x + width / 2);
        float y = Random.Range(center.y - height/2, center.y + height / 2);

        return new Vector2(x, y);

        
    }

    
}
