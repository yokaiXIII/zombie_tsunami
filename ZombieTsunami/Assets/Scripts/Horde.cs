using System.Collections.Generic;
using UnityEngine;

public class Horde : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _jumpPrefab;
    [SerializeField] private int _hordeInitSize = 2;
    [SerializeField] private Collider _hordeSpawnArea;

    private Vector3 _hordeSpawnAreaMin;
    private Vector3 _hordeSpawnAreaMax;

    private List<GameObject> _hordeMembers = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _hordeSpawnAreaMin = new Vector3(_hordeSpawnArea.bounds.min.x, _hordeSpawnArea.bounds.max.y, _hordeSpawnArea.bounds.min.z);
        _hordeSpawnAreaMax = new Vector3(_hordeSpawnArea.bounds.max.x, _hordeSpawnArea.bounds.max.y, _hordeSpawnArea.bounds.max.z);
        for (int i = 0; i < _hordeInitSize; i++)
        {
            AddHordeMember();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlaceJumpTrigger();
        }
    }

    void PlaceJumpTrigger()
    {
        GameObject headHordeMember = GetHeadHordeMember();
        GameObject jumpTrigger = Instantiate(_jumpPrefab, headHordeMember.transform.position, Quaternion.identity);
        jumpTrigger.transform.localScale = new Vector3(1, 1, 1);
        jumpTrigger.AddComponent<LaneMovement>();
    }

    void AddHordeMember()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(_hordeSpawnAreaMin.x, _hordeSpawnAreaMax.x), _hordeSpawnAreaMax.y, Random.Range(_hordeSpawnAreaMin.z, _hordeSpawnAreaMax.z));
        GameObject hordeMember = Instantiate(_prefab, spawnPosition, Quaternion.identity, this.transform);
        hordeMember.transform.localScale = new Vector3(1, 1, 1);

        _hordeMembers.Add(hordeMember);
    }
    
    GameObject GetHeadHordeMember()
    {
        GameObject headHordeMember = _hordeMembers[0];
        for (int i = 0; i < _hordeMembers.Count; i++)
        {
            if (headHordeMember.transform.position.x < _hordeMembers[i].transform.position.x)
            {
                headHordeMember = _hordeMembers[i];
            }

        }

        return headHordeMember;
    }
}
