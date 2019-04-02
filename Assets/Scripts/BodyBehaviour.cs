using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBehaviour : MonoBehaviour
{

    public static List<Vector2> snakeMovmentsHistory = new List<Vector2>();
    public static int snakeLenght = 0;
    private int bodyNumber;

    /*   public BodyBehaviour()
       {

       }*/

    // Start is called before the first frame update
    void Start()
    {
        snakeLenght++;
        bodyNumber = snakeLenght * 2;
        //  GetComponent<Rigidbody2D>().position = DotBehaviour.gridPosition;
    }

    private void FixedUpdate()
    {
        //snakeMovmentsHistory.Insert(0, DotBehaviour.gridPosition);

        /*if (snakeMovmentsHistory.Count >= snakeLenght + 1)
        {
            snakeMovmentsHistory.RemoveAt(snakeMovmentsHistory.Count - 1);
            // Destroy(snakeBody);
        }*/


        GetComponent<Rigidbody2D>().position = snakeMovmentsHistory[bodyNumber];


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Dot2x2")
        {
            Debug.Log("You lose");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
