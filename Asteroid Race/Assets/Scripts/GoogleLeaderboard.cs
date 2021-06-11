using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GoogleLeaderboard : MonoBehaviour
{
    private const string LEADER_BOARD = "CgkIh5ulyewBEAIQAA";

    private void Start() {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(success => 
        {
            if (success)
            {
                
            }
            else
            {
                
            }
        });

        AddScoreToLeaderBoard();
    }


    public void AddScoreToLeaderBoard()
    {
        Social.ReportScore((long) Mathf.Round(PlayerPrefs.GetFloat("Score")), LEADER_BOARD, (bool success) => {});
    }

    public void ShowLeaderBoardButton()
    {
        Social.ShowLeaderboardUI();
    }
    
}
