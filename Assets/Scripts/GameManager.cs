using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    private static GameManager _instance;
    private int _userScore = 0;
    private int _userHealth = 20;
    public static GameManager instance
    {
        get{
            if(_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }
    private GameManager() { }

    public void deadUnit(GameObject unit)
    {
        switch(unit.tag)
        {
            case "NPC":
                _userScore -= 10;
                if(_userScore <=-50)
                {
                    gameOver();
                }
                break;
            case "Enemy":
                _userScore++;
                break;
            case "Player":
                gameOver();
                break;
        }
        scoreEvent(_userScore);
    }

  

    public delegate void EventScoreHandler(int scores);
    public event EventScoreHandler scoreEvent = delegate { };


    private void gameOver()
    {
        scoreEvent = delegate { };
        SceneManager.LoadScene(0);
    }

}
