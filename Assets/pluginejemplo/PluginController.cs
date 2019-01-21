using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class PluginController : MonoBehaviour {
	private string TextoArrayApps = "";
    public Text textoapps;
    public Text mensaje;
    [HideInInspector]
    public string[] ArrayApps;
	// Use this for initialization
	void Start () {
		
#if UNITY_IPHONE || UNITY_STANDALONE_OSX
		
		string data = Marshal.PtrToStringAuto(OSHookBridge.ReturnString());
		data += "\n" + OSHookBridge.ReturnInt();
		
		displayText.text = data;
		
		Debug.Log ("Returned Int = " + OSHookBridge.ReturnInt());
		Debug.Log ("Returned String = " + Marshal.PtrToStringAuto(OSHookBridge.ReturnString()));
		
		IntPtr handle = OSHookBridge.CreateInstance();
		Debug.Log("Returned Instance Int = " + OSHookBridge.GetInstanceInt(handle));
#elif UNITY_ANDROID 

		/*Debug.Log ("Returned Int = " + OSHookBridge.ReturnInt());
		Debug.Log ("Returned String = " + OSHookBridge.ReturnString());
		
		Debug.Log("Returned Instance Int = " + OSHookBridge.ReturnInstanceInt());
		Debug.Log("Returned Instance String = " + OSHookBridge.ReturnInstanceString());*/

#endif
		
	}
	
			
	// Update is called once per frame
	void Update () {
        
    }

    public void listar_app(string app)
    {
#if UNITY_IPHONE
			
			IntPtr objectName = Marshal.StringToHGlobalAuto(this.name);
			IntPtr messageName = Marshal.StringToHGlobalAuto("SetButtonText");
			IntPtr parameterName = Marshal.StringToHGlobalAuto("New Text");
			
			OSHookBridge.SendUnityBridgeMessage(objectName,messageName,parameterName);
#elif UNITY_ANDROID
        TextoArrayApps = "" + OSHookBridge.ReturnString();
        textoapps.text = "" + TextoArrayApps;
        ArrayApps = TextoArrayApps.Split(new string[] {","}, StringSplitOptions.None);
        for(int i = 0; i < ArrayApps.Length;i++)
        {
            if (ArrayApps[i] == app)
            {
                mensaje.text = "correcto";
                break;
            }
            else
            {
                mensaje.text = "incorrecto";
            }
        }
#endif
    }



    public void Open_App(string app)
    {
#if UNITY_IPHONE
			
			IntPtr objectName = Marshal.StringToHGlobalAuto(this.name);
			IntPtr messageName = Marshal.StringToHGlobalAuto("SetButtonText");
			IntPtr parameterName = Marshal.StringToHGlobalAuto("New Text");
			
			OSHookBridge.SendUnityBridgeMessage(objectName,messageName,parameterName);
#elif UNITY_ANDROID
        OSHookBridge.ShowAppID(app);
#endif
    }
}
