using UnityEngine;

namespace TMG.BloonsTD.Gameplay
{
    public class ProjectileAttack : TowerAttack, IUpgradeRange, IUpgradeWeapon
    {
        private GameObject _projectile;
        
        public override void Initialize(TowerController towerController)
        {
            base.Initialize(towerController);
            _projectile = TowerController.TowerProperties.ProjectilePrefab;
            SetRange(TowerController.TowerProperties.Range);
        }

        protected override void Attack(Vector3 targetLocation)
        {
            var rotation = GetOrientationToTarget(TowerPosition, targetLocation);
            TowerController.transform.rotation = rotation;
            var newProjectile = Object.Instantiate(_projectile, TowerPosition, rotation);
            var newProjectileController = newProjectile.GetComponent<BasicProjectileController>();
            newProjectileController.MaxDistanceTraveled = ProjectileRange;
        }

        public void SetRange(float newRangeValue)
        {
            Debug.Log($"Setting Range to {newRangeValue}", TowerController.gameObject);
            ProjectileRange = newRangeValue;
            TowerBloonDetector.SetRange(newRangeValue);
        }

        public void SetWeapon(GameObject newWeaponPrefab)
        {
            _projectile = newWeaponPrefab;
        }
    }
}