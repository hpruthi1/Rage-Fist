﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI CountDownTime;
    public float currentTime=0;
    float startingTime=7f;
    public GameObject Player;
    public bool timerIsActive =true;
    public PlayerController playerController;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        if (timerIsActive)
        {
            currentTime -= 1 * Time.deltaTime;
            CountDownTime.text = currentTime.ToString("0");

            if (currentTime <= 0 )
            {
                if(playerController.VideoPanelActive==false)
                currentTime = 0.0f;
                timerIsActive = false;
                SceneManager.LoadScene(1);
            }

            if (currentTime >= 3.5f)
            {
                CountDownTime.color = Color.black;
            }

            if (currentTime < 3.5f)
            {
                CountDownTime.color = Color.red;
            }

        }
    }
}
