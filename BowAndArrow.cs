using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAndArrow : MonoBehaviour
{
    LineRenderer bowString;
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public GameObject arrow;
    public GameObject arrowInTarget;
    public GameObject eye;
    public PaladinBehaviour enemy;
    Vector3 arrowOnBow;
    int countFrames = 0;
    float delta = 0.0009f;
    bool isButtonPressed = false;
    AudioSource arrowSound;
    int maxFrames = 80;

    // Start is called before the first frame update
    void Start()
    {
        bowString = GetComponent<LineRenderer>();
        pointB.transform.position = new Vector3 ((pointA.transform.position.x + pointC.transform.position.x)/2,
            (pointA.transform.position.y + pointC.transform.position.y)/2,
            (pointA.transform.position.z + pointC.transform.position.z)/2);
        bowString.SetWidth(0.01f, 0.01f);
        arrowSound = GetComponent<AudioSource>();
        arrowOnBow = arrow.transform.position;
        arrow.transform.position = pointB.transform.position;
    }

    private void Update()
    {
        if (arrow.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //PresistentObjectMan.pickArrow = false;
                isButtonPressed = true;
                countFrames = 0;
                
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                isButtonPressed = false;
                pointB.transform.position = new Vector3((pointA.transform.position.x + pointC.transform.position.x) / 2,
                (pointA.transform.position.y + pointC.transform.position.y) / 2,
                (pointA.transform.position.z + pointC.transform.position.z) / 2);
                
                arrow.SetActive(false);
                arrowSound.Play();


                RaycastHit hit;
                if (Physics.Raycast(eye.transform.position, eye.transform.forward, out hit))
                {
                    arrowInTarget.SetActive(true);
                    arrowInTarget.transform.rotation = arrow.transform.rotation;
                    arrowInTarget.transform.position = hit.point;
                    arrowInTarget.transform.Translate(0, -1, 0, Space.Self);
                    if(hit.collider.gameObject == enemy.gameObject)
                    {
                        enemy.DoDemage();
                    }
                }
            }
            if (isButtonPressed)
            {
                if (countFrames < maxFrames)
                {
                    countFrames++;
                    pointB.transform.Translate(new Vector3(0, 0, -delta * countFrames));
                    arrow.transform.position = pointB.transform.position;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                arrow.SetActive(true);
            }
        }
        //else if (PresistentObjectMan.pickArrow)
        //{
        //    //arrow.transform.position = arrowOnBow;
        //    arrowInTarget.SetActive(false);
        //    arrow.SetActive(true);
        //}
    }
    // Update is called once per frame
    void LateUpdate()
    {
        bowString.SetPosition(0,pointA.transform.position);
        bowString.SetPosition(1, pointB.transform.position);
        bowString.SetPosition(2, pointC.transform.position);
    }
}
