using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private AudioSource shootSound;
    private static bool active;

    public static bool Active
    {
        //get { return active; }   
        set { active = value; }
    }

    private GameObject _item;

    private float timer = 0.0f;


    void Update()
    {
        if (active && Player.GameActive)
            Spawn();
    }

    //TODO: Destroy bullets
    private void Spawn()
    {
        if (timer >= 1.0f)
        {
            shootSound.Play();
            
            _item = Instantiate(itemPrefab) as GameObject;
            _item.transform.position = transform.position;

            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
