using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Preset : MonoBehaviour
{
    #region
    public static UI_Preset ins;
    public void REFERENCJA()
    {
        ins = this;
    }
    #endregion
    [Header("Referencje")]
    public AudioManager audiomanager;
    public GameObject okno_potwierdzenia_usuniecia;
    public GameObject okno_preset_Content;
    public GameObject okno_preset_dzwieki_content;
    public GameObject prefab_preset;
    public GameObject prefab_preset_dzwiek;
    public GameObject okno_nazywania_presetu;
    public UI_Nazywanie_Presetu nazywanie_presetu;
    [Header("Dane")]
    public List<Preset> lista_presetow;
    [HideInInspector]
    public int wartosc_potwierdzenia = 2;
    public Preset pytajacy_preset;
    
    
    public void BTN_StworzPreset()
    {
        Debug.Log("Stworz Preset");
        GameObject preset_go = Instantiate(prefab_preset);
        Preset preset = preset_go.GetComponent<Preset>();
        preset_go.transform.SetParent(okno_preset_Content.transform);

        //Debug.Log("lista dzwiekow count = " + audiomanager.lista_dzwiekow.Count);
        for (int i = 0; i < audiomanager.lista_dzwiekow.Count; i++)
        {
            GameObject temp_go = Instantiate(prefab_preset_dzwiek);
            temp_go.transform.SetParent(okno_preset_dzwieki_content.transform);
            Preset_Dzwiek temp_dzwiek = temp_go.GetComponent<Preset_Dzwiek>();
            Dzwiek dzwiek = audiomanager.lista_dzwiekow[i];
            UstawienieDanychPresetu(temp_dzwiek, dzwiek);
            preset.dzwieki.Add(temp_dzwiek);
        }
        lista_presetow.Add(preset);
    }

    private void UstawienieDanychPresetu(Preset_Dzwiek temp_dzwiek, Dzwiek dzwiek)
    {
        temp_dzwiek.aktywny = dzwiek.aktywny;
        temp_dzwiek.czestotliwosc = dzwiek.czestotliwosc_potworzen;
        temp_dzwiek.powtorzenia = dzwiek.ilosc_powtorzen;
        temp_dzwiek.glosnosc = dzwiek.src.volume;
        temp_dzwiek.petla = dzwiek.grane_w_petli;
    }


   public IEnumerator COROUTINE_WczytajPresety()
    {
        Debug_me.ins.LogT(3,"Rozpoczecie Wczytywania Presetow");
        Lista_Presetow_XML lista_presetow_XML;
        lista_presetow_XML = XML_Manager.Wczytaj_Liste_Presetow();

        foreach (Preset_XML preset_XML in lista_presetow_XML.lista_presetow)
        {
            GameObject temp_go = Instantiate(prefab_preset);
            temp_go.transform.SetParent(okno_preset_Content.transform);
            temp_go.transform.localScale = new Vector3(1, 1, 1);
            Preset temp_preset = temp_go.GetComponent<Preset>();
            for (int i = 0; i < preset_XML.dzwieki.Count; i++)
            {
                GameObject temp_ustawienia_go = Instantiate(prefab_preset_dzwiek);
                temp_ustawienia_go.transform.SetParent(okno_preset_dzwieki_content.transform);
                Preset_Dzwiek temp_dzwiek = temp_ustawienia_go.GetComponent<Preset_Dzwiek>();
                Preset_Dzwiek_XML dzwiek_XML = preset_XML.dzwieki[i];
                temp_dzwiek.aktywny = dzwiek_XML.aktywny;
                temp_dzwiek.czestotliwosc = dzwiek_XML.czestotliwosc;
                temp_dzwiek.powtorzenia = dzwiek_XML.powtorzenia;
                temp_dzwiek.glosnosc = dzwiek_XML.glosnosc;
                temp_dzwiek.petla = dzwiek_XML.petla;
                temp_preset.dzwieki.Add(temp_dzwiek);
            }
            temp_preset.nazwa.text = preset_XML.nazwa;
            lista_presetow.Add(temp_preset);
        }
        yield return null;
    }
    public void WczytajPresety2()
    {
        Debug_me.ins.LogT(-1,"Rozpoczecie Wczytywania Presetow");
        Lista_Presetow_XML lista_presetow_XML;
        lista_presetow_XML = XML_Manager.Wczytaj_Liste_Presetow();

        foreach (Preset_XML preset_XML in lista_presetow_XML.lista_presetow)
        {
            GameObject temp_go = Instantiate(prefab_preset);
            temp_go.transform.SetParent(okno_preset_Content.transform);
            Preset temp_preset = temp_go.GetComponent<Preset>();
            for (int i = 0; i < preset_XML.dzwieki.Count; i++)
            {
                GameObject temp_ustawienia_go = Instantiate(prefab_preset_dzwiek);
                temp_ustawienia_go.transform.SetParent(okno_preset_dzwieki_content.transform);
                Preset_Dzwiek temp_dzwiek = temp_ustawienia_go.GetComponent<Preset_Dzwiek>();
                Preset_Dzwiek_XML dzwiek_XML = preset_XML.dzwieki[i];
                temp_dzwiek.aktywny = dzwiek_XML.aktywny;
                temp_dzwiek.czestotliwosc = dzwiek_XML.czestotliwosc;
                temp_dzwiek.powtorzenia = dzwiek_XML.powtorzenia;
                temp_dzwiek.glosnosc = dzwiek_XML.glosnosc;
                temp_dzwiek.petla = dzwiek_XML.petla;
                temp_preset.dzwieki.Add(temp_dzwiek);
            }
            temp_preset.nazwa.text = preset_XML.nazwa;
            lista_presetow.Add(temp_preset);
        }
    }
    /*
    public void WczytajPresety()
    {
        Debug.Log("Wczytywanie Presetow");
        Debug_me.ins.LogT("Rozpoczecie Wczytywania Presetow");
        Inicjalizacja.ins.debug_me.UstawFunkcje("Wczytaj Presety");
        try
        {
            Lista_Presetow_XML lista_presetow_XML;
            try
            { 
                lista_presetow_XML = XML_Manager.Wczytaj_Liste_Presetow(); 
            }
            catch(Exception e)
            {
                Debug_me.ins.LogT("EXCEPTION = " + e.ToString());
                Inicjalizacja.ins.debug_me.UstawTekst(e.Message); 
            }
            lista_presetow_XML = XML_Manager.Wczytaj_Liste_Presetow();
            foreach (Preset_XML preset_XML in lista_presetow_XML.lista_presetow)
            {
                GameObject temp_go = Instantiate(prefab_preset);
                temp_go.transform.SetParent(okno_preset_Content.transform);
                Preset temp_preset = temp_go.GetComponent<Preset>();
                for (int i = 0; i < preset_XML.dzwieki.Count; i++)
                {
                    GameObject temp_ustawienia_go = Instantiate(prefab_preset_dzwiek);
                    temp_ustawienia_go.transform.SetParent(okno_preset_dzwieki_content.transform);
                    Preset_Dzwiek temp_dzwiek = temp_ustawienia_go.GetComponent<Preset_Dzwiek>();
                    Preset_Dzwiek_XML dzwiek_XML = preset_XML.dzwieki[i];
                    temp_dzwiek.aktywny = dzwiek_XML.aktywny;
                    temp_dzwiek.czestotliwosc = dzwiek_XML.czestotliwosc;
                    temp_dzwiek.powtorzenia = dzwiek_XML.powtorzenia;
                    temp_dzwiek.glosnosc = dzwiek_XML.glosnosc;
                    temp_dzwiek.petla = dzwiek_XML.petla;
                    temp_preset.dzwieki.Add(temp_dzwiek);
                }
                temp_preset.nazwa.text = preset_XML.nazwa;
                lista_presetow.Add(temp_preset);
            }
        }
        catch (Exception e)
        {
            Debug_me.ins.LogT("EXCEPTION = " + e.ToString());
            Inicjalizacja.ins.debug_me.UstawTekst(e.Message);   
        }

        Inicjalizacja.ins.krok = 5;
        Inicjalizacja.ins.debug_me.UstawFunkcje("Koniec Wczytywania Presetow");
    }
    */
    public void BTN_ZapiszListePresetow()
    {
        Debug.Log("Zapisz Liste Presetow");
        Lista_Presetow_XML lista_Presetow_XML = new Lista_Presetow_XML();
        lista_Presetow_XML.lista_presetow = new List<Preset_XML>();

        foreach(Preset preset in lista_presetow)
        {
            Preset_XML preset_xml = new Preset_XML();
            preset_xml.dzwieki = new List<Preset_Dzwiek_XML>();
            preset_xml.nazwa = preset.nazwa.text;
            for(int i = 0; i < preset.dzwieki.Count; i++)
            {
                Preset_Dzwiek preset_dzwiek = preset.dzwieki[i];
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

    /*
    public void ZapiszPresety()
    {
        List<Preset_XML> lista_presetow_XML = new List<Preset_XML>();
        Debug.Log("lista presetow xml = " + lista_presetow_XML);

        for(int i = 0; i < lista_presetow.Count; i++)
        {
            Preset_XML preset_xml = new Preset_XML();
            preset_xml.dzwieki = new List<Preset_Dzwiek_XML>();
            preset_xml.nazwa = lista_presetow[i].nazwa.text;
            for(int j = 0; j < lista_presetow[i].dzwieki.Count; j++)
            {
                Preset_Dzwiek_XML temp_p_XML = new Preset_Dzwiek_XML();
                temp_p_XML = lista_presetow[i].dzwieki[j];
                preset_xml.dzwieki.Add(temp_p_XML);
                Debug.Log("preset count = " + lista_presetow[i].dzwieki.Count);
                Debug.Log("xml count = " + preset_xml.dzwieki.Count);
            }
            lista_presetow_XML.Add(preset_xml);
            
        }

        Lista_Presetow_XML kompletna_lista = new Lista_Presetow_XML();
        kompletna_lista.lista_presetow = new List<Preset_XML>();
        kompletna_lista.lista_presetow = lista_presetow_XML;

        XML_Manager.Zapisz_Liste_Presetow(kompletna_lista);
    }
    public void BTN_UtworzPreset()
    {
        GameObject temp_go = Instantiate(prefab_preset);
        temp_go.transform.SetParent(okno_preset_Content.transform);
        Preset temp_pr = temp_go.GetComponent<Preset>();
        Dzwiek dzwiek;
        Debug.Log("dzwieki count = " + audiomanager.lista_dzwiekow.Count);
        for(int i = 0; i < audiomanager.lista_dzwiekow.Count; i++)
        {
            Preset_Dzwiek_XML temp_xml = new Preset_Dzwiek_XML();
            dzwiek = audiomanager.lista_dzwiekow[i];
            temp_xml.aktywny = dzwiek.aktywny;
            temp_xml.czestotliwosc = dzwiek.czestotliwosc_potworzen;
            temp_xml.powtorzenia = dzwiek.ilosc_powtorzen;
            temp_xml.glosnosc = dzwiek.src.volume;
            temp_xml.petla = dzwiek.grane_w_petli;
            temp_pr.dzwieki.Add(temp_xml);
        }
        lista_presetow.Add(temp_pr);
        PokazOknoNazywania(temp_pr);
    }
    public void WczytajPresety()
    {
        Lista_Presetow_XML lista_xml = XML_Manager.Wczytaj_Liste_Presetow();

        foreach(Preset_XML preset_XML in lista_xml.lista_presetow)
        {
            GameObject temp_go = Instantiate(prefab_preset);
            Preset preset = temp_go.GetComponent<Preset>();
            temp_go.transform.SetParent(okno_preset_Content.transform);
            preset.nazwa.text = preset_XML.nazwa;
            lista_presetow.Add(preset);

            foreach (Preset_Dzwiek_XML preset_dzwiek_xml in preset_XML.dzwieki)
            {   
                preset.dzwieki.Add(preset_dzwiek_xml);
            }
        }
    }

    */
    public void PokazOknoPotwierdzenia()
    {
        okno_potwierdzenia_usuniecia.transform.localScale = new Vector3(1, 1, 1);
    }
    public void BTN_Tak()
    {
        wartosc_potwierdzenia = 1;
        okno_potwierdzenia_usuniecia.transform.localScale = new Vector3(0, 0, 0);
        pytajacy_preset.Usun_Preset();
    }
    public void BTN_Nie()
    {
        wartosc_potwierdzenia = 0;
        pytajacy_preset = null;
        okno_potwierdzenia_usuniecia.transform.localScale = new Vector3(0, 0, 0);
    }

    public void PokazOknoNazywania(Preset preset)
    {
        okno_nazywania_presetu.transform.localScale = new Vector3(1,1,1);
        nazywanie_presetu.oczekujacy_preset = preset;
        nazywanie_presetu.write = true;
    }
    public void SchowajOknoNazywania()
    {
        nazywanie_presetu.write = false;
        okno_nazywania_presetu.transform.localScale = new Vector3(0, 0, 0);
    }

}
