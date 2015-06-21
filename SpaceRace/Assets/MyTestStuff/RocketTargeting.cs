using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RocketTargeting : MonoBehaviour {

	GameObject currentTarget;

	public Image OnScreenSprite; 
	public Image OffScreenSprite;

	public Texture tex;

	public GameObject rocket;

	Image sprite;
	Texture instTex;
	Vector3 screenpos;

	// Use this for initialization
	void Start () {
		sprite = (Image) Instantiate (OnScreenSprite, Vector3.zero, Quaternion.identity);
		instTex = (Texture)Instantiate (tex, Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.R)) {

			float nearest = Mathf.Infinity;
			GameObject nearestObject = null;

			foreach (GameObject o in GameObject.FindGameObjectsWithTag("Powerup")) {
				if (o.GetComponent<Renderer> () == null || !o.GetComponent<Renderer> ().isVisible) {
					continue;
				}

				float distance = Vector3.Distance (o.transform.position, transform.position);

				if (distance < nearest) {
					nearest = distance;
					nearestObject = o;
				}

			}

			currentTarget = nearestObject;

			Debug.Log ("Target: " + currentTarget);

		} else if (Input.GetKeyDown (KeyCode.F) && currentTarget != null) {
			GameObject go = (GameObject) Instantiate(rocket, transform.position, transform.rotation);
			go.GetComponent<RocketMover>().target = currentTarget;
		}

		PlaceIndicators();
	}

	void PlaceIndicators()
	{
		//GameObject[] objects = GameObject.FindObjectsOfType(typeof(AI)) as GameObject[]; //find objects by type (might ahve to find by gameobejct, and then filter for AI)
		//go through all the objects we care about
		if(currentTarget != null)
		{
			screenpos = Camera.main.WorldToScreenPoint(currentTarget.transform.position);
			Debug.Log(screenpos);
			//if onscreen
			if(screenpos.z > 0 && screenpos.x < Screen.width && screenpos.x > 0 && screenpos.y < Screen.height && screenpos.y > 0)
			{

				sprite.rectTransform.position = screenpos;
				//Debug.Log("OnScreen: " + screenpos);
			}
//			else{
//				PlaceOffscreen(screenpos);
//			}
		}
		
	}
	
	void PlaceOffscreen(Vector3 screenpos)
	{
		float x = screenpos.x;
		float y = screenpos.y;
		float offset = 10;
		
		if(screenpos.z < 0)
		{
			screenpos = -screenpos;
		}
		
		if(screenpos.x > Screen.width)
		{
			x = Screen.width - offset;
		}
		if(screenpos.x < 0)
		{
			x = offset;
		}
		
		if(screenpos.y > Screen.height)
		{
			y = Screen.height - offset;
		}
		if(screenpos.y < 0)
		{
			y = offset;
		}
		
		sprite.rectTransform.position = new Vector3 (x, y, 0);
		
	}

	void OnGUI() {
		if (currentTarget != null) {
			GUI.DrawTexture(new Rect(screenpos.x-25, Screen.height-25 - screenpos.y, 50, 50), instTex);
		}
	}
}
