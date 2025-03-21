using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviourScript : MonoBehaviour
{
    Animator animator;
    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("DoorOpen", true);
        sound.PlayDelayed(0.5f);
        
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("DoorOpen",false);
        sound.PlayDelayed(2f);

    }

    // Update is called once per frame
    void Update()
    {
        if (PresistentObjectMan.isPaladinDead)
        {
            animator.SetBool("DoorOpen", true);
            //sound.PlayDelayed(0.5f);
            sound.Play();
        }
    }
}
