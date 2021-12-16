using UnityEngine;

public class IcosphereGenerator : MonoBehaviour {
  public IcosphereRenderer icoPrefab;

  private float radius = 1.0f;
  private float padding = 0.5f;
  private int max_n = 50; // Gives 60 000 vertices

  public void Generate(int n) {
    Clean();

    // Get the specific number of division so we don't overflow the number of vertices (~65 000)
    int last_n = n % max_n;
    last_n = last_n == 0 ? max_n : last_n;
    int count = Mathf.CeilToInt((float)n / (float)max_n);

    Debug.Log("Num vertices: " + ((count - 1) * IcosphereRenderer.numVertices(max_n) + IcosphereRenderer.numVertices(last_n)));
    // Debug.Log("n: " + n + ", nast_n: " + last_n + ", count: " + count);

    float left = (count - 1) * radius + (count - 1) * 0.5f * padding;
    for (int i = 0; i < count; ++i) {
      int curr_n = (i == count - 1) ? last_n : max_n;
      IcosphereRenderer instance = Instantiate<IcosphereRenderer>(icoPrefab);
      instance.transform.SetParent(transform);
      instance.transform.position = new Vector3(-left + i * (2f * radius + padding), 0f, 0f);
      instance.Generate(curr_n, radius);
    }
  }

  private void Clean() {
    foreach (Transform child in transform)
      GameObject.Destroy(child.gameObject);
  }
}
