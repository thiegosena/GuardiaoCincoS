using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace GuardiaoCincoS.Dados
{
    public static class ConexaoBanco
    {
        // Pasta de dados do usuário do Windows atual — sempre gravável, sem precisar de admin,
        // e funciona não importa de onde o .exe seja executado (rede, pendrive, Google Drive, etc.)
        private static readonly string _caminhoArquivoBanco = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "GuardiaoCincoS", "GuardiaoCincoS.db");

        // "Foreign Keys=True" liga a checagem de chave estrangeira automaticamente
        // em toda conexão aberta (necessário para o ON DELETE CASCADE funcionar).
        private static readonly string _connectionString = $"Data Source={_caminhoArquivoBanco};Foreign Keys=True";

        public static SqliteConnection ObterConexao()
        {
            return new SqliteConnection(_connectionString);
        }

        public static bool TestarConexao(out string mensagemErro)
        {
            mensagemErro = string.Empty;
            try
            {
                using (var conexao = ObterConexao())
                {
                    conexao.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensagemErro = ex.Message;
                return false;
            }
        }

        // Cria o arquivo do banco e todas as tabelas (se ainda não existirem) e garante
        // que exista um usuário Administrador para o primeiro login. Chamado uma única
        // vez, bem no início do Program.cs, antes de qualquer tela abrir.
        public static void GarantirBancoCriado()
        {
            string pasta = Path.GetDirectoryName(_caminhoArquivoBanco)!;
            Directory.CreateDirectory(pasta);

            using (var conexao = ObterConexao())
            {
                conexao.Open();

                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText = ScriptCriacaoTabelas;
                    comando.ExecuteNonQuery();
                }

                SemearPerfisEAdminSeNecessario(conexao);
            }
        }

        private static void SemearPerfisEAdminSeNecessario(SqliteConnection conexao)
        {
            using (var comandoContagem = conexao.CreateCommand())
            {
                comandoContagem.CommandText = "SELECT COUNT(*) FROM Perfis";
                long totalPerfis = (long)comandoContagem.ExecuteScalar()!;

                if (totalPerfis == 0)
                {
                    using (var comando = conexao.CreateCommand())
                    {
                        comando.CommandText = @"
                            INSERT INTO Perfis (NomePerfil, Descricao) VALUES
                            ('Administrador', 'Acesso total, inclusive exclusao definitiva'),
                            ('Guardiao5S', 'Cadastra e edita, nao exclui definitivamente'),
                            ('Colaborador', 'Apenas visualizacao');";
                        comando.ExecuteNonQuery();
                    }
                }
            }

            using (var comandoContagem = conexao.CreateCommand())
            {
                comandoContagem.CommandText = "SELECT COUNT(*) FROM Usuarios";
                long totalUsuarios = (long)comandoContagem.ExecuteScalar()!;

                if (totalUsuarios == 0)
                {
                    string salt = Servicos.SegurancaSenha.GerarSalt();
                    byte[] hash = Servicos.SegurancaSenha.CalcularHash("Admin@123", salt);

                    using (var comando = conexao.CreateCommand())
                    {
                        comando.CommandText = @"
                            INSERT INTO Usuarios (NomeCompleto, NomeUsuario, SenhaHash, Salt, IdPerfil, Ativo)
                            VALUES ('Administrador do Sistema', 'admin', @hash, @salt,
                                    (SELECT Id FROM Perfis WHERE NomePerfil = 'Administrador'), 1);";
                        comando.Parameters.AddWithValue("@hash", hash);
                        comando.Parameters.AddWithValue("@salt", salt);
                        comando.ExecuteNonQuery();
                    }
                }
            }
        }

        private const string ScriptCriacaoTabelas = @"
            CREATE TABLE IF NOT EXISTS Perfis (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                NomePerfil TEXT NOT NULL,
                Descricao TEXT
            );

            CREATE TABLE IF NOT EXISTS Usuarios (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                NomeCompleto TEXT NOT NULL,
                NomeUsuario TEXT NOT NULL UNIQUE,
                SenhaHash BLOB NOT NULL,
                Salt TEXT NOT NULL,
                IdPerfil INTEGER NOT NULL REFERENCES Perfis(Id),
                Ativo INTEGER NOT NULL DEFAULT 1,
                DataCriacao TEXT NOT NULL DEFAULT (datetime('now','localtime')),
                Email TEXT,
                Telefone TEXT
            );

            CREATE TABLE IF NOT EXISTS Colaboradores (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                Setor TEXT,
                Turno TEXT,
                Ativo INTEGER NOT NULL DEFAULT 1
            );

            CREATE TABLE IF NOT EXISTS LogAtividades (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                IdUsuario INTEGER NOT NULL REFERENCES Usuarios(Id),
                Acao TEXT NOT NULL,
                DataHora TEXT NOT NULL DEFAULT (datetime('now','localtime'))
            );

            CREATE TABLE IF NOT EXISTS Escala5SSemanal (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                IdColaborador INTEGER NOT NULL REFERENCES Colaboradores(Id),
                DataInicioSemana TEXT NOT NULL,
                DataFimSemana TEXT NOT NULL,
                Ativo INTEGER NOT NULL DEFAULT 1
            );

            CREATE TABLE IF NOT EXISTS Rondas (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Data TEXT NOT NULL,
                Tipo TEXT NOT NULL,
                IdColaboradorResponsavel INTEGER NOT NULL REFERENCES Colaboradores(Id),
                Status TEXT NOT NULL DEFAULT 'Pendente',
                Observacoes TEXT,
                DataHoraConclusao TEXT,
                IdUsuarioRegistro INTEGER NOT NULL REFERENCES Usuarios(Id),
                DataHoraRegistro TEXT NOT NULL DEFAULT (datetime('now','localtime'))
            );

            CREATE TABLE IF NOT EXISTS Auditorias (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Data TEXT NOT NULL,
                Setor TEXT NOT NULL,
                IdColaboradorAuditor INTEGER NOT NULL REFERENCES Colaboradores(Id),
                IdColaboradorAcompanhante INTEGER REFERENCES Colaboradores(Id),
                PontuacaoTotal REAL NOT NULL,
                ObservacoesGerais TEXT,
                IdUsuarioRegistro INTEGER NOT NULL REFERENCES Usuarios(Id),
                DataHoraRegistro TEXT NOT NULL DEFAULT (datetime('now','localtime'))
            );

            CREATE TABLE IF NOT EXISTS ItensAuditoria (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                IdAuditoria INTEGER NOT NULL REFERENCES Auditorias(Id) ON DELETE CASCADE,
                Senso TEXT NOT NULL,
                Nota INTEGER NOT NULL,
                Observacao TEXT
            );

            CREATE TABLE IF NOT EXISTS PlacasProvisoriasAuditoria (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                IdAuditoria INTEGER NOT NULL REFERENCES Auditorias(Id) ON DELETE CASCADE,
                LocalPlaca TEXT NOT NULL,
                DataVencimento TEXT NOT NULL,
                Status TEXT NOT NULL DEFAULT 'Pendente'
            );

            CREATE TABLE IF NOT EXISTS ItensCorrecaoAuditoria (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                IdAuditoria INTEGER NOT NULL REFERENCES Auditorias(Id) ON DELETE CASCADE,
                Descricao TEXT NOT NULL,
                DataLimite TEXT NOT NULL,
                Status TEXT NOT NULL DEFAULT 'Pendente'
            );

            CREATE TABLE IF NOT EXISTS Demarcacoes (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Local TEXT NOT NULL,
                Descricao TEXT,
                DataIdentificacao TEXT NOT NULL,
                DataPrevista TEXT NOT NULL,
                IdColaboradorResponsavel INTEGER NOT NULL REFERENCES Colaboradores(Id),
                Status TEXT NOT NULL DEFAULT 'Pendente',
                DataConclusao TEXT,
                ObservacoesConclusao TEXT,
                IdUsuarioRegistro INTEGER NOT NULL REFERENCES Usuarios(Id),
                DataHoraRegistro TEXT NOT NULL DEFAULT (datetime('now','localtime'))
            );

            CREATE TABLE IF NOT EXISTS Onboarding (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                IdColaborador INTEGER NOT NULL REFERENCES Colaboradores(Id),
                DataInicio TEXT NOT NULL,
                Status TEXT NOT NULL DEFAULT 'Em Andamento',
                DataConclusao TEXT,
                Observacoes TEXT,
                IdUsuarioRegistro INTEGER NOT NULL REFERENCES Usuarios(Id),
                DataHoraRegistro TEXT NOT NULL DEFAULT (datetime('now','localtime'))
            );

            CREATE TABLE IF NOT EXISTS ItensOnboarding (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                IdOnboarding INTEGER NOT NULL REFERENCES Onboarding(Id) ON DELETE CASCADE,
                Descricao TEXT NOT NULL,
                Concluido INTEGER NOT NULL DEFAULT 0,
                DataConclusaoItem TEXT
            );

            CREATE TABLE IF NOT EXISTS MateriaisEstudo (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Titulo TEXT NOT NULL,
                Categoria TEXT NOT NULL,
                Descricao TEXT,
                CaminhoOuLink TEXT NOT NULL,
                DataPublicacao TEXT NOT NULL,
                Ativo INTEGER NOT NULL DEFAULT 1,
                IdUsuarioRegistro INTEGER NOT NULL REFERENCES Usuarios(Id),
                DataHoraRegistro TEXT NOT NULL DEFAULT (datetime('now','localtime'))
            );

            CREATE TABLE IF NOT EXISTS EventosCalendario (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Titulo TEXT NOT NULL,
                Tipo TEXT NOT NULL,
                DataInicio TEXT NOT NULL,
                DataFim TEXT NOT NULL,
                Local TEXT,
                Descricao TEXT,
                IdColaboradorResponsavel INTEGER REFERENCES Colaboradores(Id),
                Status TEXT NOT NULL DEFAULT 'Agendado',
                IdUsuarioRegistro INTEGER NOT NULL REFERENCES Usuarios(Id),
                DataHoraRegistro TEXT NOT NULL DEFAULT (datetime('now','localtime'))
            );
        ";
    }
}