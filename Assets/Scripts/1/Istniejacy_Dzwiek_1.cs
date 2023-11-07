using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Istniejacy_Dzwiek_1 : MonoBehaviour
{
    public Istniejacy_Dzwiek_UI_1 ui;

    public string nazwa_dzwieku;
    public int id_dzwieku;
    public int czestotliwosc_potworzen;
    public int ilosc_powtorzen;
    public bool grane_w_petli;
    public bool aktywny;

    public List<int> czas_odtworzenia;
    public AudioSource src;
    public bool poprawny = false;

    [Header("DEBUG")]
    public float aktualny_czas;
    public int aktualny_czas_int;

    private void Start()
    {
        ui = GetComponent<Istniejacy_Dzwiek_UI_1>();
        src = GetComponent<AudioSource>();
        if (grane_w_petli == false)
        {
            UstawCzas();
            SortujListe();
        }

    }
    private void Update()
    {
        if(aktywny == false)
        {
            return;
        }
        aktualny_czas += Time.deltaTime;
        aktualny_czas_int = (int)aktualny_czas;

        if (aktualny_czas >= czestotliwosc_potworzen)
        {
            aktualny_czas -= czestotliwosc_potworzen;
            UstawCzas();
            SortujListe();
        }

        GrajDzwiek();
    }
    void GrajDzwiek()
    {
        if (grane_w_petli == true)
        {
            if(src.isPlaying)
            {
                return;
            }
            src.Play();
        }

        foreach (float time in czas_odtworzenia)
        {
            if (aktualny_czas_int == time && src.isPlaying == false)
            {
                src.Play();
            }
        }
    }

    void UstawCzas()
    {
        czas_odtworzenia.Clear();
        for (int i = 0; i < ilosc_powtorzen; i++)
        {
            int t = Random.Range(0, czestotliwosc_potworzen);
            czas_odtworzenia.Add(t);
        }
    }
    void SortujListe()
    {
        czas_odtworzenia.Sort();
        UsunNakladajace();
    }
    void UsunNakladajace()
    {
        for (int i = ilosc_powtorzen - 1; i > 0; i--)
        {
            if (czas_odtworzenia[i] < czas_odtworzenia[i - 1] + src.clip.length)
            {
                czas_odtworzenia.RemoveAt(i - 1);
            }
        }
    }
}
