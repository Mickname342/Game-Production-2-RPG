using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

    void Start()
    {
        Rend = GetComponent<Renderer>();
        colors = Enumerable.Repeat(Rend.material.color, BrushSize * BrushSize).ToArray();
        PlayerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovementTutorial>();
        Ground = GameObject.FindWithTag("Ground").GetComponent<GroundTextureScript>();
        yPosUp = gameObject.transform.parent.transform.parent.transform.position.y - 0.44f;
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
        }
        
        if (Input.GetKey(PlayerScript.drawKey))
        {
            
            transform.position = new Vector3(gameObject.transform.position.x, yPosDown, gameObject.transform.position.z);
            if (Physics.Raycast(transform.position, transform.up * -1f, out touch, transform.localScale.y))
            {
                if (touch.transform.CompareTag("Ground"))
                {
                    

                    brushPos = new Vector2(touch.textureCoord.x, touch.textureCoord.y);

                    var x = (int)(brushPos.x * Ground.textureSize.x - (BrushSize/2));
                    var y = (int)(brushPos.y * Ground.textureSize.y - (BrushSize / 2));

                    if (y < 0 || y > Ground.textureSize.y || x < 0 || x > Ground.textureSize.x) return;

                    Ground.texture.SetPixels(x, y, BrushSize, BrushSize, colors);

                    Ground.texture.Apply();
                }
                
            }
        }
        else { transform.position = new Vector3(gameObject.transform.position.x, yPosUp, gameObject.transform.position.z); }
    }
}
