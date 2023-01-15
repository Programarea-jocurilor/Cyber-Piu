using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disolve : MonoBehaviour
{
    Material material;

    bool isDissiolving = false;
    float fade =1f;

    public Health playerHealth;
    public GameObject finishCanvas;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    void Start()
    {
        // Get reference to the material
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        if (playerHealth.currentHealth == 0)
        {
            isDissiolving = true;
            StartCoroutine(WaitAndDie());
        }   

        if (isDissiolving)
        {
            fade -= Time.deltaTime;

            if(fade <= 0f)
            {
                fade = 0f;
                isDissiolving = false;
            }

            //Set the property
            material.SetFloat("_Fade", fade);
        }
    }

    IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale=0;
        finishCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
