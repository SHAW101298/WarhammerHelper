using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Dzwiek : MonoBehaviour
{
    public Dzwiek dzwiek;
    public Image img;
    public AudioSource src;
    public int id_dzwieku;
    public Text nazwa;
    public Image info_img;
    public Slider glosnosc;

    public void BTN_WygluszanieDzwieku()
    {
        if(dzwiek.aktywny == true)
        {
            Debug.Log("Wylaczenie dzwieku");
            img.sprite = Inicjalizacja.ins.dzwieki.audio_muted;
            src.Stop();
            dzwiek.aktywny = false;
            src.mute = true;
        }
        else
        {
            Debug.Log("Wlaczenie Dzwieku");
            img.sprite = Inicjalizacja.ins.dzwieki.audio_playing;
            if (GetComponent<Dzwiek>().grane_w_petli == true)
            {
                src.Play();
            }
            dzwiek.aktywny = true;
            src.mute = false;
        }
    }
    public void AktywujDzwiek()
    {
        img.sprite = Inicjalizacja.ins.dzwieki.audio_playing;
        if (GetComponent<Dzwiek>().grane_w_petli == true)
        {
            src.Play();
        }
        dzwiek.aktywny = true;
        src.mute = false;
    }
    public void WylaczDzwiek()
    {
        img.sprite = Inicjalizacja.ins.dzwieki.audio_muted;
        src.Stop();
        dzwiek.aktywny = false;
        src.mute = true;
    }

    public void BTN_UsuwanieDzwieku()
    {
        AudioManager.ins.lista_dzwiekow.Remove(GetComponent<Dzwiek>());
        Destroy(gameObject);
    }
    public void BTN_PokazInformacje()
    {
        Informacje_O_Dzwieku info = AudioManager.ins.info;
        Dzwiek dzwiek = GetComponent<Dzwiek>();
        info.nazwa.text = dzwiek.nazwa_dzwieku;
        info.czestotliwosc.text = "Czestotliwosc : " + dzwiek.czestotliwosc_potworzen;
        info.powtorzenia.text = "Ilosc Powtorzen : " + dzwiek.ilosc_powtorzen;
        info.petla.text = "Czy Zapetlone ? " + dzwiek.grane_w_petli.ToString();
    }
    private void Update()
    {
        src.volume = glosnosc.value;
    }

}
