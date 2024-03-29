using UnityEngine;
using System.Collections;

/// <summary>
/// Tile cell effect and touch/click event.
/// </summary>
public class MatchItem : MonoBehaviour {
	public GameObject target;
	public Cell cell;
	public TilePoint point;
	GameObject[] flashPrefab;

	IEnumerator DoFlashEffect(float delayTime) {
		yield return new WaitForSeconds(delayTime);
		
		int type = 0;
		if (cell.cellType == Data.TileTypes.Violet) type = 1;
		GameObject instance = Instantiate(flashPrefab[type]) as GameObject;
		instance.transform.parent = transform;
		instance.transform.localPosition = new Vector3(0f, 0f, 0f);
		
		StartCoroutine( DoFlashEffect(UnityEngine.Random.Range(1f,3f)) );
	}

	public void OnMouseDown () 
	{
		if (target) target.SendMessage("OnClickAction", this, SendMessageOptions.DontRequireReceiver);
	}

	void Start () {
		flashPrefab = new GameObject[]
		{
			Resources.Load("Prefabs/FlashEffect", typeof(GameObject)) as GameObject,
			Resources.Load("Prefabs/GlowEffect", typeof(GameObject)) as GameObject
		};
		StartCoroutine( DoFlashEffect(UnityEngine.Random.Range(1f,3f)) );
	}
}
