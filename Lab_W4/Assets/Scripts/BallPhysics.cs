using UnityEngine.Assertions;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_vTargetPos;
    [SerializeField]
    private Vector3 m_vInitialVel;
    [SerializeField]
    private bool m_bDebugKickBall = false;
    [SerializeField]
    private Transform spawnPos;
    private Rigidbody m_rb = null;
    private TargetPhysics m_TargetDisplay = null;

    public bool m_bIsGrounded = true;

    private float m_fDistanceToTarget = 0f;

    private Vector3 vDebugHeading;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnPos.position;
        m_rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rb, "Houston, we've got a problem here! No Rigidbody attached");

       CreateTargetDisplay();
        m_fDistanceToTarget = (m_TargetDisplay.transform.position - transform.position).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        _CheckBounds();
		if (m_bIsGrounded)
		{
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        
        if (Input.GetMouseButtonDown(0) && m_bIsGrounded && m_TargetDisplay.transform.position.y > 0.1)
        {
            m_fDistanceToTarget = (m_TargetDisplay.transform.position - transform.position).magnitude;
            m_bIsGrounded = false;
            m_bDebugKickBall = false;
            OnKickBall();
        }
    }

    private void CreateTargetDisplay()
    {
        m_TargetDisplay = FindObjectOfType<TargetPhysics>();
       
    }

    public void OnKickBall()
    {
        // H = Vi^2 * sin^2(theta) / 2g
        // R = 2Vi^2 * cos(theta) * sin(theta) / g

        // Vi = sqrt(2gh) / sin(tan^-1(4h/r))
        // theta = tan^-1(4h/r)

        // Vy = V * sin(theta)
        // Vz = V * cos(theta)

        float fMaxHeight = m_TargetDisplay.transform.position.y;
        float fRange = (m_fDistanceToTarget * 2);
        float fTheta = Mathf.Atan((4 * fMaxHeight) / (fRange));

        float fInitVelMag = Mathf.Sqrt((2 * Mathf.Abs(Physics.gravity.y) * fMaxHeight)) / Mathf.Sin(fTheta);
        m_vInitialVel.x = fInitVelMag * transform.forward.x;
        m_vInitialVel.y = fInitVelMag * Mathf.Sin(fTheta);
        m_vInitialVel.z = fInitVelMag * Mathf.Cos(fTheta);

        m_rb.velocity = m_vInitialVel;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + vDebugHeading, transform.position);
    }

    private void _CheckBounds()
    {
        if (Vector3.Distance(transform.position,spawnPos.position) > 80.0)
        {
            transform.position = spawnPos.position;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            m_bIsGrounded = true;
        }
    }
}
