using FluentValidation;
using Processos.Dominio.Entidades;
using Processos.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using Xunit;

namespace Processos.Testes
{
    public class ValidacaoProcesso
    {
        private readonly IValidator<Processo> validadorProcesso = new ValidadorProcesso(new ValidadorEtapa());

        [Fact]
        public void ValidacaoProcesso_CamposObrigatoriosPreenchidos_Valido()
        {
            var processo = new Processo
            {
                Nome = "Processo de teste",
                Etapas = new List<Etapa>
                {
                    new Etapa {
                        Identificador = Guid.Parse("2412659d-9bb9-4576-9117-5d74330bd711"),
                        Nome = "Inicio",
                        Tipo = TipoEtapa.Inicio,
                        X = 1,
                        Y = 2,
                        EtapasSaida = new List<Guid>{
                            Guid.Parse("2c709c55-4a4f-44ea-8970-34a85cd907ad"),
                            Guid.Parse("860bdb5b-0ce9-40d9-8c92-d8a3f4c92a3f")
                        }
                    },
                    new Etapa {
                        Identificador = Guid.Parse("860bdb5b-0ce9-40d9-8c92-d8a3f4c92a3f"),
                        Nome = "Meio",
                        Tipo = TipoEtapa.Acao,
                        X = 1,
                        Y = 2,
                        EtapasSaida = new List<Guid>{ Guid.Parse("69f416df-77e9-4993-8bf7-6d114334a551") }
                    },
                    new Etapa {
                        Identificador = Guid.Parse("2c709c55-4a4f-44ea-8970-34a85cd907ad"),
                        Nome = "Meio2",
                        Tipo = TipoEtapa.Acao,
                        X = 1,
                        Y = 2,
                        EtapasSaida = new List<Guid>{ Guid.Parse("69f416df-77e9-4993-8bf7-6d114334a551") }
                    },
                    new Etapa {
                        Identificador = Guid.Parse("69f416df-77e9-4993-8bf7-6d114334a551"),
                        Nome = "Fim",
                        Tipo = TipoEtapa.Fim,
                        X = 1,
                        Y = 2
                    }
                }
            };

            var resultadoValidacao = validadorProcesso.Validate(processo);
            Assert.True(resultadoValidacao.IsValid);
        }

        [Fact]
        public void ValidacaoProcesso_FluxoSemEtapaInicio_Invalido()
        {
            var processo = new Processo
            {
                Nome = "Processo de teste",
                Etapas = new List<Etapa>
                {
                    new Etapa {
                        Identificador = Guid.Parse("860bdb5b-0ce9-40d9-8c92-d8a3f4c92a3f"),
                        Nome = "Meio",
                        Tipo = TipoEtapa.Acao,
                        X = 1,
                        Y = 2,
                        EtapasSaida = new List<Guid>{ Guid.Parse("69f416df-77e9-4993-8bf7-6d114334a551") }
                    },
                    new Etapa {
                        Identificador = Guid.Parse("69f416df-77e9-4993-8bf7-6d114334a551"),
                        Nome = "Fim",
                        Tipo = TipoEtapa.Fim,
                        X = 1,
                        Y = 2
                    }
                }
            };

            var resultadoValidacao = validadorProcesso.Validate(processo);
            Assert.False(resultadoValidacao.IsValid);
        }

        [Fact]
        public void ValidacaoProcesso_FluxoSemEtapaFim_Invalido()
        {
            var processo = new Processo
            {
                Nome = "Processo de teste",
                Etapas = new List<Etapa>
                {
                    new Etapa {
                        Identificador = Guid.Parse("2412659d-9bb9-4576-9117-5d74330bd711"),
                        Nome = "Inicio",
                        Tipo = TipoEtapa.Inicio,
                        X = 1,
                        Y = 2,
                        EtapasSaida = new List<Guid>{ Guid.Parse("860bdb5b-0ce9-40d9-8c92-d8a3f4c92a3f") }
                    },
                    new Etapa {
                        Identificador = Guid.Parse("860bdb5b-0ce9-40d9-8c92-d8a3f4c92a3f"),
                        Nome = "Meio",
                        Tipo = TipoEtapa.Acao,
                        X = 1,
                        Y = 2,
                        EtapasSaida = new List<Guid>{ Guid.Parse("69f416df-77e9-4993-8bf7-6d114334a551") }
                    }
                }
            };

            var resultadoValidacao = validadorProcesso.Validate(processo);
            Assert.False(resultadoValidacao.IsValid);
        }

        [Fact]
        public void ValidacaoProcesso_FluxoNaoInterligado_Invalido()
        {
            var processo = new Processo
            {
                Nome = "Processo de teste",
                Etapas = new List<Etapa>
                {
                    new Etapa {
                        Identificador = Guid.Parse("2412659d-9bb9-4576-9117-5d74330bd711"),
                        Nome = "Inicio",
                        Tipo = TipoEtapa.Inicio,
                        X = 1,
                        Y = 2,
                        EtapasSaida = new List<Guid>{ }
                    },
                    new Etapa {
                        Identificador = Guid.Parse("860bdb5b-0ce9-40d9-8c92-d8a3f4c92a3f"),
                        Nome = "Meio",
                        Tipo = TipoEtapa.Acao,
                        X = 1,
                        Y = 2,
                        EtapasSaida = new List<Guid>{ }
                    },
                    new Etapa {
                        Identificador = Guid.Parse("69f416df-77e9-4993-8bf7-6d114334a551"),
                        Nome = "Fim",
                        Tipo = TipoEtapa.Fim,
                        X = 1,
                        Y = 2
                    }
                }
            };

            var resultadoValidacao = validadorProcesso.Validate(processo);
            Assert.False(resultadoValidacao.IsValid);
        }

        [Fact]
        public void ValidacaoProcesso_CamposObrigatoriosNaoPreenchidos_Invalido()
        {
            var processo = new Processo { Etapas = new List<Etapa>() };
            var resultadoValidacao = validadorProcesso.Validate(processo);
            Assert.False(resultadoValidacao.IsValid);
            Assert.Equal(4, resultadoValidacao.Errors.Count);
        }
    }
}
