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
        float x = vector.x;
        float y = vector.y;

        float diagX = y - (0.5f * x);   // x point on classic x axis according to isometric coord sys
        float diagY = (0.5f * x) - y;   // x point on classic y axis according to isometric coord sys

        float diagXcoord = Mathf.Sqrt(Mathf.Pow(diagX, 2) + Mathf.Pow(0.5f * diagX, 2));   // fully converted x coordinate according to 45 degree rotated coord sys
        float diagYcoord = Mathf.Sqrt(Mathf.Pow(diagY, 2) + Mathf.Pow(-0.5f * diagY, 2));  // fully converted y coordinate according to 45 degree rotated coord sys

        return new Vector2(diagXcoord, diagYcoord);
    }

    public void move(Vector2 tilePos)
    {

        tilePos = toDiagCoord(tilePos);                         // translate to diagonal coordinates
        Vector2 playerPos = toDiagCoord(transformers.position); // translate player pos to diagonal coordinates

        Vector2 distanceVector = tilePos - playerPos;

        Debug.Log(distanceVector);


        // TODO: change other way around! think 45 deg sys and convert to classic xy
        //tilePos = new Vector2(diagXcoord%1 + 0.5f, diagYcoord%1 + 0.5f);

        //transformers.position = tilePos;
    }
}
