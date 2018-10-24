//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ShopControler: MonoBehaviour {

////	public GameObject coinsPanel;
////	public GameObject charactersPanel;
////	public GameObject shopLine;
////	public GameObject shopCanvas;
////	public GameObject gameOverUI;
////	public GameObject homeUI;
////	public GameObject charactersParentPanel;
////	public List<GameObject> itemObjects = new List<GameObject>();
////	public GameObject wantToBuyUI;
////	public GameObject notEnoughCoinsUI;
////	public string clickedCharId;
////	public int clickedCharCoinsCount;
////	public int clickedCharIndex;
////	public int coinsForVideoAmount;
////	public Image wantToBuyImage;
////	public Image wantToBuyOutline;
//	public Purchaser purchaser;
//    public Dictionary<string, string> itemDictionary;
//	public bool unlockAll;
//    public List<GameObject> itemObjects;

////	public List<string> charNames;
////	public List<GameObject> overlayUI;
////	[SerializeField]
//	public Color lockedColor;
////	public GameObject rewardedVideoMonkey;
////	public Color disabledButtonColor;
////	public GameObject watchVideoButton;
////	public GameObject videoIconSprite;
////	public GameObject videoCoinSprite;

//	// Use this for initialization
//	void Start () {
//		App.purchaser.InitializePurchasing ();
//	}

		
//	public void RegulateShop(){
		
//	}

//	public void LockAll(){
//		for(int i=1; i<itemObjects.Count; i++)
//		{
//			itemObjects [i].transform.Find ("Coins").gameObject.SetActive(true);
//			itemObjects [i].transform.Find ("LockSprite").gameObject.SetActive(true);
//			SetItemGrey(itemObjects [i].transform.Find ("HeroFull").GetComponent<Image> ());

//		}
//	}

//	public void SetItemGrey(Image i){
//		Color c = lockedColor;
//		i.color = new Color (c.r, c.g, c.b, 1f);
//	}

//	public void ClearAllSelected(){
//		foreach (GameObject go in itemObjects) {
//			go.transform.Find ("SelectedSprite").gameObject.SetActive (false);
//		}
//		itemObjects [use].transform.Find ("SelectedSprite").gameObject.SetActive(true);
//	}

////	public void SmallPack(){
////		App.player.CoinsPlus (purchaser.smallPackCoinAmount);
////	}

////	public void MediumPack(){
////		App.player.CoinsPlus (purchaser.mediumPackCoinAmount);
////	}

////	public void BigPack(){
////		App.player.CoinsPlus (purchaser.bigPackCoinAmount);
////	}

////	public void CharactersTab(){
////		shopCanvas.SetActive (true);
////		coinsPanel.SetActive (false);
////		charactersPanel.SetActive (true);
////		shopLine.transform.rotation = Quaternion.identity;
////		shopLine.transform.Rotate (Vector3.up, 180f);
////	}

////	public void SetWantToBuyImage(){
////		Image wFill = itemObjects [clickedCharIndex].transform.Find ("HeroFull").GetComponent<Image>();
////		wantToBuyImage.sprite = wFill.sprite;
////		wantToBuyImage.rectTransform.sizeDelta = wFill.rectTransform.sizeDelta;
////		Image wOutline = itemObjects [clickedCharIndex].transform.Find ("HeroOutline").GetComponent<Image>();
////		wantToBuyOutline.sprite = wOutline.sprite;
////		wantToBuyOutline.rectTransform.sizeDelta = wOutline.rectTransform.sizeDelta;
////	}

////	public void CoinsTab(){
////		Debug.Log ("Coins Tab Active");
////		shopCanvas.SetActive (true);
////		coinsPanel.SetActive (true);
////		charactersPanel.SetActive (false);
////		shopLine.transform.rotation = Quaternion.identity;
////		#if APPODEAL
////		if(!App.ads.CheckForRewardedVideo()){
////			//watchVideoButton.GetComponent<Button>().interactable = false;
////			watchVideoButton.GetComponent<Image>().color = new Color(disabledButtonColor.r, disabledButtonColor.g, disabledButtonColor.b, 
////				disabledButtonColor.a);
////			videoCoinSprite.GetComponent<Image>().color = new Color(disabledButtonColor.r, disabledButtonColor.g, disabledButtonColor.b, 
////				disabledButtonColor.a);
////			videoIconSprite.GetComponent<Image>().color = new Color(disabledButtonColor.r, disabledButtonColor.g, disabledButtonColor.b, 
////				disabledButtonColor.a);
////		}
////		else{
////			//watchVideoButton.GetComponent<Button>().interactable = true;
////			watchVideoButton.GetComponent<Image>().color = new Color(Color.white.r, Color.white.g, Color.white.b, 
////				1f);
////			videoCoinSprite.GetComponent<Image>().color = new Color(Color.white.r, Color.white.g, Color.white.b, 
////				1f);
////			videoIconSprite.GetComponent<Image>().color = new Color(Color.white.r, Color.white.g, Color.white.b, 
////				1f);
////		}
////		#endif
////	}

////	public void SetStartState(){
////		homeUI.SetActive (false);
////		gameOverUI.SetActive (false);
////		shopCanvas.SetActive (true);
////		charactersPanel.SetActive (true);
////		coinsPanel.SetActive (false);
////		shopLine.transform.rotation = Quaternion.identity;
////		shopLine.transform.Rotate (Vector3.up, 180f);
	
////		//Za likove
////		RegulateShop();
////	}

////	public void ExitShop(){
////		shopCanvas.SetActive (false);
////		if (Gameplay3.instance.currentState == Gameplay3.GameState.GameOver) {
////			gameOverUI.SetActive (true);
////		} else {
////			Gameplay3.instance.HomeScreen ();	
////		}
////	}

////	public void CloseNotEnough(){
////		notEnoughCoinsUI.SetActive (false);
////		OverlayOff ();

////	}

////	public void GetCoins(){
////		App.shopMaster.CoinsTab ();
////		notEnoughCoinsUI.SetActive (false);
////		OverlayOff ();
////	}

////	public void CloseWantToBuy(){
////		wantToBuyUI.SetActive (false);
////		OverlayOff ();

////	}


////	public void CoinsForVideoEffect(){
////		rewardedVideoMonkey.GetComponent<Monkey> ().PopUp ("DoubleCoins");
////		Invoke ("CoinsChaChing", 1f);
////	}

////	public void CoinsChaChing(){
////		App.sound.PlaySound (App.sound.coin);
////		StartCoroutine(Gameplay3.instance.PopCanvasLabel (App.player.canvasCoinLabels[0].gameObject, 0.25f));
////		App.player.CoinsPlus (App.shopMaster.coinsForVideoAmount);
////		App.local.PlayerSave ();
////		#if BestHTTP
////		App.server.Save ();
////		#endif
////	}
		



////	//KUPOVINA LIKOVA

////	public void Buy(){
////		Debug.Log (App.player.coinsCount + " BUY, Coins count ");
////		Debug.Log(Crypting.DecryptInt2 (App.player.coinsCount).ToString());
////		//ODUZIMA SE ODGOVARAJUCI BROJ COINA I DIJAMANATA

////		App.player.CoinsMinus (clickedCharCoinsCount);
////		Debug.Log(Crypting.DecryptInt2 (App.player.coinsCount).ToString());

////		//DODAJE SE ITEM U BAG ILI SE POVECAVA NJEGOV COUNT
////		if(!App.shop.itemDictionary.ContainsKey(clickedCharId)){
////			App.shop.itemDictionary.Add (clickedCharId, clickedCharIndex);
////		}

////		//PlayerPrefs.SetString("Inventory", Json.Serialize(App.inv.inventory));


////		//ZOVE SE ON PURCHASE FUNKCIJA U SHOP CONTROLE
////		OnPurchase(clickedCharId);

////		//UKLJUCUJE SE COUNT SPRITE NA ITEMU I LABELA POSTAVLJA NA ODGOVARAJUCU VREDNOST

////	}


////	public void OnPurchase(string productIdentifier){			

////		Debug.Log("ON PURCHASE FUNCTION STARTED, product id is " + productIdentifier);
////		Transaction trans = new Transaction();
////		App.shop.UpdateCoinsLabels(Crypting.DecryptInt2(App.player.coinsCount).ToString());



////		//Necemo da komplikujemo sa ovim
//////		for(int i=0; i<App.shop.customItems.Count; i++){
//////
//////			if(App.shop.customItems[i].productId.CompareTo(productIdentifier)==0){
//////				//Debug.Log("ON PURCHASE FUNCTION, FOR LOOP");
//////				trans.productName = App.shop.customItems[i].itemName;
//////				trans.customItem = App.shop.customItems[i];
//////				trans.isOneTime = App.shop.customItems[i].isOneTime;
//////				trans.productId = productIdentifier;
//////
//////				App.shop.purchasedItems.Add(App.shop.customItems[i]);
//////
//////				Debug.Log(App.shop.itemDictionary);					
//////
//////				if(App.shop.itemDictionary.ContainsKey(App.shop.customItems[i].productId)){
//////					Debug.Log ("Already in shop item dictionary");
//////				}
//////				else{
//////					App.shop.itemDictionary.Add(App.shop.customItems[i].productId, 1);
//////				}
//////
//////				PlayerPrefs.SetString("shop", Json.Serialize(App.shop.itemDictionary));
//////				//for(int k=0; k<itemDictionary.Count; k++)
//////				//Debug.Log(itemDictionary.ElementAt(k).Value.ToString());
//////
//////
//////				//Ubacujemo u inventar
//////				//					if(inventory.inventory.ContainsKey(customItems[i].productId)){
//////				//						int count =  inventory.inventory[customItems[i].productId];
//////				//						count++;
//////				//						inventory.inventory[customItems[i].productId] = count;
//////				//					}
//////				//					else{
//////				//						inventory.inventory.Add(customItems[i].productId, 1);
//////				//					}
//////
//////
//////			}
//////		}

////		trans.productId = productIdentifier;
////		trans.productName = productIdentifier.Substring (28);
////		trans.isOneTime = true;
////		//App.server.SavePurchase(trans);
////		//if(trans.isOneTime) serverAPIControl.SaveOneTimePurchase(trans);
////		//itemEffect.ApplyEffect(productIdentifier);
////		App.local.PlayerSave();
////		#if BestHTTP
////		App.server.Save();
////		#endif
////		Debug.Log(trans.Print());
////		RegulateShop ();
////		CloseWantToBuy ();
////	}
//}
