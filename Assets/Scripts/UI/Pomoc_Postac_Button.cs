using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pomoc_Postac_Button : MonoBehaviour
{
    public GameObject okno_z_danymi;
    public int id;
    public void BTN_Nacisnieto_Postac()
    {
        UI_Pomoc_Profesje_Kontrola.ins.AktywujOkno(okno_z_danymi);
    }
}
