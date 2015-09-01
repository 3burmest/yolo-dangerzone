using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class RocketTargeting : MonoBehaviour {

	GameObject currentTarget;
	public Texture tex;

	public GameObject rocket;

	Image sprite;
	Texture instTex;
	Vector3 screenpos;
	Camera camera;

	public GameObject[] RocketSlots;

	public void addRocket(){
		if (missingRockets() == 0)
			return;

		foreach (GameObject o in RocketSlots) {
			if(o.transform.childCount == 0){
				GameObject go = (GameObject) Instantiate(rocket, o.transform.position, o.transform.rotation);
				go.transform.parent = o.transform;
				break;
			}
		}
	}

	public int missingRockets(){
		int count = 0;
		foreach (GameObject o in RocketSlots)
			if (o.transform.childCount > 0)
				count++;
		return RocketSlots.Length - count;
	}

	// Use this for initialization
	void Start () {
		instTex = (Texture)Instantiate (tex, Vector3.zero, Quaternion.identity);
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0) {
			return;
		}

		if (Input.GetKeyDown (KeyCode.R)) {

			float nearest = Mathf.Infinity;
			GameObject nearestObject = null;

			foreach (GameObject o in GameObject.FindGameObjectsWithTag("Powerup").Concat(GameObject.FindGameObjectsWithTag("Enemy"))) {
				if (o.GetComponent<Renderer> () == null || !o.GetComponent<Renderer> ().isVisible) {
					continue;
				}

				Vector3 Viewpoint = camera.WorldToViewportPoint(o.transform.position);
				if(Viewpoint.x > 1.0f || Viewpoint.x < 0.0f || Viewpoint.y > 1.0f || Viewpoint.y < 0.0f){
					continue;
				}

				// Dichtestes Objekt
//				float distance = Vector3.Distance (o.transform.position, transform.position);

				// Am dichtesten an Kamera Mitte
				float distance = Vector2.Distance (new Vector2(Viewpoint.x, Viewpoint.y), Vector2.one * 0.5f);

				if (distance < nearest) {
					nearest = distance;
					nearestObject = o;
				}

			}
			if(nearestObject == currentTarget){
				currentTarget = null;
			}
			else{
				currentTarget = nearestObject;
			}

		} else if (Input.GetKeyDown (KeyCode.F) && currentTarget != null) {
//			GameObject go = (GameObject) Instantiate(rocket, transform.position, transform.rotation);
//			go.GetComponent<RocketMover>().target = currentTarget;

			foreach(GameObject g in RocketSlots){
				GameObject go = null;
				if(g.transform.childCount > 0)
					go = g.transform.GetChild(0).gameObject;
				if(go != null){
					go.GetComponent<RocketMover>().target = currentTarget;
					go.GetComponent<RocketMover>().launch();
					go.transform.parent = null;
					break;
				}
			}

		}

		PlaceIndicators();
	}

	void PlaceIndicators()
	{
		//GameObject[] objects = GameObject.FindObjectsOfType(typeof(AI)) as GameObject[]; //find objects by type (might ahve to find by gameobejct, and then filter for AI)
		//go through all the objects we care about
		if(currentTarget != null)
		{
//			screenpos = Camera.main.WorldToScreenPoint(currentTarget.transform.position);
			Vector3 view = Camera.main.WorldToViewportPoint(currentTarget.transform.position);
//			Debug.Log(screenpos);
			//if onscreen
//			if(screenpos.z > 0 && screenpos.x < Screen.width && screenpos.x > 0 && screenpos.y < Screen.height && screenpos.y > 0)
			if(view.x > 0 && view.x < 1 && view.y > 0 && view.y < 1 && view.z > 0)
			{
				screenpos = Camera.main.ViewportToScreenPoint(view);

			}
			else{
				float x = Mathf.Clamp01(view.x);
				float y = Mathf.Clamp01(view.y);
				if(view.z < 0){
					currentTarget = null;
					return;
				}

				screenpos = Camera.main.ViewportToScreenPoint(new Vector3(x, y, 0));
			}


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
		if (currentTarget != null) {
			GUI.DrawTexture(new Rect(screenpos.x-25, Screen.height-25 - screenpos.y, 50, 50), instTex);
		}
	}
}
