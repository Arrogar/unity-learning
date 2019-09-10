using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour {
    public int score = 5;
    public ParticleSystem destroyParticle;

    public Text expText;
    public Text statsText;

    void Start() {
        expText.text = "";
        statsText.text = "";
    }
}
