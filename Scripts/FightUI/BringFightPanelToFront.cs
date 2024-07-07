using UnityEngine;
using System.Collections;

public class BringFightPanelToFront : MonoBehaviour {

    void OnEnable()
    {
        transform.SetAsLastSibling();
    }
}
