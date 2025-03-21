using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //if (PresistentObjectMan.hasCastleKey)
            //{
            //    SceneManager.LoadScene(2);
            //}
            PresistentObjectMan.setGold(CoinBehaviour.coinsCounter);
            SceneManager.LoadScene(1);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
