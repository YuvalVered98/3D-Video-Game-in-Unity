using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class NewBehaviourScript : MonoBehaviour
{
    CharacterController controller;
    AudioSource footStep;
    public GameObject swordOnHand;
    public GameObject swordOffHand;
    public GameObject bowAndNoArrow;
    public GameObject bowInHand;
    public GameObject bowAndArrow;
    public GameObject bowAndArrowInHand;
    public GameObject chestTop;
    public GameObject castleKey;

    public Text coinText;
    public Text keyText;
    public Text cantOpenChest;
    public Text pickText;
    public Text openChest;
    public Text cantPickText;
    public bool isChestOpen = false;
    float speed = 100;
    float angularSpeed = 150;
    public GameObject playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
        controller = GetComponent<CharacterController>();
        footStep = GetComponent<AudioSource>();
        if (PresistentObjectMan.hasSword)
        {
            bowAndArrowInHand.SetActive(false);
            bowInHand.SetActive(false);
            swordOnHand.SetActive(true);
        }
        else if (PresistentObjectMan.hasBow)
        {
            if (PresistentObjectMan.hasBowAndArrow)
            {
                swordOnHand.SetActive(false);
                bowInHand.SetActive(false);
                bowAndArrowInHand.SetActive(true);
            }
            else
            {
                swordOnHand.SetActive(false);
                bowAndArrowInHand.SetActive(false);
                bowInHand.SetActive(true);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float dz;
        float dx;
        float rotationAboutY;
        float rotationAboutX;

        dz = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        rotationAboutX = Input.GetAxis("Mouse Y") * angularSpeed * Time.deltaTime;
        playerCamera.transform.Rotate(rotationAboutX, 0, 0);

        rotationAboutY = Input.GetAxis("Mouse X") * angularSpeed * Time.deltaTime;
        transform.Rotate(0, rotationAboutY, 0);

        Vector3 motion = new Vector3(dx, -1, dz);
        motion = transform.TransformDirection(motion);
        controller.Move(motion);
        if (!(Mathf.Abs(motion.x) < 0.001 && Mathf.Abs(motion.z) < 0.001))
        {
            if (!footStep.isPlaying)
            {
                footStep.Play();
            }
        }
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            if (hit.collider.gameObject == swordOffHand.gameObject)
            {
                pickText.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.P))
                {
                    swordOnHand.gameObject.SetActive(true);
                    swordOffHand.gameObject.SetActive(false);
                    PresistentObjectMan.setHasSword(true);
                    PresistentObjectMan.setIsSwordOffHand(false);
                    bowAndArrowInHand.gameObject.SetActive(false);
                    bowInHand.gameObject.SetActive(false);
                }
            }
            else if (hit.collider.gameObject == bowAndNoArrow.gameObject)
            {
                pickText.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.P))
                {
                    bowAndNoArrow.SetActive(false);
                    bowInHand.SetActive(true);

                    PresistentObjectMan.setHasBow(true);
                    PresistentObjectMan.setIsBowOffHand(false);
                    swordOnHand.gameObject.SetActive(false);
                }
            }
            else if (hit.collider.gameObject == bowAndArrow.gameObject)
            {
                if (PresistentObjectMan.hasBow)
                {
                    pickText.gameObject.SetActive(true);
                    if (Input.GetKey(KeyCode.P))
                    {
                        bowAndArrow.SetActive(false);
                        swordOnHand.SetActive(false);
                        bowInHand.SetActive(false);
                        bowAndArrowInHand.SetActive(true);
                        PresistentObjectMan.setHasBowAndArrow(true);
                        PresistentObjectMan.setIsBowAndArrowOffHand(false);

                        //swordOnHand.gameObject.SetActive(false);
                        bowAndNoArrow.gameObject.SetActive(false);
                    }
                }
            }
            else if (hit.collider.gameObject == chestTop.gameObject)
            {
                if (keyText.text == "Key: 1\nCastle Key: 0" && !isChestOpen)
                {
                    openChest.gameObject.SetActive(true);
                    if (Input.GetKey(KeyCode.Space))
                    {
                        isChestOpen = true;
                        ChestBehaviour chestScript = chestTop.GetComponent<ChestBehaviour>();
                        chestScript.OpenChest();
                        castleKey.SetActive(true);

                    }
                }
                else if (!isChestOpen)
                {
                    cantOpenChest.gameObject.SetActive(true);
                }
            }
            else if (hit.collider.gameObject == castleKey.gameObject)
            {
                pickText.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.P))
                {
                    castleKey.SetActive(false);

                    PresistentObjectMan.hasCastleKey = true;
                }
            }

            else
            {
                pickText.gameObject.SetActive(false);
                cantPickText.gameObject.SetActive(false);
                cantOpenChest.gameObject.SetActive(false);
                openChest.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            bowAndArrowInHand.SetActive(true);
        }
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    bowAndArrowInHand.SetActive(true);
        //}
        if (PresistentObjectMan.hasSword && (PresistentObjectMan.hasBow || PresistentObjectMan.hasBowAndArrow))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (PresistentObjectMan.hasBowAndArrow)
                {
                    bowInHand.SetActive(false);
                    if (swordOnHand.activeInHierarchy)
                    {
                        swordOnHand.SetActive(false);
                        bowAndArrowInHand.SetActive(true);
                    }
                    else
                    {
                        bowAndArrowInHand.SetActive(false);
                        swordOnHand.SetActive(true);
                    }
                }
                else
                {
                    if (swordOnHand.activeInHierarchy)
                    {
                        swordOnHand.SetActive(false);
                        bowInHand.SetActive(true);
                    }
                    else
                    {
                        bowInHand.SetActive(false);
                        swordOnHand.SetActive(true);
                    }
                }
            }
        }
        if (PresistentObjectMan.hasCastleKey && coinText.text == "Key: 1\nCastle Key: 0")
        {
            coinText.text = "Key: 1\nCastle Key: 1";
        }
        //if (PresistentObjectMan.hasBowAndArrow && PresistentObjectMan.pickArrow)
        //{
        //    bowAndArrowInHand.SetActive(true);
        //}
    }
}


    
