using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Concretec.Interfaces;



namespace Concretec.Presentador
{
    public class Presenter
    {
        public Presenter()
        { 
        
        }

        #region PresentadorPlanta

        public void ObtenerPlantasFiltro(object sender, EventArgs e)
        {
            List<Planta> Lista = new List<Planta>();
            AgentePlantas ap = new AgentePlantas();
            IPlantas vista = (IPlantas)sender;
            Lista = ap.ObtenerPlantasFiltro(vista.nombrePlanta, vista.nombrePlanta,"MTY");
            vista.Plantas = Lista;
        }

        public void ObtenerPlantas(object sender, EventArgs e)
        {
            List<Planta> Lista = new List<Planta>();
            AgentePlantas ap = new AgentePlantas();
            IPlantas vista = (IPlantas)sender;
            Lista = ap.ObtenerPlantas();

            vista.Plantas = Lista;


        }
        #endregion

        #region Clientes

        public void ObtenerClientes(object sender, EventArgs e)
        {
            AgenteClientes ac = new AgenteClientes();
            IClientes vista = (IClientes)sender;

            ac.ObtenerClientes("MTY");

        }

        public void ObtenerClientesFiltro(object sender, EventArgs e)
        {
            AgenteClientes ac = new AgenteClientes();
            IClientes vista = (IClientes)sender;

            //ac.ObtenerClientesFiltro(vista.Clientesfiltro);

        }

        #endregion

        #region Unidades
        public void ActUnidad(object sender, EventArgs e)
        {
            AgenteUnidades au = new AgenteUnidades();
            IUnidades Vista = (IUnidades)sender;

            {
                //au.ActUnidad(Vista.IDUnidad, Vista.Clave, Vista.IDPlanta, Vista.Orden, Vista.IDOperador, Vista.Estatus, Vista.IDMarca, Vista.Modelo, Vista.NumSerie, Vista.IDTipoCombustible, Vista.Placas, Vista.IDTipoPlacasint, Vista.IDCentroCostos, Vista.Poliza, Vista.Inciso, Vista.IDAseguradora, Vista.IVigencia, Vista.FVigencia, Vista.Propietario, Vista.verificacionV, Vista.ObservacionesUnidad);
                var a = 1;
            }
        }
        public void InsertarUnidad(object sender, EventArgs e)
        { }
        public void ObtenerCentroCostos(object sender, EventArgs e)
        { }
        public void ObtenerAseguradoras(object sender, EventArgs e)
        {
            AgenteUnidades au = new AgenteUnidades();
            IUnidades Lista = (IUnidades)sender;
            Lista.Aseguradoras = au.ObtenerAseguradoras();
        }
        public void ObtenerTipoPlaca(object sender, EventArgs e)
        {
            AgenteUnidades au = new AgenteUnidades();
            IUnidades Lista = (IUnidades)sender;
            Lista.TiposPlacas = au.ObtenerTipoPlaca();
        }
        public void ObtenerTipoCombustible(object sender, EventArgs e)
        {
            AgenteUnidades au = new AgenteUnidades();
            IUnidades Lista = (IUnidades)sender;
            Lista.TipoCombustibles = au.ObtenerTipoCombustible();
        }
        public void ObtenerMarcaCamion(object sender, EventArgs e)
        {
            AgenteUnidades au = new AgenteUnidades();
            IUnidades Lista = (IUnidades)sender;
            Lista.MarcaCamiones = au.ObtenerMarcaCamion();

        }
        public void ObtenerUnidades(object sender, EventArgs e)
        {
           // AgenteUnidades au = new AgenteUnidades();
            //IUnidades Vista = (IUnidades)sender;

        }
        public void ObtenerUnidadesFiltro(object sender, EventArgs e)
        {
            AgenteUnidades au = new AgenteUnidades();
            IUnidades Vista = (IUnidades)sender;
        }

        #endregion

        #region Producto

        public void InsertarProducto(object sender, EventArgs e)
        {
            AgenteProductos ap = new AgenteProductos();
            IProductos vista = (IProductos)sender;
            ap.InsertarProducto(vista.ClaveProducto, vista.DescripcionProducto, vista.UnidadProducto, vista.PrecioProducto, vista.BorradoProducto, vista.ObservacionesProducto);

        }
        public void ActualizarProducto(object sender, EventArgs e)
        {
            AgenteProductos ap = new AgenteProductos();
            IProductos vista = (IProductos)sender;
            ap.ActualizarProducto(vista.IDProducto, vista.ClaveProducto, vista.DescripcionProducto, vista.UnidadProducto, vista.PrecioProducto, vista.BorradoProducto, vista.ObservacionesProducto);

        }
        public void ObtenerProducto(object sender, EventArgs e)
        {
            AgenteProductos ap = new AgenteProductos();
            IProductos vista = (IProductos)sender;
            ap.ObtenerProducto(0, "MTY");
        }

        public void ObtenerProductoFiltro(object sender, EventArgs e)
        {
            AgenteProductos ap = new AgenteProductos();
            IProductos vista = (IProductos)sender;
            ap.ObtenerProductoFiltro(vista.filtroProducto,"","");
        }

        #endregion

        #region Obras

        public void ObtieneObras(object sender, EventArgs e)
        { }

        public void ObtieneObrasFiltro(object sender, EventArgs e)
        { }
        
        #endregion


        #region Personal

        public void ObtienePersonal(object sender, EventArgs e)
        {  AgentePersonal ap=new AgentePersonal();
           
        }

        public void ObtienePersonalFiltro(object sender, EventArgs e)
        { }


        #endregion
    }
}
