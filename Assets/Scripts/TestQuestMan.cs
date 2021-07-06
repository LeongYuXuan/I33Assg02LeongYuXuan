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

    //bool to prevent repeated interactions
    private bool CompleteQuest = false;
    //interact script
    public void Interact() 
    {
        if (Player.GetComponent<SamplePlayer>().testCollect < 3)
        {
            Debug.Log("Interact with me once you collect 3 things");
        }
        else if (Player.GetComponent<SamplePlayer>().testCollect >= 3 && !CompleteQuest)
        {
            Debug.Log("Hehe, nice");
            CompleteQuest = true;
        }
        else if (CompleteQuest)
        {
            Debug.Log("You already completed the quest");
        }
    }
}
