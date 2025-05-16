using UnityEngine;

public class ZombieCollider : MonoBehaviour
{
    [SerializeField] private Zombie _zombie;

    public Zombie Zombie{ get => _zombie; }

    public void Jump()
    {
        _zombie.Jump();
    }
}
