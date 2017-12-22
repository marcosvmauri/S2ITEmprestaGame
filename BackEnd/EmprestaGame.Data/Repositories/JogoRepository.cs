using EmprestaGame.Data.Repositories.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EmprestaGame.Data.Repositories
{
    public class JogoRepository : RepositoryBase<Jogo>, IJogoRepository
    {
        protected DbContext Db;

        public JogoRepository(DbContext db) : base(db)
        {
            this.Db = db;

        }

        public IEnumerable<Entities.Jogo> MeusJogos(int IdUsuario)
        {
            var retorno = Db.Set<Jogo>().AsNoTracking().Where(x => x.idUsuario == IdUsuario);

            return retorno;
        }

        public IEnumerable<Entities.Jogo> JogosDisponiveis(int IdUsuario)
        {
            var emprestimos = Db.Set<Emprestimo>().AsNoTracking();

            var querie = (from j in Db.Set<Jogo>().AsNoTracking()
                          join u in Db.Set<Usuario>().AsNoTracking()
                          on j.idUsuario equals u.Id
                          where !emprestimos.Select(e => e.idJogo).Contains(j.Id) || emprestimos.Where(e => e.idJogo == j.Id).All(e => e.Status == 0)
                          select new
                          {
                              jogo = j,
                              usuario = u
                          }).ToList();

            foreach (var item in querie)
            {
                yield return new Jogo()
                {
                    Console = item.jogo.Console,
                    Id = item.jogo.Id,
                    idUsuario = item.jogo.idUsuario,
                    Nome = item.jogo.Nome,
                    Status = item.jogo.Status,
                    Usuario = item.usuario
                };
            }

        }

        
        public IEnumerable<Entities.Jogo> JogosAdevolver(int IdUsuario)
        {

            var querie = (from e in Db.Set<Emprestimo>().AsNoTracking()
                          join j in Db.Set<Jogo>().AsNoTracking()
                          on e.idJogo equals j.Id
                          join u in Db.Set<Usuario>().AsNoTracking()
                          on j.idUsuario equals u.Id
                          where e.idUsuario == IdUsuario && e.Status == 1 && j.idUsuario != IdUsuario
                          select new
                          {
                              emprestimo = e,
                              jogo = j,
                              usuario = u
                          }).ToList();

            foreach (var item in querie)
            {
                yield return new Jogo()
                {
                    Console = item.jogo.Console,
                    Id = item.jogo.Id,
                    idUsuario = item.jogo.idUsuario,
                    Nome = item.jogo.Nome,
                    Status = item.jogo.Status,
                    Usuario = item.usuario
                };
            }
        }
        

        public IEnumerable<Entities.Jogo> JogosEmprestados(int IdUsuario)
        {
            var querie = (from e in Db.Set<Emprestimo>().AsNoTracking()
                          join j in Db.Set<Jogo>().AsNoTracking()
                          on e.idJogo equals j.Id
                          join u in Db.Set<Usuario>().AsNoTracking()
                          on j.idUsuario equals u.Id
                          where e.idUsuario != IdUsuario && e.Status == 1 && j.idUsuario == IdUsuario
                          select new
                          {
                              emprestimo = e,
                              jogo = j,
                              usuario = u
                          }).ToList();

            foreach (var item in querie)
            {
                yield return new Jogo()
                {
                    Console = item.jogo.Console,
                    Id = item.jogo.Id,
                    idUsuario = item.jogo.idUsuario,
                    Nome = item.jogo.Nome,
                    Status = item.jogo.Status,
                    Usuario = item.usuario
                };
            }

        }


    }
}