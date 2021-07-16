/******************************************************************************
Author: Leong Yu Xuan

Name of Class: TestCollect

Description of Class: Class for switches, which usually causes something to disappear upon being interacted
                        Only interactable after completing quest 2 and having final key

Date Created: 16/07/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
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
    ///Var to store obj that is to be disappeared
    /// </summary> 
    public GameObject Snapped;

    ///<summary>
    ///Bool that executes some additional code
    /// </summary>
    public bool AltSwitch;

    ///<summary>
    ///additional game object to snap
    ///</summary>
    public GameObject Snapped2;

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
    ///Activate switch if criteria are met
    /// </summary>
    public void Function()
    {
        if (!Player.transform.GetComponent<SamplePlayer>().OpenSesame || !QuestMan.transform.GetComponent<TestQuestMan>().CompleteQuest2)
        {
            StartCoroutine(DialogueControl("A peculiar structure. What is it for?"));
        }
        else
        {
            if(AltSwitch)
            {
                StartCoroutine(DialogueControl("Yikes! The Floor!"));
                Snapped2.SetActive(false);
                GetComponent<MeshCollider>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                StartCoroutine(DialogueControl("You hear distant rumbling, as if something has moved"));
            }
            
            Snapped.SetActive(false);
            
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
