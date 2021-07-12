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

    //Store UI text component shows interact dialogue
    public Text Dialogue;

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
        //interesting text
        StartCoroutine(DialogueControl("Huh, this looks interesting"));
        //set to inactive
        gameObject.SetActive(false);
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
            }

            yield return new WaitForSeconds(5f);
        }
    }
}
