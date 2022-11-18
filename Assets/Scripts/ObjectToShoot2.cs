using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToShoot2 : MonoBehaviour
{
    public GameObject player;

    private Rigidbody2D rb;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed=Random.Range(3,7); //ASTA VA DA DMG de cat vrem * speed
        rb=GetComponent<Rigidbody2D>();
        Vector3 direction=player.transform.position-transform.position; //directia in care o sa o ia objectToShoot
        rb.velocity=new Vector2(direction.x,direction.y) * speed;
        float objectToShootRotation=Mathf.Atan2(-direction.y,-direction.x)* Mathf.Rad2Deg; //util pentru cand o sa avem efectiv cu ceea ce trage, adica varful a ceea ce trage va fi indreptat spre player, apoi convertim in grade,ca sa putem folosi Quaternion.Euler
        transform.rotation=Quaternion.Euler(0,0,objectToShootRotation+90); //orientam efectiv varful a ceea ce trage spre player
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="Player")
            Destroy(this.gameObject);
    }
}
