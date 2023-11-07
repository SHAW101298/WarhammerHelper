using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Lokacje_Aktywne_Okna : MonoBehaviour
{
    #region
    public static UI_Lokacje_Aktywne_Okna ins;
    public void UtworzReferencje()
    {
        ins = this;
    }
    #endregion

    private void Start()
    {
        UtworzReferencje();
    }

    public UI_Lokacja ostatnia_lokacja;
    public GameObject karta_postaci;

    public void SchowajOstatnie()
    {
        Debug.Log("Schowaj Ostatnie");
        if (ostatnia_lokacja != null)
        {
            ostatnia_lokacja.SchowajWszystko();
        }
    }
    public void SchowajWszystko()
    {
        Debug.Log("Schowaj Wszystko");
        karta_postaci.SetActive(false);
    }
}
