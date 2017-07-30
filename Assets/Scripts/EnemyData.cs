using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [Space]
    bool inBattle = false;

    Animator animator;

	// Use this for initialization
	void Start ()
    {
        if(display_name != null)
            display_name.text = m_name;
        m_max_health = m_health;
        m_noteSpeed = m_BPM;

        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //if(inBattle && SceneManager.GetActiveScene().name != "Battle2")
        //{
        //    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Battle2"));
        //    if (GameObject.Find("BattleManager") == null)
        //        return;

        //    GameObject.Find("BattleManager").GetComponent<BattleSystem>().m_enemy = this;
        //    display_name = GameObject.Find("EnemyInfo").transform.GetChild(0).GetComponentInChildren<Text>();
        //    health_bar = GameObject.Find("EnemyInfo").transform.GetChild(1).GetComponentInChildren<Slider>();
        //}
    }

    public void TakeDamage(float damage)
    {
        m_health -= damage;

        if (m_health <= 0)
        {
            GameObject.Find("BattleManager").GetComponent<BattleSystem>().FinishBattle(); //Remeber to delete the enemy in overworld

            // Remove enemy from list
            GameObject.Find("PlayerObject").GetComponent<PlayerController>().RemoveInspectObject(this.GetComponentInChildren<Inspect>());

            DestroySelf();
            return;
        }
        
        UpdateUI();
    }

    void UpdateUI()
    {
        //display_name.text = m_name;
        health_bar.value = m_health / m_max_health;
    }

    public void StartBattle()
    {
        //SceneManager.LoadSceneAdditive("BattleTest");
        SceneManager.LoadScene("Battle2", LoadSceneMode.Additive);
        inBattle = true;

        PersistentData.m_Instance.adRef.PlayBattle();

        animator.SetBool("isAttacking", true);
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    public void SamuliFight()
    {
        SceneManager.LoadScene("BattleTest", LoadSceneMode.Additive);
        inBattle = true;

        PersistentData.m_Instance.adRef.PlayBattle();

        animator.SetBool("isAttacking", true);
    }
}
