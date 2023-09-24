using FlaxEngine;

namespace Game
{
    /// <summary>
    /// FireBullets Script.
    /// </summary>
    public class FireBullets : Script
    {
        public Prefab BulletPrefab { get; set; }
        public Actor BulletContainer { get; set; }

        private uint counter = 0;

        /// <inheritdoc/>
        public override void OnFixedUpdate()
        {
            if (counter++ % 60 == 0)
            {
                //var bullet = PrefabManager.SpawnPrefab(BulletPrefab, Actor.Position);
                //bullet.Parent = BulletContainer;
            }
        }
    }
}
