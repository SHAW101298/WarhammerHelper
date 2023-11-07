using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_Akcja
{
    DodajPostac,
    UsunPostac,
    Przejdz
}


public class Akcja : MonoBehaviour
{
    public ENUM_Akcja wykonana_akcja;
    public GameObject cel;

}
