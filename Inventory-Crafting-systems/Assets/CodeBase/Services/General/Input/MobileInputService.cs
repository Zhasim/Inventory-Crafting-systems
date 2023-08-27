using UnityEngine;

namespace CodeBase.Services.General.Input
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}