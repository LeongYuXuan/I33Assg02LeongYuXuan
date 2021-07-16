/******************************************************************************
Author: Leong Yu Xuan

Name of Class: TestQuestMan

Description of Class: This class teleports the player to the opposite side of the obj it 
                        is assigned to. It moves the player on the Z or X axis depending
                        on the bool.
                        Teleports have hard-coded lock at the moment for gameplay
                        progress reasons
                        

Date Created: 08/07/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    ///<summary>
    ///Store Player obj to teleport 
    /// </summary> 
    public GameObject Player;

    ///<summary>
    ///Variable to store Questman obj. Bools here used to lock teleport
    /// </summary>
    public GameObject QuestMan;

    ///<summary>
    ///Bool to control which direction to teleport on 
    /// </summary>
    public bool teleportOnX;

    ///<summary>
    ///Stores text that shows dialogue  
    /// </summary>
    public Text Dialogue;

    ///<summary>
    ///Store Particle obj to disable/enable later 
    /// </summary>
    public ParticleSystem Particle;

    ///<summary>
    ///Bool to toggle Particle SetActive State 
    /// </summary>
    private bool ToggleParticle = true;

    ///<summary>
    ///Store UI canvas for loading screens
    /// </summary>
    public GameObject Loading;

    ///<summary>
    ///Functions to execute upon interact 
    /// </summary>
    public void Interact()
    {
        //Stop all coroutines upon interact
        StopAllCoroutines();
        Teleport();
    }
    ///<summary>
    ///Teleport Function
    ///</summary>
    void Teleport()
     {
        //
        //Update player position via updating player obj
        Player = GameObject.FindGameObjectWithTag("Playe");
        //var to store player pos for easier management
        Vector3 playerPos = Player.transform.position;
        //var to store teleport pos 
        Vector3 telePos = transform.position;

        //left teleport coord
        Vector3 Left = transform.position - (transform.right * 2);
        //Right teleport coord
        Vector3 Right = transform.position - (-transform.right * 2);

        //teleports player on x if true
        if (teleportOnX)
        {
            //activate teleport if player has started the quest
            if (QuestMan.GetComponent<TestQuestMan>().GrandQuestStart)
            {
                //Teleport left if player is to the right
                if (playerPos.x > telePos.x)
                {
                    Player.transform.position = Left;

                }
                //teleport right if the player is to the left
                else if (playerPos.x < telePos.x)
                {
                    Player.transform.position = Right;
                }
                ParticleControl();
                StartCoroutine(TransitionControl());
            }
            //give message regarding why transition is locked
            else
            {
                StartCoroutine(DialogueControl("There's a hole here, but there are boxes in the way."));
            }
        }
        //teleports player on z if false
        else
        {
            //activate teleport if player completes first quest
            if (QuestMan.GetComponent<TestQuestMan>().CompleteQuest1)
            {
                //Teleport left if player is to the right
                if (playerPos.z > telePos.z)
                {
                    Player.transform.position = Left;

                }
                //teleport right if the player is to the left
                else if (playerPos.z < telePos.z)
                {
                    Player.transform.position = Right;

                }
            ParticleControl();
            StartCoroutine(TransitionControl());
            }
            //give message why it is locked
            else
            {
                StartCoroutine(DialogueControl("A strong freezing gale. It's too cold to enter..."));
            }
        }
     }

    ///<summary>
    ///Dialogue Display Coroutine. "a" is the string to display
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

    ///<summary>
    ///Control particle play/pause if teleport successful
    ///</summary>
    void ParticleControl()
        {
            //enable/diable assigned particle if it is not null
            if (Particle != null)
            {
                if (ToggleParticle)
                {
                    Particle.Pause();
                }
                else
                {
                    Particle.Play();
                }
                ToggleParticle = !ToggleParticle;
            }
        }

    ///<summary>
    ///Coroutine for transitions if teleports are successful. They last 1 second
    ///</summary>
    IEnumerator TransitionControl()
    {
        for(int i = 0; i < 2; ++i)
        {
            if(i == 0)
            {
                Loading.SetActive(true);
                Player.GetComponent<SamplePlayer>().CanMove = false;
            }
            else if(i == 1)
            {
                Loading.SetActive(false);
                Player.GetComponent<SamplePlayer>().CanMove = true;
            }
            yield return new WaitForSeconds(1f);
        }

        
    }


}
