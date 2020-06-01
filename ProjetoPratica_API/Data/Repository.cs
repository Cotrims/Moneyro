using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPratica_API.Data;
using Microsoft.EntityFrameworkCore;
using ProjetoPratica_API.Models;
using System;

namespace ProjetoPratica_API.Data
{
    public class Repository : IRepository
    {
        public MoneyroContext Context { get; }
        public Repository(MoneyroContext context)
        {
            this.Context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            //throw new System.NotImplementedException();
            this.Context.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            //throw new System.NotImplementedException();
            this.Context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            // Como é tipo Task vai gerar thread, então vamos definir o método como assíncrono (async)
            // Por ser assíncrono, o return deve esperar (await) se tem alguma coisa para salvar no BD
            // Ainda verifica se fez alguma alteração no BD, se for maior que 0 retorna true ou false
            return (await this.Context.SaveChangesAsync() > 0);
        }
        public void Update<T>(T entity) where T : class
        {
            //throw new System.NotImplementedException();
            Console.WriteLine("foi no update");
            this.Context.Update(entity);
            Console.WriteLine("passou");
        }

        public async Task<Usuarios[]> GetAllUsuarios()
        {
            //throw new System.NotImplementedException();
            //Retornar para uma query qualquer do tipo Aluno
            IQueryable<Usuarios> consultaUsuarios = (IQueryable<Usuarios>)this.Context.Usuarios;
            //consultaUsuarios = consultaUsuarios.OrderBy(u => u.IdUsuario);
            return await consultaUsuarios.ToArrayAsync();
        }
        public async Task<Usuarios> GetUsuarioById(int Id)
        {

            //throw new System.NotImplementedException();
            //Retornar para uma query qualquer do tipo Aluno
            IQueryable<Usuarios> consultaUsuario = (IQueryable<Usuarios>)this.Context.Usuarios;
            consultaUsuario = consultaUsuario.OrderBy(u => u.Id).Where(usuario => usuario.Id == Id);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaUsuario.FirstOrDefaultAsync();
        }

        public async Task<Usuarios> GetUsuarioByApelido(string apelido)
        {
            IQueryable<Usuarios> consultaUsuario = (IQueryable<Usuarios>)this.Context.Usuarios;
            consultaUsuario = consultaUsuario.OrderBy(u => u.Id).Where(usuario => usuario.Apelido.Equals(apelido));
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaUsuario.FirstOrDefaultAsync();
        }

        public async Task<Usuarios> GetUsuarioByEmail(string email)
        {
            IQueryable<Usuarios> consultaUsuario = (IQueryable<Usuarios>)this.Context.Usuarios;
            consultaUsuario = consultaUsuario.OrderBy(u => u.Id).Where(usuario => usuario.Email == email);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaUsuario.FirstOrDefaultAsync();
        }

        public async Task<Receitas[]> GetAllReceitas()
        {
            IQueryable<Receitas> consultaReceitas = (IQueryable<Receitas>)this.Context.Receitas;
            return await consultaReceitas.ToArrayAsync();

        }
        public async Task<Receitas> GetReceitaById(int Id)
        {
            IQueryable<Receitas> consultaReceita = (IQueryable<Receitas>)this.Context.Receitas;
            consultaReceita = consultaReceita.OrderBy(r => r.Id).Where(receita => receita.Id == Id);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaReceita.FirstOrDefaultAsync();
        }
        public async Task<Receitas[]> GetReceitasByUsuario(int IdUsuario)
        {
            IQueryable<Receitas> consultaReceita = (IQueryable<Receitas>)this.Context.Receitas;
            consultaReceita = consultaReceita.OrderBy(receita => receita.Id).Where(receita => receita.IdUsuario == IdUsuario);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaReceita.ToArrayAsync();
        }

        public async Task<Despesas[]> GetAllDespesas()
        {
            IQueryable<Despesas> consultaDespesas = (IQueryable<Despesas>)this.Context.Despesas;
            return await consultaDespesas.ToArrayAsync();
        }
        public async Task<Despesas> GetDespesaById(int Id)
        {
            IQueryable<Despesas> consultaDespesa = (IQueryable<Despesas>)this.Context.Despesas;
            consultaDespesa = consultaDespesa.OrderBy(d => d.Id).Where(despesa => despesa.Id == Id);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaDespesa.FirstOrDefaultAsync();
        }
        public async Task<Despesas[]> GetDespesasByUsuario(int IdUsuario)
        {
            IQueryable<Despesas> consultaDespesa = (IQueryable<Despesas>)this.Context.Despesas;
            consultaDespesa = consultaDespesa.OrderBy(d => d.IdUsuario).Where(despesa => despesa.IdUsuario == IdUsuario);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaDespesa.ToArrayAsync();
        }

        public async Task<Metas[]> GetAllMetas()
        {
            IQueryable<Metas> consultaMetas = (IQueryable<Metas>)this.Context.Metas;
            return await consultaMetas.ToArrayAsync();
        }
        public async Task<Metas> GetMetaById(int Id)
        {
            IQueryable<Metas> consultaMeta = (IQueryable<Metas>)this.Context.Metas;
            consultaMeta = consultaMeta.OrderBy(m => m.Id).Where(meta => meta.Id == Id);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaMeta.FirstOrDefaultAsync();
        }
        public async Task<Metas[]> GetMetasByUsuario(int IdUsuario)
        {
            IQueryable<Metas> consultaMeta = (IQueryable<Metas>)this.Context.Metas;
            consultaMeta = consultaMeta.OrderBy(m => m.Id).Where(meta => meta.IdUsuario == IdUsuario);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaMeta.ToArrayAsync();
        }

        public async Task<Assuntos[]> GetAllAssuntos()
        {
            IQueryable<Assuntos> consultaAssuntos = (IQueryable<Assuntos>)this.Context.Assuntos;
            return await consultaAssuntos.ToArrayAsync();
        }
        public async Task<Assuntos> GetAssuntoById(int Id)
        {
            IQueryable<Assuntos> consultaAssunto = (IQueryable<Assuntos>)this.Context.Assuntos;
            consultaAssunto = consultaAssunto.OrderBy(a => a.Id).Where(assunto => assunto.Id == Id);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaAssunto.FirstOrDefaultAsync();
        }

        public async Task<Tips[]> GetAllTips()
        {
            IQueryable<Tips> consultaTips = (IQueryable<Tips>)this.Context.Tips;
            return await consultaTips.ToArrayAsync();
        }

        // public async Task<Tips[]> GetTipsByAssunto(string Assunto)
        // {
        //     IQueryable<Assuntos> consultaAssunto = (IQueryable<Assuntos>)this.Context.Assuntos;
        //     consultaAssunto = consultaAssunto.Where(assunto => assunto.Nome == Assunto);
        //     Assuntos assunto = (Assuntos)consultaAssunto.FirstOrDefaultAsync();

        //     IQueryable<Tips> consultaTips = (IQueryable<Tips>)this.Context.Receitas;
        //     consultaTips = consultaTips.OrderBy(t => t.Id)
        //                                .Where(tip => tip.IdAssunto == consultaAssunto.FirstOrDefaultAsync().Id);

        //     // aqui efetivamente ocorre o SELECT no BD
        //     return await consultaTips.FirstOrDefaultAsync();
        // }

        public async Task<Tips> GetTipById(int Id)
        {
            IQueryable<Tips> consultaTips = (IQueryable<Tips>)this.Context.Tips;
            consultaTips = consultaTips.OrderBy(t => t.Id).Where(tip => tip.Id == Id);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaTips.FirstOrDefaultAsync();
        }

        public async Task<Videos[]> GetAllVideos()
        {
            IQueryable<Videos> consultaVideos = (IQueryable<Videos>)this.Context.Videos;
            return await consultaVideos.ToArrayAsync();
        }

        public async Task<Videos> GetVideoById(int Id)
        {
            IQueryable<Videos> consultaVideo = (IQueryable<Videos>)this.Context.Videos;
            consultaVideo = consultaVideo.OrderBy(v => v.Id).Where(video => video.Id == Id);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaVideo.FirstOrDefaultAsync();
        }

        public async Task<Amigos> GetAmigoById(int Id)
        {
            IQueryable<Amigos> consultaAmigo = (IQueryable<Amigos>)this.Context.Amigos;
            consultaAmigo = consultaAmigo.OrderBy(a => a.Id).Where(amigo => amigo.Id == Id);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaAmigo.FirstOrDefaultAsync();
        }
        public async Task<Amigos[]> GetAmigosByUsuario(int IdUsuario)
        {
            IQueryable<Amigos> consultaAmigos = (IQueryable<Amigos>)this.Context.Amigos;
            consultaAmigos = consultaAmigos.OrderBy(a => a.Id).Where(amigos => amigos.Id == IdUsuario);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaAmigos.ToArrayAsync();
        }
        public async Task<Amigos[]> GetAllAmigos()
        {
            IQueryable<Amigos> consultaAmigos = (IQueryable<Amigos>)this.Context.Amigos;
            return await consultaAmigos.ToArrayAsync();
        }

        public async Task<Artigos[]> GetAllArtigos()
        {
            IQueryable<Artigos> consultaArtigos = (IQueryable<Artigos>)this.Context.Artigos;
            return await consultaArtigos.ToArrayAsync();
        }

        // public async Task<Artigos[]> GetArtigosByAssunto(string Assunto)
        // {

        // }

        public async Task<Artigos> GetArtigoById(int Id)
        {
            IQueryable<Artigos> consultaArtigo = (IQueryable<Artigos>)this.Context.Artigos;
            consultaArtigo = consultaArtigo.OrderBy(a => a.Id).Where(artigo => artigo.Id == Id);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaArtigo.FirstOrDefaultAsync();
        }

        public async Task<Compartilhamentos[]> GetCompartilhamentosByCodigo(int Codigo)
        {
            IQueryable<Compartilhamentos> consultaCompartilhamento = (IQueryable<Compartilhamentos>)this.Context.Compartilhamentos;
            consultaCompartilhamento = consultaCompartilhamento.OrderBy(c => c.Id).Where(compartilhamento => compartilhamento.Codigo == Codigo);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaCompartilhamento.ToArrayAsync();
        }
        public async Task<Compartilhamentos> GetCompartilhamentoById(int Id)
        {
            IQueryable<Compartilhamentos> consultaCompartilhamento = (IQueryable<Compartilhamentos>)this.Context.Compartilhamentos;
            consultaCompartilhamento = consultaCompartilhamento.OrderBy(c => c.Id).Where(compartilhamento => compartilhamento.Id == Id);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaCompartilhamento.FirstOrDefaultAsync();
        }

        public async Task<Avaliacoes[]> GetAllAvaliacoes()
        {
            IQueryable<Avaliacoes> consultaAvaliacao = (IQueryable<Avaliacoes>)this.Context.Avaliacoes;
            return await consultaAvaliacao.ToArrayAsync();
        }

        public async Task<Avaliacoes> GetAvaliacaoById(int Id)
        {
            IQueryable<Avaliacoes> consultaAvaliacao = (IQueryable<Avaliacoes>)this.Context.Avaliacoes;
            consultaAvaliacao = consultaAvaliacao.OrderBy(a => a.Id).Where(avaliacao => avaliacao.Id == Id);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaAvaliacao.FirstOrDefaultAsync();
        }

        public async Task<Tags[]> GetAllTags()
        {
            IQueryable<Tags> consultaTag = (IQueryable<Tags>)this.Context.Tags;
            return await consultaTag.ToArrayAsync();
        }

        public async Task<Tags> GetTagById(int Id)
        {
            IQueryable<Tags> consultaTag = (IQueryable<Tags>)this.Context.Tags;
            consultaTag = consultaTag.OrderBy(t => t.Id).Where(tag => tag.Id == Id);

            return await consultaTag.FirstOrDefaultAsync();
        }
    }
}