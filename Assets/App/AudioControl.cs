using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource src;
    public bool aktywny_dzwiek;
    public int ilosc_na_minute;
    public float czas;
    public int czas_int;
    [Header("Czasy klipow")]
    public List<float> czas_uzycia;
    public List<bool> kontrolka_uzycia_dzwieku;
    bool kontrolka_ustawienia_uzycia;
    [Header("DEBUG")]
    public bool is_playing;


    private void Update()
    {
        is_playing = src.isPlaying;
        czas += Time.deltaTime;
        czas_int = (int)czas;

        if(czas_int % 60 == 1)
        {
            if (kontrolka_ustawienia_uzycia == false)
            {
                UstawLosowyCzas();
                kontrolka_ustawienia_uzycia = true;
            }
        }

        GrajDzwiek();
        

        if(czas > 60)
        {
            kontrolka_ustawienia_uzycia = false;
            czas -= 60;
        }

    }

    void UstawLosowyCzas()
    {
        for(int i = 0; i < ilosc_na_minute; i++)
        {
            int temp_czas = Random.Range(1, 60);
            czas_uzycia[i] = (float)temp_czas;
            kontrolka_uzycia_dzwieku[i] = false;
        }
    }
    void GrajDzwiek()
    {
        if (src.isPlaying == true)
            return;

        for(int i = 0; i < ilosc_na_minute; i++)
        {
            //Debug.Log("Czas uzycia = " + czas_uzycia[0]);
            //Debug.Log("Czas int = " + czas_int);
            if (czas_int == czas_uzycia[i])
            {
                Debug.Log("Czas sie zgadza");
                src.Play();
                kontrolka_uzycia_dzwieku[i] = true;
            }
        }
    }
}
