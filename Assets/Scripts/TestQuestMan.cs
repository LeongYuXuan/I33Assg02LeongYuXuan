/******************************************************************************
Author: Leong Yu Xuan

Name of Class: TestQuestMan

Description of Class: This class gives an output depending on 
                        how many collectables DemoPlayer has collected. 
                        Quest complete when 3 TestCollects have been gathered.

Date Created: 06/07/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestQuestMan : MonoBehaviour
{
    //for testing 
    public GameObject Player;

    //Stores UI Text that displays number of quest items collected
    public Text Count;

    //Store UI text component shows interact dialogue
    public Text Dialogue;

    //bool to prevent repeated interactions and trigger quest2
    [HideInInspector]
    public bool CompleteQuest1 = false;
    //bool to prevent repeated interactions and trigger quest2
    [HideInInspector]
    public bool CompleteQuest2 = false;
    //bool to start quest
    [HideInInspector]
    public bool GrandQuestStart = false;

    //interact script
    public void Interact()
    {
        //Stop all coroutines upon interact (only text as of now)
        StopAllCoroutines();
        Quest();
    }

    private void Quest()
    {
        //Only Start quest code if player actually talks to the guy first
        if (GrandQuestStart)
        {
            //execute quest 1 code if player has not complete it
            if (!CompleteQuest1)
            {

                if (Player.GetComponent<SamplePlayer>().testCollect < 3)
                {
                    StartCoroutine(DialogueControl("Interact with me once you collect 3 circles"));
                }

                else if (Player.GetComponent<SamplePlayer>().testCollect >= 3 && !CompleteQuest1)
                {
                    CompleteQuest1 = true;
                    //reset values for the next quest
                    Player.GetComponent<SamplePlayer>().testCollect = 0;
                    Count.text = "Things Collected: " + "0";
                    StartCoroutine(DialogueControl("Hehe, nice. \n Here is your 2nd quest: Collect 5 cones"));
                }
            }
            //execute quest 2 code if quest 1 is complete and quest 2 isn't
            else if (!CompleteQuest2)
            {
                //repeat dialog if player has not met criteria
                if (Player.GetComponent<SamplePlayer>().testCollect < 5)
                {
                    StartCoroutine(DialogueControl("Interact with me again once you collect 5 cones"));
                }
                //do things once reaching criteria
                if (Player.GetComponent<SamplePlayer>().testCollect >= 5 && !CompleteQuest2)
                {
                    StartCoroutine(DialogueControl("Two Parter Complete!"));
                    //resets value or something.
                    Player.GetComponent<SamplePlayer>().testCollect = 0;
                    Count.text = "Things Collected: " + "0";
                    Count.gameObject.SetActive(false);
                    CompleteQuest2 = true;
                }
            }
            else
            {
                StartCoroutine(DialogueControl("Very Nice"));
            }
        }

        //reveal the quest count dialoge upon first interact
        if (!GrandQuestStart)
        {
            GrandQuestStart = true;
            Count.gameObject.SetActive(true);
            Count.text = "Things Collected: " + "0";
            StartCoroutine(DialogueControl("Hey there! Welcome to test... place. You just got your first quest; collect 3 circles."));
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
