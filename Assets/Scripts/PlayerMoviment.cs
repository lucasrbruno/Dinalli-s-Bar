using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    // Start is called before the first frame update
    public static int clientPosition;
    public GameObject beer;

    void Start()
    {
        clientPosition = 0;
        //print("posicao " + clientPosition + "\n");
        transform.position = new Vector2(5.37f, 2.01f);
    }

    // Update is called once per frame
    void Update()
    {
        //float verticalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("space"))
        {
            /*CERVEJA:
             * POSITION 0: newBeer.transform.position = new Vector2(3.86f, 2.59f);
             * POSITION 1: newBeer.transform.position = new Vector2(3.86f, -0.34f);
             * POSITION 2: newBeer.transform.position = new Vector2(3.86f, -2.98f);
             * 
             * 
             * */
            GameObject newBeer = Instantiate(beer);
            //newBeer.SetActive(true);
            switch (clientPosition)
            {

                case 0:
                    newBeer.transform.position = new Vector2(3.86f, 2.6f);
                    break;

                case 1:
                    newBeer.transform.position = new Vector2(3.86f, -0.18f);
                    break;

                case 2:
                    newBeer.transform.position = new Vector2(3.86f, -2.9f);
                    break;

            }
            SoundManagerScript.PlayGlassSound();
        }

        /*
         *  POSICAO 0 = transform.position = new Vector2(5.37f, 2.01f);
         *  POSICAO 1 = transform.position = new Vector2(5.37f, -0.86f);
         *  POSICAO 2 = transform.position = new Vector2(5.37f, -3.59f);
         * 
         * 
         * */

        if (Input.GetKeyDown("up"))
        {
            switch (clientPosition){
                case 0:
                    transform.position = new Vector2(5.37f, -3.59f);
                    clientPosition = 2;
                    break;
                case 1:
                    transform.position = new Vector2(5.37f, 2.01f);
                    clientPosition = 0;
                    break;

                case 2:
                    transform.position = new Vector2(5.37f, -0.86f);
                    clientPosition = 1;
                    break;


            }
            
            print("posicao do player " + clientPosition + "\n");

        } else if(Input.GetKeyDown("down"))
        {
            switch (clientPosition)
            {
                case 0:
                    transform.position = new Vector2(5.37f, -0.86f);
                    clientPosition= 1;
                    break;

                case 1:
                    transform.position = new Vector2(5.37f, -3.59f);
                    clientPosition = 2;
                    break;

                case 2:
                    transform.position = new Vector2(5.37f, 2.01f);
                    clientPosition = 0;
                    break;
            }
            print("posicao do player " + clientPosition + "\n");
        }


    }
}
