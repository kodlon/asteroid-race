using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    void Start()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("music");

        if (objects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this);
    }
}
