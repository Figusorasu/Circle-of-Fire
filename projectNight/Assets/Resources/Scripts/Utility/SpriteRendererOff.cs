using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererOff : MonoBehaviour
{
    private void Start() {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
// Turns off sprite when game starts so the sprite can act like gizmos