using UnityEngine;
using System;

public class Collectable : MonoBehaviour
{
    static public Action<Collectable> Collected;
    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        if (other.gameObject.TryGetComponent<ZombieCollider>(out ZombieCollider zombie))
        {
            Interact();
            Destroy(this.gameObject);
        }
    }

    protected virtual void Interact(){}
}
