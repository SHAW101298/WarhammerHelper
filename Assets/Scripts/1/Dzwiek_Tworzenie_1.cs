using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Dzwiek_Tworzenie_1 : MonoBehaviour
{
    [Header("Skrypty")]
    public Dzwiek_Kontrola kontrola;
    public Dzwiek_Kontrola_UI kontrola_ui;
    [Header("Referencje")]
    public InputField id_dzwieku;
    public InputField powtorzenia;
    public InputField czestotliwosc;
    public Toggle petla;
    [Header("Prefab")]
    public GameObject prefab_dzwieku;


    public void BTN_DodajDzwiek()
    {
        GameObject temp = Instantiate(prefab_dzwieku);
        Istniejacy_Dzwiek_1 nowy = temp.GetComponent<Istniejacy_Dzwiek_1>();

        try
        {
            nowy.id_dzwieku = int.Parse(id_dzwieku.text);
            nowy.czestotliwosc_potworzen = int.Parse(czestotliwosc.text);
            nowy.ilosc_powtorzen = int.Parse(powtorzenia.text);
            nowy.nazwa_dzwieku = kontrola.audioname[nowy.id_dzwieku];
            nowy.grane_w_petli = petla.isOn;
            nowy.ui.UstawGlosnosc(0.5f);
            nowy.aktywny = true;

            kontrola.lista_dzwiekow.Add(nowy);
            temp.transform.SetParent(kontrola_ui.lista_dzwiekow_Content.transform);
            temp.transform.localScale = new Vector3(1, 1, 1);
            nowy.src.clip = kontrola.clip_list[nowy.id_dzwieku];
            nowy.src.loop = petla.isOn;
        }
        catch(Exception e)
        {
            Debug.Log("e.message " + e.Message);
            Destroy(nowy);
            Destroy(temp);
        }
        

        ResetujTworzonyDzwiek();
        kontrola_ui.ResetujOkno();
        AktualizujDanewUI(nowy);
    }

    void ResetujTworzonyDzwiek()
    {
        czestotliwosc.text = "";
        powtorzenia.text = "";
        id_dzwieku.text = "";
        petla.isOn = false;
    }
    void AktualizujDanewUI(Istniejacy_Dzwiek_1 dzwiek)
    {
        dzwiek.GetComponent<Istniejacy_Dzwiek_UI_1>().nazwa.text = dzwiek.nazwa_dzwieku;
    }

}
