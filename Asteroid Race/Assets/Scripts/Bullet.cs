using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private AudioSource asteroidSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "asteroid")
        {
            asteroidSound.Play();
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
    }
}
