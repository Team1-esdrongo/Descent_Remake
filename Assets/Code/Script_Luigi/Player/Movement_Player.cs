using UnityEngine;

public class Movement_Player : MonoBehaviour
{
    public float velocità = 5f;
    public Camera cameraPrincipale;  // Main camera
    public float sensibilitàMouse = 2f; // Sensibility
    private float rotazioneOrizzontale = 0f;
    private float rotazioneVerticale = 0f;
    public Player_Shooting muzzle;
    public Player_Shooting_Missle muzzle1;
    private Rigidbody _rigidbody;
    private Vector3 movimento;

    private void Awake()
    {
        _rigidbody = GetComponent <Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            muzzle.Fire();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            muzzle1.Fire();
        }

        // Movement of the player
        movimento = Vector3.zero;

        // Rotation of the camera
        Quaternion rotazioneCamera = cameraPrincipale.transform.rotation;

        // Direction of the camera
        Vector3 direzioneCamera = rotazioneCamera * Vector3.forward;  // Forward
        Vector3 direzioneDestra = rotazioneCamera * Vector3.right;    // Backward

        // If the player press W
        if (Input.GetKey(KeyCode.W))
            movimento += direzioneCamera;

        // If the player press S
        if (Input.GetKey(KeyCode.S))
            movimento -= direzioneCamera;

        // If the player press A
        if (Input.GetKey(KeyCode.A))
            movimento -= direzioneDestra;

        // If the player press D
        if (Input.GetKey(KeyCode.D))
            movimento += direzioneDestra;

        // If the player press Space
        if (Input.GetKey(KeyCode.Space))
            movimento += transform.up;

        // If the player press L.Ctrl
        if (Input.GetKey(KeyCode.LeftControl))
            movimento -= transform.up;

        movimento = movimento.normalized * velocità * Time.deltaTime;

        _rigidbody.linearVelocity = movimento;
        //transform.Translate(movimento, Space.World);

        float mouseX = Input.GetAxis("Mouse X") * SettingsManager.MouseSensitivity; // Orizontal movement
        float mouseY = Input.GetAxis("Mouse Y") * SettingsManager.MouseSensitivity; // Vertical movement

        rotazioneOrizzontale += mouseX;
        rotazioneVerticale += mouseY;
        rotazioneVerticale = Mathf.Clamp(rotazioneVerticale, -90f, 90f); // Limit the vertical rotation

        // Applicare la rotazione alla fotocamera e al giocatore
        //cameraPrincipale.transform.rotation = Quaternion.Euler(-rotazioneVerticale, /*rotazioneOrizzontale*/ cameraPrincipale.transform.eulerAngles.y, cameraPrincipale.transform.eulerAngles.z);
        transform.rotation = Quaternion.Euler(-rotazioneVerticale, rotazioneOrizzontale, 0);
    }
}
