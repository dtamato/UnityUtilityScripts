using UnityEngine;
using System.Collections;

public static class ExtensionMethods {

    public static void ResetTransform(this Transform transform) {

        transform.position = Vector3.one;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    public static void SetAllChildrenActive(this Transform transform) {

        int childCount = transform.childCount;
        for(int i = 0; i < childCount; i++) {

            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public static int GetActiveChildCount (this Transform transform) {

        int count = 0;

        foreach(Transform child in transform) {

            if(child.gameObject.activeSelf) {

                count++;
            }
        }

        return count;
    }
	
	public static void SetX(this Transform transform, float x) {
      
	  Vector3 newPosition = new Vector3(x, transform.position.y, transform.position.z);
      transform.position = newPosition;
    }
	
	public static void SetY(this Transform transform, float y) {
      
	  Vector3 newPosition = new Vector3(transform.position.x, y, transform.position.z);
      transform.position = newPosition;
    }
	
	public static void SetZ(this Transform transform, float z) {
      
	  Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, z);
      transform.position = newPosition;
    }
}