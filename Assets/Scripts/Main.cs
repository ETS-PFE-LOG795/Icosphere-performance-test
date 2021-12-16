using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
  public float dt = 1f;

  [SerializeField] private IcosphereGenerator icosphereGenerator;

  private int n = 5;
  private int increment = 5;
  private int max_n = 150;
  private int itr = 0;

  void Start() {
    Generate();
  }

  IEnumerator NextIncrement() {
    yield return new WaitForSeconds(dt);
    Generate();
  }

  private void Generate() {
    Debug.Log("Iteration: " + itr);
    icosphereGenerator.Generate(n);
    n += increment;
    itr++;

    if (n < max_n) {
      StartCoroutine("NextIncrement");
    } else {
      Debug.Log("Complete");
    }
  }
}
