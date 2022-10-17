using UnityEditor;
using UnityEngine;

namespace Platformer3D.Game.Objects
{
    [CustomEditor(typeof(MovingObject))]
    public class MovingObjectEditor : Editor
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        private static void Draw(MovingObject movingObject, GizmoType gizmoType)
        {
            if (!ShouldDraw(movingObject, gizmoType))
                return;


            if (!IsNotValid(movingObject))
            {
                return;
            }

            Gizmos.color = Color.blue;

            foreach (Transform point in movingObject.Points)
            {
                Gizmos.DrawSphere(point.position, 0.1f);
                
            }

            Gizmos.color = Color.green;
            
            Transform previousPoint = movingObject.Points.First(); 
            for (int i = 1; i < movingObject.Points.Count; i++)
            {
                Transform point = movingObject.Points[i];
                Gizmos.DrawLine(previousPoint.position, point.position);
                previousPoint = point; 
            }
            
            Gizmos.DrawLine(previousPoint.position, movingObject.Points.First().position);
        }

        private static bool IsNotValid(MovingObject movingObject)
        {
            return movingObject.Points == null || movingObject.Points.Count < 2;
        }

        private static bool ShouldDraw(MovingObject movingObject, GizmoType gizmoType)
        {
            if (gizmoType == GizmoType.Selected)
                return true;

            Transform parent = movingObject.transform.parent;
            if (parent == Selection.activeTransform)
                return true;
            

            for (int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i) == Selection.activeTransform)
                    return true;
            }

            return false; 
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            MovingObject movingObject = (MovingObject) target; 
            if (GUILayout.Button($"Test Button"))
            {
                movingObject.Move();
            }
                
        }
    }
}