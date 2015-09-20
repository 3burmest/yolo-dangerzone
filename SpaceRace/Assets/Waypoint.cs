using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	
	public Texture tex;

	Texture instTex;
	Vector3 screenpos;

	// Use this for initialization
	void Start () {
		instTex = (Texture)Instantiate (tex, Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0) {
			return;
		}
		PlaceIndicators ();
	}

	void PlaceIndicators()
	{

		Vector3 view = Camera.main.WorldToViewportPoint(transform.position);
		//if onscreen
		//			if(screenpos.z > 0 && screenpos.x < Screen.width && screenpos.x > 0 && screenpos.y < Screen.height && screenpos.y > 0)
//		if(view.x > 0 && view.x < 1 && view.y > 0 && view.y < 1 && view.z > 0)
		if(view.x > 0.05 && view.x < 0.95 && view.y > 0.05 && view.y < 0.95 && view.z > 0)
		{
			screenpos = Camera.main.ViewportToScreenPoint(view);
			
		}
		else{
//			float x = Mathf.Clamp01(view.x);
//			float y = Mathf.Clamp01(view.y);

			float x = Mathf.Clamp(view.x, 0.05f, 0.95f);
			float y = Mathf.Clamp(view.y, 0.05f, 0.95f);
			if(view.z < 0){
				return;
			}
			
			screenpos = Camera.main.ViewportToScreenPoint(new Vector3(x, y, 0));
		}
		
	}
	
	void PlaceOffscreen(Vector3 sp)
	{
		float x = sp.x;
		float y = sp.y;
		float offset = 10;
		
		if(sp.z < 0)
		{
			sp = -sp;
		}
		
		if(sp.x > Screen.width)
		{
			x = Screen.width - offset;
		}
		if(sp.x < 0)
		{
			x = offset;
		}
		
		if(sp.y > Screen.height)
		{
			y = Screen.height - offset;
		}
		if(sp.y < 0)
		{
			y = offset;
		}
		
		sp = new Vector3 (1, 1, 0);
		
	}
	
	void OnGUI() {
		if(Time.timeScale != 0)
		GUI.DrawTexture(new Rect(screenpos.x-25, Screen.height-25 - screenpos.y, 50, 50), instTex);
	}
}
