/******************************************************************************
Author: Leong Yu Xuan

Name of Class: TestCollect

Description of Class: Class for a test collectable. Grants player 1 item.

Date Created: 06/07/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollect : MonoBehaviour
{
    //for testing 
    public GameObject Player;
    //interact script
    public void Interact()
    {
        Player.GetComponent<SamplePlayer>().testCollect += 1;
        gameObject.SetActive(false);
    }
}