using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    Animator animator;
    AudioSource sound;
    //int countFrames = 0;
    // Start is called before the first frame update
    
    void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }
    
    public void OpenChest()
    {
        animator.SetBool("OpenChest", true);
        sound.PlayDelayed(0.5f);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
