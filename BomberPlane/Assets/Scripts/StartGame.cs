using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public GameObject textRestart;
    public GameObject textBox;
    public GameObject bomb;
    public GameObject[] buildings;
    public GameObject plane;
    public int columns = 5;
    public int maxHeight = 4;
    public float startPositin = 5;
    public float buildingHeight = 0.5f;


    void MakeBoard()
    {
        //házépítés
        float distance = 5f / (columns - 1);
        for(int i = 0; i < columns; i++)
        {
            int height = Random.Range(1, maxHeight+1);
            for (int j = 0; j < height; j++)
            {
                Vector3 position = new Vector3(i * distance - 2.5f, buildingHeight * j - 2.5f, 0);
                GameObject randomBuilding = buildings[Random.Range(0, buildings.Length)];
                Instantiate(randomBuilding,position,Quaternion.identity);
            }
        }
    }

    void Start () {
        textRestart.GetComponent<Text>().text = "";
        textBox.GetComponent<Text>().text = "";
        MakeBoard();
        Vector3 pos = new Vector3(-3f,3f,0f);
        Instantiate(plane, pos, Quaternion.identity);
    }
	
    void GameOver()
    {
        //Játék végének ellenőrzése
        bool isHouse = false;
        bool isPlayer = false;
        GameObject[] objects = gameObject.scene.GetRootGameObjects();
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].tag == "Building") isHouse = true;
            else if (objects[i].tag == "Player") isPlayer = true;
        }
        if (!isPlayer)
        {
            textRestart.GetComponent<Text>().text = "Újraindítás-R\nKilépés - Esc";
            textBox.GetComponent<Text>().text = "Vesztettél!";
            ExitGame();
        }
        else if (!isHouse)
        {
            textRestart.GetComponent<Text>().text = "Újraindítás-R\nKilépés - Esc";
            textBox.GetComponent<Text>().text = "Nyertél!";
        }

    }

	void Update () {
        GameOver();
    }

    void Check()
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

    void ExitGame()
    {
        Check();
    }
}
