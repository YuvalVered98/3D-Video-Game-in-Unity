using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PaladinBehaviour : MonoBehaviour
{
    Animator animator;
    AudioSource sound;
    UnityEngine.AI.NavMeshAgent agent;
    public GameObject target;
    //public GameObject Door;
    bool startMoving = false;
    public GameObject point1;
    public GameObject point2;
    LineRenderer path;
    public Slider healthBar;
    public Text winText;
    //float maxHealth, currentHealth = 100;
    int currentHealth = 100;
    int maxHealth = 100;
    int demage = 20;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        path = GetComponent<LineRenderer>();
        sound = GetComponent<AudioSource>();

        //maxHealth = healthBar.value;
        //currentHealth = healthBar.value;
        //healthBar.value = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance < 5 && startMoving)
        {
            if (target.transform.position.y >5)
            {
                target.transform.position = point1.transform.position;
            }
            else
            {
                target.transform.position = point2.transform.position;
            }
            agent.SetDestination(target.transform.position);
        }
        if (distance < 3 && startMoving)
        {
            animator.SetInteger("Status", 0);
            agent.isStopped = true;
            startMoving = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            startMoving = true;
            animator.SetInteger("Status", 1);
        }
        if (healthBar.value == 0)
        {
            startMoving = false;
            animator.SetInteger("Status", 2);
            PresistentObjectMan.isPaladinDead = true;
            winText.gameObject.SetActive(true);
            sound.Stop();
        }
        if (startMoving)
        {
            agent.SetDestination(target.transform.position);
            path.positionCount = agent.path.corners.Length;
            path.SetPositions(agent.path.corners);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoDemage();
        }
    }
    public void DoDemage()
    {
        if( currentHealth >= demage)
        {
            currentHealth -= demage;
            healthBar.value = currentHealth / (float)maxHealth;
            //helathBar.value = currentHealth;
           
            
        }
        else
        {
            healthBar.value = 0;
        }
    }
}
