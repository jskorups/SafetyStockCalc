﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafetyStockCalc
{
    public partial class EditModification : Form
    {
        public EditModification()
        {
            InitializeComponent();
            editModProj.SelectedIndex = -1;
            fillCombos.fillComboWithProject(editModProj);
        }
        

        private void editModPro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editModProj.SelectedIndex > -1)
            {
                fillCombos.fillComboWithSAPbyProject(editModSap, editModProj);
                fillCombos.fillComboWithMODbySAP(editModMod, editModSap);
            }
            return;
        }

        private void editModSap_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillCombos.fillComboWithMODbySAP(editModMod, editModSap);
        }

        private void CancelAddSapBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addSapToDbBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionStrin = ConfigurationManager.ConnectionStrings["SafetyStockCalc.Properties.Settings.ConnectionString"].ConnectionString;
                System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(connectionStrin);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE Modifications SET modName = @newName WHERE id = @id";
                cmd.Parameters.AddWithValue("@newName", newName.Text);
                cmd.Parameters.AddWithValue("@id", editModMod.SelectedValue);
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                MessageBox.Show("Dodano do bazy danych pod nazwą");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Coś poszło nie tak " + System.Environment.NewLine + "Sprawdz dane lub skontaktuj się z administratorem" + System.Environment.NewLine + ex.Message);
            }
        }
    }
}
