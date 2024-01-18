using Microsoft.AspNetCore.Mvc;
using Teste_Dev_C__Beeviral.Models;
using Newtonsoft.Json;

namespace Teste_Dev_C__Beeviral.Controllers
{
    public class PessoaController : Controller
    {
        public IActionResult Pessoa()
        {
            return View();
        }

        public IActionResult ListaPessoa()
        {            
            List<Pessoa> listaPessoas = new List<Pessoa>();
            try
            {
                listaPessoas = JsonConvert.DeserializeObject<List<Pessoa>>
                   (HttpContext.Session.GetString("listaPessoas"));
            }
            catch (Exception ex) { }

            HttpContext.Session.SetString("listaPessoas", JsonConvert.SerializeObject(listaPessoas));
            ViewBag.listaPessoas = listaPessoas;

            return View();
        }

        public IActionResult SalvarPessoa(string Nome, int Idade, string Email)
        {

            List<Pessoa> listaPessoas = new List<Pessoa>(); 
            try
            {
                listaPessoas = JsonConvert.DeserializeObject<List<Pessoa>>
                   (HttpContext.Session.GetString("listaPessoas"));
            }
            catch (Exception ex) { }

            Pessoa pessoa = new Pessoa(Nome, Idade, Email);

            listaPessoas.Add(pessoa);

            HttpContext.Session.SetString("listaPessoas", JsonConvert.SerializeObject(listaPessoas));

            ViewBag.listaPessoas = listaPessoas;

            return RedirectToAction("ListaPessoa", "Pessoa");
        }

        public IActionResult FiltroPessoa(int filtroSelect)
        {

            List<Pessoa> listaPessoas = new List<Pessoa>();
            try
            {
                listaPessoas = JsonConvert.DeserializeObject<List<Pessoa>>
                   (HttpContext.Session.GetString("listaPessoas"));
            }
            catch (Exception ex) { }

            if(filtroSelect != 0) { 

            List<Pessoa> listaPessoasFiltrada = listaPessoas
                .Where(p => p.Idade >= filtroSelect)
                .ToList();

            // Exibir informações das pessoas filtradas
            foreach (var pessoa in listaPessoasFiltrada)
            {
                
                    Console.WriteLine($"Nome: {pessoa.Nome}, Idade: {pessoa.Idade}, Email: {pessoa.Email}");
                
            }

                HttpContext.Session.SetString("listaPessoas", JsonConvert.SerializeObject(listaPessoas));
                HttpContext.Session.SetString("listaPessoasFiltrada", JsonConvert.SerializeObject(listaPessoasFiltrada));

                ViewBag.listaPessoas = listaPessoas;
                ViewBag.listaPessoasFiltrada = listaPessoasFiltrada;

                return View();

            } else
            {

                return RedirectToAction("ListaPessoa", "Pessoa");

            }

        }

    }
}
