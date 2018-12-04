using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour {
	public static int playerHealth;
	public int maxPlayerHealth;
	//Text text;
	private LevelManager levelManager;
	public bool isDead;
	public Slider healthBar;
	private LifeManager lifeSystem;
	// Use this for initialization
	void Start () {
		//text = GetComponent<Text> ();
		healthBar=GetComponent<Slider>();
		playerHealth = maxPlayerHealth;
		levelManager = FindObjectOfType<LevelManager>();
		lifeSystem = FindObjectOfType<LifeManager> ();
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0 && !isDead) {
			playerHealth = 0;
			levelManager.RespawnPlayer ();
			lifeSystem.TakeLife ();
			isDead = true;
		}
		if (playerHealth > maxPlayerHealth) {
			playerHealth = maxPlayerHealth;
		}
		//text.text=""+playerHealth;
		healthBar.value=playerHealth;
	}
	public static void HurtPlayer(int damageToGive){

		playerHealth -= damageToGive;
	}
	public void FullHealth(){
		playerHealth = maxPlayerHealth;

	}
}
