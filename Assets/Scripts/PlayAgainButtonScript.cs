using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButtonScript : MonoBehaviour
{
   public void OnButtonPress()
    {
        ScoreScript.scoreValue = 0;
        ScoreScript.scoreIncrement = 0;
        LifeManager.life = 3;
        SceneManager.LoadScene("Fase 1");
    }
}
