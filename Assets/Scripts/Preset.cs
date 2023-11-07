using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preset : MonoBehaviour
{
    UI_Preset rodzic;
    //public AudioManager audiomanager;
    [SerializeField]
    public List<Preset_Dzwiek> dzwieki;
    public Text nazwa;

    public void Start()
    {
        //rodzic = Inicjalizacja.ins.presety;
    }
    public void BTN_UstawDane()
    {
        Dzwiek dzwiek;
        Preset_Dzwiek pre;
        int count = Inicjalizacja.ins.audioManager.lista_dzwiekow.Count;
        for (int i = 0; i < count; i++)
        {
            pre = dzwieki[i];
            dzwiek = Inicjalizacja.ins.audioManager.lista_dzwiekow[i];
            dzwiek.aktywny = pre.aktywny;
            dzwiek.ilosc_powtorzen = pre.powtorzenia;
            dzwiek.czestotliwosc_potworzen = pre.czestotliwosc;
            dzwiek.grane_w_petli = pre.petla;
            dzwiek.UstawGlosnosc(pre.glosnosc);
            if(dzwiek.aktywny == true)
            {
                //dzwiek.src.Play();
                dzwiek.ui.AktywujDzwiek();
            }
            else
            {
                dzwiek.ui.WylaczDzwiek();
            }
            
        }
    }
    
    public void BTN_Usun()
    {
        rodzic = Inicjalizacja.ins.presety;
        rodzic.PokazOknoPotwierdzenia();
        rodzic.pytajacy_preset = this;
    }
    public void Usun_Preset()
    {
        Inicjalizacja.ins.presety.pytajacy_preset = null;
        Inicjalizacja.ins.presety.lista_presetow.Remove(this);
        Destroy(gameObject);
    }
}
