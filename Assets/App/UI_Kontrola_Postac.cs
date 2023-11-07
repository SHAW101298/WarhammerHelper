using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Kontrola_Postac : MonoBehaviour
{
    public Image img;
    public void ZerujZdrowie()
    {
        GetComponentInChildren<Postac>().zdrowie_aktualne = 0;
        img.color = Color.gray;

        Glowny_Skrypt.ins.UI_Dane_Postaci.AktualizujDane(GetComponentInChildren<Postac>());
    }
}
