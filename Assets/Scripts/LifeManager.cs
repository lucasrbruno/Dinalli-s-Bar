using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public static int life = 3;
    public Text lifeText;
    void Start()
    {
        lifeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        lifeText.text = "Vidas: " + life;
        if (life == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    public void perdeuVida(string message)
    {
        print(message);
        Time.timeScale = 0;
        life--;
        ScoreScript.scoreValue -= ScoreScript.scoreIncrement;
        ScoreScript.scoreIncrement = 0;
        StartCoroutine(Esperar());
        Time.timeScale = 1;
        print("Recomeçando fase. . .");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1);
    }
}

