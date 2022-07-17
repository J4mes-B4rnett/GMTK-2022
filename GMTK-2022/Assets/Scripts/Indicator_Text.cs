using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Indicator_Text : MonoBehaviour
{
    public TextMeshProUGUI indicatorText;

    void Start()
    {
        indicatorText = GetComponent<TextMeshProUGUI>();
    }
    
    public void UpdateText(string text)
    {
        indicatorText.text = text;
    }
}
