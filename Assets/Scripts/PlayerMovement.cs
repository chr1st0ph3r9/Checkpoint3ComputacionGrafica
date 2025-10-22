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

    [Header("camara")]
    [SerializeField] private float sensibilidadCamara=1f;
    [SerializeField] private CinemachineOrbitalFollow camara;
    private Vector2 movimientoCamara;
    [SerializeField] private float deadZoneCamara=0.1f;






    private void OnEnable() {

        inputJugador.actions["Move"].performed += MovimientoHorizontal;
        inputJugador.actions["Move"].canceled += MovimientoHorizontal;

        //inputJugador.actions["Look"].performed += MovimientoCamara;

    }

    private void MovimientoHorizontal(InputAction.CallbackContext contexto)
    {
        direccionMovimiento = contexto.ReadValue<Vector2>();
    }

    private void MovimientoCamara(InputAction.CallbackContext contexto)
    {
        movimientoCamara = contexto.ReadValue<Vector2>();
    }


    private void Update() {

        Vector3 direccionMovimientoUpdate = new Vector3(direccionMovimiento.x* velocidadMovimiento, rbJugador.linearVelocity.y, direccionMovimiento.y* velocidadMovimiento);



        rbJugador.linearVelocity = direccionMovimientoUpdate;

        //if (movimientoCamara.magnitude> deadZoneCamara)
        //{
        //    camara.HorizontalAxis.Value += movimientoCamara.x * sensibilidadCamara * Time.deltaTime;
        //    camara.VerticalAxis.Value += movimientoCamara.y * sensibilidadCamara * Time.deltaTime;

        //}



    }

    private void OnDisable()
    {
        inputJugador.actions["Move"].performed -= MovimientoHorizontal;
        inputJugador.actions["Move"].canceled -= MovimientoHorizontal;

        //inputJugador.actions["Look"].performed -= MovimientoCamara;
    }



}
