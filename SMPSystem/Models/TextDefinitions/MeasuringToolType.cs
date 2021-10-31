namespace SMPSystem.Models.TextDefinitions
{
    public static class MeasuringToolType
    {
        public const string Pachymeter = "Pachymeter";
        public const string ExternalMicrometer = "ExternalMicrometer";
        public const string InternalMicrometer = "InternalMicrometer";
        public const string DepthMicrometer = "DepthMicrometer";
        public const string DialIndicator = "DialIndicator";

        public static string TypeNameDescription(string promotionTypeName)
        {
            return promotionTypeName switch
            {
                Pachymeter => "Paquímetro",
                ExternalMicrometer => "Micrômetro Externo",
                InternalMicrometer => "Micrômetro Interno",
                DepthMicrometer => "Micrômetro de Profundidade",
                DialIndicator => "Relógio Comparador",
                _ => "Inválido",
            };
        }
    }
}
