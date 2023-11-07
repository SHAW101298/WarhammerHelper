using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowny_Skrypt : MonoBehaviour
{
    public UI_Dane_Postaci UI_Dane_Postaci;
    public UI_Lokacje_Aktywne_Okna UI_Aktywne_Okna;
    public static Glowny_Skrypt ins;
    void Start()
    {
        ins = this;
    }
}
