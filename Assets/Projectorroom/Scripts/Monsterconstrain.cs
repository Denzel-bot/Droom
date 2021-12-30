using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterconstrain : MonoBehaviour
{
    Vector3 originalPosition; 
    public GameObject moveCube; 
    public float legMoveSpeed = 7f; 
    public float moveDistance = 0.7f; 
    public float moveStoppingDistance = 0.4f; 
    public Monsterconstrain oppsiteLeg;
    bool isMoving = false; 
    bool moving = false; 
    public AudioSource step;
 
    private void Start()
    {
        originalPosition = transform.position; 
    }

    private void Update()
    {
        float distanceToMoveCube = Vector3.Distance(transform.position, moveCube.transform.position);
        if ((distanceToMoveCube >= moveDistance && !oppsiteLeg.isItMoving()) || moving)
        {
            moving = true; 
            transform.position = Vector3.Lerp(transform.position, moveCube.transform.position + new Vector3(0f, 0.3f, 0f), Time.deltaTime * legMoveSpeed); // to move the leg to the cube
            originalPosition = transform.position; 
            isMoving = true; // to tell oppsite legs that this one is moving
            if (step.isPlaying == false)
            {
                step.Play();
            }
            if (distanceToMoveCube < moveStoppingDistance) 
            {
                moving = false; 
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition + new Vector3(0f, -0.3f, 0f), Time.deltaTime * legMoveSpeed * 3f); 
            isMoving = false;
        }
    }

    public bool isItMoving() 
    {
        return isMoving;
    }

}
