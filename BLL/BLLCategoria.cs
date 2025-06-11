using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLCategoria
    {
        DALCategoria dal = new DALCategoria();
        public List<BECategoria> ListaCategoria()
        {
            return dal.ListaCategorias();
        }
    }
}
