/******************************************************************************
Author: Leong Yu Xuan

Name of Class: FinalItem

Description of Class: Class for a special collectable, which unlocks the ability to open the last door

Date Created: 06/07/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalItem : MonoBehaviour
{
    //variable that stores the game object that the script would impact 
    public GameObject Player;

    //Store UI text component that shows interact dialogue
    public Text Dialogue;

    //Stores UI text that shows the number of items collected
    public Text Count;

    //activates upon game starting
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Playe");
    }
    //interact script
    public void Interact()
    {
        StopAllCoroutines();
        //changes the status of "openSesame" to true
        Player.transform.GetComponent<SamplePlayer>().OpenSesame = true;

        //add one to the no. of things collected
        Player.GetComponent<SamplePlayer>().testCollect += 1;
        Count.text = "Things Collected: " + Player.GetComponent<SamplePlayer>().testCollect;
        
        //interesting text
        StartCoroutine(DialogueControl("Huh, this looks interesting"));
        //set to inactive
        
    }

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
                //modified to 
                gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(5f);
        }
    }
}
