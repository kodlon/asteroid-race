using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private SpriteRenderer alert;
    [SerializeField] private GameObject item;

    private float timer = 0.0f;

    private void Start()
    {
        float randomScale = Random.Range(4.0f, 7.0f);

        item.transform.Rotate(0, 0, Random.Range(0, 360));
        if (item.tag == "asteroid")
            item.transform.localScale = new Vector3(randomScale, randomScale, 0);
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
