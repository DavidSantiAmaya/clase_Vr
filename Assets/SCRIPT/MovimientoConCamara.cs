using Unity.VisualScripting;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    //MovimientoBasico
    public CharacterController Controlador;
    public float Velocidad = 15f;
    public float Gravedad = -10;
    public float FuerzaSalto = 3f;
    
    //Salto
    public Transform EnElpiso;
    public float DistanciaDelPiso;
    public LayerMask Piso;

    Vector3 VelocidadCaida;
    private bool EstaEnElPiso; //piblic si se pueden cambiar en unity y si es private solo codigo

    public Camera mainCamaia;
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
        EstaEnElPiso = Physics.CheckSphere(EnElpiso.position, DistanciaDelPiso, Piso);
        if (EstaEnElPiso && VelocidadCaida.y < 0)
        { 
            VelocidadCaida.y = -2;       
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        mover = new Vector3(x, 0, z);
        moveJugador = Vector3.ClampMagnitude(moveJugador, 1);
        moveJugador = mover.x * camRight + mover.z * camForward;
        Controlador.Move(moveJugador * Velocidad * Time.deltaTime);
        Controlador.transform.LookAt(Controlador.transform.position + moveJugador);   

        if (Input.GetButtonDown("Jump") && EstaEnElPiso)
        {
            VelocidadCaida.y = Mathf.Sqrt(FuerzaSalto * -2f * Gravedad);
        }
        VelocidadCaida.y += Gravedad * Time.deltaTime;
        Controlador.Move(VelocidadCaida * Time.deltaTime);
        DireccionCamara();
    }

    void DireccionCamara()
    {
        camForward = mainCamaia.transform.forward;
        camRight = mainCamaia.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;

    }
}