﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Ericmas001.Game.Poker.Protocol.Client;
using Com.Ericmas001.Game.Poker.GUI.Lobby;
using Com.Ericmas001.Game.Poker.GUI;
using Com.Ericmas001.Game.Poker.GUI.Game;
using Com.Ericmas001.Game.Poker.DataTypes.Enums;
using Com.Ericmas001.Game.BluffinMuffin.Client.Game;

namespace Com.Ericmas001.Game.BluffinMuffin.Client
{
    public partial class LobbyTrainingForm : Form, ITableFormFactory
    {
        private LobbyTCPClient m_Server;
        public LobbyTrainingForm(LobbyTCPClient server)
        {
            m_Server = server;
            m_Server.ServerLost += new DisconnectDelegate(m_Server_ServerLost);
            InitializeComponent();
            tableList.TableFormFactory = this;
            tableList.setServer(m_Server);
            Text = server.PlayerName + " ~ " + lblTitle.Text;
            lblPlayerName.Text = server.PlayerName;
            tableList.RefreshList();
        }

        public delegate void EmptyDelegate();
        void m_Server_ServerLost()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new EmptyDelegate(m_Server_ServerLost), new object[] { });
                return;
            }
            m_Server = null;
            Close();
        }
        public void AllowJoinOrLeave()
        {
            bool selected = tableList.SomethingSelected;
            GameTCPClient client = tableList.FindClient();
            btnJoinTable.Enabled = selected && (client == null);
            btnLeaveTable.Enabled = selected && (client != null);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tableList.RefreshList();
            AllowJoinOrLeave();
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            tableList.AddTable();
        }

        private void btnJoinTable_Click(object sender, EventArgs e)
        {
            AllowJoinOrLeave();
            tableList.JoinSelected();
        }

        private void btnLeaveTable_Click(object sender, EventArgs e)
        {
            tableList.LeaveSelected();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            tableList.LeaveAll();
            Close();
        }

        private void LobbyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_Server != null)
                m_Server.Disconnect();
            //Program.WForm.Show();
        }

        private void tableList_OnChoiceMade(object sender, EventArgs e)
        {
            AllowJoinOrLeave();
            tableList.JoinSelected();
        }

        private void tableList_OnSelectionChanged(object sender, EventArgs e)
        {
            AllowJoinOrLeave();
        }

        private void LobbyTrainingForm_Load(object sender, EventArgs e)
        {
            if (tableList.NbTables == 0)
                tableList.AddTable();
        }

        public AbstractTableForm ObtainGUI()
        {
            return new TrainingTableForm();
        }
    }
}
