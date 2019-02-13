using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

enum Spell { None = 0, Fire, Lightning };

public class SpellManager : MonoBehaviour
{

    GestureRecognizer m_GestureRecognizer;

    public ParticleSystem[] particles;

    Spell selectedSpell;
    LineRenderer[] line;
    Color startLineColor;
    Color endLineColor;

    //public AudioSource[] audio;
    public AudioSource muahaha;
    public AudioSource muihihi;

    Color startColor;

    ParticleSystem ps;

    AudioSource spellSound;

    public GameObject uiFeedbackFire;
    public GameObject uiFeedbackLightning;

    // for testing only
    int counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        m_GestureRecognizer = new GestureRecognizer();
        GestureSettings m_GestureSettings = m_GestureRecognizer.GetRecognizableGestures();
        m_GestureSettings |= GestureSettings.DoubleTap;
        m_GestureRecognizer.SetRecognizableGestures(m_GestureSettings);

        SetupGestureEvents();
        m_GestureRecognizer.StartCapturingGestures();

        selectedSpell = Spell.None;

        //audio = GetComponent<AudioSource>();
        //muihihi = GetComponent<AudioSource>();

        //StartCoroutine(attack());
    }

    void SetActiveSpell(Spell spell)
    {
        selectedSpell = spell;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator attack()
    {
        Debug.Log("ATTACK");
        if (GameManager.instance.Enemies.Count != 0 && !GameManager.instance.GameOver)
        {
            Debug.Log("HI");
            EnemyHealth randEne = GameManager.instance.Enemies[Random.Range(0, GameManager.instance.Enemies.Count)];
            randEne.GetComponent<EnemyHealth>().takeHit(10);

            ParticleSystem ps = Instantiate(particles[counter], randEne.transform.position, Quaternion.identity) as ParticleSystem;
            Destroy(ps.gameObject, ps.main.startLifetime.Evaluate(1.0f));


            counter++; // for testing only
            if (counter >= particles.Length)
            {
                counter = 0;
            }

            yield return new WaitForSeconds(4f);

        }
        yield return null;
        StartCoroutine(attack());
    }

    void SetupGestureEvents()
    {
        m_GestureRecognizer.Tapped += (args) =>
        {
            if (args.tapCount == 1)
            {
                // head position and orientation.
                var headPosition = Camera.main.transform.position;
                var gazeDirection = Camera.main.transform.forward;

                RaycastHit hitInfo;

                if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
                {
                    if ((hitInfo.transform.name.Contains("Tanker")
                    || hitInfo.transform.name.Contains("Solider")) && selectedSpell != Spell.None)
                    {
                        GameObject selected = hitInfo.transform.gameObject;
                        if ((selectedSpell == Spell.Lightning && selected.transform.name.Contains("Tanker")) 
                        || (selectedSpell == Spell.Fire && selected.transform.name.Contains("Solider")))
                        {
                            selected.GetComponent<EnemyHealth>().takeHit(100);

                            ParticleSystem ps = Instantiate(particles[(int)selectedSpell - 1], selected.transform.position, Quaternion.identity) as ParticleSystem;
                            Destroy(ps.gameObject, ps.main.startLifetime.Evaluate(1.0f));

                            if (line != null)
                            {
                                foreach (var l in line)
                                {
                                    l.startColor = startLineColor;
                                    l.endColor = endLineColor;
                                }
                            }

                            selected.GetComponentInParent<GameObject>().SetActive(false);

                            selectedSpell = Spell.None;
                        } else
                        {
                            if (selected.transform.name.Contains("Tanker"))
                            {
                                muahaha.Play();
                            }
                            else if (selected.transform.name.Contains("Solider"))
                            {
                                muihihi.Play();
                            }
                        }
                    }
                    else if (hitInfo.transform.root.name.Contains("sample_scene"))
                    {

                    }
                    else if (selectedSpell != Spell.Lightning && hitInfo.transform.name.Contains("LightningCube"))
                    {
                        selectedSpell = Spell.Lightning;
                        uiFeedbackFire.SetActive(false);
                        uiFeedbackLightning.SetActive(true);
                        /*
                        line = hitInfo.transform.GetComponentsInChildren<LineRenderer>();
                        foreach (var l in line)
                        {
                            startLineColor = l.startColor;
                            endLineColor = l.endColor;
                            l.startColor = Color.green;
                            l.endColor = Color.green;
                        }
                        */

                        spellSound = hitInfo.transform.GetComponent<AudioSource>();
                        spellSound.Play();
                    }
                    else if (selectedSpell != Spell.Fire && hitInfo.transform.name.Contains("FireCube"))
                    {
                        selectedSpell = Spell.Fire;
                        uiFeedbackFire.SetActive(true);
                        uiFeedbackLightning.SetActive(false);

                        ps = hitInfo.transform.GetComponent<ParticleSystem>();

                        spellSound = hitInfo.transform.GetComponent<AudioSource>();
                        spellSound.Play();

                    }
                }

            }
        };
    }

    

    private void OnDestroy()
    {
        m_GestureRecognizer.StopCapturingGestures();
    }
}
