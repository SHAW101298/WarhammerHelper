using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preset_Dzwiekow_1 : MonoBehaviour
{
    public Text nazwa_presetu;
    public List<Preset_Dzwiek> dzwieki_w_presecie;

    public void BTN_UsunPreset()
    {
        for(int i = dzwieki_w_presecie.Count-1; i >= 0; i--)
        {
            Destroy(dzwieki_w_presecie[i].gameObject);
        }
        Dzwiek_Preset_Kontrola.ins.lista_presetow.Remove(this);
        Destroy(this.gameObject);
    }
    public void BTN_UstawPreset()
    {
        Dzwiek_Kontrola kontrola_dzwiek = Dzwiek_Kontrola.ins;
        Istniejacy_Dzwiek_1 dzwiek;
        Preset_Dzwiek pre;
        Debug.Log("dzwieki_w_presecie.Count = " + dzwieki_w_presecie.Count);
        Debug.Log("Dzwiek_Kontrola.ins.lista_dzwiekow.Count = " + Dzwiek_Kontrola.ins.lista_dzwiekow.Count);

        if (dzwieki_w_presecie.Count == Dzwiek_Kontrola.ins.lista_dzwiekow.Count)
        {
            
            for (int i = 0; i < dzwieki_w_presecie.Count; i++)
            {
                dzwiek = kontrola_dzwiek.lista_dzwiekow[i];
                pre = dzwieki_w_presecie[i];

                dzwiek.aktywny = pre.aktywny;
                dzwiek.ilosc_powtorzen = pre.powtorzenia;
                dzwiek.czestotliwosc_potworzen = pre.czestotliwosc;
                dzwiek.grane_w_petli = pre.petla;
                Debug.Log("pre.glosnosc = " + pre.glosnosc);
                dzwiek.ui.UstawGlosnosc(pre.glosnosc);
                Debug.Log("dzwiek.glosnosc = " + dzwiek.ui.slider_glosnosc.value);
                if (dzwiek.aktywny == true)
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
    }
}
