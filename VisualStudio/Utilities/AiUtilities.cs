// ---------------------------------------------
// AiUtilities - by The Illusion
// ---------------------------------------------
// Reusage Rights ------------------------------
// You are free to use this script or portions of it in your own mods, provided you give me credit in your description and maintain this section of comments in any released source code
//
// Warning !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// Ensure you change the namespace to whatever namespace your mod uses, so it doesnt conflict with other mods
// ---------------------------------------------

namespace TEMPLATE.Utilities
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class AiUtilities
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Checks if the current BaseAi is a rabbit
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns></returns>
        public static bool IsRabbit(BaseAi baseAi)
        {
            if (baseAi.Rabbit) return true;
            return false;
        }

        /// <summary>
        /// Checks if the current BaseAi is a bear
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns></returns>
        public static bool IsBear(BaseAi baseAi)
        {
            if (baseAi.Bear) return true;
            return false;
        }

        /// <summary>
        /// Gets all wolves
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns></returns>
        public static bool IsBaseWolf(BaseAi baseAi)
        {
            if (baseAi.BaseWolf) return true;
            return false;
        }

        /// <summary>
        /// Checks if the current BaseAi is a NormalWolf (anything not Timberwolf)
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns></returns>
        public static bool IsNormalWolf(BaseAi baseAi)
        {
            if (baseAi.NormalWolf) return true;
            return false;
        }

        /// <summary>
        /// Checks if the current BaseAi is a timberwolf
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns></returns>
        public static bool IsTimberwolf(BaseAi baseAi)
        {
            if (baseAi.Timberwolf) return true;
            return false;
        }

        /// <summary>
        /// Checks if the current BaseAi is a Moose
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns></returns>
        public static bool IsMoose(BaseAi baseAi)
        {
            if (baseAi.Moose) return true;
            return false;
        }

        /// <summary>
        /// Gets all Deer
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns></returns>
        public static bool IsBaseDeer(BaseAi baseAi)
        {
            if (baseAi.BaseDeer) return true;
            return false;
        }

        /// <summary>
        /// Checks if the current BaseAi is a Normal Stag
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns></returns>
        public static bool IsStag(BaseAi baseAi)
        {
            if (baseAi.Stag) return true;
            return false;
        }

        /// <summary>
        /// Checks if the current BaseAi is a White Stag
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns></returns>
        public static bool IsStagWhite(BaseAi baseAi)
        {
            if (baseAi.StagWhite) return true;
            return false;
        }

        /// <summary>
        /// Checks if the current BaseAi is a doe
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns></returns>
        public static bool IsDoe(BaseAi baseAi)
        {
            if (baseAi.Doe) return true;
            return false;
        }

        /// <summary>
        /// Checks if the current BaseAi is a ptarmigan
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns></returns>
        public static bool IsPtarmigan(BaseAi baseAi)
        {
            if (baseAi.Ptarmigan) return true;
            return false;
        }

        /// <summary>
        /// Checks if the current BaseAi is a cougar
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns></returns>
        public static bool IsCougar(BaseAi baseAi)
        {
            if (baseAi.Cougar) return true;
            return false;
        }

        /// <summary>
        /// Checks if the current BaseAi is valid
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns>true if the BaseAi is valid</returns>
        /// <remarks>
        /// <para>Checks if the current BaseAi mode is either <see cref="AiMode.None"/> or <see cref="AiMode.Disabled"/></para>
        /// </remarks>
        public static bool IsValid(BaseAi baseAi)
        {
            if (baseAi.m_CurrentMode == AiMode.None) return false;
            if (baseAi.m_CurrentMode == AiMode.Disabled) return false;
            return true;
        }

        /// <summary>
        /// Checks if the current BaseAi is dead
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns></returns>
        public static bool IsDead(BaseAi baseAi)
        {
            if (baseAi.m_CurrentMode == AiMode.Dead) return true;
            return false;
        }

        /// <summary>
        /// Gets the WildlifeMode for the given BaseAi
        /// </summary>
        /// <param name="baseAi">The BaseAi instance</param>
        /// <returns>Current BaseAi instance WildlifeMode</returns>
        /// <remarks>
        /// <para>This is useful for when you want to know if its a normal animal or an Aurora animal</para>
        /// </remarks>
        public static WildlifeMode GetWildlifeMode(BaseAi baseAi)
        {
            return baseAi.m_WildlifeMode;
        }
    }
}
