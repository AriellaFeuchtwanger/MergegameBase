using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GemTracker : MonoBehaviour
{
    public static Int64 gemCount;
    public static Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddGems(Int64 num)
    {
        gemCount += num;
        textBox.text = gemCount.ToString();
    }

    public static void RemoveGems(Int64 num)
    {
        gemCount -= num;
        textBox.text = gemCount.ToString();
    }
}
