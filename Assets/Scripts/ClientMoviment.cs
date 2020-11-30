using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClientMoviment : MonoBehaviour
{
    // Start is called before the first frame update

    public float clientSpeed;                //Floating point variable to store the player's movement speed.
    public float backSpeed;                //Floating point variable to store the player's movement speed.
    public Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private float x, y;
    private bool canQuit = false;
    public int position;
    public GameObject emptyGlass;
    private bool evitarBugDoCopo = true;
    public SpriteRenderer sprite;
    public Sprite spriteNormal;
    public Sprite spriteBebendo;
    public int quantCervejas;


   /* private void Awake()
    {
        emptyGlassScript = GameObject.FindObjectOfType<EmptyGlassScript>();
    }*/
    // Start is called before the first frame update
    void Start()
    {
        x = rb2d.position.x;
        y = rb2d.position.y;
        //print("x inicial igual a " + x);
        sprite = GetComponent<SpriteRenderer>();
        //rb2d = GetComponent<RigidBody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 movement = new Vector2(1.0f, 0.0f);
        //rb2d.AddForce(-movement * speed);
        if (!canQuit)
        {
            rb2d.velocity = new Vector2(clientSpeed, 0.0f);
        }
        else
        {
            rb2d.velocity = new Vector2(backSpeed, 0.0f);
            //print(rb2d.position.x);
        }

        if(rb2d.position.x >= 4.2)
        {
            perdeuVida("Cliente não atendido!");
        }


        if (rb2d.position.x <= x && canQuit)
        {
            quantCervejas--;
            if (quantCervejas == 0)
            {
                print("Cliente satisfeito!");
                rb2d.gameObject.SetActive(false);
                GameObject copoVazio = Instantiate(emptyGlass, new Vector2(x, y), transform.rotation);
                copoVazio.GetComponent<EmptyGlassScript>().setPosition(position);
            }
            else
            {
                sprite.sprite = spriteNormal;
                print("Cliente ainda quer mais!");
                GameObject copoVazio = Instantiate(emptyGlass, new Vector2(x, y), transform.rotation);
                copoVazio.GetComponent<EmptyGlassScript>().setPosition(position);
                canQuit = false;
                evitarBugDoCopo = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "cerveja"){
            if (evitarBugDoCopo)
            {
                sprite.sprite = spriteBebendo;
                DrinkSoundManagerScript.PlayDrinkSound();
                print("Bebendo a cerveja. . .");
                canQuit = true;
                ScoreScript.scoreValue += 10;
                ScoreScript.scoreIncrement += 10;
                col.gameObject.SetActive(false);
                evitarBugDoCopo = false;
            }
        }
         
        
    }

    public void perdeuVida(string message)
    {
        print(message);
        //Time.timeScale = 0;
        if(LifeManager.life > 1)
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
        perdeuVida("Cliente não atendido!");

    }*/

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        print("Colidiu com o cliente");
        canQuit = true;
        collision.gameObject.SetActive(false);
        rb2d.velocity = new Vector2(-0.5f, 0.0f);
    }*/
}

