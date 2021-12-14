using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerUI : MonoBehaviour
{

    public Text ScoreText;
    public Text TimerText;
    public Text EnemyScoreText;
    public int MatchTime = 120;  
    private float StartTime = 0; 
    public int Score = 0; 
    public int EnemyScore = 0;
    private bool MatchActive = false;
    public GameOverScreen GameOverScreen; 
   

    void Start()
    {
        SetTimeDisplay(MatchTime);
        StartTime = Time.time; 
        MatchActive = true; 
         
    }

    public void GameOver()
    {
        
    }

    public void BlueTeamScore()
    {
        if(MatchActive)
        {
            EnemyScore++;
            EnemyScoreText.text = "Blue Score: "+EnemyScore.ToString();
           
        }
        
    }

    public void IncrementScore()
    {
        if(MatchActive)
        {
            Score++; 
            ScoreText.text = "Green Score: "+Score.ToString();
            
        }
        
        
    }
    
    
    void Update()
    {
        if(Time.time - StartTime < MatchTime)
        {
            float ElapsedTime = Time.time - StartTime; 
            SetTimeDisplay( MatchTime - ElapsedTime );
        }
       
        else 
        {
            MatchActive = false;
            SetTimeDisplay(0);
            ScoreText.color = Color.grey;
            TimerText.color = Color.grey;
            EnemyScoreText.color = Color.grey;
            
            
        }

        
    }

    private void SetTimeDisplay( float TimeDisplay )
    {
        TimerText.text = "Time: " + GetTimeDisplay( TimeDisplay ); 
    }

    private string GetTimeDisplay( float TimeToShow )
    {
        int SecondsToShow = Mathf.CeilToInt(TimeToShow);
        int Seconds = SecondsToShow % 60;
        string SecondsDisplay = ( Seconds < 10) ? "0"+Seconds.ToString() : Seconds.ToString();
        int Minutes = ( SecondsToShow - Seconds )  / 60; 
        return Minutes.ToString() + ":" + SecondsDisplay;
    } 
}
