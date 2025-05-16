using System;
using UnityEngine;

public class Coin : Collectable
{

    // static public Action CoinCollected;
    protected override void Interact()
    {
        Collected?.Invoke(this);
        // Add coin collection logic here
        Debug.Log("Coin collected!");
    }
}
