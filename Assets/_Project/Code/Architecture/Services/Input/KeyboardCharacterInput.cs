using UnityEngine;

namespace _Project.Code.Architecture
{
    public class KeyboardCharacterInput : ICharacterInput
    {
        public Vector2 Axis =>
            Enabled ? new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) : Vector2.zero;

        public bool IsJumping => 
            Enabled && Input.GetKey(KeyCode.Space);

        public bool Enabled { get; set; } = true;
    }
}