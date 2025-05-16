using UnityEngine;

[CreateAssetMenu(fileName = "SpawnSequence", menuName = "Scriptable Objects/SpawnSequence")]
public class SpawnSequence : ScriptableObject
{
    public GameObject blockToSpawn = null;
    public SpawnSequence[] nextBlocks = null;

    public SpawnSequence GetNextBlock()
    {
        if (nextBlocks == null || nextBlocks.Length == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, nextBlocks.Length);
        return nextBlocks[randomIndex];
    }
}
