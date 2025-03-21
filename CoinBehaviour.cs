using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CoinBehaviour : MonoBehaviour
{
    public static int coinsCounter = 1;
    public GameObject player;
    public GameObject coin;
    public Text coinText;
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
        //if (coin.gameObject.transform.localScale == new Vector3(4, 4, 4))
        //{
        //    PresistentObjectMan.pickArrow = true;
        //}
        if (coinText.text == "Key: 0\nCastle Key: 0")
        {
            coinText.text = "Key: 1\nCastle Key: 0";
            gameObject.SetActive(false);
            AudioSource sound = coin.GetComponent<AudioSource>();
            sound.Play();
        }
        
        
        else //(coinText.text == "Gold: 0")
        {
            coinText.text = "Gold: " + coinsCounter.ToString();
            coinsCounter++;
            gameObject.SetActive(false);
            AudioSource sound = coin.GetComponent<AudioSource>();
            sound.Play();
        }
    }
}
