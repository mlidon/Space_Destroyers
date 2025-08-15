using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f; // Velocidad de movimiento
    public float ppu = 125f; // Pixels per unit 
    [Header("Sprites de dirección")]
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;
    public Sprite spriteIdle; // sprite por defecto

    private SpriteRenderer sr;
    private float xLimit;
    private float yLimit;

    private enum Direction { Idle, Up, Down, Left, Right }
    private Dictionary<Direction, Sprite> spriteMap;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // Calculamos límites en unidades de Unity
        xLimit = (1920f / ppu) / 2f;
        yLimit = (1080f / ppu) / 2f;

         // Configuramos el diccionario
        spriteMap = new Dictionary<Direction, Sprite>
        {
            { Direction.Idle,  spriteIdle },
            { Direction.Up,    spriteUp },
            { Direction.Down,  spriteDown },
            { Direction.Left,  spriteLeft },
            { Direction.Right, spriteRight }
        };
    }

    void Update()
    {
        // Lectura de input (WASD o flechas)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;

        transform.position += movement;

        // Limitamos posición dentro del área
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -xLimit, xLimit),
            Mathf.Clamp(transform.position.y, -yLimit, yLimit),
            transform.position.z
        );

       // Determinar dirección
        Direction dir = Direction.Idle;
        if (moveX > 0) dir = Direction.Right;
        else if (moveX < 0) dir = Direction.Left;
        else if (moveY > 0) dir = Direction.Up;
        else if (moveY < 0) dir = Direction.Down;

        // Asignar sprite desde el diccionario
        sr.sprite = spriteMap[dir];
    }
}

