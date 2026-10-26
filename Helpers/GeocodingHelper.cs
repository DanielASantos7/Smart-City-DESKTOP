namespace MundialDESKTOP.V1.Helpers
{
    public static class GeocodingHelper
    {
        /// <summary>
        /// Mapeia as coordenadas (double x, double y) do mapa de Shanghai (1408x768)
        /// para o endereço amigável exigido no protótipo de detalhes.
        /// </summary>
        public static EnderecoInfo ObterEndereco(double x, double y)
        {
            // Cálculo do número aproximado com base no eixo Y
            int numero = ((int)y % 200) + 12;

            // Estrutura de decisão compatível com C# 7.3
            string rua;
            if (x < 400)
            {
                rua = "joe street";
            }
            else if (x < 800)
            {
                rua = "shanghai avenue";
            }
            else if (x < 1100)
            {
                rua = "central road";
            }
            else
            {
                rua = "east boulevard";
            }

            return new EnderecoInfo
            {
                Rua = rua,
                Numero = numero.ToString(),
                CEP = "12345",
                Cidade = "Shanghai"
            };
        }
    }

    public class EnderecoInfo
    {
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
    }
}