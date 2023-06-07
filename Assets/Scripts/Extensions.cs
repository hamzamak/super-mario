
using UnityEngine;

public static class Extensions
//an extension method allows you to add new functionality to an existing class without modifying its source code
{
    private static LayerMask layerMask = LayerMask.GetMask("Default");
    //This class is used to add an extension method to the Rigidbody2D class from the UnityEngine namespace.
    public static bool Raycast (this Rigidbody2D rigidbody , Vector2 direction)
    {
        if(rigidbody.isKinematic)
        {
            return false;
        }
        float radius = 0.25f;
        float distance = 0.375f;
      // Performs a circlecast using Physics2D.CircleCast with the given parameters
        // and stores the result in the hit variable
        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction.normalized, distance, layerMask);

        // Returns true if a collider was hit, and false otherwise
        return hit.collider != null && hit.rigidbody != rigidbody ;
    }
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position ; // we want know if the collider is above of you,is side of you ...
        return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
    }
}
