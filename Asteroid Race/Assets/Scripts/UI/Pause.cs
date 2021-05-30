using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Sprite pauseSprite;

    private static bool isPaused = false;

    public static bool IsPaused
    {
        get { return isPaused; }
    }

    public void OnPausePressed()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            pauseButton.image.sprite = playSprite;
            Time.timeScale = 0.0f;
        }
        else
        {
            pauseButton.image.sprite = pauseSprite;
            Time.timeScale = 1.0f;
        }

    }
}
