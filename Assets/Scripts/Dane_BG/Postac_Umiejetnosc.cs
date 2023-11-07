using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Postac_Umiejetnosc : MonoBehaviour
{
    public Umiejetnosc umiejetnosc;
    public int poziom = -1;

    public void BTN_Poziom_0()
    {
        poziom = 0;
    }
    public void BTN_Poziom_1()
    {
        poziom = 1;
    }
    public void BTN_Poziom_2()
    {
        poziom = 2;
    }
}
