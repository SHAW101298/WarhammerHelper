using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Color_Manager : MonoBehaviour
{
    #region
    public static Color_Manager ins;
    public void REFERENCJA()
    {
        ins = this;
    }
    #endregion

    [Header("Glowne kolor")]
    public Color tlo;
    public Color obramowka;

    [Header("Kolory Przyciskow")]
    public Color normalny;
    public Color najechane;
    public Color wcisniete;
    public Color aktywne;
    [Header("Przyciski")]
    public List<Image> nie_interaktywne;
    public List<Image> interaktywne;
    public Button[] Buttons;
    public InputField[] InputFields;
    public Toggle[] Toggles;
    public Image[] Obramowka;
    public Material obramowka_material;
}
