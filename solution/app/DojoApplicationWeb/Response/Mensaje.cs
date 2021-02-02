namespace DojoApplicationWeb.Response
{
    public sealed class Mensaje
    {
        public string Codigo { get; }
        public string Descripcion { get; }

        public Mensaje(string code, string description)
        {
            Codigo = code;
            Descripcion = description;
        }
    }
}
