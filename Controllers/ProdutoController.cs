using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using dotnetcore.mongo.Services;
using dotnetcore.mongo.Models;
using System;

namespace dotnetcore.mongo.Controllers
{
    [Route("vi/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produto;
        public ProdutoController(ProdutoService produto)
        {
            _produto = produto;
        }
             
       [HttpGet]
       public ActionResult<List<Produto>> Get()
       {
            return _produto.Get();
       }

       [HttpGet("{id}" , Name="GetProduto")]
       public ActionResult<Produto> Get(string id)
       {
           var produto = _produto.Get(id);

           if(produto == null)
           {
               return NotFound();
           }
           return produto;
       }

        [HttpPost]
        public ActionResult<Produto> Create([FromBody] Produto produto)
        {
            _produto.Create(produto);
            return CreatedAtRoute("GetProduto", new {id = produto.Id.ToString() } , produto);
        }

        
      
    }
}