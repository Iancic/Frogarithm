using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Quest_Controller : MonoBehaviour
{
    public TMP_Text text;
    public int ecuation;
    public int a, b, c;
    public string myString;

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
        if (ecuation == Player.Instance.playerNumber)
        {
            Player.Instance.pollywags = Player.Instance.pollywags + 100;
            text.text = "";
            ecuation = 0;
        }
    }

    public void GenerateEcuation()
    {

        //functie grad I: ecuation ax + b = c
        a = Random.Range(1, 9);
        b = Random.Range(1, 9);
        c = Random.Range(1, 9);
        ecuation = (c - b) / a;

        if ( b > c )
        {
            int aux = c;
            c = b;
            b = aux;
        }
        
        if (a == 1)
            myString = $"x + {b} = {c}";
        else
            myString = $"{a}x + {b} = {c}";
        text.text = myString;
    }

}
