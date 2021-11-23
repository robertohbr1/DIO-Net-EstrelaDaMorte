using ControleAcesso.Dao;
using ControleAcesso.Entidades;
using ControleAcesso.Extensions;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleAcesso.Forms
{
    public partial class frmControleNaves : Form
    {
        private readonly PilotoDao _pilotoDao;
        private readonly PlanetaDao _planetaDao;
        private readonly NaveDao _naveDao;

        public frmControleNaves()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            _pilotoDao = new PilotoDao();
            _planetaDao = new PlanetaDao();
            _naveDao = new NaveDao();
            InitializeComponent();
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            if(!rdbChegando.Checked && !rdbSaindo.Checked)
            {
                MessageBox.Show("É preciso informar se a nave está chegando ou saindo da Estrela da Morte!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvNaves.Rows.Count == 0 || dgvNaves.Rows.GetCountRowsChecked(1) != 1)
            {
                MessageBox.Show("É preciso selecionar apenas uma nave!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvPilotos.Rows.Count == 0 || dgvPilotos.Rows.GetCountRowsChecked(1) != 1)
            {
                MessageBox.Show("É preciso selecionar apenas um piloto da nave!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvPlanetaOrigem.Rows.Count == 0 || dgvPlanetaOrigem.Rows.GetCountRowsChecked(1) != 1)
            {
                MessageBox.Show("É preciso selecionar apenas um Planeta Origem!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvPlanetaDestino.Rows.Count == 0 || dgvPlanetaDestino.Rows.GetCountRowsChecked(1) != 1)
            {
                MessageBox.Show("É preciso selecionar apenas um Planeta Destino!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            var idPiloto = int.Parse(dgvPilotos.Rows[dgvPilotos.Rows.GetFirstIndexChecked(1)].Cells[0].Value.ToString());
            var idNave = int.Parse(dgvNaves.Rows[dgvNaves.Rows.GetFirstIndexChecked(1)].Cells[0].Value.ToString());
            var idPlanetaOrigem = int.Parse(dgvPlanetaOrigem.Rows[dgvPlanetaOrigem.Rows.GetFirstIndexChecked(1)].Cells[0].Value.ToString());
            var idPlanetaDestino = int.Parse(dgvPlanetaDestino.Rows[dgvPlanetaDestino.Rows.GetFirstIndexChecked(1)].Cells[0].Value.ToString());
            var frm = new frmRegistrarEntradaSaida(idNave, idPiloto, idPlanetaOrigem, idPlanetaDestino, rdbChegando.Checked);
            frm.ShowDialog();
        }

        private void frmControleNaves_FormClosing(object sender, FormClosingEventArgs e)
        {
            _naveDao?.Dispose();
            _pilotoDao?.Dispose();
            _planetaDao?.Dispose();
            Dispose();
        }

        private async void btnBuscarNave_Click(object sender, EventArgs e)
        {
            dgvNaves.Rows.Clear();
            dgvNaves.Columns.Clear();

            if (string.IsNullOrEmpty(txtNomeNave.Text))
                return;

            Cursor = Cursors.WaitCursor;
            DataGridViewTextBoxColumn idNaveColumn = new DataGridViewTextBoxColumn();
            DataGridViewCheckBoxColumn checkNaveColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn nomeNaveColumn = new DataGridViewTextBoxColumn();

            idNaveColumn.Visible = false;

            idNaveColumn.ReadOnly = true;
            checkNaveColumn.ReadOnly = false;
            nomeNaveColumn.ReadOnly = true;

            nomeNaveColumn.Width = 500;

            dgvNaves.RowHeadersVisible = false;
            dgvNaves.ColumnHeadersVisible = false;
            dgvNaves.Columns.Add(idNaveColumn);
            dgvNaves.Columns.Add(checkNaveColumn);
            dgvNaves.Columns.Add(nomeNaveColumn);

            var naves = await _naveDao.ObterPorNomeLike(txtNomeNave.Text);
            bool Checked = naves.Count == 1;
            foreach (var nave in naves)
                dgvNaves.Rows.Add(nave.IdNave, Checked, nave.Nome);

            dgvNaves.PerformLayout();
            Cursor = Cursors.Default;

            if (dgvNaves.Rows.Count > 0 && dgvNaves.Rows.GetCountRowsChecked(1) == 1)
            {
                var _idNave = int.Parse(dgvNaves.Rows[dgvNaves.Rows.GetFirstIndexChecked(1)].Cells[0].Value.ToString());
                using (var naveDao = new NaveDao())
                {
                    int? idPilotoComandante;
                    
                    idPilotoComandante = await naveDao.ObterComandante(_idNave);
                    if (idPilotoComandante.HasValue)
                    {
                        rdbChegando.Checked = true;
                        using (var pilotoDao = new PilotoDao())
                        {
                            Piloto _piloto = await pilotoDao.ObterPorId((int)idPilotoComandante);
                            txtNomePiloto.Text = _piloto.Nome;
                            txtNomePiloto_Leave(sender, e);
                        }
                        using (var planetaDao = new PlanetaDao())
                        {
                            int? idPlaneta = await naveDao.ObterPlanetaOrigem(_idNave);                            

                            Planeta _planeta = await planetaDao.ObterPorId((int)idPlaneta);
                            txtPlanetaOrigem.Text = _planeta.Nome;
                            txtPlanetaOrigem_Leave(sender, e);

                            idPlaneta = await naveDao.ObterPlanetaDestino(_idNave); 
                            _planeta = await planetaDao.ObterPorId((int)idPlaneta);
                            txtPlanetaDestino.Text = _planeta.Nome;
                            txtPlanetaDestino_Leave(sender, e);
                        }
                    }
                }
            }           

        }

        private async void btnBuscarPiloto_Click(object sender, EventArgs e)
        {
            dgvPilotos.Rows.Clear();
            dgvPilotos.Columns.Clear();

            if (string.IsNullOrEmpty(txtNomePiloto.Text))
                return;

            Cursor = Cursors.WaitCursor;
            DataGridViewTextBoxColumn idPilotoColumn = new DataGridViewTextBoxColumn();
            DataGridViewCheckBoxColumn checkPilotoColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn nomePilotoColumn = new DataGridViewTextBoxColumn();

            idPilotoColumn.Visible = false;

            idPilotoColumn.ReadOnly = true;
            checkPilotoColumn.ReadOnly = false;
            nomePilotoColumn.ReadOnly = true;

            nomePilotoColumn.Width = 500;

            dgvPilotos.RowHeadersVisible = false;
            dgvPilotos.ColumnHeadersVisible = false;
            dgvPilotos.Columns.Add(idPilotoColumn);
            dgvPilotos.Columns.Add(checkPilotoColumn);
            dgvPilotos.Columns.Add(nomePilotoColumn);

            var pilotos = await _pilotoDao.ObterPorNomeLike(txtNomePiloto.Text);
            bool Checked = pilotos.Count == 1;
            foreach (var piloto in pilotos)
                dgvPilotos.Rows.Add(piloto.IdPiloto, Checked, piloto.Nome);

            dgvNaves.PerformLayout();
            Cursor = Cursors.Default;
        }

        private void txtNomeNave_Leave(object sender, EventArgs e)
        {
            btnBuscarNave_Click(sender, e);
        }

        private void txtNomePiloto_Leave(object sender, EventArgs e)
        {
            btnBuscarPiloto_Click(sender, e);
        }

        private async void btnBuscarOrigem_Click(object sender, EventArgs e)
        {
            await CarregaNaves(dgvPlanetaOrigem, txtPlanetaOrigem);

        }
        private async void btnBuscarDestino_Click(object sender, EventArgs e)
        {
            await CarregaNaves(dgvPlanetaDestino, txtPlanetaDestino);
        }

        private async Task CarregaNaves(DataGridView dgvPlaneta, TextBox txtPlaneta)
        {
            dgvPlaneta.Rows.Clear();
            dgvPlaneta.Columns.Clear();

            if (string.IsNullOrEmpty(txtPlaneta.Text))
                return;

            Cursor = Cursors.WaitCursor;
            DataGridViewTextBoxColumn idPlanetaColumn = new DataGridViewTextBoxColumn();
            DataGridViewCheckBoxColumn checkPlanetaColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn nomePlanetaColumn = new DataGridViewTextBoxColumn();

            idPlanetaColumn.Visible = false;

            idPlanetaColumn.ReadOnly = true;
            checkPlanetaColumn.ReadOnly = false;
            nomePlanetaColumn.ReadOnly = true;

            nomePlanetaColumn.Width = 500;

            dgvPlaneta.RowHeadersVisible = false;
            dgvPlaneta.ColumnHeadersVisible = false;
            dgvPlaneta.Columns.Add(idPlanetaColumn);
            dgvPlaneta.Columns.Add(checkPlanetaColumn);
            dgvPlaneta.Columns.Add(nomePlanetaColumn);

            var Planetas = await _planetaDao.ObterPorNomeLike(txtPlaneta.Text);
            bool Checked = Planetas.Count == 1;
            foreach (var Planeta in Planetas)
                dgvPlaneta.Rows.Add(Planeta.IdPlaneta, Checked, Planeta.Nome);

            dgvNaves.PerformLayout();
            Cursor = Cursors.Default;
        }

        private void txtPlanetaOrigem_Leave(object sender, EventArgs e)
        {
            btnBuscarOrigem_Click(sender, e);
        }

        private void txtPlanetaDestino_Leave(object sender, EventArgs e)
        {
            btnBuscarDestino_Click(sender, e);
        }


        
    }
}
