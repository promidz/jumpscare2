using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class universalContainer : MonoBehaviour {

    public static universalContainer instance = null;
    public static string url = "Nothing";

	// Use this for initialization
	void Awake () {
		if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
	}
	
	public void ChangeUrl(string URL)
    {
        url = URL;
    }

    public string Url
    {
        get
        {
            return url;
        }
        
    }
    
}
