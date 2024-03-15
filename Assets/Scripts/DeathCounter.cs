using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    public static DeathCounter instance;
    [SerializeField] private TextMeshProUGUI deaths;
    public int deathCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        deaths.text = "Deaths: " + deathCount;
    }

    public void IncreaseDeaths()
    {
        deathCount = deathCount + 1;
    }
}
