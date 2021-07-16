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
    ///<summary>
    ///Var to store player obj to check bool from
    /// </summary> 
    public GameObject Player;

    ///<summary>
    ///Var to store QuestMan obj to check bool from
    /// </summary> 
    public GameObject QuestMan;

    ///<summary>
    ///Stores text that shows Dialogue
    /// </summary>
    public Text Dialogue;

    //activates upon game starting
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Playe");
    }
    ///<summary>
    ///Functions to execute upon interact
    /// </summary>
    public void Interact()
    {
        //Stop all coroutines upon interact (only text as of now)
        StopAllCoroutines();
        Function();
    }

    ///<summary>
    ///Set mesh collision and renderer inactive if critera are met
    /// </summary>
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
    ///<summary>
    ///Coroutine for dialogue control. "a" is the string to display
    /// </summary>
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
