/******************************************************************************
Author: Leong Yu Xuan

Name of Class: FinalTrigger

Description of Class: This class is for the trigger at the end of the level.
                        Freeze Player movement and show end screen
                        

Date Created: 14/07/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTrigger : MonoBehaviour
{
    ///<summary>
    ///Variable to store player obj to freeze
    /// </summary>
    public GameObject Player;

    ///<summary>
    ///Variable to store UI Canvas that stores Demo Over screen
    /// </summary>
    public GameObject FinalScreen;

    ///<summary>
    ///Variable to store main player UI Canvas 
    /// </summary>
    public GameObject PlayerUI;

    ///<summary>
    ///Function for doing what is stated in the Heading
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        FinalScreen.SetActive(true);
        PlayerUI.SetActive(false);
        Player.GetComponent<SamplePlayer>().CanMove = false;
    }
}
