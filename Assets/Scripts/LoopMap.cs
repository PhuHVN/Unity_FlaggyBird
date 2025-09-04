using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    private MeshRenderer MeshRenderer;

    [SerializeField] private float _speed = 0.2f;
    private void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        MeshRenderer.material.mainTextureOffset += new Vector2(Time.deltaTime * _speed, 0); 
    }
}
