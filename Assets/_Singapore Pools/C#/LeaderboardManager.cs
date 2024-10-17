using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager _instance;
    private string leaderBoardID = "com.leaderboard.singaporepools";

    void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }


    #region GAME_CENTER

    public void OpenLeaderboard()
    {
        if (!Social.localUser.authenticated)
        {
            AuthenticateToGameCenter();
        }
        else
        {
            ShowLeaderboard();
        }
    }

    public void AuthenticateToGameCenter()
    {
#if UNITY_IPHONE
        Social.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("Authentication successful");
                ShowLeaderboard();
            }
            else
            {
                Debug.Log("Authentication failed");
            }
        });
#endif
    }

    public void ReportScore(int score)
    {
        Debug.Log("Reporting score " + score + " on leaderboard " + leaderBoardID);
#if UNITY_IPHONE
        Social.ReportScore(score, leaderBoardID, success =>
           {
               if (success)
               {
                   Debug.Log("Reported score successfully");
               }
               else
               {
                   Debug.Log("Failed to report score");
               }

               Debug.Log(success ? "Reported score successfully" : "Failed to report score"); Debug.Log("New Score:" + score);
           });
#endif
    }

    private void ShowLeaderboard()
    {
#if UNITY_IPHONE
        Social.ShowLeaderboardUI();
#endif
    }
    #endregion
}
