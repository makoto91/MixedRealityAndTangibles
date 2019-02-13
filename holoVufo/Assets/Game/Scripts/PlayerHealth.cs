using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int startingHealth = 100;
    [SerializeField] float timeSinceLastHit = 2f;
    [SerializeField] Slider healthSlider;

    private float timer = 0;
    private CharacterController characterController;
    private Animator anim;
    private int currentHealth;
    private AudioSource audio;
    private ParticleSystem blood;

    private void Awake()
    {
        Assert.IsNotNull(healthSlider);
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        currentHealth = startingHealth;
        audio = GetComponent<AudioSource>();
        blood = GetComponentInChildren<ParticleSystem>();

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

	}

    private void OnTriggerEnter(Collider other)
    {
        if(timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            if (other.tag == "Weapon")
            {
                takeHit(10);
                blood.Play();
                timer = 0;
            }
        }
    }

    void takeHit(int damage)
    {
        if(currentHealth > 0)
        {
            GameManager.instance.PlayerHit(currentHealth);
            anim.Play( "Hurt");
            currentHealth -= damage;
            healthSlider.value = currentHealth;
            audio.PlayOneShot(audio.clip);
            
        }

        if(currentHealth <= 0)
        {
            killPlayer();
        }
    }

    void killPlayer()
    {
        GameManager.instance.PlayerHit(currentHealth);
        anim.SetTrigger("HeroDie");
        characterController.enabled = false;
        audio.PlayOneShot(audio.clip);
        
    }
}
