using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    [SerializeField] GameObject hero;
    [SerializeField] GameObject tanker;
    [SerializeField] GameObject solider;

    private Animator heroAnim;
    private Animator tankerAnim;
    private Animator soliderAnim;


    private void Awake()
    {
        Assert.IsNotNull(hero);
        Assert.IsNotNull(tanker);
        Assert.IsNotNull(solider);
        Destroy(GameObject.Find("SceneRoot"));
    }

    // Use this for initialization
    void Start () {
        heroAnim = hero.GetComponent<Animator>();
        tankerAnim = tanker.GetComponent<Animator>();
        soliderAnim = solider.GetComponent<Animator>();
        //ranger

        StartCoroutine(showcase());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator showcase()
    {
        yield return new WaitForSeconds(1f);
        heroAnim.Play("SpinAttack");
        yield return new WaitForSeconds(1f);
        tankerAnim.Play("Attack");
        yield return new WaitForSeconds(1f);
        soliderAnim.Play("Attack");

        yield return new WaitForSeconds(1f);
        StartCoroutine(showcase());
    }

    public void Battle()
    {
        SceneManager.LoadScene("SampleScene");
        //GameManager.instance.ReStartGame();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
