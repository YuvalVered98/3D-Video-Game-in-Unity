using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardBehaviour : MonoBehaviour
{
    public GameObject aCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position - aCamera.transform.forward);
    }
}
