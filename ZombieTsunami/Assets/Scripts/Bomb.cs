using UnityEngine;

public class Bomb : Collectable
{
    protected override void Interact(ZombieCollider other = null)
    {
        if (other != null)
        {
            other.Zombie.Death();
        }
    }
}
