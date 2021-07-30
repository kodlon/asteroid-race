using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private bool active;

    public bool Active
    {
        get { return active; }
        set { active = value; }
    }

    [SerializeField] private float timerWait = 0.0f;

    private GameObject _item;
    private float timer = 0.0f;


    void Update()
    {
        if (active && Player.GameActive)
            Spawn();
    }


    private void Spawn()
    {
        if (timer >= Random.Range(1.5f, 3.0f))
        {
            _item = Instantiate(itemPrefab) as GameObject;

            timer = timerWait;
        }
        timer += Time.deltaTime;
    }
}
