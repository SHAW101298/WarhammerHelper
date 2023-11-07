using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Dzwieki : MonoBehaviour
{
    #region
    public static UI_Dzwieki ins;
    public void REFERENCJA()
    {
        ins = this;
    }
    #endregion

    [Header("Wczytane")]
    public GameObject prefab_Dzwiek;
    public GameObject prefab_wczytany;
    [Header("Content")]
    public GameObject lista_dzwiekow_Content;
    public GameObject lista_wczytanych_WAV_Content;
    [Header("Referencje")]
    public AudioManager audio_manager;
    public GameObject okno_tworzenia_dzwieku;
    public GameObject okno_istniejace_dzwieki;
    public GameObject okno_istniejacych;
    public GameObject okno_wczytanych;
    public GameObject okno_tworzenia;
    public GameObject okno_informacje;

    public Sprite audio_muted;
    public Sprite audio_playing;

    public Debug_me debug_me;


    public void PokazOkno()
    {
        okno_istniejace_dzwieki.transform.localScale = new Vector3(0, 0, 0);
        okno_tworzenia_dzwieku.transform.localScale = new Vector3(1, 1, 1);
        //okno_istniejacych.transform.localScale = new Vector3(0, 0, 0);
        //okno_informacje.transform.localScale = new Vector3(0, 0, 0);
        //okno_wczytanych.transform.localScale = new Vector3(1, 1, 1);
        //okno_tworzenia.transform.localScale = new Vector3(1, 1, 1);
    }
    public void ResetujOkno()
    {
        okno_istniejace_dzwieki.transform.localScale = new Vector3(1, 1, 1);
        okno_tworzenia_dzwieku.transform.localScale = new Vector3(0, 0, 0);
        //okno_istniejacych.transform.localScale = new Vector3(1, 1, 1);
        //okno_informacje.transform.localScale = new Vector3(1, 1, 1);
        //okno_wczytanych.transform.localScale = new Vector3(0, 0, 0);
        //okno_tworzenia.transform.localScale = new Vector3(0, 0, 0);
    }



    public void BTN_DodajDzwiek()
    {
        PokazOkno();
    }
    public void BTN_StworzDzwiek()
    {
        ResetujOkno();
    }

    public void StworzPrefabyWczytanychDzwiekow()
    {
        Debug_me.ins.LogT(8,"Tworzenie Prefabow Wczytanych Dzwiekow");
        Lista_Dzwiekow_XML lista_xml = audio_manager.lista_Dzwiekow_XML;
        Debug_me.ins.LogT(8, "Lista Dzwiekow XML count = " + lista_xml.lista_dzwiekow_XML.Count);
        //Debug.Log("Stworz Prefaby Wczytanych Dzwiekow");
        //Debug.Log("Ilosc wczytanych = " + lista_xml.lista_dzwiekow_XML.Count);
        for(int i = 0; i < lista_xml.lista_dzwiekow_XML.Count; i++)
        {
            GameObject temp_go = Instantiate(prefab_Dzwiek);
            Dzwiek temp_d = temp_go.GetComponent<Dzwiek>();
            temp_go.transform.SetParent(lista_dzwiekow_Content.transform);
            audio_manager.lista_dzwiekow.Add(temp_d);
            temp_d.nazwa_dzwieku = lista_xml.lista_dzwiekow_XML[i].nazwa_dzwieku;
            temp_go.GetComponent<UI_Dzwiek>().nazwa.text = temp_d.nazwa_dzwieku;
            temp_go.transform.localScale = new Vector3(1, 1, 1);
        }
        Debug_me.ins.LogT(8,"Stworzono Prefaby Wczytanych Dzwiekow");
    }


    public void StworzPrefabyZnalezionych_WAV()
    {
        Debug_me.ins.LogT(6,"Stworz Prefaby Znalezionych WAV");
        Debug_me.ins.LogT(6,"audio_manager.clip_list.Count = " + audio_manager.clip_list.Count);
        for (int i = 0; i < audio_manager.clip_list.Count; i++)
        {
            GameObject temp_go = Instantiate(prefab_wczytany);
            UI_dzwiek_wczytany temp_w = temp_go.GetComponent<UI_dzwiek_wczytany>();
            temp_go.transform.SetParent(lista_wczytanych_WAV_Content.transform);
            temp_go.transform.localScale = new Vector3(1, 1, 1);
            temp_w.index = i;
            temp_w.nazwa_dzwieku.text = i + " | " + audio_manager.audioname[i];
        }
        Debug_me.ins.LogT(6,"Zakonoczno Tworzenie Prefabow Znalezionych WAV");
    }
}
