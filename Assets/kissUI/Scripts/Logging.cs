using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Logging : MonoBehaviour
{
	#region 1.Variables
	
	// TODO: Change the URL to your own scrips URL. Do Not Use my URL in your Release Builds. Included just for Testing.
	string POST_Script_URL = "http://kissui.izzysoft.com/Logs/AddLogEntry.php";
	
	string sLogResponse	= "";
	
	#endregion
	
	#region 2.Unity Messaging
	
	void OnEnable()
	{
		//Debug.Log( "Logging.OnEnable()" );
		
		//Application.RegisterLogCallback( LogHandler );
		Application.logMessageReceived += LogHandler;
	}
	
	void OnDisable()
	{
		//Application.RegisterLogCallback( null );
		Application.logMessageReceived -= LogHandler;
		
		//Debug.Log( "Logging.OnDisable()" );
	}
	
	#endregion
	
	#region Other
	
	public void LogHandler( string message, string stacktrace, LogType type )
	{
		//if( type == LogType.Log )
		//	return;
		
		if( Application.isWebPlayer )
		{
			stacktrace = GetStackTrace();
			AddLogEntry_WebService( POST_Script_URL, message, stacktrace, type );
		}
		else
		{
			//string myStackTrace = GetStackTrace();
			AddLogEntry_WebService( POST_Script_URL, message, stacktrace, type );
			
			//TODO: Create a function like AddLogEntry_LocalFile( filePath, myStackTrace );
			//      and call that instead of logging to the WebService
		}
	}
	
	public void AddLogEntry_WebService( string URL, string message, string stacktrace, LogType type )
	{
		WWWForm www = new WWWForm();
		www.AddField( "app", Application.productName + " (ver. " + Application.version + ")" );
		www.AddField( "msg", "AddLogEntry Message: " + message );
		www.AddField( "typ", type.ToString() );
		www.AddField( "dev", Application.companyName );
		www.AddField( "src", Application.absoluteURL );
		www.AddField( "log", stacktrace );
		
		WWW w = new WWW( URL, www );
		StartCoroutine( GetResponse_WebService( w ) );
	}
	
	IEnumerator GetResponse_WebService( WWW w )
	{
		yield return w;	// Waits for WebService's response.
		
		if( w.error == null )
			sLogResponse = "AddLogEntry OK Response: " + w.text;
		else
			sLogResponse = "AddLogEntry Error Response: " + w.error;
		
		if( sLogResponse == "" )
		{
			//
		}
	}
	
	string GetStackTrace()
	{
		//System.Diagnostics.StackTrace trace = new StackTrace();
		System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace( 4, true );
		return trace.ToString();
	}
	
	public void DivideByZero()
	{
		int divBy = 0;
		int val = 128 / divBy;	// should error, allowing us to test the LogHandler
		
		if( val == 0 )
		{
			//
		}
	}
	
	#endregion
}
