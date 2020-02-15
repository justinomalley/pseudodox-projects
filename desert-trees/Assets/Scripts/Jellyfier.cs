using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfier : MonoBehaviour {
    
    public float bounceSpeed, fallForce, stiffness;

    private MeshFilter meshFilter;
    private Mesh mesh;

    private JellyVertex[] jellyVertices;
    private Vector3[] currentMeshVertices;
    
    void Start() {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;

        GetVertices();
    }
    
    void GetVertices() {
        jellyVertices = new JellyVertex[mesh.vertices.Length];
        currentMeshVertices = new Vector3[mesh.vertices.Length];
        for (int i = 0; i < mesh.vertices.Length; i++) {
            jellyVertices[i] = new JellyVertex(i, mesh.vertices[i], mesh.vertices[i], Vector3.zero);
            currentMeshVertices[i] = mesh.vertices[i];
        }
    }

    private void Update() {
        UpdateVertices();
        
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Yo!");
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                Debug.Log("wE HIT SOMETHING!" + hit.collider.name);
                ApplyPressureToPoint(hit.point, fallForce);
                Debug.DrawLine(ray.origin, hit.point);
            }
        }
    }

    private void UpdateVertices() {
        for (int i = 0; i < jellyVertices.Length; i++) {
            jellyVertices[i].UpdateVelocity(bounceSpeed);
            jellyVertices[i].Settle(stiffness);

            jellyVertices[i].currPos += jellyVertices[i].currVelocity * Time.deltaTime;
            currentMeshVertices[i] = jellyVertices[i].currPos;
        }

        mesh.vertices = currentMeshVertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }

    public void OnCollisionEnter(Collision other) {
        ContactPoint[] collisionPoints = other.contacts;
        for (int i = 0; i < collisionPoints.Length; i++) {
            Vector3 inputPoint = collisionPoints[i].point + (collisionPoints[i].point * .1f);
            ApplyPressureToPoint(inputPoint, fallForce);
        }
    }
    
    public void ApplyPressureToPoint(Vector3 _point, float _pressure) {
        for (int i = 0; i < jellyVertices.Length; i++) {
            jellyVertices[i].ApplyPressureToVertex(transform, _point, _pressure);
        }
    }
}
