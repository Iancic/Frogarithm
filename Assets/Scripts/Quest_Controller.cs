using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest_Controller : MonoBehaviour
{
    public TMP_Text text;
    public int ecuation;

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
        /*
        if (ecuation == player.number)
        {
            Player.polywags ++
            text.text = "'none;
        }
        */
    }

    public void GenerateEcuation()
    {
        ecuation = Random.Range(1, 9);
        string myString = ecuation.ToString();
        text.text = myString;
    }

}
