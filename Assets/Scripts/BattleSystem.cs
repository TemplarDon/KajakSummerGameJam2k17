using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour {

    public GameObject noteBlock;

    //Enemy stuff
    public EnemyData m_enemy;
    float wave_counter = 0.0f;
    public float chanceToSpawnWave = 75.0f; //Might change to EnemyData side

    public Transform[] SpawnLocations;      //Should always be 4 
    bool m_playerTurn;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (!m_playerTurn)
            EnemyTurn();
        else
            PlayerTurn();
    }

    void GenerateWave()
    {
        //See if generate a wave
        if (Random.Range(0, 100) > chanceToSpawnWave)
            return;

        //Get how many notes this wave is gonna generate
        int numberOfNotes = Random.Range(1, m_enemy.m_maxNotes + 1);
        Debug.Log("Number of notes: " + numberOfNotes);

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
            //Debug.Log(i + " " + areaToSpawn[i]);
            GameObject go = Instantiate(noteBlock, SpawnLocations[areaToSpawn[i]].position, Quaternion.identity);
            go.GetComponent<NoteBlockScript>().SetSpeed(m_enemy.m_BPM * 2);
        }
    }

    void PlayerTurn()
    {

    }

    void EnemyTurn()
    {
        wave_counter += Time.deltaTime;
        if(wave_counter >= m_enemy.m_BPM / 60)
        {
            GenerateWave();
            wave_counter = 0.0f;
        }
    }

    void PlayerCombatInput()
    {

    }

    void PlayerChoiceInput()
    {

    }

    void DisplayEnemyUI()
    {

    }


}
