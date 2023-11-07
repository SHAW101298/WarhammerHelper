using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Wczytane_Zdjecie : MonoBehaviour
{
    public Texture2D tex;
    Sprite sprite;

    public void UtworzSprite()
    {
        sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
    public void BTN_UstawZdjecie()
    {
        Inicjalizacja.ins.mapy.widoczne_zdjecie.sprite = sprite;
    }
}
