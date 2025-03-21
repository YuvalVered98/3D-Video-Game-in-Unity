using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresistentObjectMan : MonoBehaviour
{
    public static PresistentObjectMan instance = null;
    public static int gold = 0;
    public static bool hasSword = false;
    public static bool isSwordOffHand = true;
    public static bool hasBow = false;
    public static bool isBowOffHand = true;
    public static bool hasBowAndArrow = false;
    public static bool isBowAndArrowOffHand = true;
    public static bool pickArrow = false;
    public static bool hasCastleKey = false;
    public static bool isPaladinDead = false;
    public Text coinsText;
    public GameObject swordOnHand;
    public GameObject swordOffHand;
    public GameObject bowOnHand;
    public GameObject bowOffHand;
    public GameObject bowAndArrowOnHand;
    public GameObject bowAndArrowOffHand;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(instance);
        coinsText.text = "Gold: " + gold;
        if (hasSword)
        {
            swordOnHand.SetActive(true);
        }
        else
        {
            swordOnHand.SetActive(false);
        }

        if(isSwordOffHand)
        {
            swordOffHand.SetActive(true);
        }
        else
        {
            swordOffHand.SetActive(false);
        }


        if (hasBow)
        {
            bowOnHand.SetActive(true);
        }
        else
        {
            bowOnHand.SetActive(false);
        }

        if (isBowOffHand)
        {
            bowOffHand.SetActive(true);
        }
        else
        {
            bowOffHand.SetActive(false);
        }


        if (hasBowAndArrow)
        {
            bowAndArrowOnHand.SetActive(true);
        }
        else
        {
            bowAndArrowOnHand.SetActive(false);
        }

        if (isBowAndArrowOffHand)
        {
            bowAndArrowOffHand.SetActive(true);
        }
        else
        {
            bowAndArrowOffHand.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void setGold(int g)
    {
        gold = g;
    }
    public static void setHasSword(bool value)
    {
        hasSword = value;
    }
    public static void setIsSwordOffHand(bool value)
    {
        isSwordOffHand = value;
    }

    public static void setHasBow(bool value)
    {
        hasBow = value;
    }
    public static void setIsBowOffHand(bool value)
    {
        isBowOffHand = value;
    }

    public static void setHasBowAndArrow(bool value)
    {
        hasBowAndArrow = value;
    }
    public static void setIsBowAndArrowOffHand(bool value)
    {
        isBowAndArrowOffHand = value;
    }
}
