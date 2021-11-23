using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColourShip : MonoBehaviour
{
    public Material capsuleMaterial;
    public Material shipMaterial;
    public Material holderMaterial;
    public Material lightsMaterial;

    MeshRenderer mshRenderer;

    private void Awake()
    {
        mshRenderer = GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ColourShipNow();
    }

    public void ColourShipNow()
    {
        var mats = new Material[] { capsuleMaterial, shipMaterial, holderMaterial, lightsMaterial };
        mshRenderer.materials = mats;
    }
}
