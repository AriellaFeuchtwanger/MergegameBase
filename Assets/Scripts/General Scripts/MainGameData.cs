using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameData : MonoBehaviour
{
    public int energy;
    public int maxEnergy = 50; //Go up by 5 every level
    public int coins;
    public int gems;
    public int yourLevel;
    public int xp;
    public int maxXP;

    public void AddEnergy(int num)
    {
        //Add energy to our energy
        energy += num;
    }

    public void RemoveEnergy(int num)
    {
        //Remove energy
        energy -= num;
    }

    public void CheckEnergy (int num)
    {
        //Check if we have enough energy
    }

    public void AddTo(int statNum, int otherNum)
    {
        //Add the numbers
    }

    public void Removefrom(int statNum, int otherNum)
    {

    }

    public void Check(int statNum, int otherNum)
    {

    }
}
