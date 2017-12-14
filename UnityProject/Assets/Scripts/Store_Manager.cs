using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

public class Store_Manager : MonoBehaviour {

	
	public GameObject UserBlobManager;
	public GameObject UIManager;
	
	public bool StoreLoaded = false;
	public bool RandomRestore = false;
	
	public const string No_Ads 	=  "UW_RemoveAds";
	public const string Pro_Version 	=  "UW_Pro";
	public const string ReceiptNo_AdsID = "\"product_id\":\"UW_RemoveAds\"";
	public const string ReceiptPro_VersionID = "\"product_id\":\"UW_Pro\"";
	public const string ReceiptNo_AdsItem = "\"item_id\":\"1086870819\"";
	public const string ReceiptPro_VersionItem = "\"item_id\":\"1086871047\"";
	public const string ReceiptBid = "\"bid\":\"com.blankcartridge.ultimateworkout\"";

	public string NoAdsNameString = "";
	public string ProVersionNameString = "";
	public string NoAdsPriceString = "";
	public string ProVersionPriceString = "";

	void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
		
		StoreLoaded = false;
		//PaymentManagerExample.init();
		InitPaymentManager();
	}
	
	// Use this for initialization
	void Start () 
	{
		// randomly remove all the purchases and restore them to reduce pirating
		int randomNumber = Random.Range(0,19);
		Debug.Log("Random Range = " + randomNumber);
		if(randomNumber < 2)
			//if(randomNumber >= 0)
		{
			UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds = false;
			UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.ProVersion = false;
			UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();
			RandomRestore = true;
		}	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(StoreLoaded == false)
		{
			//StoreUIObject.SetActive(false);
			
			if(IOSInAppPurchaseManager.Instance.IsStoreLoaded)
			{
				StoreLoaded = true;
				
				// set up store items strings
				NoAdsNameString = IOSInAppPurchaseManager.Instance.GetProductById("UW_RemoveAds").DisplayName.ToString();
				ProVersionNameString = IOSInAppPurchaseManager.Instance.GetProductById("UW_Pro").DisplayName.ToString();
				NoAdsPriceString = IOSInAppPurchaseManager.Instance.GetProductById("UW_RemoveAds").LocalizedPrice.ToString();
				ProVersionPriceString = IOSInAppPurchaseManager.Instance.GetProductById("UW_Pro").LocalizedPrice.ToString();
			}
		}		
	}
	
	public void InitPaymentManager()
	{
		IOSInAppPurchaseManager.OnVerificationComplete += HandleOnVerificationComplete;
		IOSInAppPurchaseManager.OnStoreKitInitComplete += OnStoreKitInitComplete;
		IOSInAppPurchaseManager.OnTransactionComplete += OnTransactionComplete;
		IOSInAppPurchaseManager.OnRestoreComplete += OnRestoreComplete;
		
		Debug.Log(UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds);
		Debug.Log(UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.ProVersion);
		IOSInAppPurchaseManager.Instance.LoadStore();
	}
	
	public void BuyRemoveAds()
	{
		if(StoreLoaded == true && IOSInAppPurchaseManager.Instance.IsInAppPurchasesEnabled)
		{
			PaymentManagerExample.buyItem(PaymentManagerExample.No_Ads);
		}
	}
	
	public void BuyProVersion()
	{
		if(StoreLoaded == true && IOSInAppPurchaseManager.Instance.IsInAppPurchasesEnabled)
		{
			PaymentManagerExample.buyItem(PaymentManagerExample.Pro_Version);
		}
	}
	
	public void RestorePurchases()
	{
		if(StoreLoaded == true && IOSInAppPurchaseManager.Instance.IsInAppPurchasesEnabled)
		{
			IOSInAppPurchaseManager.Instance.RestorePurchases();
		}
	}
	
	
	//--------------------------------------
	//  PUBLIC METHODS
	//--------------------------------------
	
	
	public static void buyItem(string productId) 
	{
		IOSInAppPurchaseManager.Instance.BuyProduct(productId);
	}
	
	//--------------------------------------
	//  GET/SET
	//--------------------------------------
	
	//--------------------------------------
	//  EVENTS
	//--------------------------------------
	
	
	private static void UnlockProducts(string productIdentifier) 
		//private void UnlockProducts(string productIdentifier) 
	{
		switch(productIdentifier) 
		{
		case No_Ads:
			//code for adding small game money amount here
			GameObject UserBlobManagerNoAds = GameObject.Find("UserBlob_Prefab");
			UserBlobManagerNoAds.GetComponent<UserBlobManager>().UserSettingsData.NoAds = true;
			UserBlobManagerNoAds.GetComponent<UserBlobManager>().SaveSettings();
			//UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds = true;
			//UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();
			Debug.Log("Purchased - No Ads");
			break;
		case Pro_Version:
			//code for unlocking cool item here
			GameObject UserBlobManagerPro = GameObject.Find("UserBlob_Prefab");
			UserBlobManagerPro.GetComponent<UserBlobManager>().UserSettingsData.ProVersion = true;
			UserBlobManagerPro.GetComponent<UserBlobManager>().SaveSettings();
			//UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.ProVersion = true;
			//UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();
			Debug.Log("Purchased - Pro Version");
			break;
			
		}
	}
	
	//private static void OnTransactionComplete (IOSStoreKitResult result) {
	private void OnTransactionComplete (IOSStoreKitResult result) {
		
		Debug.Log("OnTransactionComplete: " + result.ProductIdentifier);
		Debug.Log("OnTransactionComplete: state: " + result.State);
		
		switch(result.State) {
		case InAppPurchaseState.Purchased:
			IOSInAppPurchaseManager.Instance.VerifyLastPurchase(IOSInAppPurchaseManager.SANDBOX_VERIFICATION_SERVER);
			Debug.Log("Purchased");
			break;
		case InAppPurchaseState.Restored:
			//Our product been succsesly purchased or restored
			//So we need to provide content to our user depends on productIdentifier
			UnlockProducts(result.ProductIdentifier);
			Debug.Log("Purchases Restored");
			break;
		case InAppPurchaseState.Deferred:
			//iOS 8 introduces Ask to Buy, which lets parents approve any purchases initiated by children
			//You should update your UI to reflect this deferred state, and expect another Transaction Complete  to be called again with a new transaction state 
			//reflecting the parent’s decision or after the transaction times out. Avoid blocking your UI or gameplay while waiting for the transaction to be updated.
			IOSNativePopUpManager.showMessage("Waiting For Approval", ("Thank you! Your purchase is pending an approval from your family delegate."));
			Debug.Log("Purchases Deferred");
			break;
		case InAppPurchaseState.Failed:
			//Our purchase flow is failed.
			//We can unlock intrefase and repor user that the purchase is failed. 
			//IOSNativePopUpManager.showMessage("Purchase Failed", ("Error Code:\n" + result.Error.Code));
			Debug.Log("Transaction failed with error, code: " + result.Error.Code);
			Debug.Log("Transaction failed with error, description: " + result.Error.Description);
			
			
			break;
		}
		
		if(result.State == InAppPurchaseState.Failed) {
			//IOSNativePopUpManager.showMessage("Transaction Failed", "Error code: " + result.Error.Code + "\n" + "Error description:" + result.Error.Description);
			switch(result.Error.Code)
			{
			case 0:
				IOSNativePopUpManager.showMessage("Purchase Failed", "Error:\n" + result.Error.Description);
				break;
			case 1:
				IOSNativePopUpManager.showMessage("Purchase Failed", "Invalid client");
				break;
			case 2:
				IOSNativePopUpManager.showMessage("Purchase Failed", "Payment canceled");
				break;
			case 3:
				IOSNativePopUpManager.showMessage("Purchase Failed", "Payment invalid");
				break;
			case 4:
				IOSNativePopUpManager.showMessage("Purchase Failed", "Device is not authorized for purchaces");
				break;
			case 5:
				IOSNativePopUpManager.showMessage("Purchase Failed", "Product unavailable");
				break;
			case 6:
				IOSNativePopUpManager.showMessage("Purchase Failed", "No purchases to restore");
				break;
			case 7:
				IOSNativePopUpManager.showMessage("Purchase Failed", "Store access failed");
				break;
			default:
				IOSNativePopUpManager.showMessage("Purchase Failed", ("Error Code:\n" + result.Error.Code));
				break;
			}
		} 
		else 
		{
			/*
			if(RandomRestore == false)
			{
				if(result.State.ToString() == "Restored")
				{
					IOSNativePopUpManager.showMessage("Restore Succeeded", "Restored Purchases");
				}
				else
				{
					string tempMessage = "Purchase Complete";
					if(result.ProductIdentifier.ToString() == No_Ads)
					{
						tempMessage = "No Ads\n" + result.State.ToString();
					}
					if(result.ProductIdentifier.ToString() == Pro_Version)
					{
						tempMessage = "Pro Version\n" + result.State.ToString();
					}
					// this is commmented out because it is rendundant since there thank you message is already displayed
					//IOSNativePopUpManager.showMessage("Purchase Complete", tempMessage);
				}
			}
			*/
		}
	}
	
	//private static void OnRestoreComplete (IOSStoreKitRestoreResult res) 
	private void OnRestoreComplete (IOSStoreKitRestoreResult res) 
	{
		if(RandomRestore == true)
		{
			RandomRestore = false;
			if(res.IsSucceeded)
			{
				Debug.Log("Random Restore Successful");
			}
			else
			{
				Debug.Log("Random Restore Failed");
			}
		}
		else
		{
			if(res.IsSucceeded) 
			{
				//IOSNativePopUpManager.showMessage("Success", "Restore Compleated");
				IOSNativePopUpManager.showMessage("Restore Succeeded", "Restored Completed");
			} 
			else 
			{
				//IOSNativePopUpManager.showMessage("Error: " + res.Error.Code, res.Error.Description);
				switch(res.Error.Code)
				{
				case 0:
					IOSNativePopUpManager.showMessage("Restore Failed", "Unknown error");
					break;
				case 1:
					IOSNativePopUpManager.showMessage("Restore Failed", "Invalid client");
					break;
				case 2:
					IOSNativePopUpManager.showMessage("Restore Failed", "Payment canceled");
					break;
				case 3:
					IOSNativePopUpManager.showMessage("Restore Failed", "Payment invalid");
					break;
				case 4:
					IOSNativePopUpManager.showMessage("Restore Failed", "Device is not authorized for purchaces");
					break;
				case 5:
					IOSNativePopUpManager.showMessage("Restore Failed", "Product unavailable");
					break;
				case 6:
					IOSNativePopUpManager.showMessage("Restore Failed", "No purchases to restore");
					break;
				case 7:
					IOSNativePopUpManager.showMessage("Restore Failed", "Store access failed");
					break;
				default:
					IOSNativePopUpManager.showMessage("Restore Failed", ("Error Code:\n" + res.Error.Code));
					break;
				}
			}
		}
	}	
	
	
	//static void HandleOnVerificationComplete (IOSStoreKitVerificationResponse response) 
	void HandleOnVerificationComplete (IOSStoreKitVerificationResponse response) 
	{
		//IOSNativePopUpManager.showMessage("Verification", "Transaction verification status: " + response.status.ToString());
		Debug.Log("ORIGINAL JSON: " + response.originalJSON);
		string ReceiptString = response.originalJSON.ToString();
		
		if (ReceiptString.Contains(ReceiptNo_AdsID) == false && ReceiptString.Contains(ReceiptPro_VersionID) == false)
		{
			// not a valid receipt
			Debug.Log("Invalid Receipt");
			UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds = false;
			UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.ProVersion = false;
			UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();
		}
		else
		{
			if (ReceiptString.Contains(ReceiptNo_AdsID) == true)
			{
				if (ReceiptString.Contains(ReceiptNo_AdsItem) == true)
				{
					if (ReceiptString.Contains(ReceiptBid) == true)
					{
						// valid receipt
						Debug.Log("Valid Receipt");
						UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds = true;
						UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();
					}
					else
					{
						// not a valid receipt
						Debug.Log("Invalid Receipt");
						UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds = false;
						UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.ProVersion = false;
						UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();
					}
				}
				else
				{
					// not a valid receipt
					Debug.Log("Invalid Receipt");
					UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds = false;
					UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.ProVersion = false;
					UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();
				}
			}
			else 
			{
				if(ReceiptString.Contains(ReceiptPro_VersionID) == true)
				{
					if (ReceiptString.Contains(ReceiptPro_VersionItem) == true)
					{
						if (ReceiptString.Contains(ReceiptBid) == true)
						{
							// valid receipt
							Debug.Log("Valid Receipt");
							UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.ProVersion = true;
							UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();
						}
						else
						{
							// not a valid receipt
							Debug.Log("Invalid Receipt");
							UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds = false;
							UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.ProVersion = false;
							UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();
						}
					}
					else
					{
						// not a valid receipt
						Debug.Log("Invalid Receipt");
						UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds = false;
						UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.ProVersion = false;
						UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();
					}
				}
				else
				{
					// not a valid receipt
					Debug.Log("Invalid Receipt");
					UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds = false;
					UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.ProVersion = false;
					UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();
				}
			}
		}
	}
	
	
	//private static void OnStoreKitInitComplete(ISN_Result result) 
	private void OnStoreKitInitComplete(ISN_Result result) 
	{
		if(result.IsSucceeded == true) 
		{
			int avaliableProductsCount = 0;
			foreach(IOSProductTemplate tpl in IOSInAppPurchaseManager.instance.Products) 
			{
				if(tpl.IsAvaliable) 
				{
					avaliableProductsCount++;
				}
			}
			Debug.Log("StoreKit Init Succeeded Available products count: " + avaliableProductsCount);
			//IOSNativePopUpManager.showMessage("StoreKit Init Succeeded", "Available products count: " + avaliableProductsCount);
			
			if(RandomRestore == true)
			{
				Debug.Log("check for random restore");
				if(IOSInAppPurchaseManager.Instance.IsStoreLoaded == true && IOSInAppPurchaseManager.Instance.IsInAppPurchasesEnabled)
				{
					Debug.Log("start random restore");
					IOSInAppPurchaseManager.Instance.RestorePurchases();
				}
				else
				{
					Debug.Log("random restore failed - cant load store");
				}
			}
		}
		else 
		{
			Debug.Log("Store Init Failed:\nError code:\n" + result.Error.Code.ToString());
			//IOSNativePopUpManager.showMessage("Store Init Failed:", "Error code:\n" + result.Error.Code);
			RandomRestore = false;
		}
	}
}
