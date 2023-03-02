using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawScript : MonoBehaviour
{
    PlayerMovementTutorial PlayerScript;
    [SerializeField] private int BrushSize = 5;
    private Renderer Rend;

    private Vector2 brushPos;

    private Color[] colors;

    private GroundTextureScript Ground;
    private RaycastHit touch;
    float yPosUp;

    private LineRenderer lineRenderer;
    private List<Vector2> brushPositions = new List<Vector2>();
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    private bool isDrawingCircle = false;

    void Start()
    {
        Rend = GetComponent<Renderer>();
        colors = Enumerable.Repeat(Rend.material.color, BrushSize * BrushSize).ToArray();
        PlayerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovementTutorial>();
        Ground = GameObject.FindWithTag("Ground").GetComponent<GroundTextureScript>();
        yPosUp = gameObject.transform.parent.transform.parent.transform.position.y - 0.44f;

        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Draw();
    }

    private void Draw()
    {
        float yPosDown = yPosUp - 0.7f;
        yPosUp = gameObject.transform.parent.transform.parent.transform.position.y - 0.44f;

        if (Input.GetKeyDown(PlayerScript.drawKey))
        {
            yPosUp = gameObject.transform.parent.transform.parent.transform.position.y - 0.44f;
            yPosDown = gameObject.transform.parent.transform.parent.transform.position.y - 1.14f;

            Ground.texture = new Texture2D((int)Ground.textureSize.x, (int)Ground.textureSize.y);
            Ground.r.material.mainTexture = Ground.texture;

            lineRenderer.positionCount = 0;
            brushPositions.Clear();
            isDrawingCircle = false;
        }

        if (Input.GetKey(PlayerScript.drawKey))
        {
            transform.position = new Vector3(gameObject.transform.position.x, yPosDown, gameObject.transform.position.z);
            if (Physics.Raycast(transform.position, transform.up * -1f, out touch, transform.localScale.y))
            {
                if (touch.transform.CompareTag("Ground"))
                {
                    //Paint on the ground

                    brushPos = new Vector2(touch.textureCoord.x, touch.textureCoord.y);

                    var x = (int)(brushPos.x * Ground.textureSize.x - (BrushSize / 2));
                    var y = (int)(brushPos.y * Ground.textureSize.y - (BrushSize / 2));

                    if (y < 0 || y > Ground.textureSize.y || x < 0 || x > Ground.textureSize.x) return;

                    Ground.texture.SetPixels(x, y, BrushSize, BrushSize, colors);

                    Ground.texture.Apply();

                    //Line renderer for collider
                    lineRenderer.positionCount++;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(touch.point.x, 0f, touch.point.z));

                    Vector2 pointPos = lineRenderer.GetPosition(lineRenderer.positionCount - 1);
                    brushPositions.Add(pointPos);
                    
                }

            }
        }
        else { transform.position = new Vector3(gameObject.transform.position.x, yPosUp, gameObject.transform.position.z); }


        if (brushPositions.Count > 2 && !isDrawingCircle)
        {
            float distance = Vector2.Distance(brushPositions[0], brushPositions[brushPositions.Count - 1]);
            if (distance < 0.01f)
            {
                isDrawingCircle = true;
                if (isDrawingCircle)
                {
                    


                    foreach (Vector2 point in brushPositions)
                    {
                        Vector3 point3D = new Vector3(point.x, 0, point.y);
                        vertices.Add(point3D);
                    }
                    for (int i = 0; i < vertices.Count - 2; i++)
                    {
                        triangles.Add(0);
                        triangles.Add(i + 1);
                        triangles.Add(i + 2);
                    }
                    triangles.Add(0);
                    triangles.Add(vertices.Count - 1);
                    triangles.Add(1);

                    HashSet<Vector3> uniqueVertices = new HashSet<Vector3>(vertices);
                    vertices = uniqueVertices.ToList();

                    GameObject meshObject = new GameObject("Mesh Collider");
                    MeshFilter meshFilter = meshObject.AddComponent<MeshFilter>();
                    MeshCollider meshCollider = meshObject.AddComponent<MeshCollider>();
                    Mesh mesh = new Mesh();
                    mesh.vertices = vertices.ToArray();
                    mesh.triangles = triangles.ToArray();
                    mesh.RecalculateNormals();
                    mesh.RecalculateBounds();

                    meshCollider.sharedMesh = mesh;
                    meshFilter.sharedMesh = mesh;
                }
            }
        }
        
    }
}
