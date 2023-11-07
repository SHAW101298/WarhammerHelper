using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_WRITING : MonoBehaviour
{
    public UI_Dodawanie_Dzwieku dodawanie_dzwieku;
    public bool write;
    public string wpisane;
    public Text tekst;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(write == true)
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

            if(Input.GetKeyDown("return"))
            {
                write = false;
            }
        }
        
    }

    public void Zmiana()
    {
        Debug.Log("dodawanie dzwieku.name =  " + dodawanie_dzwieku.gameObject.name);
        Debug.Log("dodawanie dzwieku.aktywne pole =  " + dodawanie_dzwieku.aktywny_pole);
        if (dodawanie_dzwieku.aktywny_pole != null)
        {
            dodawanie_dzwieku.aktywny_pole.GetComponent<UI_WRITING>().write = false;
        }
        dodawanie_dzwieku.aktywny_pole = gameObject;
        Debug.Log("Zmiana");
        write = true; ;
    }
}
