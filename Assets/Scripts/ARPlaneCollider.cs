using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class ARPlaneCollider : MonoBehaviour
{
    private ARPlaneManager planeManager;

    void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
    }

    void OnEnable()
    {
        planeManager.planesChanged += OnPlanesChanged;
    }

    void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
            AddColliderToPlane(plane);
        }
    }

    void AddColliderToPlane(ARPlane plane)
    {
        MeshCollider meshCollider = plane.gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = plane.GetComponent<MeshFilter>().mesh;

        // Optional: Adjust physic material to make the plane bouncy
        PhysicMaterial bounceMaterial = new PhysicMaterial();
        bounceMaterial.bounciness = 1.0f;
        bounceMaterial.frictionCombine = PhysicMaterialCombine.Minimum;
        bounceMaterial.bounceCombine = PhysicMaterialCombine.Maximum;
        meshCollider.material = bounceMaterial;
    }
}
