﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(this.delayDestroy());
    }

    // Update is called once per frame
    void Update() {

    }


    private IEnumerator delayDestroy() {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
