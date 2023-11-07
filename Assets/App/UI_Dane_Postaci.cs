using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Dane_Postaci : MonoBehaviour
{
    public bool aktywne;
    public GameObject Okno_Postaci;
    public GameObject umiejetnosci_content;
    public GameObject zdolnosci_content;
    public GameObject prefab_zdolnosc_umiejetnosc;

    public Text WW;
    public Text US;
    public Text K;
    public Text OD;
    public Text ZR;
    public Text SW;
    public Text OG;

    public Text Zywotnosc;

    public void AktualizujDane(Postac postac)
    {
        Debug.Log("Aktualizuj Dane");
        WW.text = postac.cechy.Walka_Wrecz.aktualna.ToString();
        US.text = postac.cechy.Umiejetnosci_Strzeleckie.aktualna.ToString();
        K.text = postac.cechy.Krzepa.aktualna.ToString();
        OD.text = postac.cechy.Odpornosc.aktualna.ToString();
        ZR.text = postac.cechy.Zrecznosc.aktualna.ToString();
        SW.text = postac.cechy.Sila_Woli.aktualna.ToString();
        OG.text = postac.cechy.Oglada.aktualna.ToString();
        Zywotnosc.text = postac.zdrowie_aktualne.ToString();
        ZapelnijUmiejetnosci(postac);
        ZapelnijZdolnosci(postac);

        PokazOkno();

    }
    public void PokazOkno()
    {
        //aktywne = !aktywne;
        Okno_Postaci.SetActive(true);
    }
    void ZapelnijUmiejetnosci(Postac postac)
    { 

        foreach(Transform child in umiejetnosci_content.transform)
        {
            Destroy(child.gameObject);
        }

        foreach(Umiejetnosc um in postac.umiejetnosci)
        {
            GameObject temp = Instantiate(prefab_zdolnosc_umiejetnosc);
            //temp.transform.localScale = new Vector3(1, 1, 1);
            temp.transform.SetParent(umiejetnosci_content.transform);
            temp.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            temp.GetComponent<UI_Karta_Umiejetnosc>().nazwa.text = um.nazwa;
        }
    }
    void ZapelnijZdolnosci(Postac postac)
    {
        foreach (Transform child in zdolnosci_content.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Zdolnosc zd in postac.zdolnosci)
        {
            GameObject temp = Instantiate(prefab_zdolnosc_umiejetnosc);
            temp.transform.SetParent(zdolnosci_content.transform);
            temp.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            temp.GetComponent<UI_Karta_Umiejetnosc>().nazwa.text = zd.nazwa;
        }
    }
}
