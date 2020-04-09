using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineManager : MonoBehaviour {

	public GameObject linePrefab;
	public LineBehaviour activeLine;
    GameObject line;

    void Update () {
		if (Input.touchCount>0) {
			Touch touch = Input.GetTouch(0);
			Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if(touch.phase == TouchPhase.Began)
            {
				line = Instantiate (linePrefab, touchPosition, Quaternion.identity);
				activeLine = line.GetComponent<LineBehaviour> ();
            }
            else if(touch.phase == TouchPhase.Moved)
            {
				activeLine.updateLine (touchPosition);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
            	activeLine = null;
            	Destroy(line);
            }
		}
	}

}