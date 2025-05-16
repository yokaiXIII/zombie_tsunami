using UnityEngine;

public class GameController : Singleton<GameController>
{

    [SerializeField] float gameSpeedMultipler = 1f;

    public float GameSpeedMultipler
    {
        get { return gameSpeedMultipler; }
        private set { gameSpeedMultipler = value; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
