using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    public GameObject[] players;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire2"))
        {
            //Debug.Log("walkwalk: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));

            for(int i = 0; i < players.Length; i++)
            {
                if (players[i].GetComponent<playerScript>().clicked)
                {
                    //Debug.Log(players[i].name + "Move to " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    players[i].GetComponent<playerScript>().move(Camera.main.ScreenToWorldPoint(Input.mousePosition));

                }
            }


        } else if(Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].GetComponent<playerScript>().clicked)
                {
                    //Debug.Log(players[i].name + "Unselected");
                    players[i].GetComponent<SpriteRenderer>().color = Color.white;
                    players[i].GetComponent<playerScript>().clicked = false;
                    //TODO: make scripts name ex "playerScript" loaded into variable for easier name changing in engine
                }
            }
        }
    }
}
