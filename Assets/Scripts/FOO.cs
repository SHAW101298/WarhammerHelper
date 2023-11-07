using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOO : MonoBehaviour
{
    public AudioSource src;
    public bool update_clip;

    private void Update()
    {
        if(update_clip == true)
        {
            

            update_clip = false;
        }
    }

}
