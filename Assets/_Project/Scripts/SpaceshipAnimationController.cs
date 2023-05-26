using UnityEngine;

public class SpaceshipAnimationController : MonoBehaviour {
    private Animation spaceshipAnimation;

    private bool exteriorHatch = false;
    private bool interiorHatch = false;
    private bool ladder = false;
    private bool cockpitDoors = false;
    private bool pilotSeat = false;
    private bool gunnerSeat = false;

    private void Start() {
        spaceshipAnimation = GetComponent<Animation>();
    }

    public void AnimateHatchsAndLadder() {
        if (!ladder) {
            AnimateExteriorHatch();
            Invoke(nameof(AnimateInteriorHatch), 1.1f);
            Invoke(nameof(AnimateLadder), 2.2f);
        } else {
            AnimateLadder();
            Invoke(nameof(AnimateInteriorHatch), 1.1f);
            Invoke(nameof(AnimateExteriorHatch), 2.2f);
        }
    }

    public void AnimateCockpitDoors() {
        if (!cockpitDoors) {
            if (!spaceshipAnimation.IsPlaying("CockpitDoors")) {
                spaceshipAnimation["CockpitDoors"].speed = 1;
                spaceshipAnimation["CockpitDoors"].time = 0;

                spaceshipAnimation.Play("CockpitDoors");

                cockpitDoors = true;
            }
        } else {
            if (!spaceshipAnimation.IsPlaying("CockpitDoors")) {
                spaceshipAnimation["CockpitDoors"].speed = -1;
                spaceshipAnimation["CockpitDoors"].time = spaceshipAnimation["CockpitDoors"].length;

                spaceshipAnimation.Play("CockpitDoors");

                cockpitDoors = false;
            }
        }
    }

    public void AnimatePilotSeat() {
        if (!pilotSeat) {
            if (!spaceshipAnimation.IsPlaying("PilotSeat")) {
                spaceshipAnimation["PilotSeat"].speed = 1;
                spaceshipAnimation["PilotSeat"].time = 0;

                spaceshipAnimation.Play("PilotSeat");

                pilotSeat = true;
            }
        } else {
            if (!spaceshipAnimation.IsPlaying("PilotSeat")) {
                spaceshipAnimation["PilotSeat"].speed = -1;
                spaceshipAnimation["PilotSeat"].time = spaceshipAnimation["PilotSeat"].length;

                spaceshipAnimation.Play("PilotSeat");

                pilotSeat = false;
            }
        }
    }

    public void AnimateGunnerSeat() {
        if (!gunnerSeat) {
            if (!spaceshipAnimation.IsPlaying("GunnerSeat")) {
                spaceshipAnimation["GunnerSeat"].speed = 1;
                spaceshipAnimation["GunnerSeat"].time = 0;

                spaceshipAnimation.Play("GunnerSeat");

                gunnerSeat = true;
            }
        } else {
            if (!spaceshipAnimation.IsPlaying("GunnerSeat")) {
                spaceshipAnimation["GunnerSeat"].speed = -1;
                spaceshipAnimation["GunnerSeat"].time = spaceshipAnimation["GunnerSeat"].length;

                spaceshipAnimation.Play("GunnerSeat");

                gunnerSeat = false;
            }
        }
    }

    private void AnimateExteriorHatch() {
        if (!exteriorHatch) {
            if (!spaceshipAnimation.IsPlaying("ExteriorHatch")) {
                spaceshipAnimation["ExteriorHatch"].speed = 1;
                spaceshipAnimation["ExteriorHatch"].time = 0;

                spaceshipAnimation.Play("ExteriorHatch");

                exteriorHatch = true;
            }
        } else {
            if (!spaceshipAnimation.IsPlaying("ExteriorHatch")) {
                spaceshipAnimation["ExteriorHatch"].speed = -1;
                spaceshipAnimation["ExteriorHatch"].time = spaceshipAnimation["ExteriorHatch"].length;

                spaceshipAnimation.Play("ExteriorHatch");

                exteriorHatch = false;
            }
        }
    }

    private void AnimateInteriorHatch() {
        if (!interiorHatch) {
            if (!spaceshipAnimation.IsPlaying("InteriorHatch")) {
                spaceshipAnimation["InteriorHatch"].speed = 1;
                spaceshipAnimation["InteriorHatch"].time = 0;

                spaceshipAnimation.Play("InteriorHatch");

                interiorHatch = true;
            }
        } else {
            if (!spaceshipAnimation.IsPlaying("InteriorHatch")) {
                spaceshipAnimation["InteriorHatch"].speed = -1;
                spaceshipAnimation["InteriorHatch"].time = spaceshipAnimation["InteriorHatch"].length;

                spaceshipAnimation.Play("InteriorHatch");

                interiorHatch = false;
            }
        }
    }

    private void AnimateLadder() {
        if (!ladder) {
            if (!spaceshipAnimation.IsPlaying("Ladder")) {
                spaceshipAnimation["Ladder"].speed = 1;
                spaceshipAnimation["Ladder"].time = 0;

                spaceshipAnimation.Play("Ladder");

                ladder = true;
            }
        } else {
            if (!spaceshipAnimation.IsPlaying("Ladder")) {
                spaceshipAnimation["Ladder"].speed = -1;
                spaceshipAnimation["Ladder"].time = spaceshipAnimation["Ladder"].length;

                spaceshipAnimation.Play("Ladder");

                ladder = false;
            }
        }
    }
}
