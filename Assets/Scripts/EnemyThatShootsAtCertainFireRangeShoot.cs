using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThatShootsAtCertainFireRangeShoot : MonoBehaviour
{
    public GameObject objectToShoot; //cu ce trag

    public Transform objectToShootTransform;

    public Transform playerTransform;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>2) //daca au trecut 2 secunde
        {
            timer=0; //resetam timerul
            EnemyShoot();//trage
        }
        
    }

    void EnemyShoot()
    {
        GameObject objectToShootClone=Instantiate(objectToShoot,objectToShootTransform.position,Quaternion.identity); //cream efectiv cu ce trage enemy-ul
        objectToShootClone.SetActive(true);
        Destroy(objectToShootClone,5f);// il distrugem dupa 5 secunde ca sa nu ramana degeaba in hierarchy
    }

    //IDEEA: asta o sa fie un enemy care o sa traga la random fire rate-uri, si o sa fie util cand de pilda gaina vrea sa se urce undeva si ala trage acolo incontinuu ca sa o impidice
    //sa se urce
}
