using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class tracks player data, such as level, xp, and username
public class PlayerDataTracker : MonoBehaviour
{
    public static string username;
    public static int level;
    public static int xp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void IncreaseXP(int num)
    {
        xp += num;


    }
}
