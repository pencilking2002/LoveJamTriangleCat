using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {
	public Vector3 offset = new Vector3(10, 10, 0);
	public Transform player;
	public float moveDamp = 0.5f;

	private Vector3 moveVel;

    [SerializeField]
    private Transform limitDL;
    [SerializeField]
    private Transform limitUR;

    private bool camAdjusting = false;
    private Vector3 targetOffset = Vector3.zero;
    private float targetSize;
    public float moveSpeed;

	// Use this for initialization
	void Awake () 
	{
		if (player == null)
			Debug.LogError("Player is not attached to camera CamController");
	}

    public void cameraAdjustToGame() {
        camAdjusting = true;
        targetOffset = new Vector3(1.2f, 2.0f, 0.0f);
        targetSize = 4.95f;
    }

	// Update is called once per frame
	void LateUpdate () {	
		var targetPos = new Vector3(Mathf.Clamp(player.position.x, limitDL.position.x, limitUR.position.x), Mathf.Clamp(player.position.y, limitDL.position.y, limitUR.position.y), transform.position.z) + offset;
		transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref moveVel, moveDamp);
	}

    void Update() {
        if (camAdjusting) {
            offset = Vector3.MoveTowards(offset, targetOffset, Time.deltaTime * moveSpeed);
            Camera.main.orthographicSize += Time.deltaTime * moveSpeed;
            if (Vector3.Distance(offset, targetOffset) < 0.5f && Camera.main.orthographicSize >= 4.9f)
                camAdjusting = false;
        }
    }
}
