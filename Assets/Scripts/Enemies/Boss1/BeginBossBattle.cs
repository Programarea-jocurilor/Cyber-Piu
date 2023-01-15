using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginBossBattle : MonoBehaviour
{
    public GameObject boss;

    public GameObject wall1;

    public GameObject wall2;

    public GameObject chickenLeg;

    public Transform playerTransform;

    public GameObject[] spawnParticleSystem;

    public GameObject healthbar;

    void Start()
    {
        Physics2D.IgnoreCollision(boss.GetComponent<CircleCollider2D>(),wall1.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(boss.GetComponent<CircleCollider2D>(),wall2.GetComponent<BoxCollider2D>());
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="Player")
        {
            //spawn boss:
            boss.SetActive(true);

            healthbar.SetActive(true);

            //change backgroundmusic
            FindObjectOfType<SoundManager>().PauseSound("BackgroundMusic");
            FindObjectOfType<SoundManager>().PlaySound("BossAppearance");
            FindObjectOfType<SoundManager>().PlaySound("BossFight");
            
            //spawn ziduri:
            wall1.SetActive(true);
            wall2.SetActive(true);
            //spawn copane:
            StartCoroutine(SpawnChickenLegs());
            this.transform.position=Vector3.zero;

            foreach (GameObject sp in spawnParticleSystem)
                sp.GetComponent<ParticleSystem>().Play();    

        }
    }

    private IEnumerator SpawnChickenLegs()
    {
        while(true)
        {
           Debug.Log("DS");
            GameObject chickenLegClone=Instantiate(chickenLeg);
            chickenLegClone.transform.rotation=chickenLeg.transform.rotation;
            chickenLegClone.transform.position=new Vector3(Random.Range(wall1.transform.position.x+0.5f,wall2.transform.position.x-0.5f),1f,0);
            Vector3 poz=chickenLegClone.transform.position;
            while(Vector3.Distance(playerTransform.position,poz)<3)
            {
                poz=new Vector3(Random.Range(wall1.transform.position.x+0.5f,wall2.transform.position.x-0.5f),0.5f,0);
            }
            chickenLegClone.transform.position=poz;
            chickenLegClone.SetActive(true);
            Destroy(chickenLegClone,3f);
            yield return new WaitForSeconds(3f);
        }
    }
}
