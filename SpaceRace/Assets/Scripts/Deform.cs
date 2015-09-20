using UnityEngine;
using System.Collections;

public class Deform : MonoBehaviour {
	public float scale = 1.0F;

	Vector3[] baseVertices;


	// Use this for initialization
	void Start () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		baseVertices = mesh.vertices;
		Vector3[] vertices = new Vector3[baseVertices.Length];

		for(int i = 0; i<vertices.Length; ++i){
			Vector3 vertex = baseVertices[i];
			vertex *= Mathf.PerlinNoise(i/(vertices.Length*2.0F), 0) * scale;
			vertices[i] = vertex;

			//print(i/10 + " " + Time.time + " " + Mathf.PerlinNoise(i/10, Time.time));
		}

		mesh.vertices = vertices;
		//mesh.RecalculateNormals();
        mesh.RecalculateBounds();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
