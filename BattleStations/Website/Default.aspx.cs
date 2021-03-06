﻿using SpaceBattleEngine;
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
        if (!IsPostBack)
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
        // Note: Check the column structure of the GoodFleet gridview
        int index = e.NewSelectedIndex; // Which row is being selected in GV
        GridViewRow row = GoodFleet.Rows[index];
        string shipId = row.Cells[0].Text; // for a BoundField control
        // next one is for a TemplateField, looking for a control by ID
        Label powerLabel = row.FindControl("PowerReserve") as Label;
        int power = int.Parse(powerLabel.Text);
        Ship dispatch = new Ship(power, shipId);
        dispatch.RaiseShields(); // going into battle, ya know

        // Just push it into a new row for the Federation gridview
        List<Ship> existing = ShipsFromGridView(Federation);
        existing.Add(dispatch); // add my ship
        Federation.DataSource = existing;
        Federation.DataBind();

        // Remove it from my GoodFleet gridview by extracting list of data
        // from gridview and rebinding without the specified index
        List<Ship> existingData = new List<Ship>();
        foreach(GridViewRow theRow in GoodFleet.Rows)
        {
            shipId = theRow.Cells[0].Text;
            power = int.Parse((row.FindControl("PowerReserve") as Label).Text);
            existingData.Add(new Ship(power, shipId));
        }
        existingData.RemoveAt(index);
        GoodFleet.DataSource = existingData;
        GoodFleet.DataBind(); // Voilà !
    }

    private List<Ship> ShipsFromGridView(GridView gv)
    {
        // Grabbing all the rows from a GridView to create a list of objects
        List<Ship> ships = new List<Ship>();

        foreach (GridViewRow row in gv.Rows)
        {
            // Extract the data from each row. I am extracting it from 
            // columns set up as follows:
            //<Columns>
            //    <asp:BoundField DataField="Registry" HeaderText="Id"/>
            //    <asp:BoundField DataField="Power" HeaderText="Power"/>
            //    <asp:BoundField DataField="Sheilds" HeaderText="Sheilds"/>
            //    <asp:CheckBoxField DataField="Disabled" HeaderText="!!"/>
            //</Columns>
            string reg = row.Cells[0].Text; // Registry
            int pwr = int.Parse(row.Cells[1].Text); // Power
            int shld = int.Parse(row.Cells[2].Text); // Sheilds
            bool disabled = (row.Cells[3].Controls[0] as CheckBox).Checked;

            // Now I can create a ship object
            Ship frontLine = new Ship(pwr, reg, shld, disabled);
            // Add it to my list
            ships.Add(frontLine);
        }

        return ships;
    }

    protected void BadFleet_SelectedIndexChanged(object sender, EventArgs e)
    {
        // ChangED - Past tense - after the event has been processed by the GridView

    }

    protected void GoodFleet_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}