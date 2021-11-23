using ControleAcesso.Dao;
using ControleAcesso.Entidades;
using ControleAcesso.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleAcesso.Forms
{
    public partial class frmRegistrarEntradaSaida : Form
    {
        private Piloto _piloto;
        private Piloto _pilotoComandante;
        private Nave _nave;
        private Planeta _planetaOrigem;
        private Planeta _planetaDestino;
        private int _idNave;
        private int _idPiloto;
        private int _idPlanetaOrigem;
        private int _idPlanetaDestino;
        private bool _chegada;
        private bool _pilotoViajando;

        public frmRegistrarEntradaSaida(int idNave, int idPiloto, int idPlanetaOrigem, int idPlanetaDestino, bool chegada)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            _idNave = idNave;
            _idPiloto = idPiloto;
            _idPlanetaOrigem = idPlanetaOrigem;
            _idPlanetaDestino = idPlanetaDestino;
            _chegada = chegada;            

            InitializeComponent();
        }

        private async void frmRegistrarEntradaSaida_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            int? idPilotoComandante;
            using (var naveDao = new NaveDao())
            {
                _nave = await naveDao.ObterPorId(_idNave);
                idPilotoComandante = await naveDao.ObterComandante(_idNave);
            }

            using (var pilotoDao = new PilotoDao())
            {
                _piloto = await pilotoDao.ObterPorId(_idPiloto);
                _pilotoViajando = await pilotoDao.PilotoEstaViajando(_idPiloto);

                if(idPilotoComandante.HasValue)
                    _pilotoComandante = await pilotoDao.ObterPorId(idPilotoComandante.Value);
            }

            using (var planetaDao = new PlanetaDao())
            {
                _planetaOrigem = await planetaDao.ObterPorId(_idPlanetaOrigem);
                _planetaDestino = await planetaDao.ObterPorId(_idPlanetaDestino);
            }

            lvAlertas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvAlertas.PerformLayout();

            PreencherDadosNave();
            PreencherDadosPiloto();

            lblOrigem.Text = _planetaOrigem.Nome;
            lblDestino.Text = _planetaDestino.Nome;

            if (EhValido())
            {
                btnRegistrar.Enabled = true;
                this.Height = 288;
            }
            else
            {
                btnRegistrar.Enabled = false;
                this.Height = 528;
            }

            if (_chegada)
                btnRegistrar.Text = "Registrar Chegada";
            else
                btnRegistrar.Text = "Registrar Saída";

            Cursor = Cursors.Default;
        }

        private void PreencherDadosNave()
        {
            lblNomeNave.Text = _nave.Nome;
            lblModelo.Text = _nave.Modelo;
            lblClasse.Text = _nave.Classe;
        }

        private void PreencherDadosPiloto()
        {
            lblNomePiloto.Text = _piloto.Nome;
            lblAnoNacimento.Text = _piloto.AnoNascimento;
            lblPlaneta.Text = _piloto.Planeta.Nome;
        }

        private bool EhValido()
        {
            bool ehValido = PilotoEhValido();
            ehValido = NaveEhValida() && ehValido;

            return ehValido;
        }

        private bool PilotoEhValido()
        {
            bool ehValido = true;
            
            //Saindo
            if (!_chegada)
            {
                if (_pilotoViajando)
                {
                    ehValido = false;
                    lvAlertas.Items.Add(new ListViewItem("PERIGO - PILOTO AINDA NÃO CHEGOU DE VIAGEM, DEVE SER UM IMPOSTOR"));
                }

                if(!_piloto.Naves.Any(nave => nave.IdNave == _nave.IdNave))
                {
                    ehValido = false;
                    lvAlertas.Items.Add(new ListViewItem("Este piloto não está habilitado para esta nave"));
                }
            }

            //Chegando
            if (_chegada && !_pilotoViajando)
            {
                ehValido = false;
                lvAlertas.Items.Add(new ListViewItem("PERIGO - PILOTO NÃO SAIU PARA VIAGEM, DEVE SER UM IMPOSTOR"));
            }
            
            return ehValido;
        }

        private bool NaveEhValida()
        {
            bool ehValido = true;

            //Saindo
            if(!_chegada && _pilotoComandante != null)
            {
                ehValido = false;
                lvAlertas.Items.Add(new ListViewItem("Nave já está em viagem"));
            }

            //Chegando
            if (_chegada)
            {
                if (_pilotoComandante == null)
                {
                    ehValido = false;
                    lvAlertas.Items.Add(new ListViewItem("PERIGO - NAVE NÃO SAIU, PODE SER UMA NAVE IMPOSTORA"));
                }

                if(_pilotoComandante != null && _pilotoComandante.IdPiloto != _piloto.IdPiloto)
                {
                    ehValido = false;
                    lvAlertas.Items.Add(new ListViewItem($"PERIGO - PILOTO QUE RETIROU A NAVE FOI '{_pilotoComandante.Nome.ToUpper()}'"));
                }
            }

            return ehValido;
        }

        private void frmRegistrarEntradaSaida_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (_chegada)
                await RegistrarEntrada();
            else
                await RegistrarSaida();

            btnRegistrar.Enabled = false;
            MessageBox.Show("Registro efetuado com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task RegistrarEntrada()
        {
            using (var pilotoDao = new PilotoDao())
                await pilotoDao.RegistrarFimViagem(_idPiloto, _idNave);
        }

        private async Task RegistrarSaida()
        {
            using (var pilotoDao = new PilotoDao())
                await pilotoDao.RegistrarInicioViagem(_idPiloto, _idNave, _idPlanetaOrigem, _idPlanetaDestino);
        }
    }
}
