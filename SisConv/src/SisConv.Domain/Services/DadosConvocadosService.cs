using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Linq.Expressions;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
	public class DadosConvocadosService : IDadosConvocadosService
	{

		private readonly IDadosConvocadosRepository _dadosConvocadosRepository;

		public DadosConvocadosService(IDadosConvocadosRepository dadosConvocadosRepository)
		{
			_dadosConvocadosRepository = dadosConvocadosRepository;
		}

		public Convocado Add(Convocado obj)
		{
			return _dadosConvocadosRepository.Add(obj);
		}

		public Convocado GetById(Guid id)
		{
			return _dadosConvocadosRepository.GetById(id);
		}

		public IEnumerable<Convocado> GetAll()
		{
			return _dadosConvocadosRepository.GetAll();
		}

		public Convocado Update(Convocado obj)
		{
			return _dadosConvocadosRepository.Update(obj);
		}

		public void Remove(Guid id)
		{
			_dadosConvocadosRepository.Remove(id);
		}

		public IEnumerable<Convocado> Search(Expression<Func<Convocado, bool>> predicate)
		{
			return _dadosConvocadosRepository.Search(predicate);
		}

		public void SalvarCandidatos(Convocado map)
		{
			throw new NotImplementedException();
		}

		public void SalvarCandidatos(Guid id, string file)
		{

			DataSet ds;
			var conexao = ConexaoComAPlanilhaExcel(file, out var command, out var adapter, out ds);

			try
			{
				ObtemDadosDaPlanilhaExcel(id, conexao, adapter, ds, command);
			}
			catch (Exception ex)
			{
				// return RedirectToAction("EmailCandidatosViaExcel", "EnvioEmails", new { @msg = ex.Message });
			}
			finally
			{
				conexao.Close();
			}
		}

		private void ObtemDadosDaPlanilhaExcel(Guid id, OleDbConnection conexao, OleDbDataAdapter adapter, DataSet ds,
		   OleDbCommand command)
		{
			conexao.Open();
			adapter.Fill(ds);
			using (var dr = command.ExecuteReader())
			{
				var listaCandidatos = ds.Tables[0].AsEnumerable()
					.Select(row => new Convocado
					{
						Inscricao = row.Field<string>(0) == null ? "-" : row.Field<string>(0).ToString(),
						Nome = row.Field<string>(1) == null ? "-" : row.Field<string>(1).ToString(),
						Mae = row.Field<string>(2) == null ? "-" : row.Field<string>(2).ToString(),
						Sexo = row.Field<string>(3).ToString(),
						Nascimento = row.Field<string>(4).ToString(),
						Documento = row.Field<string>(5) == null ? "-" : row.Field<string>(5).ToString(),
						Cpf = row.Field<string>(6) == null ? "-" : row.Field<string>(6).ToString(),
						Email = row.Field<string>(7) == null ? "-" : row.Field<string>(7).ToString(),
						Telefone = row.Field<string>(8) == null ? "00000000000" : row.Field<string>(8).ToString(),
						Celular = row.Field<string>(9) == null ? "-" : row.Field<string>(9).ToString(),
						Endereco = row.Field<string>(10) == null ? "-" : row.Field<string>(10).ToString(),
						Numero = row.Field<string>(11) == null ? "-" : row.Field<string>(11).ToString(),
						Complemento = row.Field<string>(12) == null ? "-" : row.Field<string>(12).ToString(),
						Bairro = row.Field<string>(13) == null ? "-" : row.Field<string>(13).ToString(),
						Cidade = row.Field<string>(14) == null ? "-" : row.Field<string>(14).ToString(),
						Uf = row.Field<string>(15) == null ? "-" : row.Field<string>(15).ToString(),
						Cep = row.Field<string>(16) == null ? "-" : row.Field<string>(16).ToString(),
						Cargo = row.Field<string>(17) == null ? "-" : row.Field<string>(17).ToString(),
						CargoId = Guid.NewGuid(),
						Pontuacao = row.Field<string>(18).ToString(),
						Posicao = row.Field<string>(19).ToString(),
						Resultado = row.Field<string>(20) == null ? "-" : row.Field<string>(20).ToString(),
						ConvocadoId = Guid.NewGuid(),
						ConvocacaoId = id
					}).ToList();
				InsereDadosExcelNoBanco(listaCandidatos);
			}
		}

		private void InsereDadosExcelNoBanco(List<Convocado> listaCandidatos)
		{
			foreach (var dados in listaCandidatos)
			{
				try
				{
					FormataCpf(dados);

					FormataCelular(dados);

					FormataTelefone(dados);


					Add(dados);

				}
				catch (Exception e)
				{

				}
			}
		}

		private static OleDbConnection ConexaoComAPlanilhaExcel(string file, out OleDbCommand command,
			out OleDbDataAdapter adapter, out DataSet ds)
		{
			var conexao = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file +
											  ";Extended Properties='Excel 12.0 Xml;HDR=YES';");
			command = new OleDbCommand("select * from [Dados-Classificados-Conc-6$]", conexao);
			adapter = new OleDbDataAdapter(command);
			ds = new DataSet();
			return conexao;
		}

		private static void FormataTelefone(Convocado dados)
		{
			dados.Telefone = dados.Telefone.Replace(")", "");
			dados.Telefone = dados.Telefone.Replace("(", "");
		}

		private static void FormataCelular(Convocado dados)
		{
			dados.Celular = dados.Celular.Replace(")", "");
			dados.Celular = dados.Celular.Replace("(", "");
		}

		private static void FormataCpf(Convocado dados)
		{
			if (dados.Cpf.Length < 11)
				dados.Cpf = dados.Cpf.PadLeft(11, '0');
		}


		public int SaveChanges()
		{
			return _dadosConvocadosRepository.SaveChanges();
		}

		public void Dispose()
		{
			_dadosConvocadosRepository.Dispose();
		}
	}
}