using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeerMoviment : MonoBehaviour


{
    public float speed;                //Floating point variable to store the player's movement speed.

    public Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Start is called before the first frame update
    void Start()
    {
        //rb2d = GetComponent<RigidBody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Vector2 movement = new Vector2(1.0f, 0.0f);
        //rb2d.AddForce(-movement * speed);

        rb2d.velocity = new Vector2(speed, 0.0f);
        //print(rb2d.velocity);
        if (rb2d.position.x <= -11)
        {
            //EmptyGlassSoundScript.PlayBrokenGlassSound();
            //StartCoroutine(Esperar());
            perdeuVida("entregou cerveja sem cliente!");
        }
    }

    public void perdeuVida(string message)
    {
        print(message);
        //Time.timeScale = 0;
        if (LifeManager.life > 1)
        {
            ScoreScript.scoreValue -= ScoreScript.scoreIncrement;
            ScoreScript.scoreIncrement = 0;
        }
        LifeManager.life--;
        
        //StartCoroutine(Esperar());
        //Time.timeScale = 1;
        print("Recomeçando fase. . .");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   /* IEnumerator Esperar()
    {
        ScoreScript.isPaused = true;
        yield return new WaitForSeconds(1);
        ScoreScript.isPaused = false;
        perdeuVida("entregou cerveja sem cliente!");
    }*/
}
