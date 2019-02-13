using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] private int startingHealth = 20;
    [SerializeField] private float timeSinceLasthit = 0.5f;
    [SerializeField] private float dissapearSpeed = 2f;

    private AudioSource audio;
    private float timer = 0f;
    private Animator anim;
    private NavMeshAgent nav;
    private bool isAlive;
    private Rigidbody rigidBody;
    private CapsuleCollider capsuleColider;
    private bool dissapearEnemy = false;
    private int currentHealth;
    private ParticleSystem blood;


    public bool IsAlive
    {
        get { return isAlive; }
    }

	// Use this for initialization
	void Start () {

        GameManager.instance.RegisterEnemy(this);
        rigidBody = GetComponent<Rigidbody>();
        capsuleColider = GetComponent<CapsuleCollider>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        isAlive = true;
        currentHealth = startingHealth;
        blood = GetComponentInChildren<ParticleSystem>();

    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if (dissapearEnemy)
        {
            transform.Translate(-Vector3.up * dissapearSpeed * Time.deltaTime);
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if(timer >= timeSinceLasthit && !GameManager.instance.GameOver)
        {
            if(other.tag == "PlayerWeapon")
            {
                takeHit(10);
                blood.Play();
                timer = 0f;
            }
        }
    }


    public void takeHit(int damage)
    {
        if(currentHealth > 0)
        {
            audio.PlayOneShot(audio.clip);
            anim.Play("Hurt");
            currentHealth -= damage;
            blood.Play();
        }

        if(currentHealth <= 0)
        {
            isAlive = false;
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        GameManager.instance.KillEnemy(this);
        capsuleColider.enabled = false;
        nav.enabled = false;
        anim.SetTrigger("EnemyDie");
        rigidBody.isKinematic = true;

        StartCoroutine(removeEnemy());
        

    }

    IEnumerator removeEnemy()
    {
        yield return new WaitForSeconds(4f);
        dissapearEnemy = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
