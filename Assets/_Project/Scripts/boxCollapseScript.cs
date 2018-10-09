using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boxCollapseScript : MonoBehaviour {
    public List<Rigidbody> boxes;

	public void collapse()
    {
        if(boxes != null)
        {
            foreach (var box in boxes)
            {
                box.isKinematic = false;
            }
        }
    }
}
