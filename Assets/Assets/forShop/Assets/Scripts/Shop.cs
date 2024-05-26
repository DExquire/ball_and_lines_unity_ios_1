using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
	#region Singlton:Shop

	public static Shop Instance;

	void Awake ()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy (gameObject);
	}

	#endregion

	[System.Serializable] public class ShopItem
	{
		public Sprite Image;
		public int Price;
		public bool IsPurchased = false;
	}

	public List<ShopItem> ShopItemsList;
	[SerializeField] Animator NoCoinsAnim;
 

	[SerializeField] GameObject ItemTemplate;
	GameObject g;
	[SerializeField] Transform ShopScrollView;
	[SerializeField] GameObject ShopPanel;
	Button buyBtn;
	Button setBtn;
	[SerializeField]GameObject playBtn;
	string purchased;

	void Start ()
	{
		purchased = PlayerPrefs.GetString("bought");
		print("purchased " + PlayerPrefs.GetString("bought"));
		int len = ShopItemsList.Count;
		for (int i = 0; i < len; i++) {
			g = Instantiate (ItemTemplate, ShopScrollView);
			g.transform.GetChild (1).GetComponent <Image> ().sprite = ShopItemsList [i].Image;
//			g.transform.GetChild (2).GetChild (1).GetChild(0).GetComponent <Text> ().text = ShopItemsList [i].Price.ToString ();
			buyBtn = g.transform.GetChild (3).GetComponent <Button> ();
			setBtn = g.transform.GetChild(4).GetComponent<Button>();
			playBtn = g.transform.GetChild(5).gameObject;
			if (purchased.Contains(i.ToString()))
            {
				ShopItemsList[i].IsPurchased = true;
            }
			if (ShopItemsList[i].IsPurchased)
			{
				DisableBuyButton();
				EnableSetButton(i);
				if (!PlayerPrefs.GetString("bought").Contains(i.ToString()))
				{
					purchased += i.ToString();
					PlayerPrefs.SetString("bought", purchased);
				}
			}
			else
			{
				DisableSetButton();
			}
			buyBtn.AddEventListener (i, OnShopItemBtnClicked);
			setBtn.AddEventListener(i, OnSetSkinBtnClicked);
		}
		setBtn = null;
		print("bought " + PlayerPrefs.GetString("bought"));

	}

	void OnShopItemBtnClicked (int itemIndex)
	{
		if (Game.Instance.HasEnoughCoins (ShopItemsList [itemIndex].Price)) {
			Game.Instance.UseCoins (ShopItemsList [itemIndex].Price);
			//purchase Item
			ShopItemsList [itemIndex].IsPurchased = true;

			//disable the button
			buyBtn = ShopScrollView.GetChild (itemIndex).GetChild (2).GetComponent <Button> ();
			DisableBuyButton ();
			EnableSetButton(itemIndex);
			//change UI text: coins
			Game.Instance.UpdateAllCoinsUIText ();

			purchased += itemIndex.ToString();
			PlayerPrefs.SetString("bought", purchased);
			print(PlayerPrefs.GetString("bought"));

			//add avatar
			//			Profile.Instance.AddAvatar (ShopItemsList [itemIndex].Image);
		} else {
			NoCoinsAnim.SetTrigger ("NoCoins");
			Debug.Log ("You don't have enough coins!!");
		}
	}

	void OnSetSkinBtnClicked(int itemIndex)
    {
		ShopScrollView.GetChild(PlayerPrefs.GetInt("skinIndex")).GetChild(4).gameObject.SetActive(false);
		playBtn = ShopScrollView.GetChild(itemIndex).GetChild(4).gameObject;
		EnablePlayButton();

		PlayerPrefs.SetInt("skinIndex", itemIndex);
		Debug.Log(PlayerPrefs.GetInt("skinIndex"));
    }

	void DisableBuyButton ()
	{
		buyBtn.interactable = false;
		buyBtn.transform.GetChild (0).GetComponent <Text> ().text = "PURCHASED";
	}

	void EnableSetButton(int btnNumber)
	{
		ShopScrollView.GetChild(btnNumber).GetChild(4).GetComponent<Button>().interactable = true;
	}

	void DisableSetButton()
	{
		setBtn.interactable = false;
	}

	void EnablePlayButton()
    {
		playBtn.gameObject.SetActive(true);

		

	}

	void DisablePlayButton()
	{
		playBtn.gameObject.SetActive(false);
	}

	/*---------------------Open & Close shop--------------------------*/
	public void OpenShop ()
	{
		ShopPanel.SetActive (true);
	}

	public void CloseShop ()
	{
		ShopPanel.SetActive (false);
	}

}
