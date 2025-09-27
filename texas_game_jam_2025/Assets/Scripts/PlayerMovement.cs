using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveForce = 20f;
        public float turnTorque = 50f;
        public float hoverHgt = 2f;
        public float hoverForce = 50f;

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
        }

        void FixedUpdate()
        {
            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, hoverHgt))
            {
                float proportionalHeight = (hoverHgt - hit.distance) / hoverHgt;
                Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
                rb.AddForce(appliedHoverForce, ForceMode.Acceleration);
            }
                
            float moveInput = Input.GetAxis("Vertical");
            float turnInput = Input.GetAxis("Horizontal");

            rb.AddForce(transform.forward * moveInput * moveForce);
            rb.AddTorque(transform.up * turnInput * turnTorque);
        }

    }
}
