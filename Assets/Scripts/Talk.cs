/******************************************************************************
Author: Leong Yu Xuan

Name of Class: FinalItem

Description of Class: Simple Class that just shows dialogue if interacted with

Date Created: 16/07/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    ///<summary>
    ///Var to store player obj to check bool from
    /// </summary> 
    public GameObject Player;

    ///<summary>
    ///Store UI Text for dialogue display
    /// </summary>
    public Text Dialogue;

    /// <summary>
    /// What dialogue the item would give
    /// </summary>
    public string Say;

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
        StartCoroutine(DialogueControl(Say));

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
