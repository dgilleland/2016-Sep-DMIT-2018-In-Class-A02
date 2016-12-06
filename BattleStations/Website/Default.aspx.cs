using SpaceBattleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            var starFleet = ShipYard.BuildFleet(FleetType.Federation);
            var badGuys = ShipYard.BuildFleet(FleetType.Clingon);

            GoodFleet.DataSource = starFleet;
            GoodFleet.DataBind();
            BadFleet.DataSource = badGuys;
            BadFleet.DataBind();
        }
    }

    protected void GoodFleet_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        // ChangING - Present tense - before the event is processed by the Gridview
        int index = e.NewSelectedIndex;
        GridViewRow row = GoodFleet.Rows[index];
        string shipId = row.Cells[0].Text;
        Label powerLabel = row.FindControl("PowerReserve") as Label;
        int power = int.Parse(powerLabel.Text);
        Ship dispatch = new Ship(power, shipId);

        // Just push it into a new row
        //var data = GoodFleet.Rows.OfType<Ship>();
    }

    protected void BadFleet_SelectedIndexChanged(object sender, EventArgs e)
    {
        // ChangED - Past tense - after the event has been processed by the GridView

    }
}