using UnityEngine;

public class Object : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    public ObjectDataItem GetData()
    {
        ObjectDataItem item = new ObjectDataItem();
        item.Alfa = _meshRenderer.material.color.a;
        item.Active = _meshRenderer.enabled;
        return item;
    }
    public void SetData(float alfa, bool active)
    {
        _meshRenderer.material.color = new Color(_meshRenderer.material.color.r, _meshRenderer.material.color.g, _meshRenderer.material.color.b, alfa);
        _meshRenderer.enabled = active;
    }
}
