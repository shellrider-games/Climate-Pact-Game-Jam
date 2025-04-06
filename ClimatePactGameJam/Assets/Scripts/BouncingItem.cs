using UnityEngine;

public class BouncingItem : MonoBehaviour
{
    public float speedPos;
    public float speedRot;
    public float bounceHeight;
    public float rotation;
    public float sinePos = 0f;
    public float sineRot = 0f;
    private Vector3 _initPos;
    private Vector3 _initRot;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _initPos = transform.position;
        _initRot = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Sin(sinePos);
        sinePos += speedPos * Time.deltaTime;
        sineRot += speedRot * Time.deltaTime;
        
        transform.position = new Vector3(_initPos.x, _initPos.y+ Mathf.Sin(sinePos)*bounceHeight, _initPos.z);
        transform.rotation = Quaternion.Euler(new Vector3(_initRot.x, _initRot.y + Mathf.Sin(sineRot)*rotation, _initRot.z));
    }
}
