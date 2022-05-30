using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoNoticias : IServicoNoticia
    {

        private readonly INoticia _INoticia;

        public ServicoNoticias(INoticia iNoticia)
        {
            _INoticia = iNoticia;
        }

        public async Task AdicionaNoticia(Noticia noticia)
        {
            var validarTitulo = noticia.ValidarPropriedadeString(noticia.Titulo, "Titulo");
            var validarInformacoes = noticia.ValidarPropriedadeString(noticia.Informacao, "Informacao");

            if (validarTitulo && validarInformacoes)
            {
                noticia.DataAlteracao = DateTime.Now;
                noticia.DataCadastro = DateTime.Now;
                noticia.Ativo = true;
                await _INoticia.Adicionar(noticia);

            }
        }

        public async Task AtualizaNoticia(Noticia noticia)
        {
            var validarTitulo = noticia.ValidarPropriedadeString(noticia.Titulo, "Titulo");
            var validarInformacoes = noticia.ValidarPropriedadeString(noticia.Informacao, "Informacao");

            if (validarTitulo && validarInformacoes)
            {
                noticia.DataAlteracao = DateTime.Now;
                noticia.Ativo = true;
                await _INoticia.Atualizar(noticia);

            }
        }
        public async Task<List<Noticia>> ListarNoticias()
        {
            return await _INoticia.ListarNoticias(n => n.Ativo);
        }
    }
}