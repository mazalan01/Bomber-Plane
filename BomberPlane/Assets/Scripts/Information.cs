using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Information : MonoBehaviour {

    public Text infoText;

    public void SetInformation()
    {
        if (infoText.text == "")
        {
            infoText.text = "Ebben a játékban, egy repülő segítségével kell minnél több házat lerombolnod. Bombát, a Space-billentyű lenyomásával tudsz ledobni. Egyszerre csak egy bomba lehet a képernyőn. Sok szerencsét! \n\n Készítette: Martinák Zalán";
        }
        else
        {
            infoText.text = "";
        }
    }

}
