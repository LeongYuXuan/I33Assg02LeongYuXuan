/******************************************************************************
Author: Leong Yu Xuan

Name of Class: FinalDoor

Description of Class: This class controls the status of the final door and the dialogue text upon being interacted with. Door opens if player bool "Open sesame" is true.

Date Created: 10/07/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalDoor : MonoBehaviour
{
    //stores player object to refer to code later 
    public GameObject Player;

    //stores Quest man NPC to refer to code later 
    public GameObject QuestMan;

    //Store UI text component shows interact dialogue
    public Text Dialogue;

    //activates upon game starting
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Playe");
    }
    //interact script
    public void Interact()
    {
        //Stop all coroutines upon interact (only text as of now)
        StopAllCoroutines();
        Function();
    }

    //Coroutine that controls dialogue display
    public void Function()
    {
        if (!Player.transform.GetComponent<SamplePlayer>().OpenSesame || !QuestMan.transform.GetComponent<TestQuestMan>().CompleteQuest2)
        {
            StartCoroutine(DialogueControl("What a strange door"));
        }
        else
        {

            StartCoroutine(DialogueControl("Woah, it disappeared. It's like the coder could not be bothered to animate it, hahaha..."));
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;

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
