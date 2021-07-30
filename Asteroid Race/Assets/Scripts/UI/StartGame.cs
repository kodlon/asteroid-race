using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    public void StartGameButton()
    {
        Time.timeScale = 1.0f;
        menu.SetActive(false);
        BackgroundMoving.BackgroundActive = true;
        Player.GameActive = true;
    }
}
