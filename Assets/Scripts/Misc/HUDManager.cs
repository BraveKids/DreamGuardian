using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class HUDManager : MonoBehaviour {

	public GameObject pauseMenu;
	public Image abilityHUD;
	Slider hpHUD;
	Slider mpHUD;
	public Slider gorillaBossHP;
	public Slider knightBossHP;
	public Sprite arrowHUDSprite;
	public Sprite platformHUDSprite;
	public Dictionary<string,Sprite> HUDSprite = new Dictionary<string, Sprite> ();
	
	// Use this for initialization
	public void Start () {
		abilityHUD = gameObject.transform.GetChild (0).GetComponent<Image> ();
		hpHUD = gameObject.transform.Find ("HP").Find ("Slider").GetComponent<Slider> ();
		mpHUD = gameObject.transform.Find ("MP").Find ("Slider").GetComponent<Slider> ();
		gorillaBossHP = gameObject.transform.Find ("GorillaBossHP").Find ("Slider").GetComponent<Slider> ();
		gorillaBossHP.gameObject.SetActive (false);
		knightBossHP = gameObject.transform.Find ("KnightBossHP").Find ("Slider").GetComponent<Slider> ();
		knightBossHP.gameObject.SetActive (false);
		//manaHUD = gameObject.transform.GetChild(2);

		HUDSprite = new Dictionary<string, Sprite> ();
		HUDSprite.Add ("arrowAbility", arrowHUDSprite);
		HUDSprite.Add ("platformAbility", platformHUDSprite);

		abilityHUD.enabled = false;		
	}

	void Update () {
		/*if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Joystick1Button7)) {
			pauseMenu.SetActive (true);
			pauseMenu.GetComponent<PauseMenu> ().Start ();
		}*/
	}

	public void setAbilityHUD (string ability) {
		abilityHUD.enabled = true;
		abilityHUD.sprite = HUDSprite [ability];
	}

	public void updateBossHP(int hp){
		gorillaBossHP.value = hp;
	}
	public void updateKnightBossHP(int hp){
		knightBossHP.value = hp;
	}
	public void updateHP (int hp) {
		hpHUD.value = hp;
	}

	public void updateMP (int mp) {
		mpHUD.value = mp;
	}

	//completamente inutili a quanto pare
	void Awake () {
		DontDestroyOnLoad (gameObject);
		DontDestroyOnLoad (gameObject.transform.GetChild (0));
		
	}
}
