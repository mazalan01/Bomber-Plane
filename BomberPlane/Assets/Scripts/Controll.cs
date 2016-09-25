using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Controll : MonoBehaviour {

    private Rigidbody2D rb2d;
    private bool stopped = false;

    public GameObject bomb;
    public float speed;
    public GameObject explode;


    void Start () {
        //Kezdő sebesség beállítása
        rb2d = GetComponent<Rigidbody2D>();
        Vector2 move = new Vector2(speed, 0);
        rb2d.AddForce(move);
    }

   

    void Bomba (){
        if (stopped) return;
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject[] objects = gameObject.scene.GetRootGameObjects();
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i].tag == "Bomb") return;
            }
                Vector2 bombPosition = rb2d.position;
                bombPosition.y -= 0.3f;
                Instantiate(bomb, bombPosition, Quaternion.identity);
        }
    }

    void Check()
    {
        GameObject[] obj = gameObject.scene.GetRootGameObjects();
        bool isThereHouse = false;
        for(int i = 0; i< obj.Length; i++)
        {
            if (obj[i].tag == "Building") isThereHouse = true;
        }
        if (!isThereHouse)
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("Game");
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    void Update () {

        Check();

        //Bombadobás ellenörzése
        Bomba();
        if (rb2d.position.y == -2.6f && rb2d.position.x>0f && rb2d.position.x < 1f)
        {
            if (stopped == false)
            {
                Vector2 move = new Vector2(-speed, 0);
                rb2d.AddForce(move);
                stopped = true;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject touch = other.gameObject;
        if (touch.tag == "Building")
        {
            //Játékos megsemmisülése
            Instantiate(explode, gameObject.GetComponent<Rigidbody2D>().position, Quaternion.identity);
            Destroy(touch);
            Destroy(gameObject);

        }
    }


}
