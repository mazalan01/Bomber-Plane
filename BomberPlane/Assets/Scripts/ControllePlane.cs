using UnityEngine;
using System.Collections;

public class ControllePlane : MonoBehaviour {

    public float moveDown = 0.3f;


    void OnTriggerExit2D(Collider2D other)
    {
        GameObject touch = other.gameObject;
        if (touch.tag == "Player")
        {
            bool isHouse=false;
            GameObject[] objects = gameObject.scene.GetRootGameObjects();
            //Van-e több ház
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i].tag == "Building") isHouse = true;
            }
            //Ha van több ház, repülő leszállítása
            if (isHouse == false)
            {
                Vector2 position = new Vector2(-3.3f,-2.6f);
                touch.GetComponent<Rigidbody2D>().MovePosition(position);
            }
            //egyébként, 1 szintel lejjebb
            else
            {
                Vector2 position = touch.GetComponent<Rigidbody2D>().position;
                position.y -= moveDown;
                position.x = -3.3f;
                touch.GetComponent<Rigidbody2D>().MovePosition(position);
            }
        }
    }



}
