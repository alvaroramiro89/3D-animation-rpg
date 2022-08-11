using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

       isWalkingHash = Animator.StringToHash("isWalking"); 
       isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        //1 if a player presses w key
        if (!isWalking && forwardPressed)
        {
            //Then set the isWalking boolean to be true
            animator.SetBool(isWalkingHash, true);
        }
        //2 if player is NOT pressing w key
        if (isWalking && !forwardPressed)
        {
            //then set walking booleas to false
            animator.SetBool(isWalkingHash, false);
        }
        //3 If player is waking and not running presses left shift
        if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }
        //4 if player stops walking or stops pressing
        if (isRunning &&(!forwardPressed || !runPressed))
        {
            // tehn set the isRunning boolean to be false
            animator.SetBool(isRunningHash, false);
        }
    }
}
