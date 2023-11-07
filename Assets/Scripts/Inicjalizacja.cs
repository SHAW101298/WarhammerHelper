using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Inicjalizacja : MonoBehaviour
{
    // Postacie
    // Grupy 
    // Pomoc
    // Tabela Krytykow
    // "Zdarzenie " - ogólne informacje o zdarzeniu, postaciach itp. 
    #region
    public static Inicjalizacja ins;
    public void REFERENCJA()
    {
        ins = this;
    }
    #endregion

    public AudioManager audioManager;
    public UI_Dzwieki dzwieki;
    public UI_Preset presety;
    public UI_Mapa mapy;
    public UI_Postac postac;
    public Color_Manager kolory;
    public Debug_me debug_me;

    public string sciezka;

    public int krok = 0;

    public bool wczytano_dzwieki;
    public bool wczytano_presety;
    public bool wczytano_mapy;

    // Start is called before the first frame update
    void Start()
    {
        sciezka = Application.dataPath;
        StartProgramu();
    }

    public void StartProgramu()
    {
        //StartCoroutine(COROUTINE_StartProgramu());
        RawStart();
    }
    public void RawStart()
    {
        debug_me.REFERENCJA();
        debug_me.LogT(0, "Start Programu");
        REFERENCJA();
        audioManager.REFERENCJA();
        dzwieki.REFERENCJA();
        presety.REFERENCJA();
        Debug_me.ins.LogT(1, "Utworzono Referencje. YIELD");
        Debug_me.ins.step++;
        UtworzSciezki();
    }

    IEnumerator COROUTINE_StartProgramu()
    {
        debug_me.REFERENCJA();
        debug_me.LogT(0,"Start Programu");
        REFERENCJA();
        audioManager.REFERENCJA();
        dzwieki.REFERENCJA();
        presety.REFERENCJA();
        Debug_me.ins.LogT(1, "Utworzono Referencje. YIELD");
        Debug_me.ins.step++;
        UtworzSciezki();
        yield return StartCoroutine(COROUTINE_WczytajUtworyZFolderu());
        Debug_me.ins.LogT(2,"Wczytano Utwory z Folderu");
        yield return StartCoroutine(COROUTINE_WczytajPresety());
        Debug_me.ins.LogT(3,"Wczytano Presety z Folderu");
        yield return StartCoroutine(COROTUINE_WczytajMapy());
        Debug_me.ins.LogT(4,"Wczytano Mapy z Folderu");
        yield return StartCoroutine(COROUTINE_DokonczOperacjeNaDzwiekach());
        Debug_me.ins.LogT(5,"Dokonczono Operacje Na Dzwiekach");
        yield return StartCoroutine(COROUTINE_DokonczOperacjeNaMapach());
        Debug_me.ins.LogT(10,"Dokonczono Operacje Na Mapach");
    }

    IEnumerator COROUTINE_WczytajUtworyZFolderu()
    {
        Debug_me.ins.LogT(2, "START COROUTINE Wczytaj Utwory z Folderu");
        yield return audioManager.COROUTINE_WczytajUtworyZFolderu();
        Debug_me.ins.LogT(2,"Koniec Coroutine Wczytaj Utwory z Folderu");
    }
    IEnumerator COROUTINE_WczytajPresety()
    {
        Debug_me.ins.LogT(3, "START COROUTINE Wczytaj Preset");
        yield return presety.COROUTINE_WczytajPresety();
        Debug_me.ins.LogT(3,"Koniec Coroutine Wczytaj Preset");
    }
    IEnumerator COROTUINE_WczytajMapy()
    {
        Debug_me.ins.LogT(4, "START COROUTINE Wczytaj Mapy");
        yield return mapy.COROUTINE_WczytajZdjeciaZFolderu();
        Debug_me.ins.LogT(4,"Koniec Coroutine Wczytaj Mapy");
        yield return null;
    }
    IEnumerator COROUTINE_DokonczOperacjeNaDzwiekach()
    {
        Debug_me.ins.LogT(5, "START COROUTINE DokonczOperacjeNaDzwiekach");
        dzwieki.StworzPrefabyZnalezionych_WAV();
        yield return null;
        audioManager.WczytajPlikXML();
        yield return null;
        dzwieki.StworzPrefabyWczytanychDzwiekow();
        yield return null;
        audioManager.UzupelnijDaneDzwiekow();
        yield return null;

        Debug_me.ins.LogT(5,"Koniec Coroutine DokonczOperacjeNaDzwiekach");
    }
    IEnumerator COROUTINE_DokonczOperacjeNaMapach()
    {
        Debug_me.ins.LogT(10, "START COROUTINE DokonczOperacjeNaMapach");
        mapy.StworzPrefaby_Zdjec();
        yield return null;

        Debug_me.ins.LogT(10,"Koniec Coroutine DokonczOperacjeNaMapach");
    }

    public void UtworzSciezki()
    {
        debug_me.LogT(1,"Tworzenie Ścieżek");
        debug_me.LogT(1,"Ścieżka = " + sciezka);

        string dzwieki_path = sciezka + "/Dzwieki/";    
        audioManager.sciezka_do_folderu = dzwieki_path;
        string mapa_path = sciezka + "/Mapy/";
        mapy.sciezka_do_folderu = mapa_path;

        debug_me.LogT(1,"Ścieżka dzwiekow = " + audioManager.sciezka_do_folderu);
        debug_me.LogT(1,"Ścieżka map = " + mapy.sciezka_do_folderu);
        debug_me.LogT(1,"Zakonczono Tworzenie Sciezek");

    }
    /*
    IEnumerator WczytajDane()
    {
        for (int i = 0; i < audioname.Count; i++)
        {
            Inicjalizacja.ins.debug_me.UstawError("Load Audio File \n audioname.count = " + audioname.Count);
            //Debug.Log("FOR");
            UnityWebRequest AudioFiles = UnityWebRequestMultimedia.GetAudioClip(sciezka_do_folderu + string.Format("{0}", audioname[i]), AudioType.WAV);
            yield return AudioFiles.SendWebRequest();
            if (AudioFiles.isNetworkError)
            {
                Inicjalizacja.ins.debug_me.UstawError("Load Audio File \n audioname.count = " + audioname.Count + " \n ERROR = " + AudioFiles.error);
                //Debug.Log("IF");
                //Debug.Log(AudioFiles.error);
                //Debug.Log(sciezka_do_folderu + string.Format("{0}", audioname[i]));
            }
            else
            {
                Inicjalizacja.ins.debug_me.UstawError("Load Audio File \n audioname.count = " + audioname.Count + "ELSE ");
                //Debug.Log("ELSE");
                AudioClip clip = DownloadHandlerAudioClip.GetContent(AudioFiles);
                clip.name = audioname[i];
                clip_list.Add(clip);
                //Debug.Log(sciezka_do_folderu + string.Format("{0}", audioname[i]));
            }

    }
        */
}
