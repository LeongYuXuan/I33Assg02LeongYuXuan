/******************************************************************************
Author: Leong Yu Xuan

Name of Class: FinalDoor

Description of Class: This class controls the status of the final door and the dialogue text upon being interacted with. Door opens if player bool "Open sesame" is true.

Date Created: 06/07/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalDoor : MonoBehaviour
{
    //stores player object to refer to code later 
    public GameObject Player;

    //Store UI text component that it would impact
    public Text Dialogue;

    //activates upon game starting
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Playe");
    }
    //interact script
    public void Interact()
    {
        StartCoroutine(DialogueControl());
    }

    //Coroutine that controls dialogue display
    IEnumerator DialogueControl()
    {
        for(int i = 0; i < 2; ++i)
        {
            //dialogue to show if player cannot open final door
            if (!Player.transform.GetComponent<SamplePlayer>().OpenSesame)
            {
                if (i == 0)
                {
                    Dialogue.gameObject.SetActive(true);
                    Dialogue.text = "The door won't budge";

                }
                else if (i == 1)
                {
                    Dialogue.text = "";
                    Dialogue.gameObject.SetActive(false);
                }
            }
            else
            {
                if (i == 0)
                {
                    Dialogue.gameObject.SetActive(true);
                    Dialogue.text = "Woah it's 'Moving'";
                    GetComponent<MeshCollider>().enabled = false;
                    GetComponent<MeshRenderer>().enabled = false;

                }
                else if (i == 1)
                {
                    Dialogue.text = "";
                    Dialogue.gameObject.SetActive(false);
                }

            }
           
            yield return new WaitForSeconds(5f);
        }
 
    }
    
}
