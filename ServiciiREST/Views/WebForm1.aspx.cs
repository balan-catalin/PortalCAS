using ServiciiREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiciiREST.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private PortalCasEntities db = new PortalCasEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            foreach(Spital sp in db.Spital)
            {
                double? sumaDecont = 0;
                foreach (DateRaportSpital item in db.DateRaportSpital.Where(x => x.DataInchidereCaz.Value.Month == DateTime.Now.Month-1 && x.CodSpital == sp.IdSpital))
                {
                    if (item.CodInvestigatie != null)
                        sumaDecont += item.CostAditionalInvestigatie * 0.5 + db.Investigatie.Where(x => x.CodInvestigatie == item.CodInvestigatie).First().CostInvestigatie;
                    else
                        sumaDecont += item.CostAditionalServiciuMedical * 0.5 + db.ServiciuMedical.Where(x => x.CodServiciu == item.CodServiciuMedical).First().CostServiciu;
                }
                TableRow r = new TableRow();
                TableCell Nume = new TableCell();
                Nume.Controls.Add(new LiteralControl(sp.NumeSpital));
                r.Cells.Add(Nume);
                TableCell Suma = new TableCell();
                Suma.Controls.Add(new LiteralControl(sumaDecont.ToString() + " lei"));
                r.Cells.Add(Suma);
                raportTable.Rows.Add(r);
            }
        }
    }
}