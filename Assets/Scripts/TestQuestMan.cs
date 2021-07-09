/******************************************************************************
Author: Leong Yu Xuan

Name of Class: TestQuestMan

Description of Class: This class gives an input depending on 
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

    //
    public Text Count;

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
        //Only Start quest code if player actually talks to the guy first
        if (GrandQuestStart)
        {
            //execute quest 1 code if player has not complete it
            if (!CompleteQuest1)
            {
                
                if (Player.GetComponent<SamplePlayer>().testCollect < 3)
                {
                    Debug.Log("Interact with me once you collect 3 circles");
                }
                
                else if (Player.GetComponent<SamplePlayer>().testCollect >= 3 && !CompleteQuest1)
                {
                    CompleteQuest1 = true;
                    //reset values for the next quest
                    Player.GetComponent<SamplePlayer>().testCollect = 0;
                    Count.text = "Things Collected: " + "0";
                    Debug.Log("Hehe, nice");
                    Debug.Log("Here is your 2nd quest: Collect 5 cones");
                }
            }
            //execute quest 2 code if quest 1 is complete and quest 2 isn't
            else if (!CompleteQuest2)
            {
                //repeat dialog if player has not met criteria
                if (Player.GetComponent<SamplePlayer>().testCollect < 5)
                {
                    Debug.Log("Interact with me again once you collect 5 cones");
                }
                //do things once reaching criteria
                if (Player.GetComponent<SamplePlayer>().testCollect >= 5 && !CompleteQuest2)
                {
                    Debug.Log("Two parter complete, great");
                    CompleteQuest2 = true;
                }
            }
            else
            {
                Debug.Log("Very Nice");
            }
        } 
        
        //reveal the quest count dialoge upon first interact
        if (!GrandQuestStart)
        {
            GrandQuestStart = true;
            Count.gameObject.SetActive(true);
            Count.text = "Things Collected: " + "0";
            Debug.Log("Hey there! Welcome to test... place. You just got your first quest; collect 3 circles.");
        }



    }
}
