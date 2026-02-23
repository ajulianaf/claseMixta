using UnityEngine;
using UnityEngine.Windows;

public class Jugador : MonoBehaviour
{
    //movimiento basico
    public CharacterController Controlador;
    public float Velocidad = 15f;
    public float Gravedad = -10f;
    public float FuerzaSalto = 3f;

    //Salto
    public Transform EnElPiso;
    public float DistanciaDelPiso;
    public LayerMask Piso;

    Vector3 VelocidadCaida;
    private bool EstaEnElPiso;

    //Movimiento camara
    public Camera mainCamara;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 moveJugador;
    private Vector3 mover;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EstaEnElPiso = Physics.CheckSphere(EnElPiso.position, DistanciaDelPiso, Piso); 
        if (EstaEnElPiso && VelocidadCaida.y < 0)
        {
            VelocidadCaida.y = -2;
        }

        float x = UnityEngine.Input.GetAxis("Horizontal");
        float z = UnityEngine.Input.GetAxis("Vertical");
        mover = new Vector3(x, 0, z);
        moveJugador = Vector3.ClampMagnitude(moveJugador, 1);
        moveJugador = mover.x*camRight + mover.z*camForward;
        Controlador.Move(moveJugador * Velocidad * Time.deltaTime);
        Controlador.transform.LookAt(Controlador.transform.position + moveJugador);

        if (UnityEngine.Input.GetButtonDown("Jump") && EstaEnElPiso)
        {
            print("Salto");
            VelocidadCaida.y = Mathf.Sqrt(FuerzaSalto * -2f * Gravedad);
        }
        VelocidadCaida.y += Gravedad * Time.deltaTime;
        Controlador.Move(VelocidadCaida * Time.deltaTime);
        DireccionCamara();
    }

    void DireccionCamara() 
    {
        camForward = mainCamara.transform.forward;
        camRight = mainCamara.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
