using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Box : MonoBehaviour
{

    public float height;
    public float width;

    public Vector2 center;

    public float closenessUnit;


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
    public Vector2 chooseRandomPointInCenterBox()
    {
        float x = Random.Range(center.x - width / 2 + 2 * closenessUnit, center.x + width / 2 - 2 * closenessUnit);
        float y = Random.Range(center.y - height / 2 + 2 * closenessUnit, center.y + height / 2 - 2 * closenessUnit);

        return new Vector2(x, y);

    }

    public bool isPointInsideBox(Vector2 vec2)
    {
        float minX = center.x - width / 2;
        float maxX = center.x + width / 2;
        float minY = center.y - height / 2;
        float maxY = center.y + height / 2;

        return Mathf.Clamp(vec2.x, minX, maxX) == vec2.x && Mathf.Clamp(vec2.y, minY, maxY) == vec2.y;
    }

    public bool isPointFarFromEdges(Vector2 vec2)
    {
        float minX = center.x - width / 2 + closenessUnit;
        float maxX = center.x + width / 2 - closenessUnit;
        float minY = center.y - height / 2 + closenessUnit;
        float maxY = center.y + height / 2 - closenessUnit;

        return Mathf.Clamp(vec2.x, minX, maxX) == vec2.x && Mathf.Clamp(vec2.y, minY, maxY) == vec2.y;
    }




}
