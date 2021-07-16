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
    ///<summary>
    ///Var to store player obj to check bool from
    /// </summary> 
    public GameObject Player;

    ///<summary>
    ///Store UI Text for dialogue display
    /// </summary>
    public Text Dialogue;

    ///<summary>
    ///Store UI text that shows how many things the player has collected
    /// </summary>
    public Text Count;

    //activates upon game starting
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Playe");
    }
    ///<summary>
    ///Scripts to execute upon interaction
    /// </summary>
    public void Interact()
    {
        StopAllCoroutines();
        //changes the status of "openSesame" to true
        Player.transform.GetComponent<SamplePlayer>().OpenSesame = true;

        //add one to the no. of things collected
        Player.GetComponent<SamplePlayer>().testCollect += 1;
        Count.text = "Things Collected: " + Player.GetComponent<SamplePlayer>().testCollect;
        
        //interesting text
        StartCoroutine(DialogueControl("Huh, this looks interesting."));
        //set mesh renderer and collider to false
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    ///<summary>
    ///Coroutine for Dialogue control, with "a" being string to display
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
