using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Explode : MonoBehaviour {

	void Start () {
        StartCoroutine(DestroyTime());
    }

    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject[] objects = gameObject.scene.GetRootGameObjects();
        for (int i = 0; i < objects.Length; i++)
        {
            //Csak akkor tűnik el, ha a játékos még él
            if (objects[i].tag == "Player") Destroy(gameObject);
        }
        
    }
}
