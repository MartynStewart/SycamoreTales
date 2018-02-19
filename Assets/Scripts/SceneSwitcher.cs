using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour {

    public GameObject showObject;
    public GameObject hideObject;

    public void SwitchVisible() {
        hideObject.SetActive(false);
        showObject.SetActive(true);
    }
}
