using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class AudioManager : MonoBehaviour
{
    #region
    public static AudioManager ins;
    public void REFERENCJA()
    {
        ins = this;
        lista_Dzwiekow_XML = new Lista_Dzwiekow_XML();
        lista_Dzwiekow_XML.lista_dzwiekow_XML = new List<Dzwiek_XML>();
    }
    #endregion
    [Header("Dzwieki")]
    public List<Dzwiek> lista_dzwiekow;
    public List<AudioClip> clip_list;
    public List<string> audioname;
    [Header("Sciezka")]
    public string sciezka_do_folderu;
    [SerializeField]
    public Lista_Dzwiekow_XML lista_Dzwiekow_XML;

    [Header("Referencje")]
    public GameObject prefab_Dzwiek;
    public Informacje_O_Dzwieku info;
    public Dzwiek_Kontrola_UI ui;

    // Wczytywanie dzwiekow z folderu do listy
    IEnumerator LoadAudioFile()
    {
        Debug_me.ins.LogT(2,"Coroutine");
        //Debug.Log("Coroutine");
        //Debug.Log("Sciezka = " + sciezka_do_folderu);
        for (int i = 0; i < audioname.Count; i++)
        {
            Debug_me.ins.LogT(2,"Dzwiek " + i + " nazwa = " + audioname[i]);
            //Debug.Log("FOR");
            UnityWebRequest AudioFiles = UnityWebRequestMultimedia.GetAudioClip(sciezka_do_folderu + string.Format("{0}", audioname[i]), AudioType.WAV);
            yield return AudioFiles.SendWebRequest();
            Debug_me.ins.LogT(2,"Przeskoczyło Yield");
            if (AudioFiles.isNetworkError)
            {
                Debug_me.ins.LogT(2,"ERROR || Blad z plikiem audio = " + AudioFiles.error);
            }
            else
            {
                //Debug.Log("ELSE");
                AudioClip clip = DownloadHandlerAudioClip.GetContent(AudioFiles);
                clip.name = audioname[i];
                clip_list.Add(clip);
                //Debug.Log(sciezka_do_folderu + string.Format("{0}", audioname[i]));
            }
        }
        //Debug.Log("FINISH");

        Debug_me.ins.LogT(2,"Koniec Coroutine Load Audio File");
    }


    public IEnumerator COROUTINE_WczytajUtworyZFolderu()
    {
        Debug_me.ins.LogT(2, "START COROUTINE Wczytywanie Utworow z Folderu");
        Inicjalizacja.ins.debug_me.UstawFunkcje("Wczytaj Utwory z Folderu");
        if (!Directory.Exists(sciezka_do_folderu))
        {
            Debug_me.ins.LogT(2, "ERROR || NIE Istnieje sciezka do folderu dzwiekow = " + sciezka_do_folderu);
            Directory.CreateDirectory(sciezka_do_folderu);
        }
        else
        {
            Debug_me.ins.LogT(2, "Istnieje sciezka do folderu dzwiekow = " + sciezka_do_folderu);
        }
        //Debug.Log("Wczytaj Utwory z Folderu");
        

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
        //Debug.Log("Start Coroutine");
        yield return StartCoroutine(LoadAudioFile());
        Debug_me.ins.LogT(2, "FINISH COROUTINE Wczytywanie utworów z folderu");
        yield return null;
    }

    // Dodawanie nazwy dzwiekow z folderu do listy 
    public void WczytajUtworyZFolderu()
    {
        Debug_me.ins.LogT(2,"Wczytywanie Utworow z Folderu");
        Inicjalizacja.ins.debug_me.UstawFunkcje("Wczytaj Utwory z Folderu");
        if (!Directory.Exists(sciezka_do_folderu))
        {
            Debug_me.ins.LogT(2,"ERROR || NIE Istnieje sciezka do folderu dzwiekow = " + sciezka_do_folderu);
            Directory.CreateDirectory(sciezka_do_folderu);
        }
        else
        {
            Debug_me.ins.LogT(2,"Istnieje sciezka do folderu dzwiekow = " + sciezka_do_folderu);
        }
            //Debug.Log("Wczytaj Utwory z Folderu");
            
        if (Directory.Exists(sciezka_do_folderu))
        {
            DirectoryInfo info = new DirectoryInfo(sciezka_do_folderu);
            int temp_x = 0;
            foreach (FileInfo item in info.GetFiles("*.wav"))
            {
                temp_x++;
                audioname.Add(item.Name);
            }
            Debug_me.ins.LogT(2,"Ilosc dzwiekow w folderze = " + temp_x);
        }
        Debug_me.ins.LogT(2,"Start Coroutine Load Audio File");
        //Debug.Log("Start Coroutine");
        StartCoroutine(LoadAudioFile());
        Debug_me.ins.LogT(2,"Zakonczono Wczytywanie utworów z folderu");
    }
    public void ZapiszStworzoneDzwiekiDoPliku()
    {
        Lista_Dzwiekow_XML lista_xml = new Lista_Dzwiekow_XML();
        lista_xml.lista_dzwiekow_XML = new List<Dzwiek_XML>();

        for (int i = 0; i < lista_dzwiekow.Count; i++)
        {
            Dzwiek_XML dzwiek_xml = new Dzwiek_XML();
            Dzwiek dzwiek = lista_dzwiekow[i];

            dzwiek_xml.id_dzwieku = dzwiek.id_dzwieku;
            dzwiek_xml.nazwa_dzwieku = dzwiek.nazwa_dzwieku;
            dzwiek_xml.ilosc_powtorzen = dzwiek.ilosc_powtorzen;
            dzwiek_xml.czestotliwosc_powtorzen = dzwiek.czestotliwosc_potworzen;
            dzwiek_xml.glosnosc = dzwiek.src.volume;
            dzwiek_xml.grane_w_petli = dzwiek.src.loop;

            lista_xml.lista_dzwiekow_XML.Add(dzwiek_xml);
        }
        XML_Manager.Zapisz_Liste_Dzwiekow(lista_xml);
    }

    public void WczytajPlikXML()
    {
        Debug_me.ins.LogT(7,"Wczytywanie Pliku XML Listy Utworzonych Dzwiekow");
        lista_Dzwiekow_XML = XML_Manager.Wczytaj_Liste_Dzwiekow();
        Debug_me.ins.LogT(7,"Wczytano Plik ");
    }

    public void UzupelnijDaneDzwiekow()
    {
        Debug_me.ins.LogT(9,"Uzupelnianie Danych Dzwiekow");
        Debug_me.ins.LogT(9, "Lista Dzwiekow.Count = " + lista_dzwiekow.Count);
        //Debug.Log("Uzupelnij Dane Dzwiekow");
        //Debug.Log("Ilosc dzwiekow = " + lista_dzwiekow.Count);
        for (int i = 0; i < lista_dzwiekow.Count; i++)
        {
            Dzwiek dzwiek = lista_dzwiekow[i];
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
                dzwiek.GetComponent<UI_Dzwiek>().glosnosc.value = dzwiek.src.volume;
            }
            else
            {
                dzwiek.poprawny = false;
            }
        }
        Debug_me.ins.LogT(9,"Uzupelniono Dane \n Oznaczanie Nieprawidlowych ");
        OznaczNieprawidlowe();
        Debug_me.ins.LogT(9,"Oznaczono Nieprawidlowe ");
    }
    public AudioClip SprawdzCzyIstniejeOdpowiedniKlip(string nazwa)
    {
        for (int i = 0; i < clip_list.Count; i++)
        {
            if (audioname[i].Equals(nazwa))
            {
                return clip_list[i];
            }
        }
        return null;
    }
    public void OznaczNieprawidlowe()
    {
        // Przycisk zmienia kolor na czerwony
        //Debug.Log("Oznacz Nieprawidlowe");
        for(int i = 0; i < lista_dzwiekow.Count; i++)
        {
            
        }
        foreach(Dzwiek dzwiek in lista_dzwiekow)
        {
            if (dzwiek.poprawny == false)
            {
                dzwiek.gameObject.GetComponent<UI_Dzwiek>().info_img.color = Color.red;
            }
        }
    }

}
