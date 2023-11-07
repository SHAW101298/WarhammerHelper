using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cecha
{
    NONE,
    Walka_Wrecz,
    Umiejetnosci_Strzeleckie,
    Krzepa,
    Odpornosc,
    Zrecznosc,
    Inteligencja,
    Sila_Woli,
    Oglada
}

[CreateAssetMenu(fileName = "", menuName = "ScriptableObjects/Umiejetnosc", order = 2)]
public class Umiejetnosc : ScriptableObject
{
    public int id;
    public string nazwa;
    public bool podstawowa;
    public string opis;
    public Cecha cecha;
}
