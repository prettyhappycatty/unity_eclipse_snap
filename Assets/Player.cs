using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Player : MonoBehaviour
{
    [SerializeField] private Text _Text;

    int FlgGameOver = 0;
    // Start is called before the first frame update
    void Start()
    {
        _Text = GetComponent<Text>();
        int r2 = 5; //スタートポジション
        transform.position += new Vector3(0,0,r2)*1f;
        string msg = "Push Space-Key to snapshot the eclipse.\n Nearer eclipse, Higher score.";
        _Text.text = msg;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            FlgGameOver = 1;
            float p = ((5f-Mathf.Abs(transform.position.z))*100/5f);
            if (p < 0){p = 0f;}
            string msg = "Your score is "+ p + "。\npush Upper-Key to try again!";
            _Text.text = msg;
        }

        if (FlgGameOver == 0){

            float x = Input.GetAxisRaw("Horizontal");

            transform.position += new Vector3(0,0,-1)*0.01f;


        }else{
            if (Input.GetKey(KeyCode.UpArrow)) {
                FlgGameOver = 0;
                int r2 = 5; //スタートポジション
                transform.position += new Vector3(0,0,-transform.position.z +r2)*1f;
                string msg = "Push Space-Key to snapshot the eclipse.\n Nearer eclipse, Higher score.";
                _Text.text = msg;
            }
        }
        
    }

}
