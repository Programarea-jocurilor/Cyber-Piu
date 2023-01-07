using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : CoreComponent
{
    [SerializeField] GameManager gameManager; 
    [SerializeField] private GameObject[] deathParticles;

    private ParticleManager ParticleManager =>
        particleManager ? particleManager : core.GetCoreComponent(ref particleManager);
    
    private ParticleManager particleManager;

    private Stats Stats => stats ? stats : core.GetCoreComponent(ref stats);
    private Stats stats;
    
    public void Die()
    {
        foreach (var particle in deathParticles)
        {
            ParticleManager.StartParticles(particle);
        }
        
        core.transform.parent.gameObject.SetActive(false);
                    
        if(gameManager)
        {
            if(core.transform.parent.gameObject.CompareTag("Player"))
            {
                gameManager.Respawn();
            }
        }
    }

    private void OnEnable()
    {
        Stats.OnHealthZero += Die;
    }

    private void OnDisable()
    {
        Stats.OnHealthZero -= Die;
    }
}
