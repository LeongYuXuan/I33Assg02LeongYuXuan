/******************************************************************************
Author: Leong Yu Xuan

Name of Class: TestCollect

Description of Class: Class for a test collectable. Grants player 1 item.

Date Created: 06/07/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCollect : MonoBehaviour
{
    //for testing 
    public GameObject Player;

    //Text that it would impact
    public Text Count;

    //activates upon game starting
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Playe");
        
    }
    //interact script
    public void Interact()
    {
        //add one to the no. of things collected
        Player.GetComponent<SamplePlayer>().testCollect += 1;
        Count.text = "Things Collected: " + Player.GetComponent<SamplePlayer>().testCollect;
        gameObject.SetActive(false);
    }
}