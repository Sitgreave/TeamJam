using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    int coins;

    public void AddCoins(int count)
    {
        coins += count;
    }

    public int GetCoins()
    {
        return coins;
    }
}
