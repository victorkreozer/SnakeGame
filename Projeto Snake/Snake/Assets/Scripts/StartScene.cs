using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class StartScene : MonoBehaviour {
    public GameObject mainCanvas;

    // Start is called before the first frame update
    void Start() {
        var buttons = mainCanvas.GetComponentsInChildren<Button>();

        var soloGameBtn = (Button)(from b in buttons where b.name.Contains("SoloGame") select b).First();
        soloGameBtn.onClick.AddListener(() => {
            SceneManager.LoadScene("SoloGame");
        });

        var duosGameBtn = (Button)(from b in buttons where b.name.Contains("DuosGame") select b).First();
        duosGameBtn.onClick.AddListener(() => {
            SceneManager.LoadScene("DuosGame");
        });

        var exitGameBtn = (Button)(from b in buttons where b.name.Contains("ExitGame") select b).First();
        exitGameBtn.onClick.AddListener(() => {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update() {
        
    }
}