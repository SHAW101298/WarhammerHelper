using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicjalizacja_1 : MonoBehaviour
{
    public string sciezka;
    public Debug_me db;
    public Color_Manager kolory;
    public Dzwiek_Kontrola dzwieki;
    public Dzwiek_Kontrola_UI dzwieki_UI;
    public Dzwiek_Preset_Kontrola presety_UI;

    // Start is called before the first frame update
    void Start()
    {
        StartProgramu();
    }
    void StartProgramu()
    {
        StartCoroutine(FullStart());
    }

    IEnumerator FullStart()
    {
        //yield return UtworzReferencje();
        UtworzReferencje();
        UtworzSciezki();
        yield return StartCoroutine(dzwieki.COROUTINE_WczytajUtworyZFolderu());
        yield return StartCoroutine(dzwieki_UI.COROUTINE_DokonczProcesDzwiekowy());
        yield return StartCoroutine(presety_UI.COROUTINE_WczytajPresety());
    }

    public void UtworzReferencje()
    {
        db.REFERENCJA();
        kolory.REFERENCJA();
        dzwieki.REFERENCJA();
        dzwieki_UI.REFERENCJA();
        presety_UI.REFERENCJA();
        //yield return null;
    }
    public void UtworzSciezki()
    {
        sciezka = Application.dataPath;
        //debug_me.LogT(1, "Tworzenie Ścieżek");
        //debug_me.LogT(1, "Ścieżka = " + sciezka);

        string dzwieki_path = sciezka + "/Dzwieki/";
        dzwieki.sciezka_do_folderu = dzwieki_path;
        //string mapa_path = sciezka + "/Mapy/";
        //mapy.sciezka_do_folderu = mapa_path;

        //debug_me.LogT(1, "Ścieżka dzwiekow = " + audioManager.sciezka_do_folderu);
        //debug_me.LogT(1, "Ścieżka map = " + mapy.sciezka_do_folderu);
        //debug_me.LogT(1, "Zakonczono Tworzenie Sciezek");

    }
    
}
