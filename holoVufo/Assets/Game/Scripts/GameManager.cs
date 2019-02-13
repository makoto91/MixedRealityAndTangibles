using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    [SerializeField] GameObject player;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject tanker;
    [SerializeField] GameObject ranger;
    [SerializeField] GameObject solider;
    [SerializeField] Text levelText;
    [SerializeField] Text endGameText;
    [SerializeField] int finalLevel = 20;


    private bool gameOver = false;
    private int currentLevel;
    private float generatedSpawnTime = 1;
    private float currentSpawntime = 0;
    private GameObject newEnemy;

    private List<EnemyHealth> enemies = new List<EnemyHealth>();
    private List<EnemyHealth> killedEnemies = new List<EnemyHealth>();

    public List<EnemyHealth> Enemies
    {
        get { return enemies; }
    }

    public void RegisterEnemy(EnemyHealth enemy)
    {
        enemies.Add(enemy);
    }

    public void KillEnemy(EnemyHealth enemy)
    {
        //enemies.Remove(enemy);
        killedEnemies.Add(enemy);
    }

    public bool GameOver
    {
        get { return gameOver; }
    }

    public GameObject Player
    {
        get { return player; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        //Debug.Log("test");
        endGameText.GetComponent<Text>().enabled = false;
        currentLevel = 1;
        StartCoroutine(spawn());

    }

    // Update is called once per frame
    void Update()
    {
        currentSpawntime += Time.deltaTime;
    }

    public void PlayerHit(int currentHP)
    {
        if (currentHP > 0)
        {
            gameOver = false;
        }
        else
        {
            gameOver = true;
            StartCoroutine(endGame("Defeat!"));
        }
    }

    IEnumerator spawn()
    {
        if (currentSpawntime > generatedSpawnTime)
        {
            currentSpawntime = 0;
            if (enemies.Count < currentLevel)
            {
                //spawn a random enemy
                int randomNumber = Random.Range(0, spawnPoints.Length);

                GameObject spawnLocation = spawnPoints[randomNumber];
                int randomEnemy = Random.Range(0, 2);
                if (randomEnemy == 0)
                {
                    newEnemy = Instantiate(solider) as GameObject;
                }
                else if (randomEnemy == 1)
                {
                    newEnemy = Instantiate(tanker) as GameObject;
                }
                //else if (randomEnemy == 2)
                //{
                //    newEnemy = Instantiate(tanker) as GameObject;
                //}


                newEnemy.transform.position = spawnLocation.transform.position;
                //newEnemy.transform.parent = GameObject.Find("SceneRoot").transform;
                newEnemy.SetActive(true);

            }
        }

        if (killedEnemies.Count == currentLevel && currentLevel != finalLevel)
        {
            killedEnemies.Clear();
            enemies.Clear();

            yield return new WaitForSeconds(3f);
            currentLevel++;
            levelText.text = "Level " + currentLevel;
        }

        if (killedEnemies.Count == finalLevel)
        {
            StartCoroutine(endGame("Victory!"));
        }

        yield return null;
        StartCoroutine(spawn());
    }

    IEnumerator endGame(string outcome)
    {

        endGameText.text = outcome;
        endGameText.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(3f);
        
        SceneManager.LoadScene("GameMenu");
        
        //foreach (EnemyHealth enemy in enemies)
        //{
        //    enemy.KillEnemy();
        //}

        //player.GetComponent<CharacterController>().enabled = false;
        //gameOver = true;
    }
}
