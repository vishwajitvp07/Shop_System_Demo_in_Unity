using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Manager : MonoBehaviour
{
    
    public Text cashAmount;
    public int currentCash = 0;
    public int topup = 0;

    public void Start()
    {
        if(PlayerPrefs.HasKey("Cash"))
        {
            currentCash = PlayerPrefs.GetInt("Cash");
        }
        else
        {

        }
        cashAmount.text = ": " + currentCash;
    }


    public void AddCash()
    {
        currentCash += topup;
        PlayerPrefs.SetInt("Cash", currentCash);
        cashAmount.text = ": " + currentCash;

    }

}
