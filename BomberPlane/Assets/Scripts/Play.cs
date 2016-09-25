using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour {
	// Use this for initialization
	void Start () {
    }

    public GameObject dif;

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

}
