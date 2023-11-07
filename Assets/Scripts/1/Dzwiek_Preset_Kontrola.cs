using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dzwiek_Preset_Kontrola : MonoBehaviour
{
    #region
    public static Dzwiek_Preset_Kontrola ins;
    public void REFERENCJA()
    {
        ins = this;
    }
    #endregion

    [Header("Skrypty")]
    public Dzwiek_Kontrola dzwiek_kontrola;
    public Dzwiek_Kontrola_UI dzwiek_kontrola_UI;
    [Header("Referencje")]
    public List<Preset_Dzwiekow_1> lista_presetow;
    public InputField input_field_nazwa_presetu;

    [Header("Obiekty")]
    public GameObject okno_preset_Content;
    public GameObject okno_dzwieki_presetow_Content;
    public GameObject okno_potwierdzenia_usuniecia;
    public GameObject okno_nazywania_preetu;
    [Header("Prefaby")]
    public GameObject prefab_preset;
    public GameObject prefab_dzwiek_w_presecie;

    public IEnumerator COROUTINE_WczytajPresety()
    {
        Lista_Presetow_XML lista_presetow_XML;
        lista_presetow_XML = XML_Manager.Wczytaj_Liste_Presetow();
        yield return null;
        Debug.Log("ilosc presetow XML = " + lista_presetow_XML.lista_presetow.Count);
        for(int i = 0; i < lista_presetow_XML.lista_presetow.Count; i++)
        {
            Preset_XML preset_XML = lista_presetow_XML.lista_presetow[i];
            GameObject temp_GO = Instantiate(prefab_preset);
            Preset_Dzwiekow_1 temp_preset = temp_GO.GetComponent<Preset_Dzwiekow_1>();
            temp_GO.transform.SetParent(okno_preset_Content.transform);
            temp_GO.transform.localScale = new Vector3(1, 1, 1);
            lista_presetow.Add(temp_preset);

            for(int j = 0; j < preset_XML.dzwieki.Count; j++)
            {
                GameObject temp_GO_Dzwiek = Instantiate(prefab_dzwiek_w_presecie);
                temp_GO_Dzwiek.transform.SetParent(okno_dzwieki_presetow_Content.transform);
                Preset_Dzwiek dzwiek_w_presecie = temp_GO_Dzwiek.GetComponent<Preset_Dzwiek>();
                dzwiek_w_presecie.aktywny = preset_XML.dzwieki[j].aktywny;
                dzwiek_w_presecie.czestotliwosc = preset_XML.dzwieki[j].czestotliwosc;
                dzwiek_w_presecie.glosnosc = preset_XML.dzwieki[j].glosnosc;
                dzwiek_w_presecie.petla = preset_XML.dzwieki[j].petla;
                dzwiek_w_presecie.powtorzenia = preset_XML.dzwieki[j].powtorzenia;
                temp_preset.dzwieki_w_presecie.Add(dzwiek_w_presecie);
            }
            temp_preset.nazwa_presetu.text = preset_XML.nazwa;
        }
    }

    public void BTN_ZapiszListePresetow()
    {
        Debug.Log("Zapisz Liste Presetow");
        Lista_Presetow_XML lista_Presetow_XML = new Lista_Presetow_XML();
        lista_Presetow_XML.lista_presetow = new List<Preset_XML>();

        foreach (Preset_Dzwiekow_1 preset in lista_presetow)
        {
            Preset_XML preset_xml = new Preset_XML();
            preset_xml.dzwieki = new List<Preset_Dzwiek_XML>();
            preset_xml.nazwa = preset.nazwa_presetu.text;
            for (int i = 0; i < preset.dzwieki_w_presecie.Count; i++)
            {
                Preset_Dzwiek preset_dzwiek = preset.dzwieki_w_presecie[i];
                //Debug.Log("count = " + preset.dzwieki.Count);
                //Debug.Log("preset dzwiek = " + preset_dzwiek);
                Preset_Dzwiek_XML preset_Dzwiek_XML = new Preset_Dzwiek_XML
                {
                    aktywny = preset_dzwiek.aktywny,
                    czestotliwosc = preset_dzwiek.czestotliwosc,
                    powtorzenia = preset_dzwiek.powtorzenia,
                    glosnosc = preset_dzwiek.glosnosc,
                    petla = preset_dzwiek.petla
                };
                preset_xml.dzwieki.Add(preset_Dzwiek_XML);
            }
            lista_Presetow_XML.lista_presetow.Add(preset_xml);
        }
        XML_Manager.Zapisz_Liste_Presetow(lista_Presetow_XML);
    }

    public void BTN_StworzPreset()
    {
        Debug.Log("Stworz Preset");
        
        input_field_nazwa_presetu.text = "";
        PokazOknoNazywaniaPresetu();
    }
    public void BTN_PotwierdzNazwe()
    {
        GameObject preset_go = Instantiate(prefab_preset);
        Preset_Dzwiekow_1 preset = preset_go.GetComponent<Preset_Dzwiekow_1>();
        preset_go.transform.SetParent(okno_preset_Content.transform);

        for (int i = 0; i < dzwiek_kontrola.lista_dzwiekow.Count; i++)
        {
            GameObject temp_go = Instantiate(prefab_dzwiek_w_presecie);
            temp_go.transform.SetParent(okno_dzwieki_presetow_Content.transform);
            Preset_Dzwiek temp_dzwiek = temp_go.GetComponent<Preset_Dzwiek>();
            Istniejacy_Dzwiek_1 dzwiek = dzwiek_kontrola.lista_dzwiekow[i];
            UstawienieDanychPresetu(temp_dzwiek, dzwiek);
            preset.dzwieki_w_presecie.Add(temp_dzwiek);
        }
        lista_presetow.Add(preset);
        preset.nazwa_presetu.text = input_field_nazwa_presetu.text;
        SchowajOknoNazywaniaPresetu();
    }
    void SchowajOknoNazywaniaPresetu()
    {
        okno_nazywania_preetu.transform.localScale = new Vector3(0, 0, 0);
    }
    void PokazOknoNazywaniaPresetu()
    {
        okno_nazywania_preetu.transform.localScale = new Vector3(1, 1, 1);
    }

    private void UstawienieDanychPresetu(Preset_Dzwiek temp_dzwiek, Istniejacy_Dzwiek_1 dzwiek)
    {
        temp_dzwiek.aktywny = dzwiek.aktywny;
        temp_dzwiek.czestotliwosc = dzwiek.czestotliwosc_potworzen;
        temp_dzwiek.powtorzenia = dzwiek.ilosc_powtorzen;
        temp_dzwiek.glosnosc = dzwiek.src.volume;
        temp_dzwiek.petla = dzwiek.grane_w_petli;
    }

    public void PokazOknoPotwierdzenia()
    {
        okno_potwierdzenia_usuniecia.transform.localScale = new Vector3(1, 1, 1);
    }
}
