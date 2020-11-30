using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int scoreIncrement = 0;
    public int cervejaQuant;
    public static int cervejaQuantidade;
    public static bool isPaused = false;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        cervejaQuantidade = cervejaQuant;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
    }

    
}
