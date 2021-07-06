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

public class TestQuestMan : MonoBehaviour
{
    //for testing 
    public GameObject Player;

    //bool to prevent repeated interactions and trigger quest2
    private bool CompleteQuest1 = false;
    //bool to prevent repeated interactions and trigger quest2
    private bool CompleteQuest2 = false;
    //bool specifically to trigger final dialoge
    private bool GrandComplete = false;

    //interact script
    public void Interact() 
    {
        //Script for first quest 
        if (!CompleteQuest1) {
            if (Player.GetComponent<SamplePlayer>().testCollect < 3)
            {
                Debug.Log("Interact with me once you collect 3 circles");
            }
            else if (Player.GetComponent<SamplePlayer>().testCollect >= 3 && !CompleteQuest1)
            {
                CompleteQuest1 = true;
                //reset value for the next quest
                Player.GetComponent<SamplePlayer>().testCollect = 0;
                Debug.Log("Hehe, nice");
                Debug.Log("Interact with me again once you collect 5 cones");
            }
        }
        //Script for 2nd quest
        else if (!CompleteQuest2)
        {
            if (Player.GetComponent<SamplePlayer>().testCollect < 5)
            {
                Debug.Log("Interact with me again once you collect 5 cones");
            }
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
}
