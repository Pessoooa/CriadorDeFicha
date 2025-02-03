using System;
using System.Collections.Generic;

namespace testes.Classes
{
    public class Personagem
    {
        public string classe { get; set; }
        private Dictionary<string, int> atributos;

        public Personagem()
        {
            atributos = new Dictionary<string, int>
            {
                { "FORCA", 0 },
                { "DESTREZA", 0 },
                { "CONSTITUICAO", 0 },
                { "INTELIGENCIA", 0 },
                { "SABEDORIA", 0 },
                { "CARISMA", 0 },
                { "VIDA", 0 },
                { "MANA", 0 },
                { "DEFESA", 0 }
            };
        }

        public int GetAtributo(string nome)
        {
            return atributos.ContainsKey(nome) ? atributos[nome] : 0;
        }

        public void SetAtributo(string nome, int valor)
        {
            if (atributos.ContainsKey(nome))
            {
                if (nome == "VIDA" && valor < 0)
                    atributos[nome] = 0; 
                else
                    atributos[nome] = valor;
            }
        }
    }

    public class Paladino : Personagem
    {
        public Paladino()
        {
            SetAtributo("FORCA", 18);
            SetAtributo("DESTREZA", 12);
            SetAtributo("CONSTITUICAO", 10);
            SetAtributo("INTELIGENCIA", 16);
            SetAtributo("SABEDORIA", 12);
            SetAtributo("CARISMA", 16);
            SetAtributo("VIDA", 21);
            SetAtributo("MANA", 6);
            SetAtributo("DEFESA", 17);
            classe = "Paladino";
        }
    }
    
    public class Guerreiro : Personagem
    {
        public Guerreiro()
        {
            SetAtributo("FORCA", 20);
            SetAtributo("DESTREZA", 8);
            SetAtributo("CONSTITUICAO", 3);
            SetAtributo("INTELIGENCIA", 16);
            SetAtributo("SABEDORIA", 12);
            SetAtributo("CARISMA", 16);
            SetAtributo("VIDA", 21);
            SetAtributo("MANA", 6);
            SetAtributo("DEFESA", 17);
        }
    }
}