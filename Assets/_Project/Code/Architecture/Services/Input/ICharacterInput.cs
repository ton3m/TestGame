using UnityEngine;

namespace _Project.Code.Architecture
{
    public interface ICharacterInput
    {
        Vector2 Axis { get; }
        bool IsJumping { get; }
        bool Enabled { get; set; }
    }
}