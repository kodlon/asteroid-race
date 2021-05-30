using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    public void StartGameButton()
    {
        
        menu.SetActive(false);
        BackgroundMoving.BackgroundActive = true;
        Player.GameActive = true;
    }
}
