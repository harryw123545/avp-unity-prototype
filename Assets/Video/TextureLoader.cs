using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.PolySpatial;

public class TextureLoader : MonoBehaviour
{
    [SerializeField] private RenderTexture renderTex;

    void Update()
    {
        PolySpatialObjectUtils.MarkDirty(renderTex);
    }
}
