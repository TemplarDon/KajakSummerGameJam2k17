using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyData : MonoBehaviour {

    //EnemyData
    public string m_name = "Unnamed";
    public float m_health = 100.0f;
    public float m_BPM = 60.0f;
    public int m_maxNotes = 4; //How many notes can be given in a wave
    public float m_noteSpeed;

    private float m_max_health;

    //UI Display stuff
    public Text display_name;
    public Slider health_bar;

	// Use this for initialization
	void Start ()
    {
        display_name.text = m_name;
        m_max_health = m_health;
        m_noteSpeed = m_BPM;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(float damage)
    {
        m_health -= damage;

        if (m_health <= 0)            
            GameObject.Find("BattleManager").GetComponent<BattleSystem>().FinishBattle();
        
        UpdateUI();
    }

    void UpdateUI()
    {
        health_bar.value = m_health / m_max_health;
    }
}
