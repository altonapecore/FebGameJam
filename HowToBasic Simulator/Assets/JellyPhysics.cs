using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyPhysics : MonoBehaviour
{
    public float bounceSpeed;
    public float fallForce;
    public float stiffness;

    private MeshFilter meshFilter;
    private Mesh mesh;

    JellyVertex[] jellyVertices;
    Vector3[] currentMeshVertices;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;

        GetVertices();
    }

    private void Update()
    {
        UpdateVertices();
        MouseClick();
    }

    private void UpdateVertices()
    {
        for(int i = 0; i < jellyVertices.Length; i++)
        {
            jellyVertices[i].UpdateVelocity(bounceSpeed);
            jellyVertices[i].Settle(stiffness);

            jellyVertices[i].currentVertexPosition += jellyVertices[i].currentVelocity * Time.deltaTime;
            currentMeshVertices[i] = jellyVertices[i].currentVertexPosition;
        }

        mesh.vertices = currentMeshVertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

    }

    private void OnCollisionEnter(Collision collision)
    {
        List<ContactPoint> collisionPoints = new List<ContactPoint>();
        collision.GetContacts(collisionPoints);
        for(int i = 0; i < collisionPoints.Count; i++)
        {
            Vector3 inputPoint = collisionPoints[i].point + (collisionPoints[i].point * .1f);
            ApplyPressureToPoint(inputPoint, fallForce);
        }
    }

    private void GetVertices()
    {
        jellyVertices = new JellyVertex[mesh.vertices.Length];
        currentMeshVertices = new Vector3[mesh.vertices.Length];
        for(int i = 0; i < mesh.vertices.Length; i++)
        {
            jellyVertices[i] = new JellyVertex(i, mesh.vertices[i], mesh.vertices[i], Vector3.zero);
            currentMeshVertices[i] = mesh.vertices[i];
        }
    }

    public void ApplyPressureToPoint(Vector3 _point, float _pressure)
    {
        for(int i = 0; i < jellyVertices.Length; i++)
        {
            jellyVertices[i].ApplyPressureToVertex(transform, _point, _pressure);
        }
    }

    public void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100.0f))
            {
                Vector3 hitPoint = hit.point;
                ApplyPressureToPoint(hitPoint, fallForce);
            }
        }
    }
}
