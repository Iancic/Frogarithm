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

    private float timer = 0f, max_time = 15f, time_remaining;

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

    public void Start()
    {
        GenerateFunctionEcuation();
    }

    private void Update()
    {
        time_remaining = max_time - timer;
        timer_UI.fillAmount = timer / max_time;

        if (timer > 0f)
            timer -= Time.deltaTime;

        if (ecuation == Player.Instance.playerNumber && timer > 0f)
        {
            Player.Instance.playerNumber = 0f;
            Player.Instance.pollywags += 250;
            text.text = "";
            ecuation = 0;
            timer = 0f;
        }
        else if (timer < 0f && ecuation != 999)
        {
            Player.Instance.pollywags -= 100;
            ecuation = 999;
            text.text = "";
            timer_UI.fillAmount = 0f;
        }

    }

    public void GenerateFunctionEcuation()
    {
        Player.Instance.playerNumber = 0f;
        Player.Instance.ChangeNumber();

        timer = max_time;
            //functie grad I: ecuation ax + b = c
            int a = UnityEngine.Random.Range(1, 10);
            int x = UnityEngine.Random.Range(1, 10);
            int b = UnityEngine.Random.Range(1, 10);
            int c = a * x + b;

            ecuation = x;

            if (a == 1)
                myString = $"x + {b} = {c}";
            else
                myString = $"{a}x + {b} = {c}";

            text.text = myString;

        StartCoroutine(Spawner_Controller.Instance.Spawn_Solution());
        Spawner_Controller.Instance.Spawn_3_Numbers();
    }

    public void GeneratePowerEquation()
    {
        Player.Instance.playerNumber = 0f;
        Player.Instance.ChangeNumber();

        timer = max_time;

        int a = UnityEngine.Random.Range(2, 4);
        int x = UnityEngine.Random.Range(1, 5);
        int c = (int)Mathf.Pow(x, a);

        ecuation = x;

        myString = $"x^{a} = {c}";
        text.text = myString;

        StartCoroutine(Spawner_Controller.Instance.Spawn_Solution());
        Spawner_Controller.Instance.Spawn_3_Numbers();
    }

    public void GenerateSqrtEquation()
    {
        Player.Instance.playerNumber = 0f;
        Player.Instance.ChangeNumber();

        timer = max_time;

        int a = UnityEngine.Random.Range(1, 10);
        int b = a * a;
        int x = a;

        ecuation = x;

        string equation = $"sqrt({b}) = x";
        text.text = equation;

        StartCoroutine(Spawner_Controller.Instance.Spawn_Solution());
        Spawner_Controller.Instance.Spawn_3_Numbers();
    }

}
