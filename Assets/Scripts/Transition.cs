/******************************************************************************
Author: Leong Yu Xuan

Name of Class: TestQuestMan

Description of Class: This class teleports the player to the opposite side of the obj it 
                        is assigned to. It moves the player on the Z or X axis depending
                        on the bool.
                        Teleports have hard-coded lock at the moment for gameplay
                        progress reasons
                        

Date Created: 08/07/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    //store's player obj for reference later 
    public GameObject Player;

    //var to store quest man as bools used there would be used to lock transitions
    public GameObject QuestMan;

    //bool to tell obj which direction to teleport player
    public bool teleportOnX;

    //Store UI text component shows interact dialogue
    public Text Dialogue;

    //interact script
    public void Interact()
    {
        //Stop all coroutines upon interact (only text as of now)
        StopAllCoroutines();

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

        //teleports player on x or z axis depending on the bool
        if (teleportOnX)
        {
            //activate teleport if player has started the quest
            if (QuestMan.GetComponent<TestQuestMan>().GrandQuestStart)
            {
                //Teleport left if player is to the right
                if (playerPos.x > telePos.x)
                {
                    Player.transform.position = Left;

                }
                //teleport right if the player is to the left
                else if (playerPos.x < telePos.x)
                {
                    Player.transform.position = Right;

                }
            }//give message regarding why transition is locked
            else
            {
                StartCoroutine(DialogueControl("There's a hole here, but there are boxes in the way."));
            }
            
        }
        else
        {
            if (QuestMan.GetComponent<TestQuestMan>().CompleteQuest1)
            {
                //Teleport left if player is to the right
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
            else
            {
                StartCoroutine(DialogueControl("Such strange ruin. You wouldn't dare enter."));
            }
            

        }


        //Coroutine that controls dialogue display. Variable "a" is the text to display
        IEnumerator DialogueControl(string a)
        {
            for (int i = 0; i < 2; ++i)
            {
                //show assigned dialogue and make it disappear after 5 seconds

                if (i == 0)
                {
                    Dialogue.gameObject.SetActive(true);
                    Dialogue.text = a;

                }
                else if (i == 1)
                {
                    Dialogue.text = "";
                    Dialogue.gameObject.SetActive(false);
                }

                yield return new WaitForSeconds(5f);
            }

        }

    }
}
