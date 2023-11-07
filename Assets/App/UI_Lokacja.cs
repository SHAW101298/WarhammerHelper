using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Lokacja : MonoBehaviour
{
    public UI_Lokacje_Aktywne_Okna okno;
    public bool pokazanie;
    public GameObject obiekt;

    public void Awake()
    {
    }

    public void WcisnietyPrzycisk()
    {
        pokazanie = !pokazanie;
        obiekt.SetActive(pokazanie);

        okno.SchowajOstatnie();

        if (pokazanie == true)
        {
            okno.ostatnia_lokacja = this;
        }
        else
        {
            okno.SchowajWszystko();
            okno.ostatnia_lokacja = null;
        }


        
    }
    public void SchowajWszystko()
    {
        obiekt.SetActive(false);
        pokazanie = false;
    }

}
