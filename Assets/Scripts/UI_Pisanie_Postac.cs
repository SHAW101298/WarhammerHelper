using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pisanie_Postac : MonoBehaviour
{
    public bool write;
    public string wpisane;
    public Text tekst;
    public Image img;
    public UI_Postac ui_postac;

    void Update()
    {
        if (write == true)
        {
            if(Input.GetKey("backspace") && wpisane.Length > 0)
            //if (Input.GetKeyDown("backspace") && wpisane.Length > 0)
            {
                wpisane = wpisane.Remove(wpisane.Length - 1, 1);
            }
            else
            {
                wpisane += Input.inputString;
                tekst.text = wpisane;
            }

            if (Input.GetKeyDown("return"))
            {
                write = false;
                ZmienionaWartosc();
            }
        }

    }

    public void BTN_WcisnietyPrzycisk()
    {
        write = !write;

        ZmienKolor();
    }
    public void ZmienionaWartosc()
    {
        if(ui_postac == null)
        {
            ui_postac = Inicjalizacja.ins.postac;
        }
        ui_postac.ZmienionoWartosc();
        ZmienKolor();
        UstawDaneWPostaci();
    }
    void ZmienKolor()
    {
        if (write == true)
        {
            img.color = Inicjalizacja.ins.kolory.aktywne;
        }
        else
        {
            img.color = Inicjalizacja.ins.kolory.normalny;
        }
    }
    void UstawDaneWPostaci()
    {
        ui_postac.AktualizujDanePostaci();
    }
}
