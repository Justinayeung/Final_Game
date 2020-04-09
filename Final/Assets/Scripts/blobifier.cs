using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobifier : MonoBehaviour
{
    //attach to any object that needs to be blobby

    public float bounceSpeed;
    public float fallForce;
    public float stiffness;

    private MeshFilter meshFilter;
    private Mesh mesh;

    BlobVertex[] blobVertices;
    Vector3[] currentMeshVertices;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;

        GetVertices();
    }

    void GetVertices()
    {
        blobVertices = new BlobVertex[mesh.vertices.Length];
        currentMeshVertices = new Vector3[mesh.vertices.Length];
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            blobVertices[i] = new BlobVertex(i, mesh.vertices[i], mesh.vertices[i], Vector3.zero);
            currentMeshVertices[i] = mesh.vertices[i];
        }
    }

    void Update()
    {
        UpdateVertices();
    }

    void UpdateVertices()
    {
        for (int i = 0; i < blobVertices.Length; i++)
        {
            blobVertices[i].UpdateVelocity(bounceSpeed);
            blobVertices[i].Settle(stiffness);

            blobVertices[i].currentVertexPosition += blobVertices[i].currentVelocity * Time.deltaTime;
            currentMeshVertices[i] = blobVertices[i].currentVertexPosition;
        }

        mesh.vertices = currentMeshVertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }

    public void OnCollisionEnter(Collision other)
    {
        ContactPoint[] collisionPoints = other.contacts;
        for (int i = 0; i < collisionPoints.Length; i++)
        {
            Vector3 inputPoint = collisionPoints[i].point + (collisionPoints[i].point * .1f);
            ApplyPressureToPoint(inputPoint, fallForce);
        }
    }

    public void ApplyPressureToPoint(Vector3 _point, float _pressure)
    {
        for (int i = 0; i < blobVertices.Length; i++)
        {
            blobVertices[i].ApplyPressureToVertex(transform, _point, _pressure);
        }
    }
}
