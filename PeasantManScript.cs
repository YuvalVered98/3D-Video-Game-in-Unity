using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PeasantManScript : MonoBehaviour
{
    Animator animator;
    public GameObject player;
    public GameObject target;
    public GameObject point1;
    public GameObject waiter;
    int counter = 0;
    public Text Pt1;
    public Text Pt2;
    public Text Pt3;
    public Text Pt4;
    public bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }
    private void OnTriggerEnter(Collider other)
    {
        isPlaying = true;
        animator.SetInteger("Status", 1);
        target.transform.position = point1.transform.position;
        

    }
    //private void OnTriggerExit(Collider other)
    //{
    //    animator.SetBool("Status", false);
    //}
    // Update is called once per frame
    void Update()
    {
        float distanceFromWaiter = Vector3.Distance(waiter.transform.position, transform.position);
        float distanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanceFromWaiter > 15 && isPlaying)
        {
            isPlaying = false;
            animator.SetInteger("Status", 0);
            
        }

        if (distanceFromPlayer < 10)
        {
            Vector3 target = player.transform.position - transform.position;
            target.y = 0;
            Vector3 tmpTarget = Vector3.RotateTowards(transform.forward, target, Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(tmpTarget, new Vector3(0, 1, 0));
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (counter == 0)
                {
                    Pt1.gameObject.SetActive(true);
                    counter++;
                }
                else if (counter == 1)
                {
                    Pt1.gameObject.SetActive(false);
                    Pt2.gameObject.SetActive(true);
                    counter++;
                }
                else if (counter == 2)
                {
                    Pt2.gameObject.SetActive(false);
                    Pt3.gameObject.SetActive(true);
                    counter++;
                }
                else
                {
                    Pt3.gameObject.SetActive(false);
                    Pt4.gameObject.SetActive(true);
                }
            }
        }
        else
        {

            if (animator.GetInteger("State") != 0)
            {
                animator.SetInteger("State", 0);
            }
            Pt1.gameObject.SetActive(false);
            Pt2.gameObject.SetActive(false);
            Pt3.gameObject.SetActive(false);
            Pt4.gameObject.SetActive(false);

        }
    }
}


//public class PeasantManScript : MonoBehaviour
//{
//    Animator animator;
//    public GameObject target;
//    public GameObject point1;
//    public GameObject waiter;
//    public bool isPlaying = false;
//    private bool coroutineStarted = false; // Prevent starting coroutine multiple times

//    // Start is called before the first frame update
//    void Start()
//    {
//        animator = GetComponent<Animator>();
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        animator.SetBool("Status", true);
//        target.transform.position = point1.transform.position;
//        isPlaying = true;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        float distance = Vector3.Distance(waiter.transform.position, transform.position);

//        // Check if distance is less than 3 and animation is playing
//        if (distance < 3 && isPlaying && !coroutineStarted)
//        {
//            coroutineStarted = true; // Prevent the coroutine from being triggered multiple times
//            StartCoroutine(SetBoolAfterFrames(5)); // Start the coroutine to wait 5 frames
//        }
//    }

//    // Coroutine to wait for a certain number of frames before executing the command
//    IEnumerator SetBoolAfterFrames(int frameCount)
//    {
//        // Wait for the specified number of frames
//        for (int i = 0; i < frameCount; i++)
//        {
//            yield return new WaitForEndOfFrame();
//        }

//        animator.SetBool("Status", false);
//        isPlaying = false;
//        coroutineStarted = false; // Reset this so the coroutine can be triggered again
//    }
//}
