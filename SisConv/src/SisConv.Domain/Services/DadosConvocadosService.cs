using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Linq.Expressions;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;
using DadosConvocados = SisConv.Domain.Entities.DadosConvocados;

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

            string arquivo = file;
            // Microsoft.ACE.OLEDB.12.0 - Funciona apenas para ambientes de 64bits
            string strConexao = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=0\"", arquivo);
            OleDbConnection conn = new OleDbConnection(strConexao);
            conn.Open();

            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            //Cria o objeto dataset para receber o conteúdo do arquivo Excel
            DataSet output = new DataSet();
            foreach (DataRow row in dt.Rows)
            {
                // obtem o noma da planilha corrente
                string sheet = row["TABLE_NAME"].ToString();
                // obtem todos as linhas da planilha corrente
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                cmd.CommandType = CommandType.Text;
                // copia os dados da planilha para o datatable
                DataTable outputTable = new DataTable(sheet);
                outputTable.Rows.OfType<DataRow>()
                    .Select(dr => dr.Field<MyType>(columnName)).ToList();


                List<Convocado> lista = new List<Convocado>();

                lista.Add(outputTable);
                new OleDbDataAdapter(cmd).Fill(outputTable);
                foreach (var dados in outputTable as IEnumerable<Convocado>)
                {
                    _dadosConvocadosRepository.Add(dados);
                }
            }
            
            // Neste momento, o conteúdo de todas as planilhas presentes no arquivo Excel foi copiado para os DataTables consolidados no Dataset "output".


            //var conexao = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0 Xml;HDR=YES';");
            //var command = new OleDbCommand("select * from [Planilha1$]", conexao);
            //var adapter = new OleDbDataAdapter(command);
            //var ds = new DataSet();





            //try
            //{
            //    conexao.Open();
            //    adapter.Fill(ds);
            //    using (var dr = command.ExecuteReader())
            //    {
            //        var listaCandidatos = ds.Tables[0].AsEnumerable()
            //            .Select(row => new Convocado
            //            {
            //                Inscricao = row.Field<int>(0) == null ? "-" : row.Field<int>(0).ToString(),
            //                Nome = row.Field<string>(1) == null ? "-" : row.Field<string>(1).ToString(),
            //                Mae = row.Field<string>(2) == null ? "-" : row.Field<string>(2).ToString(),
            //                Sexo = row.Field<bool>(3),
            //                Nascimento = row.Field<DateTime>(4),
            //                Documento = row.Field<string>(5) == null ? "-" : row.Field<string>(5).ToString(),
            //                Cpf = row.Field<string>(6) == null ? "-" : row.Field<string>(6).ToString(),
            //                Email = row.Field<string>(7) == null ? "-" : row.Field<string>(7).ToString(),
            //                Telefone = row.Field<string>(8) == null ? "-" : row.Field<string>(8).ToString(),
            //                Celular = row.Field<string>(9) == null ? "-" : row.Field<string>(9).ToString(),
            //                Endereco = row.Field<string>(10) == null ? "-" : row.Field<string>(10).ToString(),
            //                Numero = row.Field<string>(11) == null ? "-" : row.Field<string>(11).ToString(),
            //                Complemento = row.Field<string>(12) == null ? "-" : row.Field<string>(12).ToString(),
            //                Bairro = row.Field<string>(13) == null ? "-" : row.Field<string>(13).ToString(),
            //                Cidade = row.Field<string>(14) == null ? "-" : row.Field<string>(14).ToString(),
            //                Uf = row.Field<string>(15) == null ? "-" : row.Field<string>(15).ToString(),
            //                Cep = row.Field<string>(16) == null ? "-" : row.Field<string>(16).ToString(),
            //                Cargo = row.Field<string>(17) == null ? "-" : row.Field<string>(17).ToString(),
            //                CargoId = new Guid(),
            //                Pontuacao =  row.Field<int>(18),
            //                Posicao = row.Field<int>(19),
            //                Resultado = row.Field<string>(20) == null ? "-" : row.Field<string>(20).ToString(),
            //                ConvocadoId = new Guid(),
            //                ConvocacaoId =id
            //            }).ToList();
            //        foreach (var dados in listaCandidatos)
            //        {
            //            _dadosConvocadosRepository.Add(dados);
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    // return RedirectToAction("EmailCandidatosViaExcel", "EnvioEmails", new { @msg = ex.Message });
            //}
            //finally
            //{
            //    conexao.Close();
            //}
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