using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class CopsConfig : using UnityEngine;
//[CreateAssetMenu(fileName = "CopsConfig", menuName = "FabRoom/CopsConfig", order = 0)]

[CreateAssetMenu()]
public class CopsConfig : ScriptableObject {
    public float maxTime = 1.0f;
    public float maxDistance = 0.5f;
    public float maxSightDistance = 5.0f;
}
