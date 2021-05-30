using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [SerializeField] private SpawnItems[] asteroidsSpawner;


    private void Update()
    {
        if (Player.Score > 10000)
        {
            asteroidsSpawner[0].Active = true;
        }
        if (Player.Score > 20000)
        {
            asteroidsSpawner[1].Active = true;
        }
        else
        {
            asteroidsSpawner[0].Active = false;
            asteroidsSpawner[1].Active = false;
        }
    }

}
