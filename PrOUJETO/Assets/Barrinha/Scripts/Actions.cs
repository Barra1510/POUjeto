using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    #region Declaration
    [SerializeField] Vector3 scale;
    [Header("Controlador de crescimento")]
    [SerializeField] float growValue;
    #endregion
    void Start()
    {
        scale = transform.localScale;
    }

    
    void Update()
    {
    }
    //Crescer
    public void Grow()
    {
        scale.x += growValue;
        scale.y += growValue;
        scale.z += growValue;
        transform.localScale = scale;
    }

    //Diminuir
    public void Shrink()
    {
        scale.x -= growValue;
        scale.y -= growValue;
        scale.z -= growValue;
        transform.localScale = scale;
    }
}
