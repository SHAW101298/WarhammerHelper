using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Dodawanie_Dzwieku : MonoBehaviour
{
    [Header("Referencje")]
    public AudioManager audio_manager;
    public UI_Dzwieki ui_dzwieki;
    public GameObject aktywny_pole;
    public GameObject dzwieki_content;
    public GameObject prefab;
    [Header("TEXT")]
    public Text czestotliwosc_Text;
    public Text powtorzenia_Text;
    public Text id_dzwieku_Text;
    public Text w_petli_Text;
    [Header("INPUT")]
    public UI_WRITING czestotliwosc_writing;
    public UI_WRITING powtorzenia_writing;
    public UI_WRITING id_dzwieku_writing;
    public bool w_petli_wartosc = true;
    //public Dzwiek tworzony_dzwiek;
    
    public void BTN_DodajDzwiek()
    {
        GameObject temp = Instantiate(prefab);
        Dzwiek nowy = temp.GetComponent<Dzwiek>();

        nowy.czestotliwosc_potworzen = int.Parse(czestotliwosc_Text.text);
        nowy.ilosc_powtorzen = int.Parse(powtorzenia_Text.text);
        nowy.id_dzwieku = int.Parse(id_dzwieku_Text.text);
        nowy.nazwa_dzwieku = audio_manager.audioname[nowy.id_dzwieku];

        audio_manager.lista_dzwiekow.Add(nowy);
        temp.transform.SetParent(dzwieki_content.transform);
        temp.transform.localScale = new Vector3(1, 1, 1);
        nowy.src.clip = audio_manager.clip_list[nowy.id_dzwieku];
        nowy.grane_w_petli = w_petli_wartosc;
        nowy.src.loop = w_petli_wartosc;

        ResetujTworzonyDzwiek();
        ui_dzwieki.ResetujOkno();
        AktualizujDanewUI(nowy);
    }
    public void BTN_Anuluj()
    {
        ResetujTworzonyDzwiek();
        ui_dzwieki.ResetujOkno();
    }
    void ResetujTworzonyDzwiek()
    {
        czestotliwosc_writing.wpisane = "";
        powtorzenia_writing.wpisane = "";
        id_dzwieku_writing.wpisane = "";
        czestotliwosc_Text.text = "";
        powtorzenia_Text.text = "";
        id_dzwieku_Text.text = "";
        
    }
    void AktualizujDanewUI(Dzwiek dzwiek)
    {
        dzwiek.GetComponent<UI_Dzwiek>().nazwa.text = dzwiek.nazwa_dzwieku;
    }
    public void BTN_W_Petli()
    {
        w_petli_wartosc = !w_petli_wartosc;
        w_petli_Text.text = w_petli_wartosc.ToString();
    }
}
