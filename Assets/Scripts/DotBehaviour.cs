using System.Collections.Generic;
using UnityEngine;
//using CodeMonkey.Utils;
//using Destoyer;

public class DotBehaviour : MonoBehaviour
{

    public float speed = 20;
    private int vertMove;  //1 - up, -1 - down, 0 - stop
    private int horzMove;  //1 - right, -1 - down, 0 - stop
    private float vertDirection = 0;
    private float horzDirection = 0;
    public GameObject dot;
    public GameObject food;
    public GameObject snakeBody;
    public static float counter = 1;
    private float saveVertDir;
    private float saveHorzDir;
    //public static int snakeLenght = 3;
    private List<Vector2> snakeMoventsHistory = new List<Vector2>();
    public static Vector2 gridPosition = new Vector2();
    static int count = 0;



    // Start is called before the first frame update
    void Start()
    {
       /* for(int i=0;i<snakeLenght;i++)
        snakeBody = Instantiate(snakeBody);*/
    }

    private void FixedUpdate()
    {
        gridPosition.x = GetComponent<Rigidbody2D>().position.x;
        gridPosition.y = GetComponent<Rigidbody2D>().position.y;
        //snakeBody.transform.position = new Vector2(count, 0);
        //snakeBody.GetComponent<Rigidbody2D>().position = new Vector2(count,0);
        if(snakeBody)
        {
            BodyBehaviour.snakeMovmentsHistory.Insert(0, gridPosition);
            //BodyBehaviour.snakeLenght++;
        }
        SnakeMovements();
       // snakeBody.GetComponent<Rigidbody2D>().position = gridPosition;
        //gridPosition = Vector2(, y: dot.transform.position.y);


      /*  snakeMoventsHistory.Insert(0, gridPosition);
        if (snakeMoventsHistory.Count >= snakeLenght + 1)
        {
            snakeMoventsHistory.RemoveAt(snakeMoventsHistory.Count - 1);
            // Destroy(snakeBody);
        }

        for (int i = 0; i < snakeMoventsHistory.Count; i++)
        {
            Debug.Log(snakeMoventsHistory[i].x + " " + snakeMoventsHistory[i].y);
            Vector2 snakeMovePosition = snakeMoventsHistory[i];
            snakeBody.GetComponent<Rigidbody2D>().position = snakeMovePosition;
            //World_Sprite worldSprite = World_Sprite.Create(new Vector3(snakeMovePosition.x, snakeMovePosition.y), Vector3.one * .5f, Color.white);

            //snakeBody.transform.position = snakeMovePosition;
        }*/


    }


    private void SnakeMovements()
    {
        vertDirection = Input.GetAxisRaw("Vertical");
        horzDirection = Input.GetAxisRaw("Horizontal");
        if (horzDirection < 0 && GetComponent<Rigidbody2D>().velocity.x > 0 ||
            horzDirection > 0 && GetComponent<Rigidbody2D>().velocity.x < 0 ||
            vertDirection < 0 && GetComponent<Rigidbody2D>().velocity.y > 0 ||
            vertDirection > 0 && GetComponent<Rigidbody2D>().velocity.y < 0)
            return;
        if (saveHorzDir < 0 && horzDirection > 0)
        {
            return;
        }
        if (saveHorzDir > 0 && horzDirection < 0)
        {
            return;
        }
        if (vertDirection < 0)
        {
            vertMove = -1; //down
            horzMove = 0; //stop
            horzDirection = 0;
        }
        else if (vertDirection > 0)
        {
            vertMove = 1; //up
            horzMove = 0; //stop
            horzDirection = 0;
        }

        if (horzDirection < 0)
        {
            horzMove = -1; //left
            vertMove = 0;  //stop
            vertDirection = 0;
        }
        else if (horzDirection > 0)
        {
            horzMove = 1; //right
            vertMove = 0; //right
            vertDirection = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, vertMove) * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "HorzWallTop" ||
            collision.gameObject.name == "HorzWallBottom") // collision scenario with horizontal walls
        {
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        }
        if (collision.gameObject.name == "VertWallRight" ||
            collision.gameObject.name == "VertWallLeft") //collision scenario with vertical walls
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }
        if(collision.gameObject.name == "Food")
        {
            Instantiate(snakeBody,gridPosition,Quaternion.identity);

            //BodyBehaviour.snakeLenght++;
        }
        /*if(collision.gameObject.name == "BodyPart")
        {
            Destroy(snakeBody);
        }*/
    }

}
