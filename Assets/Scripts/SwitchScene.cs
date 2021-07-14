/******************************************************************************
Author: Leong Yu Xuan

Name of Class: SwitchScene

Description of Class: A very simple class. Switch to specified scene upon being activated by a button
                        

Date Created: 14/07/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    ///<summary>
    ///Public variable that stores what scene to switch to
    ///</summary>
    public int SceneToLoad;

    ///<summary>
    ///Function for switching to specified scene based on float
    ///</summary>
   public void ChangeScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
