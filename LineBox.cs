using UnityEngine;

[ExecuteInEditMode]
public class LineBox : MonoBehaviour
{

    [SerializeField] private Vector3 scale = new Vector3(10f, 10f, 10f);
    [SerializeField] private Material material;

    private void OnRenderObject()
    {
        Vector3 halfScale = scale * 0.5f;
        material.SetPass(0);
        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);
        drawRectXY(halfScale, -halfScale.z);
        drawRectXY(halfScale, halfScale.z);
        drawLineZ(halfScale, -halfScale.x, -halfScale.y);
        drawLineZ(halfScale, halfScale.x, -halfScale.y);
        drawLineZ(halfScale, halfScale.x, halfScale.y);
        drawLineZ(halfScale, -halfScale.x, halfScale.y);
        GL.PopMatrix();
    }

    private void drawRectXY(Vector3 halfScale, float z)
    {
        GL.Begin(GL.LINE_STRIP);
        GL.Vertex(new Vector3(-halfScale.x, -halfScale.y, z));
        GL.Vertex(new Vector3(halfScale.x, -halfScale.y, z));
        GL.Vertex(new Vector3(halfScale.x, halfScale.y, z));
        GL.Vertex(new Vector3(-halfScale.x, halfScale.y, z));
        GL.Vertex(new Vector3(-halfScale.x, -halfScale.y, z));
        GL.End();
    }

    private void drawLineZ(Vector3 halfScale, float x, float y)
    {
        GL.Begin(GL.LINES);
        GL.Vertex(new Vector3(x, y, -halfScale.z));
        GL.Vertex(new Vector3(x, y, halfScale.z));
        GL.End();
    }
}
