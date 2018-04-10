using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
	public class DadosConvocadosService : IDadosConvocadosService
	{
		private readonly IDadosConvocadosRepository _dadosConvocadosRepository;
		private readonly ICargoRepository _cargoRepository;


		public DadosConvocadosService(IDadosConvocadosRepository dadosConvocadosRepository, ICargoRepository cargoRepository)
		{
			_dadosConvocadosRepository = dadosConvocadosRepository;
			_cargoRepository = cargoRepository;
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

		public void SalvarCandidatos(Guid id, string file)
		{
			DataSet ds;
			var conexao = ConexaoComAPlanilhaExcel(file, out var command, out var adapter, out ds);

			try
			{
				ObtemDadosDaPlanilhaExcel(id, conexao, adapter, ds, command);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			finally
			{
				conexao.Close();
			}
		}

		public void SalvarCargos(Guid id, string file)
		{
			var conexao = ConexaoComAPlanilhaExcel(file, out var command, out var adapter, out var ds);

			try
			{
				ObterListaCargos(id, conexao, adapter, ds, command);
			}
			catch (Exception)
			{
				// return RedirectToAction("EmailCandidatosViaExcel", "EnvioEmails", new { @msg = ex.Message });
			}
			finally
			{
				conexao.Close();
			}
		}

		private void ObterListaCargos(Guid id, OleDbConnection conexao, OleDbDataAdapter adapter, DataSet ds,
			OleDbCommand command)
		{
			conexao.Open();
			adapter.Fill(ds);
			using (command.ExecuteReader())
			{
				var listaCargos = ObterTodosOsCargosDoExcel(ds, out var listaCargo);
				PreencheAListaDeCargosParaSalvarNoBanco(id, listaCargos, listaCargo);

				SalvarCargos(listaCargo);
			}
		}

		private void SalvarCargos(IEnumerable<Cargo> listaCargo)
		{
			foreach (var itens in listaCargo)
				_cargoRepository.Add(itens);
		}

		private void PreencheAListaDeCargosParaSalvarNoBanco(Guid id, List<Cargo> listaCargos, List<Cargo> listaCargo)
		{
			foreach (var itens in listaCargos)
			{
				var itemcargo = itens.Nome.Split('-');
				var codigo = itemcargo[0].Trim();
				var nome = itemcargo[1].Trim();

				var dadosCargo = _cargoRepository.Search(a => a.ProcessoId.Equals(id) && a.CodigoCargo.Equals(codigo) && a.Nome.Equals(nome));

				if (!dadosCargo.Any())
				{
					if (!listaCargo.Any(a => a.CodigoCargo.Equals(codigo)))
						listaCargo.Add(new Cargo
						{
							Ativo = true,
							CargoId = Guid.NewGuid(),
							CodigoCargo = codigo,
							ProcessoId = id,
							Nome = nome
						});
				}
			}
		}

		private static List<Cargo> ObterTodosOsCargosDoExcel(DataSet ds, out List<Cargo> listaCargo)
		{
			var listaCargos = ds.Tables[0].AsEnumerable()
				.Select(row => new Cargo
				{
					Nome = row.Field<string>(17) == null ? "-" : row.Field<string>(17).ToString()
				}).ToList();
			listaCargo = new List<Cargo>();
			return listaCargos;
		}

		private void ObtemDadosDaPlanilhaExcel(Guid id, IDbConnection conexao, IDataAdapter adapter, DataSet ds,
			OleDbCommand command)
		{
			conexao.Open();
			adapter.Fill(ds);
			using (command.ExecuteReader())
			{
				try
				{
					var listaCandidatos = ds.Tables[0].AsEnumerable()
				.Select(row => new Convocado
				{
					Inscricao = row.Field<string>(0) == null ? "" : row.Field<string>(0).ToString(),
					Nome = row.Field<string>(1) == null ? "" : row.Field<string>(1).ToString(),
					Mae = row.Field<string>(2) == null ? "" : row.Field<string>(2).ToString(),
					Sexo = row.Field<string>(3).ToString(),
					DataNascimento = row.Field<DateTime>(4).ToString("dd/MM/yyyy"),				
					
					Documento =ApenasDigitos( row.Field<string>(5) == null ? "" : row.Field<string>(5).ToString()),
					Cpf = row.Field<string>(6) == null ? "" : row.Field<string>(6).ToString(),
					Email = row.Field<string>(7) == null ? "" : row.Field<string>(7).ToString(),
					Telefone = row.Field<string>(8) == null ? "00000000000" : row.Field<string>(8).ToString(),
					Celular = row.Field<string>(9) == null ? "" : row.Field<string>(9).ToString(),
					Endereco = row.Field<string>(10) == null ? "" : row.Field<string>(10).ToString(),
					Numero = row.Field<string>(11) == null ? "" : row.Field<string>(11).ToString(),
					Complemento = row.Field<string>(12) == null ? "" : row.Field<string>(12).ToString(),
					Bairro = row.Field<string>(13) == null ? "" : row.Field<string>(13).ToString(),
					Cidade = row.Field<string>(14) == null ? "" : row.Field<string>(14).ToString(),
					Estado = row.Field<string>(15) == null ? "" : row.Field<string>(15).ToString(),
					Cep = row.Field<string>(16) == null ? "" : row.Field<string>(16).ToString(),
					Cargo = row.Field<string>(17) == null ? "" : row.Field<string>(17).ToString(),
					CargoId = Guid.NewGuid(),
					Pontuacao = Convert.ToInt32(row.Field<string>(18)),
					Posicao = Convert.ToInt32(row.Field<string>(19)),
					Resultado = row.Field<string>(20) == null ? "" : row.Field<string>(20).ToString(),
					ConvocadoId = Guid.NewGuid(),
					ProcessoId = id,
					Naturalidade = String.Empty,
					Pai = String.Empty,
					EstadoCivil = "1"
				}).ToList();

					InsereDadosExcelNoBanco(listaCandidatos);
				}
				catch(Exception e)
				{
					Console.WriteLine(e);
				}
			}
		}

		public string ApenasDigitos(string dados)
		{
			var apenasDigitos = new Regex(@"[^\d]");
			return apenasDigitos.Replace(dados, "");
		}



		private void InsereDadosExcelNoBanco(List<Convocado> listaCandidatos)
		{
			foreach (var dados in listaCandidatos)
			{
				FormataCpf(dados);

				FormataCelular(dados);

				FormataTelefone(dados);

				var itemCargo = dados.Cargo.Split('-');

				string Codigo = itemCargo[0].ToString().Trim();

				var dadosCargo = _cargoRepository.Search(a =>
					a.ProcessoId.Equals(dados.ProcessoId) && a.CodigoCargo.Equals(Codigo));

				foreach (var cargo in dadosCargo)
				{
					dados.CargoId = cargo.CargoId;
					break;
				}

				try
				{
					var dadosConvocado = _dadosConvocadosRepository.Search(a => a.Nome.Equals(dados.Nome) && a.Inscricao.Equals(dados.Inscricao) && a.Cpf.Equals(dados.Cpf));

					if(!dadosConvocado.Any())
					Add(dados);
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
					throw;
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