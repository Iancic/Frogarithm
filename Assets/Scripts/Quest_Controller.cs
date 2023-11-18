using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Controller : MonoBehaviour
{
    public TMP_Text text;
    public int ecuation;
    public int a, b, x;
    public string myString;
    public bool difficulty;

    private float timer = 0f, max_time = 25f, time_remaining;

    public Image timer_UI;

    public static Quest_Controller Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    //Singleton Workflow

    void Start()
    {
        GenerateEcuation();
    }

    private void Update()
    {
        time_remaining = max_time - timer;
        timer_UI.fillAmount = 1 - (timer / max_time);

        if (timer > 0f)
            timer -= Time.deltaTime;

        if (ecuation == Player.Instance.playerNumber && timer > 0f)
        {
            Player.Instance.pollywags += 100;
            text.text = "";
            ecuation = 0;
            timer_UI.fillAmount = 0;
        }
        else if (timer < 0f && ecuation != 999)
        {
            Player.Instance.pollywags -= 500;
            ecuation = 999;
            text.text = "";
            timer_UI.fillAmount = 0f;
        }

    }

    public void GenerateEcuation()
    {
        timer = max_time;
        difficulty = true;
        if (difficulty == true)
        {
            //functie grad I: ecuation ax + b = c
            int a = UnityEngine.Random.Range(1, 9);
            int x = UnityEngine.Random.Range(1, 9); // Random whole number for x
            int b = UnityEngine.Random.Range(1, 9);
            int c = a * x + b; // Calculate c based on a, x, and b

            ecuation = x;

            if (a == 1)
                myString = $"x + {b} = {c}";
            else
                myString = $"{a}x + {b} = {c}";

            text.text = myString;
        }

        Spawner_Controller.Instance.Spawn_Solution();
    }

}
