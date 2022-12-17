using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject objectToShoot; //cu ce trag

    public Transform objectToShootTransform;

    public Transform playerTransform;
    private float timer;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
        distance=Vector2.Distance(transform.position,playerTransform.position);
        if(distance<10)// trage doar daca suntem la o distanta mai mica de 10
        {
            timer+=Time.deltaTime;
            if(timer>2) //daca au trecut 2 secunde
            {
                timer=0; //resetam timerul
                EnemyShoot();//trage
            }
        }
    }

    void EnemyShoot()
    {
        GameObject objectToShootClone=Instantiate(objectToShoot,objectToShootTransform.position,Quaternion.identity); //cream efectiv cu ce trage enemy-ul
        objectToShootClone.SetActive(true);
        Destroy(objectToShootClone,5f);// il distrugem dupa 5 secunde ca sa nu ramana degeaba in hierarchy
    }

    //IDEEA: asta o sa fie un enemy care trage doar daca gaina e la un certain distance de el, cum ar fi de exemplu vrea sa treaca gaina undeva si asta o sa fie ceva deasupra ei 
    //si cand se apropie gaina se apuca sa traga in ea

}
