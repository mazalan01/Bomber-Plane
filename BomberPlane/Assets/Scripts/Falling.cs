using UnityEngine;
using System.Collections;

public class Falling : MonoBehaviour {
    public GameObject explode;
    private Rigidbody2D rb2d;
    public float speed;
    

	void Start () {
        //Kezdősebesség
        rb2d = GetComponent<Rigidbody2D>();
        Vector2 move = new Vector2(0, 5*-speed);
        rb2d.AddForce(move);
    }
	
	void FixedUpdate () {
        //Sebesség növelés
        rb2d = GetComponent<Rigidbody2D>();
        Vector2 move = new Vector2(0, -speed);
        rb2d.AddForce(move);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //"Robbanás"
        GameObject touch = other.gameObject;
        if (touch.tag == "Barrier")
        {
            Destroy(gameObject);
        }
        else if(touch.tag == "Building")
        {
            Instantiate(explode, gameObject.GetComponent<Rigidbody2D>().position, Quaternion.identity);
            Destroy(touch);
            Destroy(gameObject);
        }
    }

}
