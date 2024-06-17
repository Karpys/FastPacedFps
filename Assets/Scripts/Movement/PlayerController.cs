namespace KarpysDev.Fps.Movement
{
    using KarpysUtils;
    using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform m_Forward = null;
        [SerializeField] private float m_Acceleration = 0;
        [SerializeField] private float m_Deceleration = 0;
        [SerializeField] private float m_StopTreshold = 0;
        [SerializeField] private float m_MaxSpeed = 0;

        [Header("Drag")] 
        [SerializeField] private Transform m_StartGroundCheck = null;
        [SerializeField] private float m_GroundCheckHeight = 0;
        [SerializeField] private LayerMask m_GroundMask;

        [Header("Jump")] 
        [SerializeField] private float m_JumpForce = 0;
        
        private Vector2 m_Input = Vector2.zero;
        private bool m_IsGrounded = false;
        private bool m_RequestJump = false;
        private Vector3 m_HorizontalVelocity = Vector3.zero;
        private void Update()
        {
            PlayerInput();

            m_IsGrounded = Physics.Raycast(m_StartGroundCheck.position, Vector3.down, m_GroundCheckHeight, m_GroundMask);
           
            HorizontalMovement();
            JumpCheck();

            Vector3 horizontalVelocity = new Vector3(m_HorizontalVelocity.x, 0, m_HorizontalVelocity.z); 
            horizontalVelocity.magnitude.Log("Horizontal Velocity");
            transform.position += horizontalVelocity * Time.deltaTime;
        }

        private void PlayerInput()
        {
            m_Input.x = Input.GetAxisRaw("Horizontal");
            m_Input.y = Input.GetAxisRaw("Vertical");
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_RequestJump = true;
            }
        }
        
        private void HorizontalMovement()
        {
            Vector3 newHorizontalVelocity = m_Forward.forward * m_Input.y + m_Forward.right * m_Input.x;

            if (newHorizontalVelocity != Vector3.zero)
            {
                m_HorizontalVelocity += newHorizontalVelocity.normalized * (m_Acceleration * Time.deltaTime);
                
                if (m_HorizontalVelocity.magnitude > m_MaxSpeed)
                {
                    m_HorizontalVelocity = m_HorizontalVelocity.normalized * m_MaxSpeed;
                }
            }
            else if(m_HorizontalVelocity != Vector3.zero)
            {
                Vector3 inverse = -m_HorizontalVelocity;
                m_HorizontalVelocity += inverse.normalized * (m_Deceleration * Time.deltaTime);
                StopCheck();
                //Decelerate
            }
        }

        private void StopCheck()
        {
            if (m_HorizontalVelocity.magnitude <= m_StopTreshold)
            {
                m_HorizontalVelocity = Vector3.zero;
            }
        }

        private void JumpCheck()
        {
            if (m_IsGrounded && m_RequestJump)
            {
                Jump();
            }
        }
        
        private void Jump()
        {
           
        }
    }
}