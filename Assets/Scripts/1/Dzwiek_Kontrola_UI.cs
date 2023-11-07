using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dzwiek_Kontrola_UI : MonoBehaviour
{
    #region
    public static Dzwiek_Kontrola_UI ins;
    public void REFERENCJA()
    {
        ins = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    #endregion
    [Header("Skrypty")]
    public Dzwiek_Kontrola dzwieki;
    public Informacje_O_Dzwieku info;
    public Dzwiek_Tworzenie_1 tworzenie;
    [Header("Obiekty")]
    public GameObject okno_istniejacych_dzwiekow;
    public GameObject okno_tworzenia_dzwieku;
    [Header("Content")]
    public GameObject lista_dzwiekow_Content;
    public GameObject lista_wczytanych_WAV_Content;
    [Header("Prefaby")]
    public GameObject prefab_istniejacy_dzwiek;
    public GameObject prefab_wczytany_WAV;
    public GameObject prefab_preset;

    public IEnumerator COROUTINE_DokonczProcesDzwiekowy()
    {
        UtworzPrefabyZnalezionychWAV();
        dzwieki.WczytajPlikXML();
        StworzPrefabyWczytanychDzwiekow();
        dzwieki.UzupelnijDaneDzwiekow();

        yield return null;
    }

    void UtworzPrefabyZnalezionychWAV()
    {
        for (int i = 0; i < dzwieki.audioname.Count; i++)
        {
            GameObject temp_GO = Instantiate(prefab_wczytany_WAV);
            temp_GO.transform.SetParent(lista_wczytanych_WAV_Content.transform);
            temp_GO.transform.localScale = new Vector3(1, 1, 1);

            UI_dzwiek_wczytany temp_w = temp_GO.GetComponent<UI_dzwiek_wczytany>();
            temp_w.index = i;
            temp_w.nazwa_dzwieku.text = i + " | " + dzwieki.audioname[i];
        }
    }
    public void StworzPrefabyWczytanychDzwiekow()
    {
        Debug_me.ins.LogT(8, "Tworzenie Prefabow Wczytanych Dzwiekow");
        Lista_Dzwiekow_XML lista_xml = dzwieki.lista_Dzwiekow_XML;
        Debug_me.ins.LogT(8, "Lista Dzwiekow XML count = " + lista_xml.lista_dzwiekow_XML.Count);
        //Debug.Log("Stworz Prefaby Wczytanych Dzwiekow");
        //Debug.Log("Ilosc wczytanych = " + lista_xml.lista_dzwiekow_XML.Count);
        for (int i = 0; i < lista_xml.lista_dzwiekow_XML.Count; i++)
        {
            GameObject temp_go = Instantiate(prefab_istniejacy_dzwiek);
            Istniejacy_Dzwiek_1 temp_d = temp_go.GetComponent<Istniejacy_Dzwiek_1>();
            temp_go.transform.SetParent(lista_dzwiekow_Content.transform);
            dzwieki.lista_dzwiekow.Add(temp_d);
            temp_d.nazwa_dzwieku = lista_xml.lista_dzwiekow_XML[i].nazwa_dzwieku;
            temp_go.GetComponent<Istniejacy_Dzwiek_UI_1>().nazwa.text = temp_d.nazwa_dzwieku;
            temp_go.transform.localScale = new Vector3(1, 1, 1);
        }
        Debug_me.ins.LogT(8, "Stworzono Prefaby Wczytanych Dzwiekow");
    }

    void UtworzPrefabyZnalezionychDzwiekow()
    {
        Lista_Dzwiekow_XML lista_xml = dzwieki.lista_Dzwiekow_XML;
        Dzwiek_XML dzwiek_xml;
        Debug.Log("count = " + lista_xml.lista_dzwiekow_XML.Count);
        for (int i = 0; i < lista_xml.lista_dzwiekow_XML.Count; i++)
        {
            dzwiek_xml = lista_xml.lista_dzwiekow_XML[i];
            AudioClip clip = dzwieki.SprawdzCzyIstniejeOdpowiedniKlip(dzwiek_xml.nazwa_dzwieku);
            //Debug.Log(dzwiek_xml.id_dzwieku);
            GameObject temp_GO_dzwiek = Instantiate(prefab_istniejacy_dzwiek);
            temp_GO_dzwiek.transform.SetParent(lista_dzwiekow_Content.transform);
            Istniejacy_Dzwiek_1 temp_dzwiek = temp_GO_dzwiek.GetComponent<Istniejacy_Dzwiek_1>();

            temp_dzwiek.id_dzwieku = dzwieki.clip_list.IndexOf(clip);
            temp_dzwiek.nazwa_dzwieku = dzwiek_xml.nazwa_dzwieku;
            temp_dzwiek.ui.nazwa.text = dzwiek_xml.nazwa_dzwieku;
            temp_dzwiek.czestotliwosc_potworzen = dzwiek_xml.czestotliwosc_powtorzen;
            temp_dzwiek.ilosc_powtorzen = dzwiek_xml.ilosc_powtorzen;
            temp_dzwiek.grane_w_petli = dzwiek_xml.grane_w_petli;
            temp_dzwiek.src.loop = dzwiek_xml.grane_w_petli;
            temp_dzwiek.ui.UstawGlosnosc(dzwiek_xml.glosnosc);
            temp_dzwiek.src.clip = clip;
            temp_dzwiek.aktywny = dzwiek_xml.aktywny;
            dzwieki.lista_dzwiekow.Add(temp_dzwiek);
        }
    }

    public void BTN_DodajDzwiek()
    {
        Debug.Log("Dodaj Dzwiek");
        PokazOknoTworzenia();
    }
    public void BTN_ZapiszDzwiek()
    {
        tworzenie.BTN_DodajDzwiek();
        //Debug.LogWarning("Nie Utwrzona Funkcja");
    }
    public void BTN_ZapiszWszystkieDzwieki()
    {
        dzwieki.ZapiszStworzoneDzwiekiDoPliku();
    }

    public void PokazOknoTworzenia()
    {
        okno_istniejacych_dzwiekow.transform.localScale = new Vector3(0, 0, 0);
        okno_tworzenia_dzwieku.transform.localScale = new Vector3(1, 1, 1);
    }
    public void ResetujOkno()
    {
        okno_istniejacych_dzwiekow.transform.localScale = new Vector3(1, 1, 1);
        okno_tworzenia_dzwieku.transform.localScale = new Vector3(0, 0, 0);
    }

}
