using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEvents : MonoBehaviour
{

    public void CameraAcabou()
    {
        CutSceneController.instancia.ProximaCamera();
    }
}