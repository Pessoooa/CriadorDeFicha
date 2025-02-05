using testes.Classes;

namespace testes;

public class Ficha
{
    public List<ComponenteDeFicha> ComponentesDeFicha { get; set; } = new List<ComponenteDeFicha>();
    public Dictionary<string, int> Atributos => ObterAtributos();

    private Dictionary<string, int> ObterAtributos()
    {
        var atributos = new Dictionary<string, int>();
        foreach (var componente in ComponentesDeFicha)
        {
            foreach (var atributo in componente.Atributos)
            {
                if (atributos.ContainsKey(atributo.Key))
                    atributos[atributo.Key] += atributo.Value;
                else
                    atributos.Add(atributo.Key, atributo.Value);
            }
        }

        return atributos;
    }
}
