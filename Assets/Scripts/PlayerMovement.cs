using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput inputJugador;
    [SerializeField] private Rigidbody rbJugador;

    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento=2f;
    private Vector2 direccionMovimiento;

    [SerializeField] private Animator animatorMovimiento;

    [SerializeField] private Camera camaraPrincipal;








    private void OnEnable() {

        inputJugador.actions["Move"].performed += MovimientoHorizontal;
        inputJugador.actions["Move"].canceled += MovimientoHorizontal;

        //inputJugador.actions["Look"].performed += MovimientoCamara;

    }

    private void MovimientoHorizontal(InputAction.CallbackContext contexto)
    {
        direccionMovimiento = contexto.ReadValue<Vector2>();
    }




    private void Update() {

    Vector3 direccionMovimientoUpdate = new Vector3(direccionMovimiento.x * velocidadMovimiento, rbJugador.linearVelocity.y, direccionMovimiento.y * velocidadMovimiento);
        Vector3 direccionCamaraAdelante = camaraPrincipal.transform.forward;
        direccionCamaraAdelante.y = 0;
        Vector3 direccionCamaraDerecha = camaraPrincipal.transform.right;
        direccionCamaraDerecha.y = 0;


        direccionMovimientoUpdate = direccionMovimientoUpdate.z*direccionCamaraAdelante  + direccionMovimientoUpdate.x*direccionCamaraDerecha;





        transform.forward = direccionCamaraAdelante;

        rbJugador.linearVelocity = direccionMovimientoUpdate;

        animatorMovimiento.SetFloat("Velocidad", rbJugador.linearVelocity.magnitude);


    }

    private void OnDisable()
    {
        inputJugador.actions["Move"].performed -= MovimientoHorizontal;
        inputJugador.actions["Move"].canceled -= MovimientoHorizontal;

        //inputJugador.actions["Look"].performed -= MovimientoCamara;
    }



}
