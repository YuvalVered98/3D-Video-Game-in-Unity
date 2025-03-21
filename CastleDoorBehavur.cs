using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleDoorBehavur : MonoBehaviour
{
    Animator animator;
    AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("DoorOpenCastle", true);
        AudioSource.PlayDelayed(0.5f);

    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("DoorOpenCastle", false);
        AudioSource.PlayDelayed(2f);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
