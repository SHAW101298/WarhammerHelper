using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class Dzwiek_Kontrola : MonoBehaviour
{
    #region
    public static Dzwiek_Kontrola ins;
    public void REFERENCJA()
    {
        ins = this;
        lista_Dzwiekow_XML = new Lista_Dzwiekow_XML
        {
            lista_dzwiekow_XML = new List<Dzwiek_XML>()
        };
    }
    #endregion

    [Header("Referencje")]
    public GameObject prefab_Dzwiek;
    public Informacje_O_Dzwieku info;
    public Dzwiek_Kontrola_UI ui;


    [Header("Dzwieki")]
    public List<Istniejacy_Dzwiek_1> lista_dzwiekow;
    public List<AudioClip> clip_list;
    public List<string> audioname;
    [Header("Sciezka")]
    public string sciezka_do_folderu;
    public Lista_Dzwiekow_XML lista_Dzwiekow_XML;



    public IEnumerator COROUTINE_WczytajUtworyZFolderu()
    {
        Debug_me.ins.LogT(2, "START COROUTINE Wczytywanie Utworow z Folderu");
        if (!Directory.Exists(sciezka_do_folderu))
        {
            Debug_me.ins.LogT(2, "ERROR || NIE Istnieje sciezka do folderu dzwiekow = " + sciezka_do_folderu);
            Directory.CreateDirectory(sciezka_do_folderu);
        }
        else
        {
            Debug_me.ins.LogT(2, "Istnieje sciezka do folderu dzwiekow = " + sciezka_do_folderu);
        }

        if (Directory.Exists(sciezka_do_folderu))
        {
            DirectoryInfo info = new DirectoryInfo(sciezka_do_folderu);
            int temp_x = 0;
            foreach (FileInfo item in info.GetFiles("*.wav"))
            {
                temp_x++;
                audioname.Add(item.Name);
            }
            Debug_me.ins.LogT(2, "Ilosc dzwiekow w folderze = " + temp_x);
        }
        yield return null;

        Debug_me.ins.LogT(2, "START COROUTINE Load Audio File");
        yield return StartCoroutine(LoadAudioFile());

        Debug_me.ins.LogT(2, "FINISH COROUTINE Wczytywanie utworów z folderu");
        yield return null;
    }
    IEnumerator LoadAudioFile()
    {
        Debug_me.ins.LogT(2, "Coroutine");

        for (int i = 0; i < audioname.Count; i++)
        {
            Debug_me.ins.LogT(2, "Dzwiek " + i + " nazwa = " + audioname[i]);
            UnityWebRequest AudioFiles = UnityWebRequestMultimedia.GetAudioClip(sciezka_do_folderu + string.Format("{0}", audioname[i]), AudioType.WAV);
            yield return AudioFiles.SendWebRequest();

            Debug_me.ins.LogT(2, "Przeskoczyło Yield");
            if (AudioFiles.isNetworkError)
            {
                Debug_me.ins.LogT(2, "ERROR || Blad z plikiem audio = " + AudioFiles.error);
            }
            else
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(AudioFiles);
                clip.name = audioname[i];
                clip_list.Add(clip);
            }
        }
        Debug_me.ins.LogT(2, "Koniec Coroutine Load Audio File");
    }

    public void ZapiszStworzoneDzwiekiDoPliku()
    {
        Lista_Dzwiekow_XML lista_xml = new Lista_Dzwiekow_XML
        {
            lista_dzwiekow_XML = new List<Dzwiek_XML>()
        };

        for (int i = 0; i < lista_dzwiekow.Count; i++)
        {
            Dzwiek_XML dzwiek_xml = new Dzwiek_XML();
            Istniejacy_Dzwiek_1 dzwiek = lista_dzwiekow[i];

            dzwiek_xml.id_dzwieku = dzwiek.id_dzwieku;
            dzwiek_xml.nazwa_dzwieku = dzwiek.nazwa_dzwieku;
            dzwiek_xml.ilosc_powtorzen = dzwiek.ilosc_powtorzen;
            dzwiek_xml.czestotliwosc_powtorzen = dzwiek.czestotliwosc_potworzen;
            dzwiek_xml.glosnosc = dzwiek.src.volume;
            dzwiek_xml.grane_w_petli = dzwiek.src.loop;
            dzwiek_xml.aktywny = dzwiek.aktywny;

            lista_xml.lista_dzwiekow_XML.Add(dzwiek_xml);
        }
        XML_Manager.Zapisz_Liste_Dzwiekow(lista_xml);
    }
    public void WczytajPlikXML()
    {
        Debug_me.ins.LogT(7, "Wczytywanie Pliku XML Listy Utworzonych Dzwiekow");
        lista_Dzwiekow_XML = XML_Manager.Wczytaj_Liste_Dzwiekow();
        Debug_me.ins.LogT(7, "Wczytano Plik ");
    }
    public void UzupelnijDaneDzwiekow()
    {
        Debug_me.ins.LogT(9, "Uzupelnianie Danych Dzwiekow");
        Debug_me.ins.LogT(9, "Lista Dzwiekow.Count = " + lista_dzwiekow.Count);
        for (int i = 0; i < lista_dzwiekow.Count; i++)
        {
            Istniejacy_Dzwiek_1 dzwiek = lista_dzwiekow[i];
            Dzwiek_XML dzwiek_xml = lista_Dzwiekow_XML.lista_dzwiekow_XML[i];
            AudioClip clip;
            clip = SprawdzCzyIstniejeOdpowiedniKlip(lista_dzwiekow[i].nazwa_dzwieku);
            if (clip != null)
            {
                dzwiek.id_dzwieku = i;
                dzwiek.poprawny = true;
                dzwiek.src.clip = clip;
                dzwiek.ilosc_powtorzen = dzwiek_xml.ilosc_powtorzen;
                dzwiek.czestotliwosc_potworzen = dzwiek_xml.czestotliwosc_powtorzen;
                dzwiek.grane_w_petli = dzwiek_xml.grane_w_petli;
                dzwiek.src.volume = dzwiek_xml.glosnosc;
                dzwiek.src.loop = dzwiek_xml.grane_w_petli;
                Debug.Log("aktywny = " + dzwiek_xml.aktywny);
                dzwiek.aktywny = dzwiek_xml.aktywny;

                dzwiek.GetComponent<Istniejacy_Dzwiek_UI_1>().slider_glosnosc.value = dzwiek.src.volume;
            }
            else
            {
                dzwiek.poprawny = false;
            }
        }
        Debug_me.ins.LogT(9, "Uzupelniono Dane \n Oznaczanie Nieprawidlowych ");
        OznaczNieprawidlowe();
        Debug_me.ins.LogT(9, "Oznaczono Nieprawidlowe ");
    }
    public AudioClip SprawdzCzyIstniejeOdpowiedniKlip(string nazwa)
    {
        for (int i = 0; i < clip_list.Count; i++)
        {
            Debug.Log("=====");
            Debug.Log(nazwa + " | " + audioname[i]);
            if (audioname[i].Equals(nazwa))
            {
                Debug.Log("Znaleziono klip");
                return clip_list[i];
            }
        }
        return null;
    }
    public void OznaczNieprawidlowe()
    {
        foreach (Istniejacy_Dzwiek_1 dzwiek in lista_dzwiekow)
        {
            if (dzwiek.poprawny == false)
            {
                dzwiek.gameObject.GetComponent<Istniejacy_Dzwiek_UI_1>().tlo_img.color = Color.red;
            }
        }
    }
}
