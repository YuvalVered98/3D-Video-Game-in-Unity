using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveScript : MonoBehaviour
{
    Animator animator;
    public GameObject waiter;
    public GameObject action;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //float distance = Vector3.Distance(waiter.transform.position, transform.position);
        //if (distance < 3)
        //{
        //    animator.SetInteger("Status", 1);
        //}
        //if (distance > 15)
        //{
        //    animator.SetInteger("Status", 0);
        //}
        //if (distance > 10)
        //{
        //    animator.SetInteger("Status", 0);
        //}
        float distance = Vector3.Distance(waiter.transform.position, action.transform.position);
        if (distance < 3)
        {
            animator.SetInteger("Status", 1);
        }
        else
        {
            animator.SetInteger("Status", 0);
        }
    }
}
