using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pomoc_Profesje_Kontrola : MonoBehaviour
{
    public static UI_Pomoc_Profesje_Kontrola ins;
    private void Start()
    {
        ins = this;
    }

    public GameObject ostatnie_aktywne;
    

    public void AktywujOkno(GameObject wywolujacy)
    {
        if(ostatnie_aktywne != null)
        ostatnie_aktywne.SetActive(false);

        ostatnie_aktywne = wywolujacy;
        ostatnie_aktywne.SetActive(true);
    }
}
