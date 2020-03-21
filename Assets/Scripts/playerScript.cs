using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    Transform transformers;

    public bool clicked;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transformers = GetComponent<Transform>();
        clicked = false;

        //Debug.Log("Started: " + this.name);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseUp()
    {
       if(clicked)
        {
            return;
        }
        //Debug.Log("Selected: " + this.name);

        spriteRenderer.color = Color.blue;

        clicked = true;
            
    }


    Vector2 toDiagCoord(Vector2 vector)
    {
        float a = vector.x;
        float b = vector.y;

        // rotated coord sys has x-axis = 1/2 x and y-axis = -1/2 x

        float diagXcoord = Mathf.Sqrt(Mathf.Pow((0.5f * a + b), 2) + Mathf.Pow((0.25f * (a + 2 * b)), 2));   // fully converted x coordinate according to rotated coord sys
        float diagYcoord = Mathf.Sqrt(Mathf.Pow((0.5f * a - b), 2) + Mathf.Pow((0.25f * (-a + 2 * b)), 2));  // fully converted y coordinate according to rotated coord sys

        return new Vector2(diagXcoord%1, diagYcoord%1);
    }

    Vector2 toXyCoord(Vector2 vector)
    {
        vector = toDiagCoord(vector);

        float x = vector.y * -1;
        float y = vector.x;

        return new Vector2(x, y);
    }

    public void move(Vector2 tilePos)
    {

        tilePos = toDiagCoord(tilePos);                         // translate to diagonal coordinates
        Vector2 playerPos = toDiagCoord(transformers.position); // translate player pos to diagonal coordinates

        //Vector2 distanceVector = tilePos - playerPos;

        //Debug.Log(tilePos);


        // TODO: change other way around! think 45 deg sys and convert to classic xy
        //tilePos = new Vector2(diagXcoord%1 + 0.5f, diagYcoord%1 + 0.5f);

        transformers.position = toXyCoord(tilePos);
    }
}
