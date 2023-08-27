using UnityEngine;

namespace CodeBase.Services.GamePlay.Factory
{
    public interface IGameFactory
    {
        GameObject CreatePlayer(Transform parent);
    }
}