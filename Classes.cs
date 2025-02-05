namespace testes.Classes
{
    public class Personagem
    {
        public string Nome { get; set; }
        public Dictionary<string, int> Atributos { get; set; }

        public int GetAtributo(string nome)
        {
            return Atributos.ContainsKey(nome) ? Atributos[nome] : 0;
        }

        public void SetAtributo(string nome, int valor)
        {
            if (Atributos.ContainsKey(nome))
            {
                if (nome == "VIDA" && valor < 0)
                    Atributos[nome] = 0;
                else
                    Atributos[nome] = valor;
            }
        }
    }
}
