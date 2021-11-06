using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{
    /*!
     * Valida data no padrão brasil
     * "dd/MM/yyyy"
     */
    public static class ValidaDataBrasil
    {
        //
        public static bool Valida(string data)
        {
            bool valido = true;
            int dia = 0;
            int mes = 0;
            int ano = 0;
            string[] p = data.Split('/');
            if (p.Length == 3)
            {
                try
                {
                    dia = int.Parse(p[0]);
                    mes = int.Parse(p[1]);
                    ano = int.Parse(p[2]);
                }
                catch(Exception ex)
                {
                    valido = false;
                    Mensagem = ex.Message;
                    return valido;
                }
                if (ano >= 1900 && ano <= 2999)
                {
                    if (mes >= 1 && mes <= 12)
                    {
                        switch (mes)
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 7:
                            case 8:
                            case 10:
                            case 12:
                                {
                                    if (!(dia >= 1 && dia <= 31))
                                    {
                                        valido = false;
                                        Mensagem = "dia não suportado pelo mês";
                                    }
                                }; break;
                            case 4:
                            case 6:
                            case 9:
                            case 11:
                                {
                                    if (!(dia >= 1 && dia <= 30))
                                    {
                                        valido = false;
                                        Mensagem = "dia não suportado pelo mês";
                                    }
                                }; break;
                            case 2:
                                {
                                    if ((ano % 4) == 0)
                                    {
                                        if (!(dia >= 1 && dia <= 29))
                                        {
                                            valido = false;
                                            Mensagem = "dia não suportado pelo mês";
                                        }
                                    }
                                    else
                                    {
                                        if (!(dia >= 1 && dia <= 28))
                                        {
                                            valido = false;
                                            Mensagem = "dia não suportado pelo mês";
                                        }
                                    }
                                }; break;
                        }
                    }
                    else
                    {
                        valido = false;
                        Mensagem = "mês invalido";
                    }
                }
                else
                {
                    valido = false;
                    Mensagem = "ano invalido";
                }
            }
            else
            {
                valido = false;
                Mensagem = "numero incorreto de parametros";
            }
            return valido;
        }
        //
        public static string Mensagem { get; private set; }
    }
}
