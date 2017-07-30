using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour {

    public GameObject noteBlock;

    //Enemy stuff
    [Space]
    public EnemyData m_enemy;
    float wave_counter = 0.0f;
    public float chanceToSpawnWave = 75.0f; //Might change to EnemyData side
    private float spawnTimer;

    [Space]
    public Slider AttackBar;

    [Space]
    public int PlayerHealth;
    public Text PlayerHealthTextDisplay;

    [Space]
    public Transform[] SpawnLocations;      //Should always be 4 

    private GameObject player_info;

    public Animator[] character_anims;

    // Use this for initialization
    void Start()
    {
        player_info = GameObject.Find("PlayerObject");
        PlayerHealth = player_info.GetComponent<PartyMembersList>().PartyList.Count + 1;
        spawnTimer = 1 / (m_enemy.m_BPM / 60);  //Algo for how frequent waves spawn
        PlayerHealthTextDisplay.text = PlayerHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyUpdate();
        AttackInput();
    }

    void AttackInput()
    {
        if(Input.GetKeyDown("space"))
        {
            for(int i = 0; i < character_anims.Length; ++i)
                character_anims[i].SetInteger("state", (int)PartyMember.ANIM_STATE.ATTACK);

            m_enemy.TakeDamage(AttackBar.value);    //What's a good value to deal with this?
            AttackBar.value = 0;
        }
    }

    void GenerateWave()
    {
        //See if generate a wave
        if (Random.Range(0, 100) > chanceToSpawnWave)
            return;

        //Get how many notes this wave is gonna generate
        int numberOfNotes = Random.Range(1, m_enemy.m_maxNotes + 1);

        //See which areas should generate the notes
        List<int> areaToSpawn = new List<int>();
        for (int i = 0; i < numberOfNotes;)
        {
            int number = Random.Range(0, 4); 
            if (areaToSpawn.Contains(number))    //If already has that number, try again
                continue;
            else
            {
                areaToSpawn.Add(number);
                ++i;
            }
        }

        //Spawn
        for(int i = 0; i < areaToSpawn.Count; ++i)
        {
            GameObject go = Instantiate(noteBlock, SpawnLocations[areaToSpawn[i]].position, Quaternion.identity);
            go.GetComponent<NoteBlockScript>().SetSpeed(m_enemy.m_noteSpeed * 2);
        }
    }

    void EnemyUpdate()
    {
        wave_counter += Time.deltaTime;

        if(wave_counter >= spawnTimer)
        {
            GenerateWave();
            wave_counter = 0.0f;
        }
    }

    public void FinishBattle()
    {
        PersistentData.m_Instance.adRef.PlayBGM();

        SceneManager.UnloadSceneAsync("BattleTest");
        //Back to overworld?
    }

    //Player only ever takes one damage at a time
    public void PlayerTakeDamage()
    {
        PlayerHealth--;
        //Do some animation stuff I guess?
        if (PlayerHealth == 0)
            DoGameOver();

        PlayerHealthTextDisplay.text = PlayerHealth.ToString();
    }

    public void DoGameOver()
    {
        //Back to previous water cooler point or something?
    }
}
