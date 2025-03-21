using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCastleDoorBehavur : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    bool isTriggered;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        isTriggered = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (PresistentObjectMan.hasCastleKey)
        {
            animator.SetBool("DoorOpen", true);
            isTriggered = true;
            audioSource.PlayDelayed(0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("DoorOpen", false);
        isTriggered = false;
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // Stop the audio if it is playing to avoid issues with re-triggering
        }
        audioSource.PlayDelayed(2.5f);
    }
    void Update()
    {
        if (audioSource.isPlaying)
        {
            if (isTriggered)
            { 
                enterCheck();
            }
            else
            {
                exitCheck();
            }
        }
       
        //AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        //if (((stateInfo.IsName("2ndFloorCastleEntranceOpen") || stateInfo.IsName("2ndFloorCastleEntranceClose"))
        //    || (stateInfo.IsName("2ndTo3rdFloorGateClose") || stateInfo.IsName("2ndTo3rdFloorGateOpen")) ||
        //    (stateInfo.IsName("CastleGateOpenAnimation") || stateInfo.IsName("CastleGateCloseAnimation")))
        //    && stateInfo.normalizedTime >= 1.0f) // Animation finished
        //{
        //    if (audioSource.isPlaying)
        //    {
        //        audioSource.Stop(); // Stop the audio when the animation ends

            //    }
            //}
    }
    private void exitCheck()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if ((stateInfo.IsName("2ndFloorCastleEntranceClose") || stateInfo.IsName("2ndTo3rdFloorGateClose") || 
            stateInfo.IsName("CastleGateCloseAnimation")) && stateInfo.normalizedTime >= 1.0f)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop(); // Stop the audio when the animation ends

            }
        }
    }
    private void enterCheck()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if ((stateInfo.IsName("2ndFloorCastleEntranceOpen") || stateInfo.IsName("2ndTo3rdFloorGateOpen") ||
            stateInfo.IsName("CastleGateOpenAnimation")) && stateInfo.normalizedTime >= 1.0f)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop(); // Stop the audio when the animation ends

            }
        }
    }
}
