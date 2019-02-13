using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField] private float range = 0.1f;
    [SerializeField] private float timeBetweenAttacks = 0.5f;

    private Animator anim;
    private List<EnemyHealth> enemies;
    private bool enemyInRange;
    private BoxCollider[] weaponColliders;
    private PlayerHealth playerHealth;

    // Use this for initialization
    void Start () {

        playerHealth = GetComponent<PlayerHealth>();
        weaponColliders = GetComponentsInChildren<BoxCollider>();
        anim = GetComponent<Animator>();

        StartCoroutine(attack());
    }
	
	// Update is called once per frame
	void Update () {
        foreach (EnemyHealth enemy in GameManager.instance.Enemies)
        {
            if (enemy != null && Vector3.Distance(transform.position, enemy.transform.position) < range && !GameManager.instance.GameOver && enemy.IsAlive)
            {
                enemyInRange = true;
                break;
            }
            else
            {
                enemyInRange = false;
            }
        }

        
    }


    IEnumerator attack()
    {
        if (enemyInRange && !GameManager.instance.GameOver)
        {
            anim.Play("SpinAttack");
            yield return new WaitForSeconds(timeBetweenAttacks);

        }
        yield return null;
        StartCoroutine(attack());
    }

    public void BeginAttack()
    {
        foreach (var weapon in weaponColliders)
        {
            weapon.enabled = true;
        }
    }

    public void EndAttack()
    {
        foreach (var weapon in weaponColliders)
        {
            weapon.enabled = false;
        }
    }


}
