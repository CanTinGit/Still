/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID BUBBLE_RISE = 3673951289U;
        static const AkUniqueID BUBBLE_SHOT = 1531020610U;
        static const AkUniqueID BUTTON_CLICK = 814543256U;
        static const AkUniqueID CAMERA_TRIGGER = 1860426137U;
        static const AkUniqueID CAN_IMPACT = 697519634U;
        static const AkUniqueID CRANE_PICKUP = 412826751U;
        static const AkUniqueID PLAYER_ACCIDENT = 4205375722U;
        static const AkUniqueID PLAYER_CARRY = 662165722U;
        static const AkUniqueID PLAYER_CATCH = 1049036554U;
        static const AkUniqueID PLAYER_DROP = 1922690190U;
        static const AkUniqueID PLAYER_JUMP = 1305133589U;
        static const AkUniqueID PLAYER_LIFT = 3762137770U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace IMPACT_FORCE
        {
            static const AkUniqueID GROUP = 2939788855U;

            namespace STATE
            {
                static const AkUniqueID HEAVY = 2732489590U;
                static const AkUniqueID LIGHT = 1935470627U;
                static const AkUniqueID MEDIUM = 2849147824U;
                static const AkUniqueID VERY_LIGHT = 2401347528U;
            } // namespace STATE
        } // namespace IMPACT_FORCE

        namespace MATERIAL
        {
            static const AkUniqueID GROUP = 3865314626U;

            namespace STATE
            {
                static const AkUniqueID ICE_OBJECT = 1453789772U;
                static const AkUniqueID METAL_OBJECT = 468109460U;
                static const AkUniqueID PLASTIC_OBJECT = 3350771019U;
                static const AkUniqueID WOOD_OBJECT = 3729124792U;
            } // namespace STATE
        } // namespace MATERIAL

    } // namespace STATES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID NOISE_DETECTION = 866473373U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID ENEMY = 2299321487U;
        static const AkUniqueID PLAYER = 1069431850U;
        static const AkUniqueID TEST = 3157003241U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID AMBIENCE = 85412153U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MASTER_SECONDARY_BUS = 805203703U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
        static const AkUniqueID VOICE = 3170124113U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID REVERB = 348963605U;
    } // namespace AUX_BUSSES

}// namespace AK

#endif // __WWISE_IDS_H__
