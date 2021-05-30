using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSettings : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;
    [SerializeField] private AudioSource menuSound;

    private bool active = true;
    public bool Active
    {
        get { return active; }
    }


    private void Awake()
    {
        active = !Convert.ToBoolean(PlayerPrefs.GetInt("ChangeSettings" + gameObject.name));
        OnChange();
    }


    public void OnChange()
    {
        menuSound.Play();
        active = !active;

        image.sprite = active ? on: off;

        PlayerPrefs.SetInt("ChangeSettings" + gameObject.name, Convert.ToInt32(active));
    }
}
