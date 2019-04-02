using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Destoyer
{
    public class Destroyer : MonoBehaviour
    {
        public static int i;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Dot2x2")
            {
                /*bool positionIsNotClear = true;
                do
                {*/
                    transform.position = new Vector2(Random.Range(-2.2f, 2.2f), Random.Range(-2.2f, 2.2f));
                   /* foreach (var item in BodyBehaviour.snakeMovmentsHistory)
                    {
                        if (transform.position != new Vector3(item.x, item.y))
                        {
                            positionIsNotClear = false;
                        }
                    }
                } while (positionIsNotClear);*/

            }
            //Instantiate(this.gameObject);
        }
    }
}
