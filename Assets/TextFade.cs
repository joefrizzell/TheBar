﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFade : MonoBehaviour
{
    [SerializeField] private float FadeRate;
    [SerializeField] private float targetAlpha; //serialized for debugging
    private TextMeshProUGUI tmpText;
    private bool isFading = false;
    // Use this for initialization
    void Start()
    {
        // getting text
        tmpText = GetComponentInChildren<TextMeshProUGUI>();
        if (tmpText == null)
        {
            Debug.LogError("Error: No text on " + name);
        }
        targetAlpha = tmpText.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        Color curTextColor = tmpText.color;
        float alphaDiffText = Mathf.Abs(curTextColor.a - targetAlpha);
        if (alphaDiffText > 0.01f)
        {
            isFading = true;
            curTextColor.a = Mathf.Lerp(curTextColor.a, targetAlpha, FadeRate * Time.deltaTime);
            tmpText.color = curTextColor;
        } else
        {
            isFading = false;
        }
    }

    public bool CheckFading()
    {
        return isFading;
    }

    public void FadeOut()
    {
        targetAlpha = 0.0f;
    }

    public void FadeIn()
    {
        targetAlpha = 1.0f;
    }
}
