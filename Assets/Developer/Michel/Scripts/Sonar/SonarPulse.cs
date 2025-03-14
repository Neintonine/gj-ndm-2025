using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;


public sealed class SonarPulse : MonoBehaviour
{
    public record Line(IReadOnlyList<Vector2> points, float distance)
    {
        public float distance { get; } = distance;
        public IReadOnlyList<Vector2> points { get; } = points;
    }

    private static readonly int DISTANCE_SHADER_ID = Shader.PropertyToID("_Distance");
    private static readonly int TIME_SHADER_ID = Shader.PropertyToID("_AnimationTime");

    [Header("Pulse")]
    [SerializeField] private SpriteRenderer _circle;
    [SerializeField] private float _pulseDistance = 10;
    [SerializeField] private float _pulseDuration = 3;
    
    [Header("Line")]
    [SerializeField] private LineRenderer _linePrefab;
    [SerializeField] private int _lineResolution;
    [FormerlySerializedAs("_playerMask")] [SerializeField] private LayerMask _lineRaycastMask;

    private float _distancePerSecond;
    private float _timer = 0;
    private Material _circleMaterial;
    private ICollection<Line> _lines;
    
    private void Start()
    {
        this._distancePerSecond = this._pulseDistance / this._pulseDuration;
        
        this._lines = this.createLines();

        this._circle.transform.localScale = new Vector3(this._pulseDistance * 2, this._pulseDistance * 2, 1);
        this._circleMaterial = this._circle.material;
        
        Destroy(this.gameObject, this._pulseDuration);
    }

    private void Update()
    {
        _timer += Time.deltaTime / this._pulseDuration;
        
        float currentDistance = this._pulseDistance * Mathf.Sqrt(this._timer);
        this._circleMaterial.SetFloat(SonarPulse.DISTANCE_SHADER_ID, currentDistance / this._pulseDistance);
        this._circleMaterial.SetFloat(SonarPulse.TIME_SHADER_ID, _timer);

        List<Line> foundLines = new List<Line>();
        foreach (Line line in this._lines.Where(line => line.distance >= currentDistance))
        {
            this.createLineRenderer(line.points);
            
            foundLines.Add(line);
        }
        
        foundLines.ForEach(line => this._lines.Remove(line));
    }

    private ICollection<Line> createLines()
    {
        float steps = (Mathf.PI * 2) / this._lineResolution;
        
        List<Vector2> currentPoints = new List<Vector2>();
        List<float> currentDistances = new List<float>();
        List<Line> lines = new();

        for (float i = 0f; i < Mathf.PI * 2; i += steps)
        {
            Vector2 direction = new Vector2(Mathf.Cos(i), Mathf.Sin(i));
            RaycastHit2D raycastHit2D = Physics2D.Raycast(this.transform.position, direction, this._pulseDistance, this._lineRaycastMask);
            
            if (raycastHit2D.collider != null)
            {
                currentDistances.Add(raycastHit2D.distance);
                currentPoints.Add(raycastHit2D.point);
                Debug.DrawLine(this.transform.position, raycastHit2D.point, Color.green, 5);
                continue;
            }

            Debug.DrawRay(this.transform.position, direction, Color.red, 5);
            
            if (currentPoints.Count == 0)
            {
                continue;
            }

            if (currentPoints.Count > 1)
            {
                float total = currentDistances.Aggregate(0f, (current, distance) => current + distance);
                lines.Add(new Line(currentPoints.ToArray(), total / currentDistances.Count));
            }

            currentPoints.Clear();
        }

        return lines;
    }

    private LineRenderer createLineRenderer(IReadOnlyCollection<Vector2> points)
    {
        LineRenderer lineRenderer = Instantiate(this._linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.Select(point => new Vector3(point.x, point.y, 0f)).ToArray());
        
        return lineRenderer;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, this._pulseDistance);
    }
}
