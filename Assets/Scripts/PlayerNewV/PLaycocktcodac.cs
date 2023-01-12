using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLaycocktcodac : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayCotcodac());
    }

   private IEnumerator PlayCotcodac()
   {
    while(true)
    {
        FindObjectOfType<SoundManager>().PlaySound("Cotcodac");
        yield return new WaitForSeconds(time);
    }
   }
    
}
