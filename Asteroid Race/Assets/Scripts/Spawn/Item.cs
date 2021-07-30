using UnityEngine;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{
    [SerializeField] private SpriteRenderer alert;
    [SerializeField] private GameObject[] item;
    private GameObject _item;

    private float timer = 0.0f;

    private void Start()
    {
        float randomScale = Random.Range(4.0f, 7.0f);
        float randomPosition = Random.Range(-2.3f, 2.3f);
        int randomItem= Random.Range(0, item.Length);

        item[randomItem].transform.Rotate(0, 0, Random.Range(0, 360));
        if (item[randomItem].CompareTag("asteroid"))
            item[randomItem].transform.localScale = new Vector3(randomScale, randomScale, 0);

        _item = Instantiate(item[randomItem]) as GameObject;
        _item.transform.position = new Vector3(randomPosition, 6.4f, 0);
        this.transform.position = new Vector3(randomPosition, 6.4f, 0);

        Destroy(_item, 5f);
    }

    private void Update()
    {
        if (timer > 2.0f)
        {
            alert.enabled = false;

            Destroy(gameObject, 4);
        }

        timer += Time.deltaTime;
    }
}
