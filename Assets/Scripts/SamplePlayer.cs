/******************************************************************************
Author: Elyas Chua-Aziz

Editor: Leong Yu Xuan

Name of Class: DemoPlayer

Description of Class: This class will control the movement and actions of a 
                        player avatar based on user input.

Date Created: 09/06/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamplePlayer : MonoBehaviour
{
    /// <summary>
    /// The distance this player will travel per second.
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotationSpeed;

    //Test Variable for facilitating quest 
    public int testCollect;

    //Variable that stores the text under crosshair
    public Text objectName;

    //Variable that stores the nunmber of items collected
    public Text Count;

    /// <summary>
    /// The camera attached to the player model.
    /// Should be dragged in from Inspector.
    /// </summary>
    [SerializeField]
    private Camera playerCamera;

    private string currentState;

    private string nextState;

    //Used for interaction. Var to determin interaction distance in unity units
    [SerializeField] private float interactDistance;

    // Start is called before the first frame update
    void Start()
    {
        nextState = "Idle" + "";
        Count.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (nextState != currentState)
        {
            SwitchState();
        }

        CheckRotation();
        InteractRaycast();
    }

    //raycast for interactions
    private void InteractRaycast()
    {
        //debug line for raycast
        Debug.DrawLine(playerCamera.transform.position,
            playerCamera.transform.position + playerCamera.transform.forward * interactDistance);
        
        //variable that stores what raycast has hit
        RaycastHit hitinfo;

        //layer mask for the raycast. I still do not know how it works
        int layermask = 1 << LayerMask.NameToLayer("Interactable");

        //do something if the raycast hits something
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitinfo, interactDistance, layermask))
        {    

            //Activate the "Interact" function in obj depending on name
            //I directly copied this from my ASSG1 Script...
            if (Input.GetKeyDown(KeyCode.E))
            {

                if(hitinfo.transform.tag == "Collectable")
                {
                    hitinfo.transform.GetComponent<TestCollect>().Interact();
                }
                else if(hitinfo.transform.name == "TestQuestMan")
                {
                    hitinfo.transform.GetComponent<TestQuestMan>().Interact();
                }
                else if(hitinfo.transform.tag == "Transition")
                {
                    hitinfo.transform.GetComponent<Transition>().Interact();
                }
                
            }

            ///summary
            ///change the text in under the crosshair 
            objectName.text = hitinfo.transform.name;
        } //do something if raycast hits nothing
        else
        {
            objectName.text = "";
        }
        
        

    }

    
    
    /// <summary>
    /// Sets the current state of the player
    /// and starts the correct coroutine.
    /// </summary>
    private void SwitchState()
    {
        StopCoroutine(currentState);
        currentState = nextState;
        StartCoroutine(currentState);
    }


    //Coroutine for the "idle" state
    private IEnumerator Idle()
    {
        while(currentState == "Idle")
        {
            //Revealed in CA4 ans in wk 11 Logic error
            if(Input.GetAxis("Horizontal") !!= 0 || Input.GetAxis("Vertical") != 0)
            {
                nextState = "Moving";
                //Debug.Log("Move");
            }
            yield return null;
        }
    }
    //Coroutine for the "moving" state
    private IEnumerator Moving()
    {
        while (currentState == "Moving")
        {
            if (!CheckMovement())
            {
                nextState = "Idle";
                //Debug.Log("Stop");
                
            }
            yield return null;
        }
        
    }

    //This affected camera movement
    private void CheckRotation()
    {
        Vector3 playerRotation = transform.rotation.eulerAngles;
        playerRotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(playerRotation);

        //changing from += to -= makes the camera move as intended
        Vector3 cameraRotation = playerCamera.transform.rotation.eulerAngles;
        cameraRotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        playerCamera.transform.rotation = Quaternion.Euler(cameraRotation);
    }

    /// <summary>
    /// Checks and handles movement of the player
    /// </summary>
    /// <returns>True if user input is detected and player is moved.</returns>
    private bool CheckMovement()
    {
        //this was deemed unecessary. Commenting out affected nothing (I hope)
        //Vector3 newPos = transform.position;

        //move left and right (Problematic)
        Vector3 xMovement = transform.right * Input.GetAxis("Horizontal");
        //move forward and bacl
        Vector3 zMovement = transform.forward * Input.GetAxis("Vertical");

        Vector3 movementVector = xMovement + zMovement;

        //HAs something to do with movement
        if(movementVector.sqrMagnitude > 0)
        {
            movementVector *= (moveSpeed * Time.deltaTime);
            //newPos = movementVector;

            transform.position += movementVector;
            return true;
        }
        else
        {
            return false;
        }

    }
}
