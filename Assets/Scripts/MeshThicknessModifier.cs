using UnityEngine;
using System.Collections;

public class MeshThicknessModifier : MonoBehaviour
{

    void Awake()
    {
        MeshCollider mc = GetComponent<MeshCollider>();
        mc.sharedMesh = ThickerMeshUsingNormals(mc.sharedMesh, 0.25f);
    }

    Mesh ThickerMeshUsingNormals(Mesh m, float fPerturb)
    {
        Vector3[] rv3OrigVerts = m.vertices;
        Vector3[] rv3Norms = m.normals;

        int nVertCt = rv3OrigVerts.Length;
        Vector3[] rv3NewVerts = new Vector3[nVertCt];
        for (int i = 0; i < nVertCt; ++i)
            rv3NewVerts[i] = rv3OrigVerts[i] + rv3Norms[i] * fPerturb;

        Mesh mRet = new Mesh();
        mRet.vertices = rv3NewVerts;
        mRet.triangles = m.triangles;
        mRet.RecalculateNormals();

        return mRet;
    }

}