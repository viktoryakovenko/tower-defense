using Code.Towers;
using UnityEditor;
using UnityEngine;

namespace Code.Editor
{
    [CustomEditor(typeof(TriggerObserver))]
    public class TowerAttackRadiusEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(TriggerObserver observer, GizmoType gizmo)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(observer.transform.position, observer.GetComponent<CircleCollider2D>().radius);
        }
    }
}
