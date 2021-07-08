using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    //for testing 
    public GameObject Player;

    //bool to tell obj which direction to teleport player
    public bool teleportOnX;

    //activates upon game starting
    private void Start()
    {
        
    }
    //interact script
    public void Interact()
    {
        //Update player position via updating player obj
        Player = GameObject.FindGameObjectWithTag("Playe");
        //var to store player pos for easier management
        Vector3 playerPos = Player.transform.position;
        //var to store teleport pos 
        Vector3 telePos = transform.position;

        //left teleport coord
        Vector3 Left = transform.position - (transform.right * 2);
        //Right teleport coord
        Vector3 Right = transform.position - (-transform.right * 2);

        //check if player is behind or infront of the obj for teleport
        //Teleport left if player is to the right
        if (teleportOnX)
        {
            if (playerPos.x > telePos.x)
            {
                Player.transform.position = Left;
                
            }
            //teleport right if the player is to the left
            else if (playerPos.x < telePos.x)
            {
                Player.transform.position = Right;
                
            }
        }
        else
        {
            if (playerPos.z > telePos.z)
            {
                Player.transform.position = Left;
                
            }
            //teleport right if the player is to the left
            else if (playerPos.z < telePos.z)
            {
                Player.transform.position = Right;
                
            }

        }
       

        //teleport script
        //Player.transform.position = transform.position - (transform.right * 2);
        
    }
}
