﻿using UnityEngine;
using System.Collections;



public class EFE_Base: MonoBehaviour {
	
	[Tooltip("The first panel that is displayed at game start")]
	public  GameObject firstPanel; //the first panel you want to display at game start
	[Tooltip("Should the first panel use its transition the first time it is displayed?")]
	public bool useFirstPanelTransition;
	public GameObject [] panelList;
	public static Vector3 panelLastPosition;
	public GameObject currentPanel;
	public GameObject previousPanel;
	public static GameObject currentOverlay;
	public static Vector3 overlayLastPosition;
	private bool isFirstPanel=true;
	
	EFE_PanelTransition panelTransitionScript;
	EFE_PanelTransition prevPanelTransitionScript ;
		
	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad(gameObject);
		
		if(firstPanel==null)
		{
			Debug.LogError("Please assign a panel string in the EFE_Container inspector. This will be the first panel that will be opened by default.");
		}
		OpenPanel(firstPanel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OpenPanel(GameObject panel)
	{
		
		string panelName=panel.name;
		//close current panel if applicabale
		if(currentPanel)
		{
			//currentPanel.transform.position = panelLastPosition;
			previousPanel = currentPanel;
		}
		

		currentPanel = FindPanel(panelName);
		currentPanel.SetActive(true);
		panelLastPosition = currentPanel.transform.position;

		////position panel on the screen!
		currentPanel.transform.position = currentPanel.transform.parent.position;
	
		/////////////////////////////////////////////
		panelTransitionScript = currentPanel.GetComponent<EFE_PanelTransition>();
		if(previousPanel)
		{prevPanelTransitionScript = previousPanel.GetComponent<EFE_PanelTransition>();}
		
		float hidePanelWaitTime =0f;
		
		//Prevent any transitions on first panel (if required)
		if(panelName ==firstPanel.name && isFirstPanel==true)
		{
			if(useFirstPanelTransition==false)
			{panelTransitionScript=null;}
			
			isFirstPanel=false;
		}
		
		//Do transition
		if(panelTransitionScript)
		{
			
			panelTransitionScript.DoTransitionIn();
			
			if(prevPanelTransitionScript){
				prevPanelTransitionScript.DoTransitionOut();}
			
			hidePanelWaitTime = panelTransitionScript.transitionSpeed;
			//
			currentPanel.transform.SetAsLastSibling ();
			StartCoroutine(HideAllPanelsAfterDelay(hidePanelWaitTime));
			
		}
		else
		{
			hidePanelWaitTime = 0f;
			HideAllPanels();//do it now
			if(previousPanel)
			{previousPanel.transform.position = panelLastPosition;}
			return;
		}
		
		//////////////////////////////////////////////
		
	}
	
	public void CloseCurrentPanel()//used for transition
	{
		//DoTransitionOut()
	}
	
	public void CloseCurrentOverlayPanel()
	{
		if(currentOverlay)
		{
			//currentOverlay.transform.position = overlayLastPosition;
			
		}
		
		panelTransitionScript = currentOverlay.GetComponent<EFE_PanelTransition>();
		float hidePanelWaitTime =0f;
		
		if(panelTransitionScript)
		{
			panelTransitionScript.DoTransitionOut();
			hidePanelWaitTime = panelTransitionScript.transitionSpeed;
			StartCoroutine(HideAllPanelsAfterDelay(hidePanelWaitTime));
		}
		else
		{
			currentOverlay.transform.position = overlayLastPosition;
		}
		
		//fade out the dark fade screen
		BroadcastMessage("BackgroundFadeOut",SendMessageOptions.DontRequireReceiver);
		
		
		StartCoroutine(HideAllPanelsAfterDelay(hidePanelWaitTime));
	}
	
	
	public IEnumerator HideAllPanelsAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		
		HideAllPanels();
		
		if(previousPanel)
		{
			previousPanel.transform.position = panelLastPosition;
		}
	}
	
	private GameObject foundPanel;
	
	public GameObject FindPanel(string panelName)
	{

		for (int i=0;i<panelList.Length;i++)
		{
			if(panelList[i]!=null)
			{
				if(panelList[i].name==panelName)
				{
					foundPanel = panelList[i];
					
				}
			}
			//else
			//{
			//	Debug.LogError("It looks like you havent added your new panel ("+panelName+") to the EFE Base panel list.");
			//}
		}
		
		return (foundPanel);
	}
	
	public void HideAllPanels()//except for curent panel
	{
		//return;
		for (int i=0;i<panelList.Length;i++)
		{
			if(panelList[i]!=null)
			{
				if(panelList[i].name!=currentPanel.name)
				{
					panelList[i].SetActive(false);
				}
			}
		}
	}
	
	public void HideCurrentPanel()
	{
		currentPanel.transform.position = panelLastPosition;
	}

	
	public void OpenOverlayPanel(GameObject panel)
	{
		
		string panelName = panel.name;
		currentOverlay = FindPanel(panelName);
		//print("Current overlay name "+currentOverlay.name);
		currentOverlay.SetActive(true);
		//get the starting position of the overlay (for resetting its position later)
		overlayLastPosition = currentOverlay.transform.position;
		//Do the Overlay
		currentOverlay.transform.position = currentPanel.transform.parent.position;
		
		currentOverlay.SendMessage("PositionBackgroundFadePanel");
		
		currentOverlay.SendMessage("DoTransitionIn");
		currentOverlay.transform.SetAsLastSibling ();
		
		
		
	}
	
	
	
	//Util functions
	
	public void OpenUrl(string url)
	{
		Application.OpenURL(url);
	}
	
	public void LoadScene(string sceneName)
	{
		
		Application.LoadLevel(sceneName);

	}
	
	public void ReloadCurrentScene()
	{
		
		Application.LoadLevel(Application.loadedLevel);

	}
	
	
}
