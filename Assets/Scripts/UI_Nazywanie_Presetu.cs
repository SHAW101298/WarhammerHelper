using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Nazywanie_Presetu : MonoBehaviour
{
    public bool write;
    public string wpisane;
    public Text tekst;
    public Preset oczekujacy_preset;

    private void Update()
    {
        if (write == true)
        {
            if (Input.GetKeyDown("backspace") && wpisane.Length > 0)
            {
                //Debug.Log("Backspace");
                //Debug.Log("Wpisane = " + wpisane);
                //Debug.Log("last = " + wpisane[wpisane.Length - 1]);
                wpisane = wpisane.Remove(wpisane.Length - 1, 1);
                //Debug.Log("Wpisane = " + wpisane);
            }
            else
            {
                wpisane += Input.inputString;
                tekst.text = wpisane;
            }

            if (Input.GetKeyDown("return"))
            {
                write = false;
            }
        }
    }
    public void BTN_ZapiszNazwe()
    {
        oczekujacy_preset.nazwa.text = tekst.text;
        oczekujacy_preset = null;
        Inicjalizacja.ins.presety.SchowajOknoNazywania();
    }
}
