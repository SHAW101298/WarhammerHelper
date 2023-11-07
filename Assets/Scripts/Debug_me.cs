using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_me : MonoBehaviour
{
    public static Debug_me ins;
    public void REFERENCJA()
    {
        ins = this;
    }
    public int step;

    public bool czy_gotowe;
    public Text text_field;
    public Text func_field;
    public Text ERROR_FIELD;
    public Text LOG_FIELD;
    [SerializeField]
    string log;
    //public Text konsola;
    [SerializeField]
    string pokazany_tekst;
    public int ilosc_petli;

    private void Start()
    {
    }

    public void LogT(int krok, string tekst)
    {
        log = log +(krok + " ]" + tekst + "\n");
        LOG_FIELD.text = log;
    }
    public void DodajTekst(string tekst)
    {
        pokazany_tekst = pokazany_tekst + step + " | " + tekst + "\n";
    }

    public void UstawTekst(string wartosc)
    {
        text_field.text = wartosc + "\n Ilosc obrotu petli = " + ilosc_petli + "\n czy gotowe ? = " + czy_gotowe;
    }
    public void UstawFunkcje(string wartosc)
    {
        func_field.text = wartosc;
    }
    public void UstawError(string wartosc)
    {
        ERROR_FIELD.text = wartosc;
    }
}
