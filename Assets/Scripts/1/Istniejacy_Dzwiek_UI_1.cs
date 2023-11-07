using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Istniejacy_Dzwiek_UI_1 : MonoBehaviour
{
    public Istniejacy_Dzwiek_1 dzwiek;

    public Toggle toggle_wygluszanie;
    public Slider slider_glosnosc;
    public Text nazwa;
    public Image tlo_img;

    // Start is called before the first frame update
    void Start()
    {
        dzwiek = GetComponent<Istniejacy_Dzwiek_1>();
    }

    public void BTN_Info()
    {
        Informacje_O_Dzwieku info = Dzwiek_Kontrola.ins.ui.info;
        Istniejacy_Dzwiek_1 dzwiek = GetComponent<Istniejacy_Dzwiek_1>();
        info.nazwa.text = dzwiek.nazwa_dzwieku;
        info.czestotliwosc.text = "Czestotliwosc : " + dzwiek.czestotliwosc_potworzen;
        info.powtorzenia.text = "Ilosc Powtorzen : " + dzwiek.ilosc_powtorzen;
        info.petla.text = "Czy Zapetlone ? " + dzwiek.grane_w_petli.ToString();
    }
    public void BTN_Wygluszanie()
    {
        Debug.Log("BTN_Wygluszanie");
        if(toggle_wygluszanie.isOn)
        {
            dzwiek.aktywny = true;
            dzwiek.src.mute = false;
        }
        else
        {
            dzwiek.aktywny = false;
            dzwiek.src.mute = true;
        }
    }
    public void BTN_Usun()
    {
        //Debug.LogWarning("usuwanie nie utworzone");
        Dzwiek_Kontrola.ins.lista_dzwiekow.Remove(dzwiek);
        Destroy(gameObject);
        //AudioManager.ins.lista_dzwiekow.Remove(GetComponent<Dzwiek>());
        //Destroy(gameObject);
    }
    public void BTN_ZmienGlosnosc()
    {
        dzwiek.src.volume = slider_glosnosc.value;
    }
    public void UstawGlosnosc(float value)
    {
        dzwiek.src.volume = value;
        slider_glosnosc.value = value;
    }
    public void AktywujDzwiek()
    {
        dzwiek.src.mute = false;
        dzwiek.aktywny = true;
        toggle_wygluszanie.isOn = true;
    }
    public void WylaczDzwiek()
    {
        dzwiek.src.mute = true;
        dzwiek.aktywny = false;
        toggle_wygluszanie.isOn = false;
    }

}
