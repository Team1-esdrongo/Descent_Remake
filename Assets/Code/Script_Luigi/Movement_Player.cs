using UnityEngine;

public class Movement_Player : MonoBehaviour
{
    public float velocità = 5f;
    public Camera cameraPrincipale;  // Main camera
    public float sensibilitàMouse = 2f; // Sensibility
    private float rotazioneOrizzontale = 0f;
    private float rotazioneVerticale = 0f;
    public Player_Shooting muzzle;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            muzzle.Fire();
        }

        // Movement of the camera
        Vector3 movimento = Vector3.zero;

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

        transform.Translate(movimento, Space.World);

        float mouseX = Input.GetAxis("Mouse X") * sensibilitàMouse; // Orizontal movement
        float mouseY = Input.GetAxis("Mouse Y") * sensibilitàMouse; // Vertical movement

        rotazioneOrizzontale += mouseX;
        rotazioneVerticale -= mouseY;
        rotazioneVerticale = Mathf.Clamp(rotazioneVerticale, -90f, 90f); // Limit the vertical rotation

        // Applicare la rotazione alla fotocamera e al giocatore
        cameraPrincipale.transform.rotation = Quaternion.Euler(rotazioneVerticale, rotazioneOrizzontale, 0);
        transform.rotation = Quaternion.Euler(0, rotazioneOrizzontale, 0);
    }
}
