using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car_Selector : MonoBehaviour
{
    public int currentcarindex;
    public GameObject[] cars;

    private void Start()
    {
        currentcarindex = PlayerPrefs.GetInt("SelectCar", 0);
        foreach (GameObject car in cars)
            car.SetActive(false);
        cars[currentcarindex].SetActive(true);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
