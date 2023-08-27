using Vector2 = UnityEngine.Vector2;

namespace CodeBase.Services.General.Input
{
    public interface IInputService
    {
        Vector2 Axis { get; }
        bool IsAttackButtonUp();
    }
}