using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTracker : MonoBehaviour
{
    public static Int64 coinCount;
    public static Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddCoins(Int64 num)
    {
        coinCount += num;
        textBox.text = coinCount.ToString();
    }

    public static void RemoveCoins(Int64 num)
    {
        coinCount -= num;
        textBox.text = coinCount.ToString();
    }
}
