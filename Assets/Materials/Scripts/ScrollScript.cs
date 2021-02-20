/* Scrolls looping menu background image */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public float scroll_Speed = 0.008f;

        private MeshRenderer mesh_Renderer;

    void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }


    // Start is called before the first frame update
    void Update()
    {

        float x = Time.time * scroll_Speed;

        Vector2 offset = new Vector2(x, 0);

        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
