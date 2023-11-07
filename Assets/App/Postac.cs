using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Postac : MonoBehaviour
{
    public int id;
    public string nazwa;
    public int zdrowie_max;
    public int zdrowie_aktualne;
    public UI_Postac ui_postac;

    public Text nazwa_tekst;

    [Space(10)]
    public Cechy cechy;
    [Space(10)]
    public List<Umiejetnosc> umiejetnosci;
    [Space(10)]
    public List<Zdolnosc> zdolnosci;

    public void BTN_NacisnietoPostac()
    {
        Inicjalizacja.ins.postac.WcisnietoPostac(this);
    }
    public void BTN_UsunPostac()
    {
        ui_postac = Inicjalizacja.ins.postac;
        ui_postac.lista_postaci.Remove(GetComponent<Postac>());
        Destroy(gameObject);
    }
}
