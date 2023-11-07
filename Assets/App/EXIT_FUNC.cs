using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXIT_FUNC : MonoBehaviour
{
    public void Przycisk_Wyjscie()
    {
        Debug.Log("WYJSCIE");
        Application.Quit(0);
    }
}
