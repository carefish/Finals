using UnityEngine;
using System.Collections;

public class RotateGUI : MonoBehaviour {

	public Texture2D texture = null;
	public float angle = 0;
	public Vector2 size = new Vector2(128, 128);
	Vector2 pos = new Vector2(0, 0);
	Rect rect;
	Vector2 pivot;
	// Use this for initialization
	public RotateGUI (GameObject gameobj)
	{
		size = new Vector2(gameobj.GetComponent<GUITexture>().pixelInset.width, 
		                   gameobj.GetComponent<GUITexture>().pixelInset.height);
		//texture = gameobj.GetComponent<GUITexture>().texture;
		//UpdateSettings();
	}
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

	}
	/*void UpdateSettings() {
		pos = new Vector2(transform.localPosition.x, transform.localPosition.y);
		rect = new Rect(pos.x - size.x * 0.5f, pos.y - size.y * 0.5f, size.x, size.y);
		pivot = new Vector2(rect.xMin + rect.width * 0.5f, rect.yMin + rect.height * 0.5f);
	}
	void OnGUI() {
		if (Application.isEditor) { UpdateSettings(); }
		Matrix4x4 matrixBackup = GUI.matrix;
		GUIUtility.RotateAroundPivot(angle, pivot);
		GUI.DrawTexture(rect, texture);
		GUI.matrix = matrixBackup;
	}*/
}
