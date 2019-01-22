using UnityEngine;
using System.Collections;
using System;

public class JavaCallbackScript : MonoBehaviour {
	
	void onActivityResult(string resultData){
		Debug.Log("onActivityResult = " + resultData);
		
		string[] sTmp = resultData.Split(new string[] {":"},StringSplitOptions.None);
		
		if (sTmp.Length > 1){
			Debug.Log("requestCode = " + sTmp[0]);
			Debug.Log ("responseCode = " + sTmp[1]);
			
		}
	}
	
}
