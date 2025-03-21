using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlEntranceScript : MonoBehaviour
{
    public GameObject player;
    Animator animator;
    int counter;
    public Text Pt1;
    public Text Pt2;
    public Text Pt3;
    public Text Pt4;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position,transform.position);
        if (distance < 10) // if the player is near, talk to player
        {
            if (animator.GetInteger("State") != 1)
            {
                animator.SetInteger("State",1);
            }
            Vector3 target = player.transform.position - transform.position;
            target.y = 0;
            Vector3 tmpTarget = Vector3.RotateTowards(transform.forward, target, Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(tmpTarget, new Vector3(0,1,0));
            
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

            if (animator.GetInteger("State") !=0)
            {
                animator.SetInteger("State",0);
            }
            Pt1.gameObject.SetActive(false);
            Pt2.gameObject.SetActive(false);
            Pt3.gameObject.SetActive(false);
            Pt4.gameObject.SetActive(false);
        }
    }
}
