namespace TEMPLATE.Utilities.Converters
{
    public class Rotation
    {
        public class RotationArray
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; }
            public float W { get; set; }

            public RotationArray(float X, float Y, float Z, float W)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
                this.W = W;
            }
        }

        Quaternion? m_Quaternion { get; set; }
        RotationArray? m_RotationArray { get; set; }
        
        public Rotation(Quaternion quaternion, RotationArray rotation)
        {
            this.m_Quaternion = quaternion;
            this.m_RotationArray = rotation;
        }

        public static explicit operator Quaternion(Rotation rotation)
        {
            return new Quaternion(rotation.m_RotationArray.X, rotation.m_RotationArray.Y, rotation.m_RotationArray.Z, rotation.m_RotationArray.W);
        }

        public static explicit operator RotationArray(Rotation rotation)
        {
            return new RotationArray(rotation.m_Quaternion.Value[0], rotation.m_Quaternion.Value[1], rotation.m_Quaternion.Value[2], rotation.m_Quaternion.Value[3]);
        }
    }
}