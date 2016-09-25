using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointController : MonoBehaviour {

    private int bildingAmount=0;
    private bool isChecked = false;

    void LateUpdate()
    {
        if (!isChecked)
        {
            GameObject[] objects = gameObject.scene.GetRootGameObjects();
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i].tag == "Building") bildingAmount++;
            }
            isChecked = true;
        }
    }


	void Update () {
        //pont számítás/kiírás
        int bildingAmountNow = 0;
        GameObject[] objects = gameObject.scene.GetRootGameObjects();
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].tag == "Building") bildingAmountNow++;
        }
        gameObject.GetComponent<Text>().text = "Pontszám:" + ( bildingAmount - bildingAmountNow );
	}
}