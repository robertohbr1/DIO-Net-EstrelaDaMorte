using ControleAcesso.Extensions;
using ControleAcesso.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAcesso.Dao
{
    public class PlanetaDao : DaoBase
    {
        public async Task InserirPlanetas(List<Planeta> planetas)
        {
            if (!planetas.Any())
                return;

            var check = "if (not exists(select 1 from Planetas where IdPlaneta = {0}))\n";
            var insert = "insert Planetas (IdPlaneta, Nome, Rotacao, Orbita, Diametro, Clima, Populacao) values({0}, '{1}', {2}, {3}, {4}, '{5}', {6});\n";
            var comandos = planetas.Select(planeta => string.Format(check, planeta.IdPlaneta) + string.Format(insert, planeta.IdPlaneta, planeta.Nome, planeta.Rotacao, planeta.Orbita, planeta.Diametro, planeta.Clima, planeta.Populacao));

            await Insert(string.Join('\n', comandos));
        }
        public async Task<Planeta> ObterPorId(int idPlaneta)
        {
            Planeta planeta = null;
            var comando = @$"
                                select	t1.*
                                from	Planetas t1
                                where	t1.IdPlaneta = {idPlaneta}";

            await Select(comando, resultadoSQL =>
            {
                while (resultadoSQL.Read())
                {
                    planeta = new Planeta
                    {
                        IdPlaneta = resultadoSQL.GetValueOrDefault<int>("IdPlaneta"),
                        Nome = resultadoSQL.GetValueOrDefault<string>("Nome")
                    };
                }
            });

            return planeta;
        }

        public async Task<List<Planeta>> ObterPorNomeLike(string nome)
        {
            var planetas = new List<Planeta>();
            var comando = $"select * from Planetas where nome like '%{nome.Replace(' ', '%')}%'";

            await Select(comando, resultadoSQL =>
            {
                while (resultadoSQL.Read())
                {
                    planetas.Add(new Planeta
                    {
                        IdPlaneta = resultadoSQL.GetValueOrDefault<int>("IdPlaneta"),
                        Nome = resultadoSQL.GetValueOrDefault<string>("Nome")
                    });
                }
            });

            return planetas;
        }

    }
}
