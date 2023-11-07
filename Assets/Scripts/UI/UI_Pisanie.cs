using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pisanie : MonoBehaviour
{
    public bool write;
    public string wpisane;
    public Text tekst;
    public GameObject zmieniono_wartosc;

    // Update is called once per frame
    void Update()
    {
        if (write == true)
        {
            if (Input.GetKeyDown("backspace") && wpisane.Length > 0)
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
                ZmienionaWartosc();
                write = false;
            }
        }

    }

    public void BTN_WcisnietyPrzycisk()
    {
        write = !write;
    }
    public void ZmienionaWartosc()
    {

    }
}
