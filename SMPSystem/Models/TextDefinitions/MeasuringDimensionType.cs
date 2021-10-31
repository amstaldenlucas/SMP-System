namespace SMPSystem.Models.TextDefinitions
{
    public static class MeasuringDimensionType
    {
        public const string ExternalDiameter = "ExternalDiameter";
        public const string InternalDiameter = "InternalDiameter";
        public const string Height = "Height";
        public const string Depth = "Depth";
        public const string Roughness = "Roughness";

        public static string TypeNameDescription(string promotionTypeName)
        {
            return promotionTypeName switch
            {
                ExternalDiameter => "Diâmetro Externo",
                InternalDiameter => "Diâmetro Interno",
                Height => "Altura",
                Depth => "Profundidade",
                Roughness => "Rugosidade",
                _ => "Inválido",
            };
        }
    }
}
