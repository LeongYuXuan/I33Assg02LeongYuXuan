/******************************************************************************
Author: Leong Yu Xuan

Name of Class: SpecialTele

Description of Class: This class teleports the player to the designated "start area" upon being triggered
                        Copied over from my 3RT work with modifications to suit this prj's needs
                        

Date Created: 15/07/2021
Modified Start: 16/07/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTele : MonoBehaviour
{
    ///<summary>
    ///Store Player obj to teleport 
    /// </summary> 
    public GameObject Player;

    ///<summary>
    ///Store Particle obj to disable/enable later 
    /// </summary>
    public ParticleSystem Particle;

    ///<summary>
    ///Store Questman obj for a certain bool
    /// </summary> 
    public GameObject TestQuestMan;

    ///<summary>
    ///Bool to toggle Particle SetActive State 
    /// </summary>
    private bool ToggleParticle = true;

    ///<summary>
    ///Store UI canvas for loading screens
    /// </summary>
    public GameObject Loading;

    ///<summary>
    ///Varaible that contains the "start area" that the player teleports to
    ///</summary>
    public GameObject StartArea;

    ///<summary>
    ///Store position of the "Start Area"
    ///</summary>
    private Vector3 TeleLocate;

    private void Start()
    {
        TeleLocate = StartArea.transform.position;
    }

    /// <summary>
    /// Scripts to execute upon trigger enter
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        StopAllCoroutines();

        ///<summary>
        ///Reset the player's position
        ///</summary>
        Player.transform.position = TeleLocate;
        ParticleControl();
        StartCoroutine(TransitionControl());
        TestQuestMan.GetComponent<TestQuestMan>().Special = true;
        


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
        for (int i = 0; i < 2; ++i)
        {
            if (i == 0)
            {
                Loading.SetActive(true);
                Player.GetComponent<SamplePlayer>().CanMove = false;
            }
            else if (i == 1)
            {
                Loading.SetActive(false);
                Player.GetComponent<SamplePlayer>().CanMove = true;
            }
            yield return new WaitForSeconds(1f);
        }


    }
}
