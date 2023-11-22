using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Shop_Manager : MonoBehaviour
{
    public int currentcarindex = 0;
    public GameObject[] carModel;
    public unlock_cars[] carss;
    public Button buyButton;
 

    void Start()
    {
        foreach(unlock_cars car in carss)
        {
            if (car.price == 0)
                car.isUnlocked = true;
            else
                car.isUnlocked = PlayerPrefs.GetInt(car.name, 0) == 0 ? false : true;
        }
        currentcarindex = PlayerPrefs.GetInt("SelectCar", 0);
        foreach (GameObject car in carModel)
            car.SetActive(false);
        carModel[currentcarindex].SetActive(true);

    }
    private void Update()
    {
        
        UpdateUI();
    }
    public void ChangeNext()
    {
        carModel[currentcarindex].SetActive(false);
        currentcarindex++;
        if (currentcarindex == carModel.Length)
            currentcarindex = 0;
        carModel[currentcarindex].SetActive(true);
        PlayerPrefs.SetInt("SelectCar", currentcarindex);

    }
    public void ChangePrev()
    {
        carModel[currentcarindex].SetActive(false);
        currentcarindex--;
        if (currentcarindex == -1)
            currentcarindex = carModel.Length - 1;
        carModel[currentcarindex].SetActive(true);
        PlayerPrefs.SetInt("SelectCar", currentcarindex);

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
     }


    public void UnlockCar() 
    {
        unlock_cars c = carss[currentcarindex];
        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("SelectCar", currentcarindex);
        c.isUnlocked = true;
      
        PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash", 0) - c.price);
    
    }
    void UpdateUI()
    {
        unlock_cars c = carss[currentcarindex];
        if(c.isUnlocked)
        {
            
            buyButton.gameObject.SetActive(false);
           
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<Text>().text = "BUY:" + c.price;
            if(c.price <= PlayerPrefs.GetInt("Cash",0))
            {
                buyButton.interactable = true;
              
            }
            else
            {
                buyButton.interactable = false;
                
            }
        }
    }

}
