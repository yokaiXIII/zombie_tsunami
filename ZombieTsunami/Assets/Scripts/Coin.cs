using UnityEngine;

public class Coin : Collectable
{
    protected override void Interact()
    {
        // Add coin collection logic here
        Debug.Log("Coin collected!");
    }
}
