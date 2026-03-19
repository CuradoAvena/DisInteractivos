using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    public void Cerrar()
    {
        // "gameObject" se refiere al objeto 3D o UI
        // en el que este script está puesto (o sea, el Panel)
        gameObject.SetActive(false);
    }
}
