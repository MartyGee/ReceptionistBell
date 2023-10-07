using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player GameObject's Transform
    public AudioClip collisionSound;

    [Header("Don't touch")]
    public float volumeMultiplier = 0.1f; // Adjust this multiplier as needed
    public float minVolume = 0.2f; // Minimum volume
    public float maxVolume = 1.0f; // Maximum volume



    private AudioSource audioSource;

    void Start()
    {
        // Create an AudioSource component if it doesn't exist on the GameObject
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the collision sound
        audioSource.clip = collisionSound;

        // Enable 3D spatialization
        audioSource.spatialBlend = 1.0f; // 1.0 means fully 3D
    }

    void OnCollisionEnter(Collision collision)
    {
        // Calculate the relative velocity of the collision
        float relativeVelocity = collision.relativeVelocity.magnitude;

        // Calculate the volume based on the relative velocity and volume multiplier
        float volume = relativeVelocity * volumeMultiplier;

        // Calculate the direction from the player to the collision point
        Vector3 directionToPlayer = playerTransform.position - collision.contacts[0].point;

        // Calculate the distance between the player and the collision point
        float distanceToPlayer = directionToPlayer.magnitude;

        // Calculate the falloff factor based on distance
        float falloffFactor = 1.0f / distanceToPlayer;

        // Adjust the volume based on falloff
        volume *= falloffFactor;

        // Clamp the volume between the specified minimum and maximum values
        volume = Mathf.Clamp(volume, minVolume, maxVolume);

        // Set the volume
        audioSource.volume = volume;

        // Play the collision sound
        audioSource.Play();
    }
}




