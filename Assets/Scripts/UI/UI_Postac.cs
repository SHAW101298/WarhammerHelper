using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Postac : MonoBehaviour
{
    public List<Postac> lista_postaci;
    public GameObject prefab_postaci;
    public GameObject postacie_content;
    public Postac wybrana_postac;
    //public Cechy cechy_wybranej_postaci;
    public Color aktywne_pisanie;
    public Color brak_pisania;
    [Header("Dane Wyswietlanej Postaci")]
    public UI_Pisanie_Postac WW;
    public UI_Pisanie_Postac US;
    public UI_Pisanie_Postac Krz;
    public UI_Pisanie_Postac ODP;
    public UI_Pisanie_Postac ZR;
    public UI_Pisanie_Postac INT;

    internal void WcisnietoPostac(Postac postac)
    {
        wybrana_postac = postac;
        UzupelnijDanePostaci(postac);
    }

    public UI_Pisanie_Postac SW;
    public UI_Pisanie_Postac OG;
    [Space(10)]
    public UI_Pisanie_Postac Zywotnosc;
    public UI_Pisanie_Postac Ataki;
    public UI_Pisanie_Postac Sila;
    public UI_Pisanie_Postac Wytrzymalosc;
    public UI_Pisanie_Postac Szybkosc;
    public UI_Pisanie_Postac Magia;
    public UI_Pisanie_Postac Punkty_Obledu;
    public UI_Pisanie_Postac Punkty_Przeznaczenia;


    public void UzupelnijDanePostaci(Postac postac)
    {
        WW.tekst.text = postac.cechy.Walka_Wrecz.aktualna.ToString();
        US.tekst.text = postac.cechy.Umiejetnosci_Strzeleckie.aktualna.ToString();
        Krz.tekst.text = postac.cechy.Krzepa.aktualna.ToString();
        ODP.tekst.text = postac.cechy.Odpornosc.aktualna.ToString();
        ZR.tekst.text = postac.cechy.Zrecznosc.aktualna.ToString();
        INT.tekst.text = postac.cechy.Inteligencja.aktualna.ToString();
        SW.tekst.text = postac.cechy.Sila_Woli.aktualna.ToString();
        OG.tekst.text = postac.cechy.Oglada.aktualna.ToString();
        Zywotnosc.tekst.text = postac.cechy.Zywotnosc.aktualna.ToString();
        Ataki.tekst.text = postac.cechy.Ataki.aktualna.ToString();
        Sila.tekst.text = (postac.cechy.Krzepa.aktualna / 10).ToString();
        Wytrzymalosc.tekst.text = (postac.cechy.Odpornosc.aktualna / 10).ToString();
        Szybkosc.tekst.text = postac.cechy.Szybkosc.aktualna.ToString();
        Magia.tekst.text = postac.cechy.Magia.aktualna.ToString();
        Punkty_Obledu.tekst.text = postac.cechy.Punkty_Obledu.aktualna.ToString();
        Punkty_Przeznaczenia.tekst.text = postac.cechy.Punkty_Przeznaczenia.aktualna.ToString();
    }

    public void AktualizujDanePostaci()
    {
        wybrana_postac.cechy.Walka_Wrecz.aktualna = int.Parse(WW.tekst.text);
        wybrana_postac.cechy.Umiejetnosci_Strzeleckie.aktualna = int.Parse(US.tekst.text);
        wybrana_postac.cechy.Krzepa.aktualna = int.Parse(Krz.tekst.text);
        wybrana_postac.cechy.Odpornosc.aktualna = int.Parse(ODP.tekst.text);
        wybrana_postac.cechy.Zrecznosc.aktualna = int.Parse(ZR.tekst.text);
        wybrana_postac.cechy.Inteligencja.aktualna = int.Parse(INT.tekst.text);
        wybrana_postac.cechy.Sila_Woli.aktualna = int.Parse(SW.tekst.text);
        wybrana_postac.cechy.Oglada.aktualna = int.Parse(OG.tekst.text);

        wybrana_postac.cechy.Ataki.aktualna = int.Parse(Ataki.tekst.text);
        wybrana_postac.cechy.Zywotnosc.aktualna = int.Parse(Zywotnosc.tekst.text);
        wybrana_postac.cechy.Sila.aktualna = int.Parse(Sila.tekst.text);
        wybrana_postac.cechy.Wytrzymalosc.aktualna = int.Parse(Wytrzymalosc.tekst.text);
        wybrana_postac.cechy.Magia.aktualna = int.Parse(Magia.tekst.text);
        wybrana_postac.cechy.Punkty_Obledu.aktualna = int.Parse(Punkty_Obledu.tekst.text);
        wybrana_postac.cechy.Punkty_Przeznaczenia.aktualna = int.Parse(Punkty_Przeznaczenia.tekst.text);
    }

    public void BTN_StworzPostac()
    {
        GameObject temp_go = Instantiate(prefab_postaci);
        temp_go.transform.SetParent(postacie_content.transform);
        temp_go.transform.localScale = new Vector3(1, 1, 1);
        wybrana_postac = temp_go.GetComponent<Postac>();
        UzupelnijDanePostaci(wybrana_postac);
    }
    public void ZmienionoWartosc()
    {
    }

    public void BTN_ZapiszListePostaci()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
