using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeManager : MonoBehaviour
{
    LoopScript loop;
    public List<GameObject> _OriginalObjs;
    public List<GameObject> _ChangeObjs;

    // Start is called before the first frame update
    void Start() {
        loop = FindObjectOfType<LoopScript>(); //Find LoopScript reference
        for (int i = 0; i < _ChangeObjs.Count; i++) { //Set all object in _ChangeObjs to false
            _ChangeObjs[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() {
        LoopChanges(loop.loopNum);
    }

    /// <summary>
    /// Will set _OrginalObjs false and _ChangeObjs true base on the loop number
    /// </summary>
    /// <param name="loopNumber"></param>
    public void LoopChanges(int loopNumber) {
        if (loop.firstLoop == false) { //Do everything only if the player has gone through the loop first
            if (loopNumber - 1 < _ChangeObjs.Count) { //If loop number is less than the amount in the list
                _ChangeObjs[loopNumber - 1].SetActive(true);
                _OriginalObjs[loopNumber - 1].SetActive(false);
            }
        }
    }
}
