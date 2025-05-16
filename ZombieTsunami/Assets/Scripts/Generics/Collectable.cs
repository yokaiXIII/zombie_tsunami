using UnityEngine;
using System;

public class Collectable : MonoBehaviour
{
    static public Action<Collectable> Collected;
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ZombieCollider>(out ZombieCollider zombie))
        {
            Interact(zombie);
            Destroy(this.gameObject);
        }
    }

    protected virtual void Interact(ZombieCollider other = null)
    {
        Collected?.Invoke(this);
    }
}
