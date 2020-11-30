using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmptyGlassScript : MonoBehaviour
{
    public float speed;                //Floating point variable to store the player's movement speed.

    public Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private int position;

    public void setPosition(int position)
    {
        this.position = position;
    }
    // Start is called before the first frame update
    void Start()
    {
        print("copo vazio na posicao = " + position);
    }

    // Update is called once per frame
    void Update()
    {
            rb2d.velocity = new Vector2(speed, 0.0f);

            if (rb2d.position.x >= 3.7f)
                if (position == PlayerMoviment.clientPosition)
                {
                    PegouCopoVazioScript.PlayBrokenGlassSound();
                    ScoreScript.cervejaQuantidade--;
                    print("player pegou o copo vazio! Copos restantes: " + ScoreScript.cervejaQuantidade);

                    if (ScoreScript.cervejaQuantidade == 0)
                    {
                        passouDeFase();
                    }
                    ScoreScript.scoreValue += 10;
                    ScoreScript.scoreIncrement += 10;
                    rb2d.gameObject.SetActive(false);

                }
                else if (rb2d.position.x >= 4.4f)
                {
                //EmptyGlassSoundScript.PlayBrokenGlassSound();
                //StartCoroutine(Esperar());
                    perdeuVida("Deixou a cerveja cair!");
            }
    }

    public void perdeuVida(string message)
    {
        print(message);
        //ScoreScript.isPaused = true;
        if(LifeManager.life > 1)
        {
            ScoreScript.scoreValue -= ScoreScript.scoreIncrement;
            ScoreScript.scoreIncrement = 0;
        }  
        LifeManager.life--;      
        print("Recomeçando fase. . .");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void passouDeFase()
    {
        //Time.timeScale = 0;
        ScoreScript.scoreIncrement = 0;
        //ScoreScript.isPaused = true;
        //StartCoroutine(Esperar());
       // Time.timeScale = 1;
        switch (SceneManager.GetActiveScene().name)
        {
            case "Fase 1":
                SceneManager.LoadScene("Fase 2");
                break;

            case "Fase 2":
                SceneManager.LoadScene("Fase 3");
                break;

            case "Fase 3":
                SceneManager.LoadScene("Fase 4");
                break;

            case "Fase 4":
                SceneManager.LoadScene("You Won");
                break;



        }
    }

   /* IEnumerator Esperar()
    {
        ScoreScript.isPaused = true;
        Time.timeScale = 0;
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
        ScoreScript.isPaused = false;
        perdeuVida("Deixou a cerveja cair!");
    }*/

    /* private void OnTriggerEnter2D(Collider2D other)
     {

     }*/
}
