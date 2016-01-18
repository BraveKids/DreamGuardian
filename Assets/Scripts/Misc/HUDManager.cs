using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class HUDManager : MonoBehaviour {


	public Image abilityHUD;
	public Slider hpHUD;
	public Slider mpHUD;
	public Sprite arrowHUDSprite;
	public Sprite platformHUDSprite;
	public Dictionary<string,Sprite> HUDSprite = new Dictionary<string, Sprite> ();
	public GameObject pauseMenu;
	
	// Use this for initialization
	public void Start () {
		abilityHUD = gameObject.transform.GetChild (0).GetComponent<Image> ();
		hpHUD = gameObject.transform.Find ("HP").Find ("Slider").GetComponent<Slider> ();
		mpHUD = gameObject.transform.Find ("MP").Find ("Slider").GetComponent<Slider> ();
		
		//manaHUD = gameObject.transform.GetChild(2);

		HUDSprite = new Dictionary<string, Sprite> ();
		HUDSprite.Add ("arrowAbility", arrowHUDSprite);
		HUDSprite.Add ("platformAbility", platformHUDSprite);

		abilityHUD.enabled = false;		
	}


	public void setAbilityHUD (string ability) {
		abilityHUD.enabled = true;
		abilityHUD.sprite = HUDSprite [ability];
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
