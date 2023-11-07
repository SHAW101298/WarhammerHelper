using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "nazwa", menuName = "ScriptableObjects/Profesja", order = 1)]
public class Profesja : ScriptableObject
{
    public Cechy Statystyki;
    public int id;
    public string nazwa;
    public bool podstawowa;

    public List<Umiejetnosc> lista_Umiejetnosci;
    public List<Zdolnosc> lista_Zdolnosci;

}
