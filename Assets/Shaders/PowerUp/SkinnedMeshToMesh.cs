using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class SkinnedMeshToMesh : MonoBehaviour
{

    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private VisualEffect VFX;
    [SerializeField] private float refreshRate = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(UpdateMeshCoroutine());
    }


    private IEnumerator UpdateMeshCoroutine()
    {
        while (gameObject.activeSelf)
        {
            Mesh bakedMesh = new Mesh();
            skinnedMeshRenderer.BakeMesh(bakedMesh);
            

            Mesh bakedMesh2 = new Mesh();
            Vector3[] VerticesNuevos = bakedMesh.vertices;
            bakedMesh2.vertices = VerticesNuevos;


            VFX.SetMesh("Malla", bakedMesh2);



            yield return new WaitForSeconds(refreshRate);

        }
        yield return null;
    }
}
