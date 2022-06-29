using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoB.Models;
using ProjetoB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoB.Models;

namespace ProjetoB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolhaController : ControllerBase
    {
        private FolhaService service = new FolhaService();
        
        [HttpGet("listar")]
        public List<Folha> Listar()
        {
            return this.service.Listar();
        }

        [HttpGet("total")]
        public double Total()
        {
            return this.service.Total();
        }

        [HttpGet("media")]
        public double Media()
        {
            return this.service.Media();
        }

        [HttpGet("cadastrar")]
        public void Cadastrar(Folha folha)
        {
            this.service.Cadastrar(folha);
        }
    }
}
