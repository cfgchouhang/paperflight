using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Texture2D texture = Resources.Load ("Textures/LoopSky2") as Texture2D;
		Material material = new Material (Shader.Find ("Diffuse"));
		material.mainTexture = texture;

		gameObject.GetComponent<Renderer> ().material = material;
	}
}
