using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text recordScore;
    [SerializeField] private ChangeSettings audioActive;

    private void Awake()
    {
        recordScore.text = "Record\n" + Mathf.Round(PlayerPrefs.GetFloat("Score")).ToString() + " km";

    }

    private void Update() {
        if (audioActive.Active)
            AudioListener.volume = 1.0f;
        else
            AudioListener.volume = 0.0f;
    }


}
