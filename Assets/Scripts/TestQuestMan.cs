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
                    StartCoroutine(DialogueControl("Remember, I need 3 batteries", false, "b"));
                }

                else if (Player.GetComponent<SamplePlayer>().testCollect >= 3 && !CompleteQuest1)
                {
                    CompleteQuest1 = true;
                    //reset values for the next quest
                    Player.GetComponent<SamplePlayer>().testCollect = 0;
                    Count.text = "Things Collected: " + "0";
                    StartCoroutine(DialogueControl("Thank you for those, I really needed the heat. \n" +
                        "You may have seen the ruins outside. We suspect there could be some artefacts in there. Could you get 6 of such?", true, 
                        "Here, I gave you a spare heat lamp. Don't ask why I bought two but only had one battery..."));
                }
            }
            //execute quest 2 code if quest 1 is complete and quest 2 isn't
            else if (!CompleteQuest2)
            {
                //repeat dialog if player has not met criteria
                if (Player.GetComponent<SamplePlayer>().testCollect < 6)
                {
                    StartCoroutine(DialogueControl("We would like 6 artefacts to observe after we are done setting up...", false, "b"));
                }
                //do things once reaching criteria
                if (Player.GetComponent<SamplePlayer>().testCollect >= 6 && !CompleteQuest2)
                {
                    StartCoroutine(DialogueControl("Wow, did't expect you to actually come back with 6. That's superb on your part.", true, "A key? I think this door had a keyhole, you could try it on that."));
                    //resets value or something.
                    Player.GetComponent<SamplePlayer>().testCollect = 0;
                    Count.text = "Things Collected: " + "0";
                    Count.gameObject.SetActive(false);
                    CompleteQuest2 = true;
                }
            }
            else
            {
                StartCoroutine(DialogueControl("Try it on the door, I have your back", false, "b"));
            }
        }

        //reveal the quest count dialoge upon first interact
        if (!GrandQuestStart)
        {
            GrandQuestStart = true;
            Count.gameObject.SetActive(true);
            Count.text = "Things Collected: " + "0";
            StartCoroutine(DialogueControl("Hey, you're a little late. Everyone but me went to collect tools. Can you believe they forgot to get the crowbar?", 
                true, "I'm trying to find a non-destructive way to open this door, but it is getting cold. Could you find three batteries? \n" +
                "There should be some outside, I only have one on me..."));
           
        }
    }

    //Coroutine that controls dialogue display. Variable "a" is the text to display
    IEnumerator DialogueControl(string a, bool Talk2, string b)
    {
        for (int i = 0; i < 2; ++i)
        {
            //show assigned dialogue and make it disappear after 7 seconds
            if (i == 0)
            {
                Dialogue.gameObject.SetActive(true);
                Dialogue.text = a;

            }
            else if (i == 1)
            {
                Dialogue.text = "";
                Dialogue.gameObject.SetActive(false);
                if (Talk2)
                {
                    StartCoroutine(AltDialogueControl(b));
                }
            }


            yield return new WaitForSeconds(7f);
        }

    }
    //For twoparter dialogue. Test function
    IEnumerator AltDialogueControl(string a)
    {
        for (int i = 0; i < 2; ++i)
        {
            //show assigned dialogue and make it disappear after 7 seconds

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

            yield return new WaitForSeconds(7f);
        }

    }
}
