using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public Text scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.scoreEvent += ScoreChange;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void ScoreChange(int score)
    {
        if(scoreDisplay != null)
        {
            scoreDisplay.text = score.ToString();
        }
    }


    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
