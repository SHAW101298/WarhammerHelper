using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;

// Zachowanie wszystkich przycisków w oknie mapa
public class UI_Mapa : MonoBehaviour
{
    
    [Header("Wczytane Zdjecia")]
    public List<Texture2D> lista_zdjec;
    public List<string> lista_nazw;
    [Header("Timing")]
    [Header("Dane")]
    public string sciezka_do_folderu;
    [Header("Referencje")]
    public GameObject zdjecia_prefab;
    public GameObject zdjecia_content;
    public Image widoczne_zdjecie;

    // Start is called before the first frame update

    public IEnumerator COROUTINE_WczytajZdjeciaZFolderu()
    {
        Debug_me.ins.LogT(4, "Wczytywanie Zdjec z folderu");
        if (!Directory.Exists(sciezka_do_folderu))
        {
            //Debug.Log("Brak folderu");
            Directory.CreateDirectory(sciezka_do_folderu);
        }

        if (Directory.Exists(sciezka_do_folderu))
        {
            DirectoryInfo info = new DirectoryInfo(sciezka_do_folderu);

            foreach (FileInfo item in info.GetFiles("*.jpg"))
            {
                lista_nazw.Add(item.Name);
            }
            foreach (FileInfo item in info.GetFiles("*.png"))
            {
                lista_nazw.Add(item.Name);
            }

        }
        Debug_me.ins.LogT(4, "Stworzono nazwy zdjec");
        Debug_me.ins.LogT(4, "Start Coroutine LoadImageFiles");
        yield return LoadImageFiles();
    }

    public void WczytajZdjeciaZFolderu()
    {
        Debug_me.ins.LogT(4,"Wczytywanie Zdjec z folderu");
        if (!Directory.Exists(sciezka_do_folderu))
        {
            //Debug.Log("Brak folderu");
            Directory.CreateDirectory(sciezka_do_folderu);
        }
            
        if (Directory.Exists(sciezka_do_folderu))
        {
            DirectoryInfo info = new DirectoryInfo(sciezka_do_folderu);

            foreach (FileInfo item in info.GetFiles("*.jpg"))
            {
                lista_nazw.Add(item.Name);
            }
            foreach (FileInfo item in info.GetFiles("*.png"))
            {
                lista_nazw.Add(item.Name);
            }
            
        }
        Debug_me.ins.LogT(4,"Stworzono nazwy zdjec");
        Debug_me.ins.LogT(4,"Start Coroutine LoadImageFiles");
        StartCoroutine(LoadImageFiles());
        //Debug.Log("Start Coroutine");

    }


    IEnumerator LoadImageFiles()
    {
        Debug_me.ins.LogT(4, "Corouine");
        //Debug.Log("Coroutine");
        //Debug.Log("Sciezka = " + sciezka_do_folderu);
        for (int i = 0; i < lista_nazw.Count; i++)
        {
            //Debug.Log("FOR");
            UnityWebRequest ImageFiles = UnityWebRequestTexture.GetTexture(sciezka_do_folderu + lista_nazw[i]);
            yield return ImageFiles.SendWebRequest();
            if (ImageFiles.isNetworkError)
            {
                //Debug.Log("IF");
                Debug.Log(ImageFiles.error);
                Debug.Log(sciezka_do_folderu + string.Format("{0}", lista_nazw[i]));
            }
            else
            {
                Texture2D zdjecie = DownloadHandlerTexture.GetContent(ImageFiles);
                //Debug.Log("ELSE");
                zdjecie.name = lista_nazw[i];
                lista_zdjec.Add(zdjecie);
                Debug.Log(sciezka_do_folderu + string.Format("{0}", lista_nazw[i]));
            }
        }
        //Debug.Log("FINISH");
        Debug_me.ins.LogT(4,"Zakonczono Coroutine LoadImageFiles");
        Inicjalizacja.ins.krok = 6;
    }

    public void StworzPrefaby_Zdjec()
    {
        Debug_me.ins.LogT(10,"Tworzenie Prefabow Zdjec");
        for(int i = 0; i < lista_nazw.Count; i++)
        {
            GameObject temp_go = Instantiate(zdjecia_prefab);
            temp_go.transform.SetParent(zdjecia_content.transform);
            UI_Wczytane_Zdjecie temp_zdjecie = temp_go.GetComponent<UI_Wczytane_Zdjecie>();
            temp_zdjecie.tex = lista_zdjec[i];
            temp_zdjecie.UtworzSprite();
            temp_go.transform.localScale = new Vector3(1, 1, 1);
        }
        Debug_me.ins.LogT(10,"Zakonczono Tworzenie Prefabow Zdjec");
    }
}
