using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "z_", menuName = "ScriptableObjects/Zdolnosc", order = 3)]
public class Zdolnosc : ScriptableObject
{
    public int id;
    public string nazwa;
    public string opis;
}
