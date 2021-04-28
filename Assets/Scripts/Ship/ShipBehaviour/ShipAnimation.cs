using UnityEngine;

namespace Ship.Behaviour
{
    public class ShipAnimation
    {
        private readonly Animator _shipAnimator;
        private readonly int SHIP_ON;
        private readonly int SHIP_OFF;

        private int _currentStateHash;

        public ShipAnimation(Animator shipAnimator)
        {
            _shipAnimator = shipAnimator;

            SHIP_ON = Animator.StringToHash("ShipOn");
            SHIP_OFF = Animator.StringToHash("ShipOff");
        }

        public void PlayAnimation()
        {
            ChangeToState(SHIP_ON);
        }

        public void StopAnimation()
        {
            ChangeToState(SHIP_OFF);
        }

        private void ChangeToState(int newStateHash)
        {
            if (_currentStateHash == newStateHash)
                return;

            _shipAnimator.Play(newStateHash);
            _currentStateHash = newStateHash;
        }
    }
}