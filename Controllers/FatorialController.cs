using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Teste_Dev_C__Beeviral.Controllers
{
    public class FatorialController : Controller
    {
        public IActionResult Fatorial()
        {
            return View();
        }
        
        public IActionResult CalculoResultadoFatorial(string sNumero)
        {

            int iNumero = 0; 
            
            try
            {
                iNumero = int.Parse(sNumero);

                if(iNumero <= 20) { 

                if (iNumero < 0)
                {
                    ViewBag.Mensagem = "O número deve ser não negativo.";
                }
                else
                {
                                       
                    // Lembre-se de lidar com o caso especial do fatorial de 0.
                    if(iNumero == 0)
                    {
                        ViewBag.Mensagem = "O resultado fatorial de 0! é 1 (Caso especial).";
                    }
                    // Calcule o fatorial aqui e exiba o resultado.
                    else
                    {
                        string mensagem = "";
                        BigInteger controle = 1;

                        for(int laco = 1; laco <= iNumero; laco++)
                        {
                            controle *= laco;
                        }

                        ViewBag.Mensagem = "O resultado fatorial de " + iNumero + "! é " + controle + ".";
                    }

                }
                } else
                {
                    ViewBag.Mensagem = "O limite para cálculo de fatorial é 20!.";
                }
            }
            catch(Exception ex)
            {

            }            

            return View();
        }
    }
}


