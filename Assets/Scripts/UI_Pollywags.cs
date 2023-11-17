using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Pollywags : MonoBehaviour
{
    public TMP_Text text;
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.SetText(Player.Instance.pollywags.ToString());
    }
}
