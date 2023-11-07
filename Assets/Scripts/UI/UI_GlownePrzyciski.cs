using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GlownePrzyciski : MonoBehaviour
{
    [Header("Skrypty")]
    public Inicjalizacja_1 ini;
    [Header("Przyciski")]
    public GameObject mapa_BTN;
    public GameObject postac_BTN;
    public GameObject grupa_BTN;
    public GameObject dzwiek_BTN;
    public GameObject pomoc_BTN;
    [Header("Okna")]
    public GameObject mapa_okno;
    public GameObject postac_okno;
    public GameObject grupa_okno;
    public GameObject dzwiek_okno;
    public GameObject pomoc_okno;
    [Header("Debug")]
    public GameObject aktywne_okno;
    public GameObject aktywny_przycisk;
    
    public Vector3 ruch_przycisku = new Vector3(-30,0,0);

    public void BTN_Mapa()
    {
        if(aktywne_okno != mapa_okno)
        {
            PokazOkno(mapa_okno, mapa_BTN);
        }
    }
    public void BTN_Postac()
    {
        if (aktywne_okno != postac_okno)
        {
            PokazOkno(postac_okno, postac_BTN);
        }
    }
    public void BTN_Grupa()
    {
        if (aktywne_okno != grupa_okno)
        {
            PokazOkno(grupa_okno, grupa_BTN);
        }
    }
    public void BTN_Dzwiek()
    {
        if (aktywne_okno != dzwiek_okno)
        {
            ini.dzwieki_UI.ResetujOkno();
            PokazOkno(dzwiek_okno, dzwiek_BTN);
        }
    }
    public void BTN_Pomoc()
    {
        if (aktywne_okno != pomoc_okno)
        {
            PokazOkno(pomoc_okno, pomoc_BTN);
        }
    }

    public void PokazOkno(GameObject okno, GameObject btn)
    {
        if(aktywne_okno != null)
        {
            aktywne_okno.transform.localScale = new Vector3(0, 0, 0);
        }
        okno.transform.localScale = new Vector3(1, 1, 1);
        aktywne_okno = okno;


        if (aktywny_przycisk != null)
        {
            aktywny_przycisk.transform.Translate(-ruch_przycisku);
        }
        btn.transform.Translate(ruch_przycisku);
        aktywny_przycisk = btn;
    }
}
